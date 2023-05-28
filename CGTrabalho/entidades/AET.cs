using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2bimestre.entidades
{
    class AET
    {
        private List<NoAET> lista;

        public AET()
        {
            lista = new List<NoAET>();
        }

        public void add(NoAET info)
        {
            lista.Add(info);
        }

        public List<NoAET> getList()
        {
            return lista;
        }

        public void add(List<NoAET> L)
        {
            foreach (NoAET n in L)
                lista.Add(n);
        }

        public void sort()
        {

            if (lista.Count > 1)
            {
                Stack<int> pilha = new Stack<int>();
                int inicio = 0, fim = lista.Count - 1, i, j, meio;
                NoAET aux;
                double pivoX;//, pivoY;
                pilha.Push(inicio);
                pilha.Push(fim);
                while (pilha.Count > 0)
                {
                    fim = pilha.Pop();
                    inicio = pilha.Pop();
                    i = inicio;
                    j = fim;
                    meio = (i + j) / 2;
                    pivoX = lista[meio].getXmin();
        
                    while (i < j)
                    {

                        while (lista[i].getXmin() < pivoX)
                            ++i;

                        while (lista[j].getXmin() > pivoX)
                            --j;
                        if (i <= j)
                        {
                            aux = lista[i];
                            lista[i] = lista[j];
                            lista[j] = aux;
                            ++i;
                            --j;
                        }
                    }
                    if (inicio < j)
                    {
                        pilha.Push(inicio);
                        pilha.Push(j);
                    }
                    if (i < fim)
                    {
                        pilha.Push(i);
                        pilha.Push(fim);
                    }
                }

            }
        }
    }
}
