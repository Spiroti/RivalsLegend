using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RivalsLegends
{
    public class Player
    {
        private String pseudo { get; set; }

        private UInt16 AGR { get; set; }// Agressivité ( potentiel de kill pdt phase de lane ??)
        private UInt16 CLU { get; set; } // Cluch facteur (potentiel de réussite d'action peu probable)
        private UInt16 COM { get; set; } // Communication (capacité à être sunchroniser avec son équipe) COM
        private UInt16 CON { get; set; } // Connaissance ( match up, faiblesses, forces champ ~taux de surprise)
        private UInt16 DIS { get; set; } // Discipline (appliqué une stratégie, pour la fin de jeu ??)
        private UInt16 FAR { get; set; } // Farming (potentiel de prendre de l'avance en Gold)
        private UInt16 MAC { get; set; } // Maccro (prise de décision par rapport à la situation)
        private UInt16 MEC { get; set; } // Mécanique (en action propre)
        private UInt16 VDJ { get; set; } // vision de jeu (lien avec Maccro)

        public String GetPseudo()
        {
            return pseudo;
        }
        public Player(String _pseudo, UInt16 agr, UInt16 clu, UInt16 com, UInt16 con, UInt16 dis, UInt16 far, UInt16 mac, UInt16 mec, UInt16 vdj)
        {
            pseudo = _pseudo; MEC = mec; MAC = mac; AGR = agr; COM = com; VDJ = vdj; FAR = far; CLU = clu; DIS = dis; CON = con;
        }
        public Player()
        {
        }

    }
}
