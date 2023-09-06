using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiTemel
{
    class Okul
    {
        // Okul ve öğrencilerle ilgili herhangi bir veri değişikliği burada yapılacak. 
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            //Parametreden gelen tüm değişkenler buraya gelene kadar kontrol edilmiş doğruluğundan emin olunmuş 
            //olmalı. 
            Ogrenci o = new Ogrenci();
            o.AdresEkle("-", "-", "-");
            o.Ad = ad;
            o.No = no;
            o.Soyad = soyad;
            o.DogumTarihi = dogumTarihi;
            o.Cinsiyet = cinsiyet;
            o.Sube = sube;


            this.Ogrenciler.Add(o);

        }
        public void KitapEkle(int no, string kitapAdi)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.KitapEkle(kitapAdi);
            }
        }
        public void AdresEkle(int no, string il, string ilce, string mahalle)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            if (o != null)
            {
                o.AdresEkle(il, ilce, mahalle);
            }
        }

        public void OgrenciSil(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();
            if (o != null)
            {
                Ogrenciler.Remove(o);
            }


        }

        public void OgrenciGuncelle(int no, string isim, string soyisim, DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {

            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            if (o != null)
            {
                if (isim != "")
                {
                    o.Ad = isim;
                }
                if (soyisim != "")
                {
                    o.Soyad = soyisim;
                }
                if (dogumTarihi != DateTime.MinValue)
                {
                    o.DogumTarihi = dogumTarihi;
                }
                if (cinsiyet != CINSIYET.Empty)
                {
                    o.Cinsiyet = cinsiyet;
                }
                if (sube != SUBE.Empty)
                {
                    o.Sube = sube;
                }
            }


        }

        public void NotEkle(int no, string ders, int not)
        {

            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {

                //DersNotu dn = new DersNotu(ders, not);

                //o.Notlar.Add(dn);

                o.Notlar.Add(new DersNotu(ders, not));

            }
            ////else 
            //{

            //    throw new Exception("Bu noya sahip öğrenci yok alooooo!!");

            //}

        }
        public bool VarMi(int no)
        {
            return this.Ogrenciler.Where(a => a.No == no).FirstOrDefault() != null;
        }
        public int NoOlustur(int no)
        {
            while (true)
            {
                if (VarMi(no))
                {
                    no++;
                     
                }
                else
                {
                    return no;
                }
            }
            
        }
        public List<string> KitapListele(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            List<string> kitaplar;

            if (o != null)
            {
                if (o.Kitaplar != null)
                {
                    kitaplar = o.Kitaplar.ToList();
                    return kitaplar;
                }
            }
            return null;
        }

        public string AdSoyadGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();

            string birlesikIsim = "";

            if (o != null)
            {
                birlesikIsim = o.Ad + " " + o.Soyad;
            }
            return birlesikIsim;
            //burda isimleri birlestirmek icin bos string actim
        }
        public SUBE SubeGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();
            
                return o.Sube;
            
            

        }
        public List<DersNotu> NotGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();
            List<DersNotu> notlar;
            if (o != null)
            {
                notlar = o.Notlar.ToList();
                return notlar;
            }
            return null;

        }
        public List<string> SonKitabiGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();
            List<string> kitaplar;
            if (o != null)
            {
                if (o.Kitaplar != null)
                {
                    kitaplar = o.Kitaplar.ToList();
                    kitaplar.Reverse();

                    return kitaplar.Take(1).ToList();
                    ///1 tane son kitabi getirmesi icin take 1 verdim
                }
            }
            return null;


        }
        public double OrtalamalariGetir(int no)
        {
            Ogrenci o = this.Ogrenciler.Where(b => b.No == no).FirstOrDefault();
            if (o != null)
            {
                return o.Ortalama;
            }
            return 0;

        }




    }
}
