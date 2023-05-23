namespace ConKutyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sorok = File.ReadAllLines("Datas\\Kutyak.csv");
            foreach (var sor in sorok)
            {
                Console.WriteLine(sor);
            }
        }
    }
}