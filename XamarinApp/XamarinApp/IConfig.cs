using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp
{
    public interface IConfig
    {
        string PathSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
