using System;
namespace Medici.Models
{
    public class RelationProcedureDoctor : Entity
    {
        public int proc_id { get; set; }
        public int doc_id { get; set; }
    }
}
