using ShopApp.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ClassApp
{
    internal class DBConnection
    {
        public static ShopDBEntities Connection = new ShopDBEntities();
    }
}
