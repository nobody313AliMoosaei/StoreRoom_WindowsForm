using SQLite;
using SQLiteNetExtensions.Attributes;
using StoreRoom_WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Estate
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public DateTime Date_Insert { get; set; } = DateTime.Now;

        //دستور دهنده
        [ForeignKey(typeof(Users))]
        public int Directive_Id { get; set; }

        // نگهبان
        [ForeignKey(typeof(Users))]
        public int Guard_Id { get; set; }

        //امین اموال
        [ForeignKey(typeof(Users))]
        public int Honest_Id { get; set; }

        // خارج کننده
        [ForeignKey(typeof(Users))]
        public int Extruder_Id { get; set; }

        // واحد
        [ForeignKey(typeof(Unit))]
        public int Unit_Id { get; set; }

        //رئیس دانشگاه
        [ForeignKey(typeof(Users))]
        public int UniRector_Id { get; set; }

        //ذی حساب
        [ForeignKey(typeof(Users))]
        public int ZEAccount_Id { get; set; }

        [ForeignKey(typeof(Product))]
        public int Product_Id { get; set; }

        public int Product_Number { get; set; }

        public string Lable_Number { get; set; }

        public string Document_Number { get; set; }
    }
}
