using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string HashPassword { get; set; }

        public string Role { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Estate Estate { get; set; }
    }
}
