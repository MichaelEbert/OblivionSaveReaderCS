using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OblivionSaveReader.web
{
    //just the parts that we need to make savedata.
    public class Cell
    {
        public string name { get; set; }
        public List<Cell>? elements { get; set; }
        //leaf nodes only:
        public object? id { get; set; }
        public string? formId { get; set; }
        public int? formIdInt 
        { 
            get
            {
                if (Int32.TryParse(formId?.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out int result))
                {
                    return result;
                }
                return null;
            }
        }
        public string? gateCloseLink { get; set; }
        public int? gateCloseLinkInt
        {
            get
            {
                if (Int32.TryParse(gateCloseLink?.Substring(2), System.Globalization.NumberStyles.HexNumber, null, out int result))
                {
                    return result;
                }
                return null;
            }
        }
        public string? type { get; set; }
        //used for save file reading only
        public List<int>? stages { get; set; }
        //used for wayshrines
        public int? globalIndex { get; set; }

    }

    public class Hive : Cell
    {
        public int version { get; set; }
        private string _classname = null;
        public string classname { 
            get
            {
                if(_classname == null)
                {
                    return this.name;
                }
                return _classname;
            } set
            {
                _classname = value;
            } }
    }
}
