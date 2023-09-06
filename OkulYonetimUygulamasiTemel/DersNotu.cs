using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasiTemel
{
    class DersNotu
    {

        public string DersAdi;
        public int Not;

        public DersNotu(string dersAdi, int not)
        {

            this.DersAdi = dersAdi;
            this.Not = not;
        
        }

        //DersNotu dn = new DersNotu("matematik", 80);

    }
}
