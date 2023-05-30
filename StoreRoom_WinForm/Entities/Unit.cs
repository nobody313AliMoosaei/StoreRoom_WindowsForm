using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [OneToOne(CascadeOperations =CascadeOperation.All)]
        public Estate Estate { get; set; }
    }
}
