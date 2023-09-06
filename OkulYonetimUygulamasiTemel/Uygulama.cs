using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiTemel
{
    class Uygulama
    {
        static Okul Okul = new Okul();

        static int sayac = 0;

        static Random rnd = new Random();
         
        static public void Calistir()
        {


            SahteVeriGir();

            Menu();


            while (true)
            {
                Console.WriteLine();
                string secim = SecimAl();

                switch (secim)
                {
                    case "1":
                        TümOgrencileriListele();
                        break;
                    case "2":
                        SubeyeGoreListele();
                        break;
                    case "3":
                        CinsiyeteGoreListele();
                        break;
                    case "4":
                        DogumTarihineGoreListele();
                        break;
                    case "5":
                        IllereGoreListele();
                        break;
                    case "6":
                        NotlariGoster();
                        break;
                    case "7":
                        KitapListele();
                        break;
                    case "8":
                        EnBasariliBesO();
                        break;
                    case "9":
                        OkulEnBasarisizUc();
                        break;
                    case "10":
                        SubeEnBasariliBes();
                        break;
                    case "11":
                        SubeEnBasarisizUc();
                        break;
                    case "12":
                        OrtalamaGoster();
                        break;
                    case "13":
                        SinifinOrtalamasi();
                        break;
                    case "14":
                        SonKitap();
                        break;
                    case "15":
                        OgrenciEkle();
                        break;
                    case "16":
                        Guncelle();
                        break;
                    case "17":
                        OgrenciSil();
                        break;
                    case "18":
                        AdresGir();
                        break;
                    case "19":
                        KitapGir();
                        break;
                    case "20":
                        NotGir();
                        break;

                    case "CİKİS":
                    case "ÇIKIŞ":
                    case "cikis":
                    case "çıkış":
                        Environment.Exit(0);
                        break;
                    case "LİSTE":
                        Console.WriteLine();
                        Menu();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        sayac++;
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }

        }


        
        static  int NoAl()
        {
            int no;

            do
            {
                no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                if (!Okul.VarMi(no))
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }
                return no;
            } while (true);
        }

        static string SecimAl()
        {
            if (sayac != 10)
            {
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                return Console.ReadLine().ToUpper();
            }
            else
            {
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                return "ÇIKIŞ";
            }
        }
        static void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("çıkış yapmak için \"çıkış\" yazıp \"enter\"a basın.");
        }
        
        static void TümOgrencileriListele()
        {
            Console.WriteLine();
            Console.WriteLine("1-Bütün Ögrencileri Listele --------------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            Console.WriteLine();
            Listele(Okul.Ogrenciler);
        }
        static public void Listele(List<Ogrenci> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek ögrenci yok.");
                return;
            }

            Console.WriteLine("Sube".PadRight(10, ' ') + "No".PadRight(10, ' ') +
               "Adı" + " " + "Soyadı".PadRight(21, ' ') +
               "Not Ort.".PadRight(15, ' ') + "Okuduğu Kitap Say.");

            Console.WriteLine("".PadRight(79, '-'));

            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10, ' ') +
                    item.No.ToString().PadRight(10, ' ') +
                    (item.Ad + " " + item.Soyad).PadRight(25, ' ') +
                    item.Ortalama.ToString().PadRight(15, ' ')
                    + item.KitapSayisi);
            }

        }

        static void SubeyeGoreListele()
        {
            Console.WriteLine();
            Console.WriteLine("2-Subeye Göre Ögrencileri Listele --------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            SUBE sub = AracGerecler.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            List<Ogrenci> liste = Okul.Ogrenciler.Where(item => item.Sube == sub).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void CinsiyeteGoreListele()
        {
            Console.WriteLine();
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");

            CINSIYET cns = AracGerecler.KizMiErkekMi("Listelemek istediğiniz cinsiyeti girin (K/E): ");
            List<Ogrenci> liste = Okul.Ogrenciler.Where(a => a.Cinsiyet == cns).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void DogumTarihineGoreListele()
        {
            Console.WriteLine();
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");


            DateTime trh = AracGerecler.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
            List<Ogrenci> liste = Okul.Ogrenciler.Where(a => a.DogumTarihi > trh).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void IllereGoreListele()
        {
            Console.WriteLine();
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");

            List<Ogrenci> liste = Okul.Ogrenciler.OrderBy(a => a.Adresi.Il).ToList();/// a'dan z'ye listelemesi icin orderby kullandim

            Console.WriteLine();

            if (liste.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            Console.WriteLine("Sube".PadRight(10, ' ') +
                              "No".PadRight(10, ' ') + ("Adı" + " " + "Soyadı").PadRight(21, ' ') +
                              "Sehir".PadRight(15, ' ') + "Semt");

            Console.WriteLine("".PadRight(79, '-'));

            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10, ' ') +
                                  item.No.ToString().PadRight(10, ' ') +
                                  (item.Ad + " " + item.Soyad).PadRight(21, ' ') +
                                  item.Adresi.Il.PadRight(15, ' ') + item.Adresi.Ilce);
            }

        }

       
        static  void NtListele(List<DersNotu> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Öğrenciye ait bir not bulunmamaktadır");
                return;
            }

            Console.WriteLine("Dersin Adi".PadRight(15, ' ') + "Notu");

            Console.WriteLine("".PadRight(20, '-'));

            foreach (DersNotu item in liste)
            {
                Console.WriteLine(item.DersAdi.ToString().PadRight(15) + item.Not);
            }
        }
        static public void KListele(List<string> liste)
        {

            if (liste != null)
            {
                Console.WriteLine("Okudugu Kitaplar");

                Console.WriteLine("-----------------");

                foreach (string item in liste)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Öğrencinin okuduğu herhangi bir kitap bulunmamaktadır.");
            }

        }

        static public void BilgileriYazdir(int no)
        {
            Console.WriteLine();
            Console.Write("Ögrencinin Adı Soyadı: ");
            Console.WriteLine(Okul.AdSoyadGetir(no));
            Console.Write("Ögrencinin Subesi: ");
            Console.WriteLine(Okul.SubeGetir(no));
            Console.WriteLine();
        }
        static void NotlariGoster()
        {
            Console.WriteLine();
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no = NoAl();
            BilgileriYazdir(no);

            List<DersNotu> list = Okul.NotGetir(no);
            NtListele(list);
        }
        static void KitapListele()
        {
            Console.WriteLine();
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");

            int no = NoAl();
            BilgileriYazdir(no);

            KListele(Okul.KitapListele(no));
        }
        static void EnBasariliBesO()
        {
            Console.WriteLine();
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");

            List<Ogrenci> liste = Okul.Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void OkulEnBasarisizUc()
        {
            Console.WriteLine();
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");

            List<Ogrenci> liste = Okul.Ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void SubeEnBasariliBes()
        {
            Console.WriteLine();
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");

            SUBE sub = AracGerecler.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            List<Ogrenci> liste = Okul.Ogrenciler.Where(item => item.Sube == sub).OrderByDescending(a => a.Ortalama).Take(5).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void SubeEnBasarisizUc()
        {
            Console.WriteLine();
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");

            SUBE sub = AracGerecler.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            List<Ogrenci> liste = Okul.Ogrenciler.Where(item => item.Sube == sub).OrderBy(a => a.Ortalama).Take(3).ToList();

            Console.WriteLine();
            Listele(liste);
        }
        static void OrtalamaGoster()
        {
            Console.WriteLine();
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no = NoAl();
            BilgileriYazdir(no);

            Console.Write("Ögrencinin not ortalaması: " + Okul.OrtalamalariGetir(no));
            Console.WriteLine();
        }
        static void SinifinOrtalamasi()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");

                SUBE sube = AracGerecler.SubeAl("Bir şube seçin (A/B/C): ");
                Console.WriteLine();

                double ort = 0;
                ort = Okul.Ogrenciler.Where(a => a.Sube == sube).Average(a => a.Ortalama);

                Console.Write(sube + " subesinin not ortalaması: " + decimal.Round((decimal)ort, 2));
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
            }
        }
        static void OgrenciEkle()
        {
            Console.WriteLine();
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");
            int gno = AracGerecler.SayiAl("Ögrencinin numarası: ");
            int vno = Okul.NoOlustur(gno);

            string isim;
            while (true)
            {
                isim = AracGerecler.YaziAl("Ögrencinin adı: ");

                if (isim == " ")

                {
                    break;
                }
                else if (isim == "")
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                }

                else
                {
                    isim = AracGerecler.IlkHarfBuyut(isim);
                    break;
                }

            }

            string soyisim;
            while (true)
            {
                soyisim = AracGerecler.YaziAl("Ögrencinin soyadı: ");

                if (soyisim == " ")
                {
                    break;
                }
                else if (soyisim == "")
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                }

                else
                {
                    soyisim = AracGerecler.IlkHarfBuyut(soyisim);
                    break;
                }

            }

            DateTime tarih = AracGerecler.TarihAl("Ögrencinin dogum tarihi: ");
            CINSIYET cins = AracGerecler.KizMiErkekMi("Ögrencinin cinsiyeti (K/E): ");
            SUBE sube = AracGerecler.SubeAl("Ögrencinin subesi (A/B/C): ");

            Okul.OgrenciEkle(vno, isim, soyisim, tarih, cins, sube);
            Console.WriteLine();
            Console.WriteLine(vno + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");

            if (gno != vno)
            {
                Console.WriteLine($"Sistemde {gno} numaralı öğrenci olduğu için verdiğiniz öğrenci no {vno} olarak değiştirildi. ");
            }
            /// gno girilen numara icin, vno da verilen no icin
        }

        static void Guncelle()
        {
            Console.WriteLine();
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede güncellenecek ögrenci yok.");
                return;
            }

            int no = NoAl();
            string isim;
            while (true)
            {
                isim = AracGerecler.YaziAl("Ögrencinin adı: ");

                if (isim == " ")

                {
                    break;
                }
                else if(isim == "")
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                }

                else
                {
                    isim = AracGerecler.IlkHarfBuyut(isim);
                    break;
                }

            }



            string soyisim;
            while (true)
            {
                soyisim = AracGerecler.YaziAl("Ögrencinin soyadı: ");

                if (soyisim == " ")

                {
                    break;
                }
                else if (soyisim == "")
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                }

                else
                {
                    soyisim = AracGerecler.IlkHarfBuyut(soyisim);
                    break;
                }

            }

            
            DateTime tarih = AracGerecler.TarihAlGuncelle("Ögrencinin dogum tarihi: ");

            
            CINSIYET cins = AracGerecler.KizMiErkekMi("Ögrencinin cinsiyeti (K/E): ");

            SUBE sube = AracGerecler.SubeAl("Ögrencinin subesi (A/B/C): ");

            Okul.OgrenciGuncelle(no, isim, soyisim, tarih, cins, sube);
            Console.WriteLine();
            Console.WriteLine("Ogrenci güncellendi.");
        }

        static void OgrenciSil()
        {
            Console.WriteLine();
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
                return;
            }

            int no = NoAl();
            BilgileriYazdir(no);

            string secim = AracGerecler.YaziAl("Ögrenciyi silmek istediginize emin misiniz (E/H): ");  // sayi olup olmadigi kontrol edildi

            if (secim.ToUpper() == "E")
            {
                Okul.OgrenciSil(no);
                Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");

            }
            else if (secim.ToUpper() == "H")
            {
                return;
            }
        }

        static void AdresGir()
        {
            Console.WriteLine();
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no = NoAl();
            BilgileriYazdir(no);

            string yeniIl = AracGerecler.IlkHarfBuyut(AracGerecler.YaziAl("Il: "));
            string yeniIlce = AracGerecler.IlkHarfBuyut(AracGerecler.YaziAl("Ilce: "));
            string yeniMah = AracGerecler.IlkHarfBuyut(AracGerecler.YaziAl("Mahalle: "));

            Okul.AdresEkle(no, yeniIl, yeniIlce, yeniMah);

            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }

        static void KitapGir()
        {
            Console.WriteLine();
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");

            if (Okul.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }

            int no = NoAl();
            BilgileriYazdir(no);

            Console.Write("Eklenecek Kitabin Adı: ");
            string kitap = AracGerecler.IlkHarfBuyut(Console.ReadLine());
            Okul.KitapEkle(no, kitap);

            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }
        static void SonKitap()
        {
            Console.WriteLine();
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");

            int no = NoAl();
            BilgileriYazdir(no);

            List<string> Kitaplar = Okul.SonKitabiGetir(no);

            if (Kitaplar != null)
            {
                Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                Console.WriteLine("-----------------------------");

                foreach (string item in Kitaplar)
                {
                    Console.WriteLine(item);
                }
            }
            
        }

        static void NotGir()
        {

            try
            {

                Console.WriteLine("20-Not Gir ----------------------------------------------------------");
                                
                if (Okul.Ogrenciler.Count == 0)
                {
                    Console.WriteLine("Listede ögrenci yok.");
                    return;
                }
               
                int no = NoAl();
                BilgileriYazdir(no);

                Console.Write("Not eklemek istediğiniz dersi giriniz: ");
                string ders = Console.ReadLine();

                Console.Write("Eklemek istediğiniz not adedi: ");
                int adet = int.Parse(Console.ReadLine());

                for (int i = 1; i <= adet; i++)
                {
                    Console.Write(i + ". notu girin: ");
                    int not = int.Parse(Console.ReadLine());
                    Okul.NotEkle(no, ders, not);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

        }

        static void SahteVeriGir()
        {
            Okul.OgrenciEkle(1, "Cansel", "Korkmaz", new DateTime(1999, 12, 1), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(2, "Yunus Emre", "Bayık", new DateTime(1997, 11, 28), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(3, "Meltem Müyesser", "Gökce", new DateTime(2000, 4, 29), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(4, "Melek", "Satıcı", new DateTime(1999, 7, 7), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(5, "Ömer", "Sert", new DateTime(2000, 3, 5), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(6, "Ali", "Karabulut", new DateTime(1998, 3, 15), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(7, "Zeynep", "Bozbaş", new DateTime(1997, 1, 21), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(8, "Abdurrahman", "Horzum", new DateTime(2000, 7, 16), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(9, "Okay", "Bozkaya", new DateTime(1998, 5, 23), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(10, "Hanife", "Can", new DateTime(1999, 10, 27), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(11, "Selin", "Ciğerci", new DateTime(1998, 2, 12), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(12, "Ahmet", "Kaya", new DateTime(1999, 9, 19), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(13, "Fuat", "Harman", new DateTime(1997, 6, 18), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(14, "Sultan", "Çakır", new DateTime(1998, 10, 20), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(15, "Azize", "Yüksel", new DateTime(2001, 5, 17), CINSIYET.Kiz, SUBE.C);



            string[] ders = new string[4];

            ders[0] = "Matematik";
            ders[1] = "Türkçe";
            ders[2] = "Fen";
            ders[3] = "Sosyal";



            for (int i = 1; i <= 15; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Okul.NotEkle(i, ders[j], rnd.Next(0, 100));
                }
            }

            string[] il = new string[5];


            il[0] = "Denizli";
            il[1] = "Afyonkarahisar";
            il[2] = "Şanlıurfa";
            il[3] = "Isparta";
            il[4] = "İzmir";

            string[] ilce = new string[5];

            ilce[0] = "Başmakçı";
            ilce[1] = "Dazkırı";
            ilce[2] = "Çal";
            ilce[3] = "Honaz";
            ilce[4] = "Dinar";

            string[] mahalle = new string[5];

            mahalle[0] = "Gültepe";
            mahalle[1] = "Atatürk";
            mahalle[2] = "Yıldız";
            mahalle[3] = "Başak";
            mahalle[4] = "Kınıklı";


            for (int i = 1; i <= 15; i++)
            {

                Okul.AdresEkle(i, il[rnd.Next(0, 5)], ilce[rnd.Next(0, 5)], mahalle[rnd.Next(0, 5)]);


            }


            string[] kitaplar = new string[10];

            kitaplar[0] = "Masumiyet Müzesi";
            kitaplar[1] = "İnsan NEDİR";
            kitaplar[2] = "Cin Ali";
            kitaplar[3] = "1884";
            kitaplar[4] = "Nutuk";
            kitaplar[5] = "Safahat";
            kitaplar[6] = "Gizli Anların Yolcusu";
            kitaplar[7] = "Tutunamayanlar";
            kitaplar[8] = "Elveda Güzel Vatanım";
            kitaplar[9] = "Suç ve Ceza";




            for (int i = 1; i <= 15; i++)
            {
                Okul.KitapEkle(i, kitaplar[rnd.Next(0, 10)]);
            }

        }


    }
}
