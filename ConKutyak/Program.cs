using System.Security.Cryptography.X509Certificates;

namespace ConKutyak
{
    internal class Program
    {
        static List<string> kutyaNevek;
        static List<KutyaFajta> fajtak;

        static void Main(string[] args)
        {

            //2.

            kutyaNevek = File.ReadAllLines("Datas\\KutyaNevek.csv")
                 .Skip(1)
                 .Select(sor => sor.Split(';')[1])
                 .ToList();

            //kutyaNevek.ForEach(nev => Console.Write(nev + ";"));

            //3. 
            Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");

            //4.
            fajtak = File.ReadAllLines("Datas\\KutyaFajtak.csv")
                                         .Skip(1)
                                         .Select(sor => StringToKutyaFajta(sor))
                                         .ToList();


            //5.

            List<Kutya> kutyak = File.ReadAllLines("Datas\\Kutyak.csv")
                                     .Skip(1)
                                     .Select(sor => StringToKutya(sor))
                                     .ToList();

            //6.
            Console.WriteLine($"6. feladat: Kutyák átlagos életkora: {kutyak.Average(x => x.Eletkor):f2}");

            /*
            Console.WriteLine($"6. feladat: Kutyák átlagos életkora:" +
                $" {Math.Round(kutyak.Average(x => x.Eletkor), 2)}");
            */

            //7. 
            Kutya legidosebbKutya = kutyak.OrderBy(x => x.Eletkor).Last();

            //Alternatív jó megoldások
            legidosebbKutya = kutyak.OrderByDescending(x => x.Eletkor).First();
            legidosebbKutya = kutyak.MaxBy(x => x.Eletkor);

            //Nem kell segéd metódus
            Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája:" +
                $" {kutyaNevek[legidosebbKutya.Nev_id - 1]}, " +
                $"{fajtak[legidosebbKutya.Fajta_id - 1].Nev}");

            //Alkalmazok konverziós eszközöket. Ez a követendő példa
            Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája:" +
                $" {GetKutyaNev(legidosebbKutya.Nev_id)}, {GetKutyaFajta(legidosebbKutya.Fajta_id)}");

            //8.
            Console.WriteLine("8. feladat: Január 10-én vizsgált kutyafajták:");
            kutyak.Where(x => x.EllenorzesIdeje == new DateTime(2018, 1, 10))
                  .GroupBy(x => x.Fajta_id)
                  .ToList()
                  .ForEach(csoport =>
                            Console.WriteLine($"\t{GetKutyaFajta(csoport.Key)}: {csoport.Count()} kutya"));

            //9.
            var legterheltebbNap = kutyak.GroupBy(x => x.EllenorzesIdeje).MaxBy(x => x.Count());
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {legterheltebbNap.Key.ToShortDateString()}: {legterheltebbNap.Count()} kutya");

            //10.
            /*
            var sorok = kutyak.GroupBy(x => x.Nev_id)
                              .OrderByDescending(csop => csop.Count())
                              .ThenBy(csop => csop.Key)
                              .Select(csop => $"{GetKutyaNev(csop.Key)};{csop.Count()}");
            File.WriteAllLines("Névstatisztika.txt", sorok);
            */

            File.WriteAllLines("Névstatisztika.txt", 
                               kutyak.GroupBy(x => x.Nev_id)
                                     .OrderByDescending(csop => csop.Count())
                                     .ThenBy(csop => csop.Key)
                                     .Select(csop => $"{GetKutyaNev(csop.Key)};{csop.Count()}"));
        }

        //7. Kereső metódusok a 7. feladathoz

        static public string GetKutyaNev(int id)
        {
            return kutyaNevek[id - 1];
        }
        static public string GetKutyaFajta(int id)
        {
            return fajtak[id - 1].Nev;
        }


        //4. feladat segéd metódus. Szokás gyártómetódusnak is nevezni, mivel a paraméter alapján egy új
        //objektumot hoz létre, amit visszaad a hívónak.
        private static KutyaFajta StringToKutyaFajta(string sor)
        {
            string[] mezok = sor.Split(';');
            return new KutyaFajta(int.Parse(mezok[0]), mezok[1], mezok[2]);
        }

        //5. feladat
        private static Kutya StringToKutya(string sor)
        {
            string[] mezok = sor.Split(';');
            return new Kutya(int.Parse(mezok[0]),
                             int.Parse(mezok[1]),
                             int.Parse(mezok[2]),
                             int.Parse(mezok[3]),
                             Convert.ToDateTime(mezok[4]));
        }

    }
}