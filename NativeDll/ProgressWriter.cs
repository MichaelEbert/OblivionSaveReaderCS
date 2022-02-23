using OblivionSaveReader.web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader
{
	/// <summary>
	/// Class that creates a progress file from the save file object.
	/// </summary>
	public class ProgressWriter
	{
		private Dictionary<string, Hive> jsondata;

		/// <summary>
		/// Create a progressWriter. May fetch data from the web, so its async.
		/// </summary>
		/// <param name="progressJsonUrl"></param>
		/// <param name="forceRefresh"></param>
		/// <returns></returns>
		public static async Task<ProgressWriter> Create(string progressJsonUrl, bool forceRefresh = false)
        {
			WebDataRetriever dataMaker = new WebDataRetriever();
			var data = await dataMaker.getData(progressJsonUrl, forceRefresh);
			return new ProgressWriter(data);
		}

		private ProgressWriter(Dictionary<string, Hive> jsondata)
        {
			this.jsondata=jsondata;
        }

		private Action<Cell> UpdateQuest(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record != null)
				{
					if (record.subRecord != null)
					{
						foreach (var stage in ((RecordQuest)record.subRecord).stage)
						{
							if (cell.stages != null && cell.stages.Contains(stage.index) && (stage.flag & 0x1) != 0)
							{
								savedata.quest[cell.id] = true;
								return;
							}
						}
					}
				}
				savedata.quest[cell.id] = false;
			};
		}

		private Action<Cell> UpdateLocation(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				Cell? gateCloseLinkCell = null;
				if (cell.gateCloseLink != null)
				{
					gateCloseLinkCell = ObliviondataMjs.findCell(jsondata, cell.gateCloseLink);
				}

				bool isSet = false;
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record?.subRecord is RecordInstanceReference rir)
				{
					Prop prop = rir.properties.Find((p => p.flag == 51));
					if ((byte?)(prop.value) == 3)
					{
						savedata.location[cell.id] = true;
						isSet = true;
					}
					// update gate closures at the same time
					if (gateCloseLinkCell != null && (record.flags & 0x7000005) == 0x7000005)
					{
						savedata.misc[gateCloseLinkCell.id] = true;
					}
				}
				if (!isSet)
				{
					savedata.location[cell.id] = false;
					if(gateCloseLinkCell != null)
                    {
						savedata.misc[gateCloseLinkCell.id] = false;
					}
				}
			};
		}

		private Action<Cell> UpdateSkill(dynamic savedata, SaveFile saveFile)
        {
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == 0x7));
				if (record?.subRecord is RecordCreature rc)
				{
					//this needs to be switched like this becuase recordcreature is an actual type.
                    int? skillLevel = cell.name.ToLower() switch
                    {
                        "armorer" => rc.armorer,
                        "athletics" => rc.athletics,
						"blade" => rc.blade,
						"block" => rc.block,
						"blunt" => rc.blunt,
						"hand to hand" => rc.handToHand,
						"heavy armor" => rc.heavyArmor,
						"alchemy" => rc.alchemy,
						"alteration" => rc.alteration,
						"conjuration" => rc.conjuration,
						"destruction" => rc.destruction,
						"illusion" => rc.illusion,
						"mysticism" => rc.mysticism,
						"restoration" => rc.restoration,
						"acrobatics" => rc.acrobatics,
						"light armor" => rc.lightArmor,
						"marksman" => rc.marksman,
						"mercantile" => rc.mercantile,
						"security" => rc.security,
						"sneak" => rc.sneak,
						"speechcraft" => rc.speechcraft,
						_ => null,
                    };
					if (skillLevel >= 100)
					{
						savedata.skill[cell.id] = true;
					}
					else
					{
						savedata.skill[cell.id] = false;
					}
				}
			};
		}

		private Action<Cell> UpdateHorse(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record != null)
				{
					if ((record.flags & 0x40000000) != 0)
					{
						savedata.misc[cell.id] = true;
						return;
					}
				}
				savedata.misc[cell.id] = false;
			};
		}

		private Action<Cell> UpdateHouse(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record != null)
				{
					if (record.subRecord?.stageNum > 0)
					{
						savedata.misc[cell.id] = true;
						return;
					}
				}
				savedata.misc[cell.id] = false;
			};
		}

		private Action<Cell> UpdateArena(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record != null)
				{
					if (record.subRecord?.topicSaidOnce)
						{
						savedata.misc[cell.id] = true;
						return;
					}
				}
				savedata.misc[cell.id] = false;
			};
		}

		private Action<Cell> UpdatePower(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == 0x7));
				if (record?.subRecord is RecordCreature rc)
				{
					IEnumerable<int> spellFormIds = rc.spellIds.Select(i => (i >= 0 && i < saveFile.formIds.Length) ? saveFile.formIds[i] : i);
					if (spellFormIds.Contains(cell.formIdInt.Value))
					{
						savedata.misc[cell.id] = true;
					}
					else
					{
						savedata.misc[cell.id] = false;
					}
				}
			};
		}

		private Action<Cell> UpdateWayshrine(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var fameLevel = saveFile.globals[(int)cell.globalIndex]?.value;
				if (fameLevel > 0)
				{
						savedata.misc[cell.id] = true;
						return;
				}
				savedata.misc[cell.id] = false;
			};
		}

		/// <summary>
		/// Update misc. Different because we do multiple different types of update here.
		/// </summary>
		/// <param name="miscHive"></param>
		/// <param name="savedata"></param>
		/// <param name="saveFile"></param>
		private void RunMiscUpdates(Cell miscHive, dynamic savedata, SaveFile saveFile)
        {
			if (miscHive == null || miscHive.elements == null)
			{
				return;
			}
			foreach (var child in miscHive.elements)
            {
				switch (child.name.ToLower())
				{
					case "horses":
						ObliviondataMjs.runOnTree(child, UpdateHorse(savedata, saveFile));
						break;
					case "houses":
						ObliviondataMjs.runOnTree(child, UpdateHouse(savedata, saveFile));
						break;
					case "pilgrim's grace":
						ObliviondataMjs.runOnTree(child, UpdateWayshrine(savedata, saveFile));
						break;
					case "arena fights":
						ObliviondataMjs.runOnTree(child, UpdateArena(savedata, saveFile));
						break;
					case "greater powers":
						ObliviondataMjs.runOnTree(child, UpdatePower(savedata, saveFile));
						break;
					case null:
					default:
						RunMiscUpdates(child, savedata, saveFile);
						break;
				}
            }
        }

		private Action<Cell> UpdateStore(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record?.subRecord is RecordCreatureReference rcr)
				{
					if ((int?)(rcr.properties.Find(p => p.flag == 82).value) == 500)
					{
						savedata.store[cell.id] = true;
						return;
					}
				}
				savedata.store[cell.id] = false;
			};
		}

		private Action<Cell> UpdateBook(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record?.subRecord is RecordBook rb)
				{
					if (rb.teaches == 255)
					{
						savedata.book[cell.id] = true;
						return;
					}
				}
				savedata.book[cell.id] = false;
			};
		}

		private Action<Cell> UpdateNirnroot(dynamic savedata, SaveFile saveFile)
		{
			return (cell) =>
			{
				var record = saveFile.records.Find((e => e.formId == cell.formIdInt));
				if (record != null)
				{
					if ((record.flags & 0x44000000) == 0x44000000)
					{
						savedata["nirnroot"][cell.id] = true;
						return;
					}
				}
				savedata["nirnroot"][cell.id] = false;
			};
		}

		private void writeProgressForHive(Hive hive, DObject savedata, SaveFile saveFile)
		{
			string classname = hive.classname;
			savedata[classname] = new DObject();

			Action<Cell> updateFunction;
			switch (hive.classname)
			{
				case "quest":
					updateFunction = UpdateQuest(savedata, saveFile);
					break;
				case "location":
					updateFunction = UpdateLocation(savedata, saveFile);
					break;
				case "skill":
					updateFunction = UpdateSkill(savedata, saveFile);
					break;
				case "store":
					updateFunction = UpdateStore(savedata, saveFile);
					break;
				case "nirnroot":
					updateFunction = UpdateNirnroot(savedata, saveFile);
					break;
				case "book":
					updateFunction = UpdateBook(savedata, saveFile);
					break;
				case "misc":
					RunMiscUpdates(hive, savedata, saveFile);
					return;
				default:
					return;
			}

			ObliviondataMjs.runOnTree(hive, updateFunction);
		}

		public DObject CreateUserProgressFile(SaveFile saveFile)
		{
			dynamic savedata = new DObject();
			savedata.version = 11;
			foreach (var klass in JsonClass.classes.Where(klass => klass.containsUserProgress))
			{
				writeProgressForHive(jsondata[klass.name], savedata, saveFile);
			}
			return savedata;
		}
	}
}
