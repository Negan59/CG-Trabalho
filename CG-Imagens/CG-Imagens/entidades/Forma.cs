using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class Forma
    {
        private Ponto pcentro;
        private List<List<int>> faces, listaFacesVertices;
        private List<Ponto> verticesOri, verticesAtuais;
        private Ponto[] vetNfaces, vetNvertices;
        private double[,] matrizTransformacao; // 4x4
        private double mx, my, mz, lx, ly, lz;


        private Forma()
        {
        }

        private void inicializa()
        {
            pcentro = new Ponto(0, 0, 0);
            faces = new List<List<int>>();
            verticesOri = new List<Ponto>();
            verticesAtuais = new List<Ponto>();
            listaFacesVertices = new List<List<int>>();
            vetNfaces = vetNvertices = null;
            matrizTransformacao = gerarMatrizIdentidade(4);
        }

        public Forma(string filepath)
        {
            inicializa();
            abrirObjeto(filepath);
        }

        public double[,] getMatrizTransformacao()
        {
            return copiarMatriz(matrizTransformacao);
        }

        public double[,] copiarMatriz(double[,] mat)
        {
            double[,] nova = new double[mat.GetLength(0), mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(0); ++i)
                for (int j = 0; j < mat.GetLength(1); ++j)
                    nova[i, j] = mat[i, j];
            return nova;
        }

        public void setMA(double[,] mat)
        {
            matrizTransformacao = mat;
        }

        public int getMatrizTransformacaoxX()
        {
            return (int)Math.Round(mx);
        }

        public int getMinX()
        {
            return (int)Math.Round(lx);
        }

        public int getMatrizTransformacaoxY()
        {
            return (int)Math.Round(my);
        }

        public int getMinY()
        {
            return (int)Math.Round(ly);
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
            return pcentro;
        }



        public void abrirObjeto(string filepath)
        {
            string linha;
            string[] vs, vs2;
            double x, y, z, xm, ym, zm;
            this.mx = this.my = this.mz = this.lx = this.ly = this.lz = xm = ym = zm = 0;
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
                        if (x > this.mx)
                            this.mx = x;
                        else if (x < this.lx)
                            this.lx = x;
                        if (y > this.my)
                            this.my = y;
                        else if (y < this.ly)
                            this.ly = y;
                        if (z > this.mz)
                            this.mz = z;
                        else if (z < this.lz)
                            this.lz = z;
                        addVertice(new Ponto(x, y, z));
                        listaFacesVertices.Add(new List<int>());
                    }
                    else if (vs[0] == "f")
                    {
                        face = new List<int>();
                        for (int i = 1; i < vs.Length; ++i)
                        { 
                            vs2 = vs[i].Split('/');
                            idx = int.Parse(vs2[0]) - 1;
                            face.Add(idx);
                            listaFacesVertices[idx].Add(faces.Count);
                        }
                        addFace(face);
                    }
                }
            }
            d = verticesOri.Count;
            this.pcentro = new Ponto(xm / d, ym / d, zm / d);
            read.Close();
            file.Close();
            calcularVetoresNormais(); // caso ja abra sem faces ocultas
        }

        public void addVertice(Ponto ponto)
        {
            verticesOri.Add(ponto);
            verticesAtuais.Add(ponto);
        }

        public void addFace(List<int> f)
        {
            faces.Add(f);
        }

        private double[,] gerarMatrizIdentidade(int ordem)
        {
            double[,] mat = new double[ordem, ordem];
            for (int i = 0; i < ordem; ++i)
                mat[i, i] = 1;
            return mat;
        }

        private double[,] multiplicar(double[,] m1, double[,] m2)
        {
            int l1 = m1.GetLength(0), c1 = m1.GetLength(1);
            int l2 = m1.GetLength(0), c2 = m2.GetLength(1);
            double[,] mat = new double[l1, c2];
            for (int i = 0; i < l1; ++i) 
                for (int j = 0; j < c2; ++j)
                    for (int k = 0; k < l1; ++k)
                        mat[i, j] += m1[i, k] * m2[k, j];
            return mat;
        }



        private void atualizarVertices()
        {
            Ponto ponto;
            double[,] matp;
            double x, y, z;
            x = y = z = 0;
            mx = my = mz = 0;
            lx = ly = lz = int.MaxValue;
            verticesAtuais = new List<Ponto>();
            for (int i = 0; i < verticesOri.Count; ++i)
            {
                ponto = verticesOri[i];
                matp = multiplicar(matrizTransformacao, Ponto2Matriz(ponto));
                verticesAtuais.Add(new Ponto(matp[0, 0], matp[1, 0], matp[2, 0]));
                x += matp[0, 0]; y += matp[1, 0]; z += matp[2, 0];
                if (matp[0, 0] > mx) mx = matp[0, 0];
                else if (matp[0, 0] < lx) lx = matp[0, 0];
                if (matp[1, 0] > my) my = matp[1, 0];
                else if (matp[1, 0] < ly) ly = matp[1, 0];
            }
            int d = verticesOri.Count;
            pcentro = new Ponto(Math.Round(x / d), Math.Round(y / d), Math.Round(z / d));
        }

        public double[,] Ponto2Matriz(Ponto ponto)
        {
            double[,] matp = new double[4, 1];
            matp[0, 0] = ponto.getX();
            matp[1, 0] = ponto.getY();
            matp[2, 0] = ponto.getZ();
            matp[3, 0] = 1;
            return matp;
        }

        public Ponto matriz2Ponto(double[,] m)
        {
            return new Ponto(m[0, 0], m[1, 0], m[2, 0]);
        }

        public void atualizarVetoresNormaisFaces()
        {
            calcularVetoresNormais();
        }

        public void atualizarVetoresNormaisVertices()
        {
            for (int i = 0; i < vetNvertices.Length; ++i)
            {
                List<Ponto> normais = new List<Ponto>();
                foreach (int j in listaFacesVertices[i])
                    normais.Add(vetNfaces[j]);
                vetNvertices[i] = mediaVetsNormais(normais);
            }
        }

        public void rotacaoX(double r, bool ocultas)
        {
            Ponto centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = gerarMatrizIdentidade(4);
            rot[1, 1] = Math.Cos(r); rot[1, 2] = -Math.Sin(r);
            rot[2, 1] = Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                translacao(-tx, -ty, -tz);
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
                translacao(tx, ty, tz);
            }
            else
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
            atualizarVertices();
            if (ocultas)
                atualizarVetoresNormaisFaces();
        }

        public void rotacaoY(double r, bool ocultas)
        {
            Ponto centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = gerarMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 2] = Math.Sin(r);
            rot[2, 0] = -Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                translacao(-tx, -ty, -tz);
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
                translacao(tx, ty, tz);
            }
            else
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
            atualizarVertices();
            if (ocultas)
                atualizarVetoresNormaisFaces();
        }

       
        public void rotacaoZ(double r, bool ocultas) // radianos
        {
            Ponto centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = gerarMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 1] = -Math.Sin(r);
            rot[1, 0] = Math.Sin(r); rot[1, 1] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                translacao(-tx, -ty, -tz);
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
                translacao(tx, ty, tz);
            }
            else
                matrizTransformacao = multiplicar(rot, matrizTransformacao);
            atualizarVertices();
            if (ocultas)
                atualizarVetoresNormaisFaces();
        }

        public void translacaoX(int tx)
        {
            translacao(tx, 0, 0);
        }

        public void translacaoY(int ty)
        {
            translacao(0, ty, 0);
        }

        public void translacaoZ(int tz)
        {
            translacao(0, 0, tz);
        }

        public void translacao(int tx, int ty, int tz)
        {
            /*
            double[,] trans = gerarMatrizIdentidade(4);
            trans[0, 3] = tx;
            trans[1, 3] = ty;
            trans[2, 3] = tz;
            matrizTransformacao = multiplicar(trans, matrizTransformacao);
            atualizarVertices();
            */
        }

        public void escalaX(double sx)
        {
            escala(sx, 1, 1);
        }

        public void escalaY(double sy)
        {
            escala(1, sy, 1);
        }

        public void escalaZ(double sz)
        {
            escala(1, 1, sz);
        }

        public void escala(double sx, double sy, double sz)
        {
            Ponto centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] esc = gerarMatrizIdentidade(4);
            esc[0, 0] = sx;
            esc[1, 1] = sy;
            esc[2, 2] = sz;
            translacao(-tx, -ty, -tz);
            matrizTransformacao = multiplicar(esc, matrizTransformacao);
            translacao(tx, ty, tz);
            atualizarVertices();
        }

        public Ponto getVetNFace(int id)
        {
            return vetNfaces[id];
        }

        private void inicializarVetoresNormais()
        {
            vetNfaces = new Ponto[faces.Count];
            vetNvertices = new Ponto[verticesOri.Count];
        }

        private void calcularVetoresNormais()
        {
            Ponto vn;
            inicializarVetoresNormais();
            // normais das faces
            for (int i = 0; i < faces.Count; ++i)
            {
                vn = vetorNormal(faces[i]);
                vn = vn.normalizar();
                vetNfaces[i] = vn;
            }
        }

        private Ponto mediaVetsNormais(List<Ponto> normais)
        {
            double x, y, z, d = normais.Count;
            x = y = z = 0;
            foreach (Ponto v in normais)
            {
                x += v.getX();
                y += v.getY();
                z += v.getZ();
            }
            return new Ponto(x / d, y / d, z / d);
        }

        private Ponto vetorNormal(List<int> face)
        {
            Ponto a, b, n;
            a = verticesAtuais[face[0]];
            b = verticesAtuais[face[1]];
            n = verticesAtuais[face[face.Count - 1]];
            Ponto ab = b.menos(a);
            Ponto an = n.menos(a);
            Ponto vn = ab.produtoVetorial(an);
            return vn;
        }


        public Ponto[] getVetoresNormaisFaces()
        {
            return vetNfaces;
        }

        public Ponto[] getVetoresNormaisVertices()
        {
            return vetNvertices;
        }



        
    }
}
