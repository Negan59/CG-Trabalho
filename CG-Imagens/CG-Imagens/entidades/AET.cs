using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
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
            /*
            public void quickPivo()
            {
                int i, j, pivo, aux, ini = 0, fim = tl - 1;
                pivo = vet[(ini + fim) / 2];
                Stack<Integer> pilha = new Stack<>();
                pilha.push(ini);
                pilha.push(fim);
                while (!pilha.isEmpty())
                {
                    fim = pilha.pop();
                    ini = pilha.pop();

                    i = ini;
                    j = fim;

                    pivo = vet[(i + j) / 2];

                    while (i < j)
                    {
                        while (vet[i] < pivo)
                            i++;

                        while (vet[j] > pivo)
                            j--;

                        if (i <= j)
                        {
                            aux = vet[i];
                            vet[i] = vet[j];
                            vet[j] = aux;

                            i++;
                            j--;
                        }
                    }
                    if (ini < j)
                    {
                        pilha.push(ini);
                        pilha.push(j);
                    }
                    if (i < fim)
                    {
                        pilha.push(i);
                        pilha.push(fim);

                    }
                }

            }
            */
            public void sort()
            {
                /*
                TROCAR A INFORMAÇÃO
                prioridade meNoAETr ymax, meNoAETr xmin
                */
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
                        //pivoY = lista[meio].getYmax();
                        while (i < j)
                        {
                            //while (lista[i].getYmax() < pivoY)
                            //    ++i;
                            while (/*lista[i].getYmax() == pivoY && */lista[i].getXmin() < pivoX)
                                ++i;
                            //while (lista[j].getYmax() > pivoY)
                            //    --j;
                            while (/*lista[j].getYmax() == pivoY && */lista[j].getXmin() > pivoX)
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
            } // fim sort
        }
    }
