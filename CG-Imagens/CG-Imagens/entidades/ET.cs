using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class ET
    {
        private AET[] et;
        private int TF, qtde;

        public ET(int tf)
        {
            TF = tf;
            qtde = 0;
            et = new AET[TF];
        }

        public AET getAET(int pos)
        {
            if (pos >= TF)
                return null;
            return et[pos];
        }

        public int getTF()
        {
            return TF;
        }

        public int getQtde()
        {
            return qtde;
        }

        public void init(int pos)
        {
            et[pos] = new AET();
            qtde++;
        }

        public void addNo(int pos, No n)
        {
            if (et[pos] == null)
                init(pos);
            et[pos].add(n);
        }
    }
}
