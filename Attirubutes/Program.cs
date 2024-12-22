using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attirubutes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Attribute : özellik nitelik
            //
            Customer customer = new Customer {Id=1 ,LasttName = "Acar", Age=26 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
            //Açıkçası güzel anlatmadı pek birşey anlamadım araştıracam.
        }
    }
    
   //[ToTable("Customers")]

    class Customer
    {
        public int Id  { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }

        public string LasttName { get; set; }

        public int Age { get; set; }

    }

    class CustomerDal
    {
        [Obsolete("DOnt use Add use AddNew Method")]
        //yukarıdaki attribute  hazır bir attribute eskimiş anlamına geliyormuş
        public void Add(Customer customer){

            Console.WriteLine("{0},{1},{2}{3} added! ",
                customer.Id,customer.FirstName,customer.LasttName,customer.Age);

        }
        
        public void AddNew(Customer customer)
        {

            Console.WriteLine("{0},{1},{2}{3} added! ",
                customer.Id, customer.FirstName, customer.LasttName, customer.Age);

        }

    }

    //AttributeTargets.Class yazarsan bu özelliği sadece class larda kullanımıyla kısıtlıyorsun.
    // AttributeTargets.Property | AttributeTargets.Field şeklinde yazarak birden çok türde kullanılabilmesini sağlar.
    // 


    [AttributeUsage(AttributeTargets.All)]
    class RequiredPropertyAttribute:Attribute
    {
        // Attribute tanımlarken kullanmak istediğimiz ismin sonuna Attribute ekliyoruz ve Attribute sınıfını inherit ediyoruz.
        // Kullanırken sadece [] içine isim kısmını kullanıyoruz.
    }

    class ToTableAttribute : Attribute
    {
        //Buradaki ToTable nesneyle ilgili veri tabanını belirtmek için kullanılırmış.
        // ve Bu yapı dinamik sorgular üretmek için kullanılırmış.
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }

    }
}
