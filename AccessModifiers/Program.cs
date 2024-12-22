using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccessModifiers
{
    public class Program
    {
        static void Main(string[] args)
        {
            // private bir değişken sadece tanımlandığı sınıf veya blok içerisinde geçerlidir. en az erişim düzeyidir.
            // public değişkenler heryerde kullanılabilir.

            // protected : private gibi tanımlandığı blok içerinde kullanılabilir ve de  kalıtım yoluylada aktarılabilir.
            // internal : Bağlı olduğu projede (aseembly access modifier) içerisinde referans ihtiyacı olmadan kullanabilirsin.
            // sınıfların başına bir şey yazılmadığında default u internaldır.

            // Başka bir sınıfı bu projeninin içinde kullanabilmek için referansa öncelikle eklemek gerekiyor.
            // Sonrasında Using kelimesini kullanarak kullanacağımız projeyi kütüphane gibi yazamamız gerekiyor.
            // Bu FUCK you sınıfını TRY projesinde kullanacaz.


        }
    }

    public class Fuckyou
    {
        public String name { get; set; }
        public String sanane { get; , set; }

    }
}
    
