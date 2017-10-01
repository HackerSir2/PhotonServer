using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace Nhibernate_Mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly("Nhibernate-Mysql");

            Console.ReadKey();
        }
    }
}
