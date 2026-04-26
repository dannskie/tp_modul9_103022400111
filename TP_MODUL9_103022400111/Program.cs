using System;

namespace TP_MODUL9_103022400111 
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig CC = new CovidConfig();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {CC.config.satuan_suhu}: ");
            double suhuInput = Convert.ToDouble(Console.ReadLine());
            Console.Write("Berapa hari yang lalu anda terakhir memiliki gejala deman? ");
            int hariInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); 

            bool suhuValid = false;

            if (CC.config.satuan_suhu == "celcius")
            {
                if (suhuInput >= 36.5 && suhuInput <= 37.5)
                {
                    suhuValid = true;
                }
            }
            else if (CC.config.satuan_suhu == "fahrenheit")
            {
                if (suhuInput >= 97.7 && suhuInput <= 99.5)
                {
                    suhuValid = true;
                }
            }

            bool hariValid = hariInput < CC.config.batas_hari_deman;

            if (suhuValid && hariValid)
            {
                Console.WriteLine(CC.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(CC.config.pesan_ditolak);
            }
            CC.UbahSatuan();
        }
    }
}