using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiTemel
{
    class Ogrenci
    {

        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
       
        public SUBE Sube { get; set; }
        public CINSIYET Cinsiyet { get; set; }
        public Adres Adresi { get; set; }

        public List<DersNotu> Notlar = new List<DersNotu>();
        public List<string> Kitaplar = new List<string>();

        public double Ortalama
        {
            get
            {
                double ort = this.Notlar.Sum(a => a.Not);

                if (ort == 0)
                {
                    return 0;
                }
                else
                {
                    return ort / this.Notlar.Count;
                }

            }
        }
        public void KitapEkle(string kitap)
        {
            if (this.Kitaplar == null)
            {
                this.Kitaplar = new List<string>();
            }
            this.Kitaplar.Add(kitap);
        }
        public int KitapSayisi
        {
            get
            {
                return this.Kitaplar == null ? 0 : this.Kitaplar.Count;
            }
        }
        public void AdresEkle(string il, string ilce, string mahalle)
        {
            if (this.Adresi == null)
            {
                this.Adresi = new Adres();
            }
            this.Adresi.Il = il;
            this.Adresi.Ilce = ilce;
            this.Adresi.Mahalle = mahalle;
        }

    }
    


    public enum SUBE
    { 
    
        Empty, A, B, C
    
    }

    public enum CINSIYET
    { 
    
        Empty, Kiz, Erkek
    
    }
}
