using System;
namespace Medici.Models.AdapterHelpers
{
    public class ProcedureModel
    {
        public string name { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public string coment { get; set; }
        public bool isExpanded { get; set; }
    }
}
