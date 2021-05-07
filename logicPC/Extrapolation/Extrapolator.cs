using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC.Extrapolation
{
    public class Extrapolator
    {
        const double difficulte = 20608845737768.16;
        public static Carte ExtrapolateCardData(Carte atraiter, float difficulty)
        {
            float GHZ = (float)(atraiter.FrequenceGpu / 1000.00);
            float fillRate = atraiter.RopUnits * GHZ;       //en gigaPixels/s
            float TextureRate = atraiter.TmuUnits * GHZ;    //en gigaTexels/s

            float GFLOPS = 0;
            double hashrate = 0;
            
            if (atraiter.IPC > 0)
                GFLOPS = GHZ * atraiter.RopUnits * atraiter.IPC; //IPC = Instructions par cycle 
            else
                GFLOPS = GHZ * atraiter.RopUnits * 81;    //Defaut 2 instructions par cycle

            float GLOPS = GFLOPS / 2;                      //1 opération integer = 2 opérations à point flottant
            if(difficulty < 0)
                hashrate = GLOPS / difficulty;
            else
                hashrate = GLOPS / difficulte;

            atraiter.acceptExtrapolatedData(hashrate, GFLOPS);

            return atraiter;
        }
    }
}
