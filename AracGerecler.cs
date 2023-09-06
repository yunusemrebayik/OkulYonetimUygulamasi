using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiTemel
{
    class AracGerecler
    {
        static public string IlkHarfBuyut(string metin)
        {
            return metin.Substring(0, 1).ToUpper() + metin.Substring(1).ToLower();
        }
        static public int SayiAl(string mesaj)
        {
            int sayi;

            do
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);

        }
        static public string YaziAl(string yazi)
        {
            int sayi;

            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    Console.WriteLine("Hatalı islem tekrar girin.");
                }
                
                else
                {
                    return giris;
                }
            } while (true);

        }
        static public DateTime TarihAl(string yazi)
        {
            DateTime tarihx;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarihx))
                {
                    return tarihx;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }
            } while (true);
        }
        static public CINSIYET KizMiErkekMi(string yazi)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                 

                if (giris.ToUpper() == "K")
                {
                    return CINSIYET.Kiz;
                }
                else if (giris.ToUpper() == "E")
                {
                    return CINSIYET.Erkek;
                }
                else if (giris == "")
                {
                    return CINSIYET.Empty;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }
        static public SUBE SubeAl(string yazi)
        {
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();

                

                if (giris.ToUpper() == "A")
                {
                    return SUBE.A;
                }
                else if (giris.ToUpper() == "B")
                {
                    return SUBE.B;
                }
                else if (giris.ToUpper() == "C")
                {
                    return SUBE.C;
                }
                else if (giris == "")
                {
                    return SUBE.Empty;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }

            } while (true);
        }
        static public DateTime TarihAlGuncelle(string yazi)
        {
            DateTime tarih;
            do
            {
                Console.Write(yazi);
                string giris = Console.ReadLine();
                if (DateTime.TryParse(giris, out tarih))
                {
                    return tarih;
                }
                else
                {
                    return DateTime.MinValue;

                }

            } while (true);
        }
        static public string DersGir()
        {


            while (true)
            {
                Console.Write("Not eklemek istediğiniz dersi giriniz: ");
                return Console.ReadLine().ToUpper();


            }

        }

    }
}
