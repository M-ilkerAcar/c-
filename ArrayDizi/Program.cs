using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDizi
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] dizi1 = { "eleman1", "Eleman2", "eleman3" };
            // Dizi tanımlama şekillerinden biri yukarıda görebileceğimiz şeklinde Tip[]diziismi =[dğer,değe2]; gibi şeklinde yazılabilir.
            string[] dizi2 = new string[3];
            dizi2[0] = "ilk eleman";
            dizi2[1] = "ikinci eleman";
            dizi2[2] = "üçüncü eleman";
            //Yukarısıda dizi tanımlama şekillerinden biridir => Tip[] dizi ismi = new Tip [dizi içindeki değerler]
            //Sonrasında da tek tek indexlere değer ataması yapılır. oda => dizi ismi [Dizi indexi* 0 dan başlar] = değer ; şeklinde yazımı yapılır.
            Console.WriteLine(dizi2[1]);
            Console.ReadLine();
            


        }



    }
}
