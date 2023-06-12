using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class AET
    {
        private List<No> lista;

        public AET()
        {
            lista = new List<No>();
        }

        public void add(No info)
        {
            lista.Add(info);
        }

        public List<No> getList()
        {
            return lista;
        }

        public void add(List<No> L)
        {
            foreach (No n in L)
                lista.Add(n);
        }

        public void sort()
        {
            if (lista.Count > 1)
            {
                Stack<int> pilha = new Stack<int>();
                int inicio = 0, fim = lista.Count - 1, i, j, meio;
                No aux;
                double pivoX;
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
