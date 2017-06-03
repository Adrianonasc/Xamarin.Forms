using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public class SQLiteHelpers : IDisposable
    {
        private SQLiteConnection connDB;

        public SQLiteHelpers()
        {
            string fileDB = "my.db3";
            var config = DependencyService.Get<IConfig>();
            string fullPath = Path.Combine(config.PathSQLite, fileDB);
            connDB = new SQLiteConnection(config.Plataforma, fullPath);
        }

        public void InserirCliente(Usuario usuario)
        {
            connDB.Insert(usuario);
        }

        public void CreateTb()
        {
            connDB.CreateTable<Usuario>();
        }

        public void dropTb()
        {
            connDB.DropTable<Usuario>();
        }

        public int CountRegistro()
        {
            return connDB.Table<Usuario>().Count();
        }

        public void Dispose()
        {
            connDB.Dispose();
        }
    }

}
