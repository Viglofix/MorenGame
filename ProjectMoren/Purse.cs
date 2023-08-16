using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMoren
{
    public class PurseHP
    {
        public int HP;

        public override string ToString()
        {
            return $"{HP}";
        }
    }
    public class PurseMoreny
    {
        public int Moreny;

        public override string ToString()
        {
            return $"{Moreny}";
        }
    }

    public interface IPurseService
    {
       void AddPurseMoreny(int money);
       void AddPurseHP(int hp);
       void DeletePurseMoreny(int money);
        void DeletePurseHP(int hp);
    }

    public class PurseService : IPurseService
    {
        public List<PurseMoreny> PurseMoreny = new List<PurseMoreny> { new PurseMoreny() { Moreny = 0 }};
        public List<PurseHP>? PurseHP = new List<PurseHP> { new PurseHP() { HP = 0 } };

        public void AddPurseMoreny(int money)
        {
           PurseMoreny[0].Moreny += money;
        }
        public void AddPurseHP(int hp)
        {
           PurseHP![0].HP += hp;
        }
        public void DeletePurseMoreny(int money)
        {
           PurseMoreny[0].Moreny -= money;
        } 
        public void DeletePurseHP(int hp)
        {
           PurseHP![0].HP -= hp;
        }
    }
}
