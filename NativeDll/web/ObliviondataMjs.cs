using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader.web
{
    internal class ObliviondataMjs
    {
		static Action<Cell> mergeCell(Cell[] mapping)
		{
			return (cell => {
				var maybeMapping = mapping.Where(x => x.formId == cell.formId).FirstOrDefault();
				if (maybeMapping != null)
				{
					cell.id ??= maybeMapping.id;
					cell.name ??= maybeMapping.name;
					cell.gateCloseLink ??= maybeMapping.gateCloseLink;
				}
			});
		}

		/**
		 * run a function on leaves in a tree and sum the results.
		 * @param {*} rootNode root node to run on
		 * @param {(x:object)=>boolean} runFunc function to run on leaves
		 */
		public static void runOnTree(Cell rootNode, Action<Cell> runFunc)
		{
			if (rootNode.elements == null)
			{
				runFunc(rootNode);
			}
			else
			{
				foreach (var node in rootNode.elements)
				{
					runOnTree(node, runFunc);
				}
			}
		}

		public static void MergeData(Hive hive, Cell[] extradata)
        {
			runOnTree(hive, mergeCell(extradata));
        }

		private static Cell? findOnTree(Cell root, string formId)
		{
			if (root?.formId == formId)
			{
				return root;
			}

			if (root?.elements == null)
			{
				return null;
			}

			foreach (var e in root.elements){
				var mayberesult = findOnTree(e, formId);
				if (mayberesult != null)
				{
					return mayberesult;
				}
			}
			return null;
		}

		public static Cell? findCell(Dictionary<string,Hive> hives, string formId)
		{
			Cell? cell = null;
			foreach (var hive in hives.Values)
			{
				cell = findOnTree(hive, formId);
				if (cell != null)
				{
					break;
				}
			}
			return cell;
		}

	}
}
