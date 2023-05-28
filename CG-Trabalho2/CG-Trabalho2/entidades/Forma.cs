using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2bimestre.entidades
{
    class Forma
    {
        private Ponto pontoCentral; //ponto central do objeto 3D, pra facilitar translãção e rotação
        private List<List<int>> faces, listaFacesVertices; //matriz de faces
        private List<Ponto> vOriginais, vAtuais; //vertices atuais e vértices originais
        private Ponto[] vetNfaces, vetNvertices; //vetor de pontos, para as faces e para os vértices
        private double[,] matrizTransformacao; // matriz 4x4
        private double maiorx, maiory, maiorz, menorx, menory, menorz;

        public Forma()
        {

        }

        public Forma(string filepath)
        {
            inicializa();
            carregarForma(filepath);
        }

        private void inicializa()
        {
            pontoCentral = new Ponto(0, 0, 0);
            faces = new List<List<int>>();
            vOriginais = new List<Ponto>();
            vAtuais = new List<Ponto>();
            listaFacesVertices = new List<List<int>>();
            vetNfaces = vetNvertices = null;
            matrizTransformacao = geraMatrizIdentidade(4);

        }

        private double[,] geraMatrizIdentidade(int ordem)
        {
            double[,] mat = new double[ordem, ordem];
            for (int i = 0; i < ordem; ++i)
                mat[i, i] = 1;
            return mat;
        }

        public double[,] getMatrizTransformacao()
        {
            return copiarMatriz(matrizTransformacao);
        }

        public void setMatrizTransformacao(double[,] matriz)
        {
            this.matrizTransformacao = matriz;
        }

        public int getMaiorX()
        {
            return (int)Math.Round(maiorx);
        }

        public int getMenorX()
        {
            return (int)Math.Round(menorx);
        }

        public int getMaiorY()
        {
            return (int)Math.Round(maiory);
        }

        public int getMenorY()
        {
            return (int)Math.Round(menory);
        }

        public List<Ponto> getVertices()
        {
            return verticesAtuais;
        }

        public List<List<int>> getFaces()
        {
            return faces;
        }

        public Ponto getCentro()
        {
            return pontoCentral;
        }

        public double[,] copiarMatriz(double[,] mat)
        {
            double[,] nova = new double[mat.GetLength(0), mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(0); ++i)
                for (int j = 0; j < mat.GetLength(1); ++j)
                    nova[i, j] = mat[i, j];
            return nova;
        }

        public void carregarForma(string filepath)
        {
            string linha;
            string[] vs, vs2;
            double x, y, z, xm, ym, zm;
            this.maiorx = this.maiory = this.maiorz = this.menorx = this.menory = this.menorz = xm = ym = zm = 0;
            int idx, d;
            List<int> face;
            FileStream file = File.OpenRead(filepath);
            StreamReader read = new StreamReader(file);
            while ((linha = read.ReadLine()) != null)
            {
                linha = linha.Trim();
                if (linha.Length > 0)
                {
                    vs = linha.Split(' ');
                    if (vs[0] == "v")
                    {// vertice
                        double.TryParse(vs[1].Replace('.', ','), out x);
                        double.TryParse(vs[2].Replace('.', ','), out y);
                        double.TryParse(vs[3].Replace('.', ','), out z);
                        xm += x;
                        ym += y;
                        zm += z;
                        if (x > this.maiorx)
                            this.maiorx = x;
                        else if (x < this.menorx)
                            this.menorx = x;
                        if (y > this.maiory)
                            this.maiory = y;
                        else if (y < this.menory)
                            this.menory = y;
                        if (z > this.maiorz)
                            this.maiorz = z;
                        else if (z < this.menorz)
                            this.menorz = z;
                        addVertice(new Ponto(x, y, z));
                        listaFacesVertices.Add(new List<int>());
                    }
                    else if (vs[0] == "f")
                    {
                        face = new List<int>();
                        for (int i = 1; i < vs.Length; ++i)
                        { // pontos
                            vs2 = vs[i].Split('/');
                            idx = int.Parse(vs2[0]) - 1;
                            face.Add(idx);
                            listaFacesVertices[idx].Add(faces.Count);
                        }
                        addFace(face);
                    }
                }
            }
            d = vOriginais.Count;
            this.pontoCentral = new Ponto(xm / d, ym / d, zm / d);
            read.Close();
            file.Close();
            //calcularVetoresNormais(); // caso ja abra sem faces ocultas
        }

        public void addVertice(Ponto ponto)
        {
            vOriginais.Add(p);
            vAtuais.Add(p);
        }

        public void addFace(List<int> f)
        {
            faces.Add(f);
        }

        private double[,] multiplicar(double[,] m1, double[,] m2)
        {
            int l1 = m1.GetLength(0), c1 = m1.GetLength(1);
            int l2 = m1.GetLength(0), c2 = m2.GetLength(1);
            // GetLength(idx) retorna a quantidade de valores na dimenssão idx
            double[,] mat = new double[l1, c2];
            for (int i = 0; i < l1; ++i) // linha da primeira
                for (int j = 0; j < c2; ++j) // coluna da segunda
                    for (int k = 0; k < l1; ++k) // linha da seg ou coluna da prim
                        mat[i, j] += m1[i, k] * m2[k, j];
            return mat;
        }

        private void atualizarVertices()
        {
            Ponto3D p;
            double[,] matp;
            double x, y, z;
            x = y = z = 0;
            mx = my = mz = 0;
            lx = ly = lz = int.MaxValue;
            verticesAtuais = new List<Ponto3D>();
            for (int i = 0; i < verticesOri.Count; ++i)
            {
                p = verticesOri[i];
                matp = multiplicar(ma, ponto3D2Matriz(p));
                // atualizando verticesAtuais
                verticesAtuais.Add(new Ponto3D(matp[0, 0], matp[1, 0], matp[2, 0]));
                x += matp[0, 0]; y += matp[1, 0]; z += matp[2, 0];
                if (matp[0, 0] > mx) mx = matp[0, 0];
                else if (matp[0, 0] < lx) lx = matp[0, 0];
                if (matp[1, 0] > my) my = matp[1, 0];
                else if (matp[1, 0] < ly) ly = matp[1, 0];
            }
            // atualizando centro
            int d = verticesOri.Count;
            pcentro = new Ponto3D(Math.Round(x / d), Math.Round(y / d), Math.Round(z / d));
        }



    }
}
