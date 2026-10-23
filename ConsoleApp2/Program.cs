using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=============================================");
            Console.WriteLine("🕷️ KAAN DEMIR AĞ SIVISI ANALIZ SİSTEMİ 🧪");
            Console.WriteLine("=============================================");

            //Kullanıcıdan Veri Al.

            Console.WriteLine("Polimer miktarı (mg): "); //Polimer miktarı kullanıcıdan alınır.
            decimal p = Convert.ToDecimal(Console.ReadLine()); 

            Console.WriteLine("Katalizör miktarı (mg): "); //Katalizör miktarı kullanıcıdan alınır.
            decimal k= Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Çözücü Miktarı (ml): "); //Çözücü miktarı kullanıcıdan alınır.
            decimal c = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Bulunduğunuz Ortam Sıcaklığı (C): "); //Kullanıcının bulunduğu ortam sıcaklığını alır.
            decimal C = Convert.ToDecimal(Console.ReadLine());


            //Değişkenleri Tanımla.

            decimal intensity = 0.789m; //Çözücü kütlesini bulmak için yoğunluk miktarı.
            decimal total = p + k + (c * intensity); //Karışımın toplam kütlesi.
            decimal capacity = p / 10m; //Ağın taşıma gücünü bulur.
            decimal barrel = 0.3m * 0.3m; //Web shoterin namlu ucu genişliği.
            decimal sole = barrel * (total * p/c);//Tek atışta harcanan miktarı bulur.
            decimal totalSole = total / sole;//Toplam atış sayısını bulur.
            decimal ratioP = (p / total) * 100m;//Karışımdaki Polimer (PVA) miktarı.
            decimal ratioC = ((c * intensity) / total) * 100m;//Karışımdaki Çözücü (Etil Alkol) miktarı.
            decimal ratioK = (k / total) * 100m;//Karışımdaki Katalizör (Boraks) miktarı.
            decimal extinction = (p / (c + 1m) * 2.0m) * (25m / (C + 10m));//Karışımın doğada kaybolma süresi.

            //Çıktıları Ekrana Yazdır.

     
            if (p / (c + 1) > 2.5m) //Polimer çözücüye oranla çok fazla ise.
            {
                Console.WriteLine("🚨 KRİTİK HATA: Viskozite çok yüksek! Karışım macunlaştı, kartuş tıkandı!");
            }
            else if (c < 5m) //Çözücü az ise
            {
                Console.WriteLine("🚨 UYARI: Çözücü yetersiz! Sistem kilitlendi.");
            }
            else
            {
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine($"📊 TEK ATIŞTA HARCANAN MİKTAR: {sole:F2} mg/ml");
                Console.WriteLine($"🎯 HESAPLANAN TOPLAM ATIŞ SAYISI (N): {totalSole:F1} Kez");
                Console.WriteLine("-------------------------------------------\n");


                Console.WriteLine("🧪 AĞ ÖZELLİKLERİ VE KİMYASAL ANALİZ BÜLTENİ:\n");
                Console.WriteLine($"🍺 - PVA (Polimer) Oranı: %{ratioP:F1}");
                Console.WriteLine($"💅 - Boraks (Katalizör) Oranı: %{ratioK:F1}");
                Console.WriteLine($"⚗️ - Etil Alkol (Çözücü) Oranı: %{ratioC:F1}");
                Console.WriteLine($"💪 - Tahmini Taşıma Kapasitesi: ~{capacity:F1} kg");
                Console.WriteLine($"⌚ - Doğada Yok Olma Süresi: ~{extinction:F1} saat");
                Console.WriteLine($"🌡️ - Ortam Sıcaklığı Etkisi: {C}°C (Kuruma Hızı Hesaplandı)");
                Console.WriteLine("-------------------------------------------\n");
            }
            


        }
    }
}
