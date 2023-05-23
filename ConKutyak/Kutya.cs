using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConKutyak
{
    public class Kutya
    {
        int id;
        int fajta_id;
        int nev_id;
        int eletkor;
        DateTime ellenorzesIdeje;

        public Kutya(int id, int fajta_id, int nev_id, int eletkor, DateTime utolso_ellenorzes)
        {
            this.id = id;
            this.fajta_id = fajta_id;
            this.nev_id = nev_id;
            this.eletkor = eletkor;
            this.ellenorzesIdeje = utolso_ellenorzes;
        }

        public int Id { get => id;}
        public int Fajta_id { get => fajta_id; }
        public int Nev_id { get => nev_id; }
        public int Eletkor { get => eletkor; }
        public DateTime EllenorzesIdeje { get => ellenorzesIdeje; }
    }
}
