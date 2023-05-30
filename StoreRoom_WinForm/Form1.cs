using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;


namespace StoreRoom_WinForm
{
    public partial class Form1 : Form
    {
        private DataLayer.Database.Project_Database _context;
        public Form1()
        {
            InitializeComponent();
            _context = new DataLayer.Database.Project_Database();

            var Admin = _context.FindUser("3981231102");
            if (Admin == null)
            {
                _context.DbSet();
                var Resualt_Add_Admin = _context.InsertUser(new Model.INPUT.UserManager.Insert_DTO
                {
                    FullName = "AliMoosaei",
                    Password = "123456",
                    Role = "Admin",
                    UserName = "3981231102"
                });
            }
        }
    }
}
