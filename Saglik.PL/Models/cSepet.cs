using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saglik.PL.Models
{
    public class cSepet
    {
        public int urunid { get; set; }
        public string urunad { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal tutar { get; set; }

        public static List<cSepet> SepetAl()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["sepet"] == null)
                context.Session["sepet"] = new List<cSepet>();

            return (List<cSepet>)context.Session["sepet"];
        }
        public void SepeteEkle(List<cSepet> sepet, cSepet siparis)
        {
            if (sepet.Any(s => s.urunid == siparis.urunid))
            {
                //eğer aynı ürün önceden sepete atılmışsa, yeni sipariş eklenmemeli, var olan siparişin adet ve tutar değerleri artırılmalı.
                foreach (cSepet item in sepet)
                {
                    if(item.urunid == siparis.urunid)
                    {
                        item.adet += siparis.adet;
                        item.tutar += siparis.tutar;
                    }
                }
            }
            else
            {
                sepet.Add(siparis);  //siparişi verilen ürün ilk defa sepete ekleniyorsa...
            }
            HttpContext.Current.Session["sepet"] = sepet;
            HttpContext.Current.Session["toplamadet"] = ToplamAdetBul(sepet);
            HttpContext.Current.Session["toplamtutar"] = ToplamTutarBul(sepet);
        }
        public void SepettenSil(List<cSepet> sepet, cSepet siparis)
        {
            sepet.Remove(siparis);
            HttpContext.Current.Session["sepet"] = sepet;
            HttpContext.Current.Session["toplamadet"] = ToplamAdetBul(sepet);
            HttpContext.Current.Session["toplamtutar"] = ToplamTutarBul(sepet);
        }
        public int ToplamAdetBul(List<cSepet> sepet)
        {
            int ToplamAdet = 0;
            foreach (cSepet item in sepet)
            {
                ToplamAdet += item.adet; 
            }
            return ToplamAdet;
        }
        public decimal ToplamTutarBul(List<cSepet> sepet)
        {
            decimal ToplamTutar = 0;
            foreach (cSepet item in sepet)
            {
                ToplamTutar += item.tutar;
            }
            return ToplamTutar;
        }
    }
}