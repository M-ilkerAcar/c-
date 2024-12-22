using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Add();
            database.Delete();

            Database database1 = new SqlServer();
            database1.Add();
            database1.Delete();

            Console.ReadLine();



        }
    }
    abstract class Database
    {
        public void Add()
        {
            Console.WriteLine("Added by Default");
        }

        public abstract void Delete();
        // Burada herhangi bir gövde yazdırmıyor bu sınıf aşağıda olduğu gibi
        // kalıtım edildiğinde mutlaka override edilmesi gereken nesneler için 
        // kullanılıyor.
        
    }
    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Sql");
        }
    }
    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deleted by Oracle");
        }
    }
}
