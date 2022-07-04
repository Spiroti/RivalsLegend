using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RivalsLegends
{
    public class Team
    {
        private String sName { get; set; }
        private List<Player> lListTeam;

        public void AddPro(List<Player> lListePro)
        {
            lListePro.ForEach( element => lListTeam.Add(element));

        }

        public void ShowEquipe()
        {
            Console.WriteLine("Team : " + sName + Environment.NewLine + "List :");
            lListTeam.ForEach(element => Console.WriteLine("Player's name : " + element.GetPseudo()));

        }
        public Team(String _name, List<Player> lListTeam)
        {
            sName = _name;
            AddPro(lListTeam);
        }
        public Team(String _name)
        {
            sName = _name;
        }
    }
}
