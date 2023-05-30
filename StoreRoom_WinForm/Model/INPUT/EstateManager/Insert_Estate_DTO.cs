using DataLayer.Entities;
using StoreRoom_WinForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRoom_WinForm.Model.INPUT.EstateManager
{
    public class Insert_Estate_DTO
    {

        public Insert_Estate_DTO()
        {
            Date_Insert= DateTime.Now;
        }
        public DateTime Date_Insert { get; set; }

        //دستور دهنده
        public int Directive_Id { get; set; }

        // نگهبان
        public int Guard_Id { get; set; }

        //امین اموال
        public int Honest_Id { get; set; }

        // خارج کننده
        public int Extruder_Id { get; set; }

        // واحد
        public int Unit_Id { get; set; }

        //رئیس دانشگاه
        public int UniRector_Id { get; set; }

        //ذی حساب
        public int ZEAccount_Id { get; set; }

        // کالا
        public int Product_Id { get; set; }

        // کد کالا
        public int Product_Number { get; set; }

        // شماره برچسب
        public string Lable_Number { get; set; }

        // شماره سند
        public string Document_Number { get; set; }
    }
}
