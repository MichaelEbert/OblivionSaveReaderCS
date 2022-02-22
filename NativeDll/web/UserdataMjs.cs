using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader.web
{
	public class JsonClass
    {
		public string name;
		public bool containsUserProgress;
		public bool standard;

        public JsonClass(string name, bool containsUserProgress = false, bool standard = false)
        {
            this.name = name;
            this.containsUserProgress = containsUserProgress;
            this.standard = standard;
        }

		public static JsonClass[] classes = {
			// name, containsUserProgress, isStandard, completionWeight
			// containsUserProgress means that it will show in the main checklist page (and save in userdata, sync with server, etc.)
			new JsonClass("quest", true, true),
			new JsonClass("book", true, true),
			new JsonClass("skill", true, true),
			new JsonClass("store", true, true),
			new JsonClass("misc", true),
			new JsonClass("npc", false),
			new JsonClass("fame", true),
			new JsonClass("nirnroot", true, true),
			new JsonClass("location", true, true),
			new JsonClass("save", true),
			new JsonClass("locationPrediscovered", false),
			//used in class reset calculator only
			new JsonClass("race", false),
			new JsonClass("birthsign", false)
		};
	}

	public class UserdataMjs
    {
		Dictionary<string, Hive> jsondata;

        public UserdataMjs(Dictionary<string, Hive> jsondata)
        {
            this.jsondata = jsondata;
        }


        /*object compressSaveData(object saveDataObject)
		{
			var compressed = new ExpandoObject;
			compressed.version = saveDataObject.version;
			foreach(var prop in saveDataObject){
				const matchingClass = classes.find(x => x.name == propname);
				if (matchingClass != null && matchingClass.standard)
				{
					//for "standard" classes, we do a more efficient compression
					compressed[propname] = [];
					const elements = saveDataObject[propname];
					for (const elementPropName in elements){
						compressed[propname][parseInt(elementPropName)] = elements[elementPropName] == 1 ? 1 : 0;
					}
				}
				else
				{
					//otherwise, we just leave it be.
					compressed[propname] = savedata[propname];
				}
			}
			return compressed;
		}*/
        /**
		 * Reset savedata progress for specific hive. Helper function for resetProgress.
		 * @param {object} hive hive to reset
		 */
        private void resetProgressForHive(Hive hive, DObject savedata)
		{
			string classname = hive.classname;
			savedata[classname] = new DObject();
			ObliviondataMjs.runOnTree(hive, (cell => {
				if (cell.id == null)
				{
					//this cell doesn't have a sequential ID, so we can't save it.
					return;
				}
				if (cell.type == "number")
				{
					savedata[classname][cell.id] = 0;
				}
				else
				{
					savedata[classname][cell.id] = false;
				}
			}));
		}

		/**
		 * Generate a new, clean savedata object, and saves it to cookie.
		 * @param {boolean} shouldConfirm Should we confirm with the user or not
		 */
		public dynamic resetProgress()
		{
			dynamic savedata = new DObject();
			savedata.version = 11;

			foreach(var klass in JsonClass.classes.Where(klass=>klass.containsUserProgress)){
				resetProgressForHive(jsondata[klass.name], savedata);
			}
			return savedata;
		}

		
	}
}
