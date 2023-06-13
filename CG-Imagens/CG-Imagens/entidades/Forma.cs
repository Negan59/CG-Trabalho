using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private double[,] matrizTransformacao;
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
            calcularVetoresNormais();
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
            int l2 = m2.GetLength(0), c2 = m2.GetLength(1);

            if (c1 != l2)
            {
                throw new ArgumentException("As dimensões das matrizes não são compatíveis.");
            }

            double[,] mat = new double[l1, c2];

            for (int i = 0; i < l1; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < c1; k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }
                    mat[i, j] = sum;
                }
            }

            return mat;

        }



        private void atualizarVertices()
        {
            Ponto centro = new Ponto(0, 0, 0);
            double maxX = double.MinValue, minX = double.MaxValue;
            double maxY = double.MinValue, minY = double.MaxValue;
            double somaX = 0, somaY = 0, somaZ = 0;

            verticesAtuais = new List<Ponto>();

            for (int i = 0; i < verticesOri.Count; i++)
            {
                Ponto ponto = verticesOri[i];
                double[,] matp = multiplicar(matrizTransformacao, Ponto2Matriz(ponto));

                double x = matp[0, 0];
                double y = matp[1, 0];
                double z = matp[2, 0];

                verticesAtuais.Add(new Ponto(x, y, z));

                somaX += x;
                somaY += y;
                somaZ += z;

                if (x > maxX)
                    maxX = x;
                if (x < minX)
                    minX = x;
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
            }

            int totalVertices = verticesOri.Count;

            centro.setX(Math.Round(somaX / totalVertices));
            centro.setY(Math.Round(somaY / totalVertices));
            centro.setZ(Math.Round(somaZ / totalVertices));

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

        public void atualizarVetoresNormaisFaces()
        {
            calcularVetoresNormais();
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

        public void translacao(int tx, int ty, int tz)
        {
            
            double[,] trans = gerarMatrizIdentidade(4);
            trans[0, 3] = tx;
            trans[1, 3] = ty;
            trans[2, 3] = tz;
            matrizTransformacao = multiplicar(trans, matrizTransformacao);
            atualizarVertices();
            
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
            for (int i = 0; i < faces.Count; ++i)
            {
                vn = vetorNormal(faces[i]);
                vn = vn.normalizar();
                vetNfaces[i] = vn;
            }
        }
        private Ponto vetorNormal(List<int> face)
        {
            Ponto a, b, n;
            a = verticesAtuais[face[0]];
            b = verticesAtuais[face[1]];
            n = verticesAtuais[face[face.Count - 1]];
            Ponto ab = b.subtrai(a);
            Ponto an = n.subtrai(a);
            Ponto vn = ab.produtoVetorial(an);
            return vn;
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

        public void atualizarVetoresNormaisVertices()
        {
            // vetNormaisPontos
            for (int i = 0; i < vetNvertices.Length; ++i)
            {
                List<Ponto> normais = new List<Ponto>();
                foreach (int j in listaFacesVertices[i])
                    normais.Add(vetNfaces[j]);
                vetNvertices[i] = mediaVetsNormais(normais);
            }
        }

        internal ET gerarETFacePhong(int f, int height, int tx, int ty, Ponto luz, Ponto eye, int n, Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke, Color cor)
        {
            Color m, l;
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            {
                if (verticesAtuais[face[i]].getY() >= verticesAtuais[face[i + 1]].getY())
                {
                    xmax = verticesAtuais[face[i]].getX();
                    ymax = verticesAtuais[face[i]].getY();
                    zmax = verticesAtuais[face[i]].getZ();
                    m = Cores.corPhong(luz, eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke, cor);
                    xmin = verticesAtuais[face[i + 1]].getX();
                    ymin = verticesAtuais[face[i + 1]].getY();
                    zmin = verticesAtuais[face[i + 1]].getZ();
                    l = Cores.corPhong(luz, eye, vetNvertices[face[i+1]], n, ia, id, ie, ka, kd, ke, cor);
                }
                else
                {
                    xmin = verticesAtuais[face[i]].getX();
                    ymin = verticesAtuais[face[i]].getY();
                    zmin = verticesAtuais[face[i]].getZ();
                    l = Cores.corPhong(luz, eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke, cor);
                    xmax = verticesAtuais[face[i + 1]].getX();
                    ymax = verticesAtuais[face[i + 1]].getY();
                    zmax = verticesAtuais[face[i + 1]].getZ();
                    m = Cores.corPhong(luz, eye, vetNvertices[face[i+1]], n, ia, id, ie, ka, kd, ke, cor);
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (m.R - l.R) / dy;
                incgy = (m.G - l.G) / dy;
                incbz = (m.B - l.B) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    l.R, l.G, l.B, incrx, incgy, incbz));
            }

            if (verticesAtuais[face[0]].getY() >= verticesAtuais[face[face.Count - 1]].getY())
            {
                xmax = verticesAtuais[face[0]].getX();
                ymax = verticesAtuais[face[0]].getY();
                zmax = verticesAtuais[face[0]].getZ();
                m = Cores.corPhong(luz, eye, vetNvertices[0], n, ia, id, ie, ka, kd, ke, cor);
                xmin = verticesAtuais[face[face.Count - 1]].getX();
                ymin = verticesAtuais[face[face.Count - 1]].getY();
                zmin = verticesAtuais[face[face.Count - 1]].getZ();
                l = Cores.corPhong(luz, eye, vetNvertices[face.Count - 1], n, ia, id, ie, ka, kd, ke, cor);
            }
            else
            {
                xmin = verticesAtuais[face[0]].getX();
                ymin = verticesAtuais[face[0]].getY();
                zmin = verticesAtuais[face[0]].getZ();
                l = Cores.corPhong(luz, eye, vetNvertices[0], n, ia, id, ie, ka, kd, ke, cor);
                xmax = verticesAtuais[face[face.Count - 1]].getX();
                ymax = verticesAtuais[face[face.Count - 1]].getY();
                zmax = verticesAtuais[face[face.Count - 1]].getZ();
                m = Cores.corPhong(luz, eye, vetNvertices[face.Count - 1], n, ia, id, ie, ka, kd, ke, cor);
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (m.R - l.R) / dy;
            incgy = (m.G - l.G) / dy;
            incbz = (m.B - l.B) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                l.R, l.G, l.B, incrx, incgy, incbz));
            return et;
        }




        public ET gerarETFaceGouraud(int f, int height, int tx, int ty, Ponto luz, Ponto eye, int n,
    Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke,Color cor)
        {
            Color cl, cm;
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            { // do primeiro ponto até o ultimo
                if (verticesAtuais[face[i]].getY() >= verticesAtuais[face[i + 1]].getY())
                {
                    xmax = verticesAtuais[face[i]].getX();
                    ymax = verticesAtuais[face[i]].getY();
                    zmax = verticesAtuais[face[i]].getZ();
                    cm = Cores.corPhong(luz, eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke,cor);
                    xmin = verticesAtuais[face[i + 1]].getX();
                    ymin = verticesAtuais[face[i + 1]].getY();
                    zmin = verticesAtuais[face[i + 1]].getZ();
                    cl = Cores.corPhong(luz, eye, vetNvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke,cor);

                }
                else
                {
                    xmin = verticesAtuais[face[i]].getX();
                    ymin = verticesAtuais[face[i]].getY();
                    zmin = verticesAtuais[face[i]].getZ();
                    cl = Cores.corPhong(luz, eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke,cor);
                    xmax = verticesAtuais[face[i + 1]].getX();
                    ymax = verticesAtuais[face[i + 1]].getY();
                    zmax = verticesAtuais[face[i + 1]].getZ();
                    cm = Cores.corPhong(luz, eye, vetNvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke,cor);
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (cm.R - cl.R) / dy;
                incgy = (cm.G - cl.G) / dy;
                incbz = (cm.B - cl.B) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cl.R, cl.G, cl.B, incrx, incgy, incbz));
            }// fim for
             // ultimo com o primeiro
            if (verticesAtuais[face[0]].getY() >= verticesAtuais[face[face.Count - 1]].getY())
            {
                xmax = verticesAtuais[face[0]].getX();
                ymax = verticesAtuais[face[0]].getY();
                zmax = verticesAtuais[face[0]].getZ();
                cm = Cores.corPhong(luz, eye, vetNvertices[face[0]], n, ia, id, ie, ka, kd, ke,cor);
                xmin = verticesAtuais[face[face.Count - 1]].getX();
                ymin = verticesAtuais[face[face.Count - 1]].getY();
                zmin = verticesAtuais[face[face.Count - 1]].getZ();
                cl = Cores.corPhong(luz, eye, vetNvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke,cor);
            }
            else
            {
                xmin = verticesAtuais[face[0]].getX();
                ymin = verticesAtuais[face[0]].getY();
                zmin = verticesAtuais[face[0]].getZ();
                cl = Cores.corPhong(luz, eye, vetNvertices[face[0]], n, ia, id, ie, ka, kd, ke,cor);
                xmax = verticesAtuais[face[face.Count - 1]].getX();
                ymax = verticesAtuais[face[face.Count - 1]].getY();
                zmax = verticesAtuais[face[face.Count - 1]].getZ();
                cm = Cores.corPhong(luz, eye, vetNvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke,cor);
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (cm.R - cl.R) / dy;
            incgy = (cm.G - cl.G) / dy;
            incbz = (cm.B - cl.B) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cl.R, cl.G, cl.B, incrx, incgy, incbz));
            return et;
        }

        public ET gerarETFaceFlat(int f, int height, int tx, int ty, Ponto Luz, Ponto Eye, int n,
    Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke,Color cor)
        {
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz;
            int y;
            List<int> face = faces[f];
            cor = Cores.corPhong(Luz, Eye, vetNfaces[f], n, ia, id, ie, ka, kd, ke,cor);
            for (int i = 0; i + 1 < face.Count; ++i)
            { // do primeiro ponto até o ultimo
                if (verticesAtuais[face[i]].getY() >= verticesAtuais[face[i + 1]].getY())
                {
                    xmax = verticesAtuais[face[i]].getX();
                    ymax = verticesAtuais[face[i]].getY();
                    zmax = verticesAtuais[face[i]].getZ();
                    xmin = verticesAtuais[face[i + 1]].getX();
                    ymin = verticesAtuais[face[i + 1]].getY();
                    zmin = verticesAtuais[face[i + 1]].getZ();

                }
                else
                {
                    xmin = verticesAtuais[face[i]].getX();
                    ymin = verticesAtuais[face[i]].getY();
                    zmin = verticesAtuais[face[i]].getZ();
                    xmax = verticesAtuais[face[i + 1]].getX();
                    ymax = verticesAtuais[face[i + 1]].getY();
                    zmax = verticesAtuais[face[i + 1]].getZ();
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cor.R, cor.G, cor.B, 0, 0, 0));
            }// fim for
             // ultimo com o primeiro
            if (verticesAtuais[face[0]].getY() >= verticesAtuais[face[face.Count - 1]].getY())
            {
                xmax = verticesAtuais[face[0]].getX();
                ymax = verticesAtuais[face[0]].getY();
                zmax = verticesAtuais[face[0]].getZ();
                xmin = verticesAtuais[face[face.Count - 1]].getX();
                ymin = verticesAtuais[face[face.Count - 1]].getY();
                zmin = verticesAtuais[face[face.Count - 1]].getZ();
            }
            else
            {
                xmin = verticesAtuais[face[0]].getX();
                ymin = verticesAtuais[face[0]].getY();
                zmin = verticesAtuais[face[0]].getZ();
                xmax = verticesAtuais[face[face.Count - 1]].getX();
                ymax = verticesAtuais[face[face.Count - 1]].getY();
                zmax = verticesAtuais[face[face.Count - 1]].getZ();
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new No((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cor.R, cor.G, cor.B, 0, 0, 0));
            return et;
        }




    }
}
