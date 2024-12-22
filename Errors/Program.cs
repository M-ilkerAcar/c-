using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errors
{
    class Program
    {
        static void Main(string[] args)
        {
            //Malesef kolleksiyon diye tanımlanan aslında List, ArrayList ,Array gibi konuların anlatıldığı
            //Collection solitionu kaydederken donup kapandı ve kurtaramadım hiçbir veriyi.

            // Hataların kontrolü için try catch yapısı kullanılır.

            try
            {
                string[] students = new string[3] { "Ahmet", "Mehmet", "Ali" };
                students[3] = "Ahmet";
            }
            catch (NullReferenceException)
            {
                //Parantez içerisindeki türde bir hatayı alırsa burayı  yazdıracak.
                Console.WriteLine("a");

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("b");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata kodu :{0}" , e.Message);
            }


        }
    }
}
