using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewer
{
    class Objeto3D
    {
        private Ponto3D pcentro;
        private List<List<int>> faces, listaFacesVertices;
        private List<Ponto3D> verticesOri, verticesAtuais;
        private Ponto3D[] vetNfaces, vetNvertices;
        private double[,] ma; // 4x4
        private double mx, my, mz, lx, ly, lz;
        //transformações
        // Translação, Escala e Rotação: 4x4
        // vetNormal = prodVet de vAB e vAN
        // vetNormal = vetNormal / ||vetNormal||
        // ||vetNormal|| = sqrt(x^2 + y^2 + z^2)
        public Objeto3D getCopia()
        {
            Objeto3D o = new Objeto3D();
            // centro, faces, verticesOri, ListaFacesVertices, vetNfacesOri, ma
            o.pcentro = new Ponto3D(0, 0, 0);
            o.verticesOri = this.verticesOri;
            o.faces = this.faces;
            o.listaFacesVertices = this.listaFacesVertices;
            o.vetNfaces = this.vetNfaces;
            o.vetNfaces = (Ponto3D[])this.vetNfaces.Clone();
            o.ma = cloneMat(this.ma);
            o.translacao((int)-pcentro.getX(), (int)-pcentro.getY(), (int)-pcentro.getZ());
            return o;
        }

        private Objeto3D()
        {
        }

        private void inicializa()
        {
            pcentro = new Ponto3D(0, 0, 0);
            faces = new List<List<int>>();
            verticesOri = new List<Ponto3D>();
            verticesAtuais = new List<Ponto3D>();
            listaFacesVertices = new List<List<int>>();
            vetNfaces = vetNvertices = null;
            ma = newMatrizIdentidade(4);
        }

        public Objeto3D(string filepath)
        {
            inicializa();
            lerObjeto3D(filepath);
        }

        public double[,] getMA()
        {
            return cloneMat(ma);
        }

        public double[,] cloneMat(double[,] mat)
        {
            double[,] nova = new double[mat.GetLength(0), mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(0); ++i)
                for (int j = 0; j < mat.GetLength(1); ++j)
                    nova[i, j] = mat[i, j];
            return nova;
        }

        public void setMA(double[,] mat)
        {
            ma = mat;
        }

        public int getMaxX()
        {
            return (int)Math.Round(mx);
        }

        public int getMinX()
        {
            return (int)Math.Round(lx);
        }

        public int getMaxY()
        {
            return (int)Math.Round(my);
        }

        public int getMinY()
        {
            return (int)Math.Round(ly);
        }



        public void lerObjeto3D(string filepath)
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
                //Console.WriteLine(linha);
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
                        addVertice(new Ponto3D(x, y, z));
                        listaFacesVertices.Add(new List<int>());
                    }
                    else if (vs[0] == "f")
                    {
                        // face
                        // novo split por /
                        // vs[1] = "23/23/23"
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
            d = verticesOri.Count;
            this.pcentro = new Ponto3D(xm / d, ym / d, zm / d);
            read.Close();
            file.Close();
            calcularVetoresNormais(); // caso ja abra sem faces ocultas
        }

        public void addVertice(Ponto3D p)
        {
            verticesOri.Add(p);
            verticesAtuais.Add(p);
        }

        public void addFace(List<int> f)
        {
            faces.Add(f);
        }

        public List<Ponto3D> getVertices()
        {
            return verticesAtuais;
        }

        public List<List<int>> getFaces()
        {
            return faces;
        }

        private double[,] newMatrizIdentidade(int ordem)
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
            // GetLength(idx) retorna a quantidade de valores na dimenssão idx
            double[,] mat = new double[l1, c2];
            for (int i = 0; i < l1; ++i) // linha da primeira
                for (int j = 0; j < c2; ++j) // coluna da segunda
                    for (int k = 0; k < l1; ++k) // linha da seg ou coluna da prim
                        mat[i, j] += m1[i, k] * m2[k, j];
            return mat;
        }

        public Ponto3D getCentro()
        {
            return pcentro;
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
                verticesAtuais.Add(new Ponto3D(matp[0, 0],matp[1, 0], matp[2, 0]));
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

        public double[,] ponto3D2Matriz(Ponto3D p)
        {
            double[,] matp = new double[4, 1];
            matp[0, 0] = p.getX();
            matp[1, 0] = p.getY();
            matp[2, 0] = p.getZ();
            matp[3, 0] = 1;
            return matp;
        }

        public Ponto3D matriz2Ponto3D(double[,] m)
        {
            return new Ponto3D(m[0, 0], m[1, 0], m[2, 0]);
        }

        public void atualizarVetoresNormaisFaces()
        {
            calcularVetoresNormais();
        }

        public void atualizarVetoresNormaisVertices()
        {
            // vetNormaisPontos
            for (int i = 0; i < vetNvertices.Length; ++i)
            {
                List<Ponto3D> normais = new List<Ponto3D>();
                foreach (int j in listaFacesVertices[i])
                    normais.Add(vetNfaces[j]);
                vetNvertices[i] = mediaVetsNormais(normais);
            }
        }

        public void rotacaoX(double r, bool rmfacesOcultas)
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = newMatrizIdentidade(4);
            rot[1, 1] = Math.Cos(r); rot[1, 2] = -Math.Sin(r);
            rot[2, 1] = Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizarVertices();
            if (rmfacesOcultas)
                atualizarVetoresNormaisFaces();
        }

        public void rotacaoY(double r, bool rmfacesOcultas)
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = newMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 2] = Math.Sin(r);
            rot[2, 0] = -Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizarVertices();
            if (rmfacesOcultas)
                atualizarVetoresNormaisFaces();
        }

        internal ET gerarETFacePhong(int f, int height, int tx, int ty, Ponto3D luz, Ponto3D eye, int n, Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz, rl, rm, gl, gm, bl, bm;
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
                    rm = vetNvertices[face[i]].getX();
                    gm = vetNvertices[face[i]].getY();
                    bm = vetNvertices[face[i]].getZ();
                    xmin = verticesAtuais[face[i + 1]].getX();
                    ymin = verticesAtuais[face[i + 1]].getY();
                    zmin = verticesAtuais[face[i + 1]].getZ();
                    rl = vetNvertices[face[i + 1]].getX();
                    gl = vetNvertices[face[i + 1]].getY();
                    bl = vetNvertices[face[i + 1]].getZ();

                }
                else
                {
                    xmin = verticesAtuais[face[i]].getX();
                    ymin = verticesAtuais[face[i]].getY();
                    zmin = verticesAtuais[face[i]].getZ();
                    rl = vetNvertices[face[i]].getX();
                    gl = vetNvertices[face[i]].getY();
                    bl = vetNvertices[face[i]].getZ();
                    xmax = verticesAtuais[face[i + 1]].getX();
                    ymax = verticesAtuais[face[i + 1]].getY();
                    zmax = verticesAtuais[face[i + 1]].getZ();
                    rm = vetNvertices[face[i + 1]].getX();
                    gm = vetNvertices[face[i + 1]].getY();
                    bm = vetNvertices[face[i + 1]].getZ();
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (rm - rl) / dy;
                incgy = (gm - gl) / dy;
                incbz = (bm - bl) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    rl, gl, bl, incrx, incgy, incbz));
            }// fim for
             // ultimo com o primeiro
            if (verticesAtuais[face[0]].getY() >= verticesAtuais[face[face.Count - 1]].getY())
            {
                xmax = verticesAtuais[face[0]].getX();
                ymax = verticesAtuais[face[0]].getY();
                zmax = verticesAtuais[face[0]].getZ();
                rm = vetNvertices[face[0]].getX();
                gm = vetNvertices[face[0]].getY();
                bm = vetNvertices[face[0]].getZ();
                xmin = verticesAtuais[face[face.Count - 1]].getX();
                ymin = verticesAtuais[face[face.Count - 1]].getY();
                zmin = verticesAtuais[face[face.Count - 1]].getZ();
                rl = vetNvertices[face[face.Count - 1]].getX();
                gl = vetNvertices[face[face.Count - 1]].getY();
                bl = vetNvertices[face[face.Count - 1]].getZ();
            }
            else
            {
                xmin = verticesAtuais[face[0]].getX();
                ymin = verticesAtuais[face[0]].getY();
                zmin = verticesAtuais[face[0]].getZ();
                rl = vetNvertices[face[0]].getX();
                gl = vetNvertices[face[0]].getY();
                bl = vetNvertices[face[0]].getZ();
                xmax = verticesAtuais[face[face.Count - 1]].getX();
                ymax = verticesAtuais[face[face.Count - 1]].getY();
                zmax = verticesAtuais[face[face.Count - 1]].getZ();
                rm = vetNvertices[face[face.Count - 1]].getX();
                gm = vetNvertices[face[face.Count - 1]].getY();
                bm = vetNvertices[face[face.Count - 1]].getZ();
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (rm - rl) / dy;
            incgy = (gm - gl) / dy;
            incbz = (bm - bl) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                rl, gl, bl, incrx, incgy, incbz));
            return et;
        }

        public void rotacaoZ(double r, bool rmfacesOcultas) // radianos
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = newMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 1] = -Math.Sin(r);
            rot[1, 0] = Math.Sin(r); rot[1, 1] = Math.Cos(r);
            if(!(tx == 0 && ty == 0 && tz ==0))
            {
                translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizarVertices();
            if (rmfacesOcultas)
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
            double[,] trans = newMatrizIdentidade(4);
            trans[0, 3] = tx;
            trans[1, 3] = ty;
            trans[2, 3] = tz;
            ma = multiplicar(trans, ma);
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
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] esc = newMatrizIdentidade(4);
            esc[0, 0] = sx;
            esc[1, 1] = sy;
            esc[2, 2] = sz;
            translacao(-tx, -ty, -tz);
            ma = multiplicar(esc, ma);
            translacao(tx, ty, tz);
            atualizarVertices();
        }

        public Ponto3D getVetNFace(int id)
        {
            return vetNfaces[id];
        }

        private void inicializarVetoresNormais()
        {
            vetNfaces = new Ponto3D[faces.Count];
            vetNvertices = new Ponto3D[verticesOri.Count];
        }

        private void calcularVetoresNormais()
        {
            Ponto3D vn;
            inicializarVetoresNormais();
            // normais das faces
            for (int i = 0; i < faces.Count; ++i)
            {
                vn = newVetNormal(faces[i]);
                vn = vn.normalizar();
                vetNfaces[i] = vn;
            }
        }

        private Ponto3D mediaVetsNormais(List<Ponto3D> normais)
        {
            double x, y, z, d = normais.Count;
            x = y = z = 0;
            foreach (Ponto3D v in normais)
            {
                x += v.getX();
                y += v.getY();
                z += v.getZ();
            }
            return new Ponto3D(x / d, y / d, z / d);
        }

        private Ponto3D newVetNormal(List<int> face)
        {
            Ponto3D a, b, n;
            a = verticesAtuais[face[0]];
            b = verticesAtuais[face[1]];
            n = verticesAtuais[face[face.Count - 1]];
            Ponto3D ab = b.menos(a);
            Ponto3D an = n.menos(a);
            Ponto3D vn = ab.produtoVetorial(an);
            return vn;
        }


        public Ponto3D[] getVetoresNormaisFaces()
        {
            return vetNfaces;
        }

        public Ponto3D[] getVetoresNormaisVertices()
        {
            return vetNvertices;
        }



        public ET gerarETFaceGouraud(int f, int height, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            Ponto3D cl, cm;
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
                    cm = Desenhar.corPhong(Luz, Eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke);
                    xmin = verticesAtuais[face[i + 1]].getX();
                    ymin = verticesAtuais[face[i + 1]].getY();
                    zmin = verticesAtuais[face[i + 1]].getZ();
                    cl = Desenhar.corPhong(Luz, Eye, vetNvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke);

                }
                else
                {
                    xmin = verticesAtuais[face[i]].getX();
                    ymin = verticesAtuais[face[i]].getY();
                    zmin = verticesAtuais[face[i]].getZ();
                    cl = Desenhar.corPhong(Luz, Eye, vetNvertices[face[i]], n, ia, id, ie, ka, kd, ke);
                    xmax = verticesAtuais[face[i + 1]].getX();
                    ymax = verticesAtuais[face[i + 1]].getY();
                    zmax = verticesAtuais[face[i + 1]].getZ();
                    cm = Desenhar.corPhong(Luz, Eye, vetNvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke);
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (cm.getX() - cl.getX()) / dy;
                incgy = (cm.getY() - cl.getY()) / dy;
                incbz = (cm.getZ() - cl.getZ()) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cl.getX(), cl.getY(), cl.getZ(), incrx, incgy, incbz));
            }// fim for
             // ultimo com o primeiro
            if (verticesAtuais[face[0]].getY() >= verticesAtuais[face[face.Count - 1]].getY())
            {
                xmax = verticesAtuais[face[0]].getX();
                ymax = verticesAtuais[face[0]].getY();
                zmax = verticesAtuais[face[0]].getZ();
                cm = Desenhar.corPhong(Luz, Eye, vetNvertices[face[0]], n, ia, id, ie, ka, kd, ke);
                xmin = verticesAtuais[face[face.Count - 1]].getX();
                ymin = verticesAtuais[face[face.Count - 1]].getY();
                zmin = verticesAtuais[face[face.Count - 1]].getZ();
                cl = Desenhar.corPhong(Luz, Eye, vetNvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke);
            }
            else
            {
                xmin = verticesAtuais[face[0]].getX();
                ymin = verticesAtuais[face[0]].getY();
                zmin = verticesAtuais[face[0]].getZ();
                cl = Desenhar.corPhong(Luz, Eye, vetNvertices[face[0]], n, ia, id, ie, ka, kd, ke);
                xmax = verticesAtuais[face[face.Count - 1]].getX();
                ymax = verticesAtuais[face[face.Count - 1]].getY();
                zmax = verticesAtuais[face[face.Count - 1]].getZ();
                cm = Desenhar.corPhong(Luz, Eye, vetNvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke);
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (cm.getX() - cl.getX()) / dy;
            incgy = (cm.getY() - cl.getY()) / dy;
            incbz = (cm.getZ() - cl.getZ()) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cl.getX(), cl.getY(), cl.getZ(), incrx, incgy, incbz));
            return et;
        }

        public ET gerarETFaceFlat(int f, int height, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            Ponto3D cor;
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz;
            int y;
            List<int> face = faces[f];
            cor = Desenhar.corPhong(Luz, Eye, vetNfaces[f], n, ia, id, ie, ka, kd, ke);
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
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cor.getX(), cor.getY(), cor.getZ(), 0, 0, 0));
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
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cor.getX(), cor.getY(), cor.getZ(), 0, 0, 0));
            return et;
        }
    }
}
