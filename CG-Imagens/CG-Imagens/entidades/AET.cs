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
                QuickSort(0, lista.Count - 1);
            }
        }

        private void QuickSort(int inicio, int fim)
        {
            if (inicio < fim)
            {
                int pivo = Partition(inicio, fim);
                QuickSort(inicio, pivo - 1);
                QuickSort(pivo + 1, fim);
            }
        }

        private int Partition(int inicio, int fim)
        {
            No pivo = lista[fim];
            int i = inicio - 1;

            for (int j = inicio; j <= fim - 1; j++)
            {
                if (Compare(lista[j], pivo) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, fim);
            return i + 1;
        }

        private int Compare(No a, No b)
        {
            int compareYmax = a.getYmax().CompareTo(b.getYmax());
            if (compareYmax != 0)
                return compareYmax;
            return a.getXmin().CompareTo(b.getXmin());
        }

        private void Swap(int i, int j)
        {
            No temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
    }
}
