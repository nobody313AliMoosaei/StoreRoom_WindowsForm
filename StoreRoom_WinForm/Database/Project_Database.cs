using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using SQLite;
using StoreRoom_WinForm.Entities;

namespace DataLayer.Database
{
    public class Project_Database
    {
        // Connection string is Static
        private string ConnectionString = 
            System.IO.Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Database_StoreRoom.db");
        private SQLite.SQLiteConnection Connection;

        public Project_Database()
        {
            Connection = new SQLiteConnection(ConnectionString);
        }

        public void DbSet()
        {
            Connection.CreateTable<Users>();
            Connection.CreateTable<Unit>();
            Connection.CreateTable<Estate>();
            Connection.CreateTable<Product>(); 
        }

        #region UserManager

        public bool InsertUser(StoreRoom_WinForm.Model.INPUT.UserManager.Insert_DTO Insert)
        {
            try
            {
                var user = new Users()
                {
                    FullName = Insert.FullName,
                    Username = Insert.UserName,
                    HashPassword = Insert.Password,
                    Role= Insert.Role,
                };
                var Resualt = Connection.Insert(user);

                if (Resualt > 0)
                    return true;

                return false;
            }catch
            {
                return false;
            }
        }

        public bool IsExistUser(string UserName,string Password)
        {
            try
            {
                var Users = Connection.Table<Users>();
                var MyUser = Users.FirstOrDefault(t => t.Username == UserName && t.HashPassword == Password);
                if (MyUser == null) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Users FindUser(string Value)
        {
            try
            {
                var Users = Connection.Table<Users>();
                var MyUser = Users.FirstOrDefault(u => u.Username == Value || u.FullName == Value);
                if (MyUser == null) return null;

                return MyUser;
            }catch
            {
                return null;
            }
        }

        public Users FindAdmin(string Value,string password)
        {
            var user = Connection.Table<Users>()
                .FirstOrDefault(t=>(t.Username==Value || t.FullName==Value)
                && t.HashPassword==password
                && t.Role == "Admin");
            if (user == null) return null;
            return user;
        }

        #endregion

        #region Product Manager
        
        // Add Product
        public bool Insert_Product(string Pro_Name , string pro_Code)
        {
            try
            {
                Product pro = new Product()
                {
                    Name = Pro_Name,
                    Code = pro_Code
                };
                Connection.Insert(pro);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Product Get_Product_ById(int Id)
        {
            try
            {
                var product = Connection.Table<Product>().FirstOrDefault(t=>t.Id==Id);
                if (product == null) return null;
                return product;
            }catch
            {
                return null;
            }
        }
        public Product Get_Product_ByName(string Name)
        {
            try
            {
                var product = Connection.Table<Product>().FirstOrDefault(t => t.Name == Name);
                if (product == null) return null;
                return product;
            }catch
            {
                return null;
            }
        }

        #endregion

        #region Unit Manager
        // Add Unit
        public bool Insert_Unit(string Pro_Unit)
        {
            try
            {
                var Unit = new Unit()
                {
                    Name = Pro_Unit,
                };
                Connection.Insert(Unit);
                return true;
            }catch
            {
                return false;
            }
        }
        public Unit GetUnit_ById(int Id)
        {
            try
            {
                var unit = Connection.Table<Unit>().FirstOrDefault(t => t.Id == Id);
                if (unit == null) return null;
                return unit;
            }catch
            {
                return null;
            }
        }
        public Unit GetUnit_ByName(string Name)
        {
            try
            {
                var unit = Connection.Table<Unit>().FirstOrDefault(t => t.Name == Name);
                if (unit == null) return null;
                return unit;
            }catch
            {
                return null;
            }
        }
        #endregion

        #region Estate Manager
        public bool InsertE_Estate(StoreRoom_WinForm.Model.INPUT.EstateManager.Insert_Estate_DTO NewEstate)
        {
            try
            {
                var estate = new Estate()
                {
                    ZEAccount_Id = NewEstate.ZEAccount_Id,
                    Directive_Id = NewEstate.Directive_Id,
                    Document_Number = NewEstate.Document_Number,
                    Extruder_Id = NewEstate.Extruder_Id,
                    Unit_Id = NewEstate.Unit_Id,
                    Guard_Id = NewEstate.Guard_Id,
                    Honest_Id = NewEstate.Honest_Id,
                    Lable_Number = NewEstate.Lable_Number,
                    Product_Id = NewEstate.Product_Id,
                    Product_Number = NewEstate.Product_Number,
                    UniRector_Id = NewEstate.UniRector_Id,
                };
                Connection.Insert(estate);
                return true;
            }catch
            {
                return false;
            }
        }
        public Estate GetEstate_ById(int Id)
        {
            try
            {
                var Estate = Connection.Table<Estate>().FirstOrDefault(t => t.Id == Id);
                if (Estate == null) return null;
                return Estate;
            }catch
            {
                return null;
            }
        }
        public Estate GetEstate_ByDocumentNumber(string DocumentNumber)
        {
            try
            {
                var Estate = Connection.Table<Estate>().FirstOrDefault(t=>t.Document_Number==DocumentNumber);
                if (Estate == null) return null;
                return Estate;
            }catch
            {
                return null;
            }
        }
        #endregion
    }
}
