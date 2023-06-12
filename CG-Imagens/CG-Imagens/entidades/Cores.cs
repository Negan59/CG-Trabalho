using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class Cores
    {
        Desenhar desenha = new Desenhar();
        public Cores() { }
        //No phong, vamos seguir o slide, nele tem alguns valores sendo colocados
        public static Ponto corPhong(Ponto Luz, Ponto Eye, Ponto N, int n, Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke)
        {
            Ponto H = Luz.soma(Eye).normalizar();
            double hnn = Math.Pow(H.produtoEscalar(N), n);
            double ln = Luz.produtoEscalar(N);

            double r = ia.getX() * ka.getX() + id.getX() * kd.getX() * ln + ie.getX() * ke.getX() * hnn;
            double g = ia.getY() * ka.getY() + id.getY() * kd.getY() * ln + ie.getY() * ke.getY() * hnn;
            double b = ia.getZ() * ka.getZ() + id.getZ() * kd.getZ() * ln + ie.getZ() * ke.getZ() * hnn;

            r = r < 0 ? 0 : (r > 1 ? 1 : r);
            g = g < 0 ? 0 : (g > 1 ? 1 : g);
            b = b < 0 ? 0 : (b > 1 ? 1 : b);

            return new Ponto(r * 255, g * 255, b * 255);
        }
        //z-buffer para tratar as faces ocultas
        private double[,] gerarZBuffer(int width, int height)
        {
            double[,] zbuffer = new double[width, height];
            for (int x = 0; x < width; ++x)
                for (int y = 0; y < height; ++y)
                    zbuffer[x, y] = int.MinValue;
            return zbuffer;
        }
        public void scanLineFlat(Bitmap bmp, Forma obj, int tx, int ty, Ponto Luz, Ponto Eye, int n,
            Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke)
        {
            int height = bmp.Height, width = bmp.Width;

            double[,] zbuffer = gerarZBuffer(width, height);
            ET et;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizarVetoresNormaisFaces();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFaceFlat(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFaceFlat(data, et, zbuffer);
                    }
                }
            }
            bmp.UnlockBits(data);

        }

        private void scanLineFaceFlat(BitmapData data, ET et, double[,] zbuffer)
        {
            List<No> lista;
            double z, inczx;
            int y = 0, cont = 0;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            AET aet = new AET(), aetAux;
            do // laço AET
            {
                if (et.getAET(y) != null)
                {
                    ++cont;
                    aet.add(et.getAET(y).getList()); // adicionando novos nodos
                }
                aetAux = new AET();
                foreach (No no in aet.getList()) // removendo nodos com Ymax == Y
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
                // desenhando linhas
                lista = aet.getList();
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    z = lista[i].getZmin();
                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / ((x2) - (x));
                    for (int c = x, c2 = (int)lista[i + 1].getXmin(); c <= c2; ++c)
                    {
                        if (desenha.inImage(data, x, y) && z > zbuffer[x, y])
                        {
                            zbuffer[x, y] = z;
                            desenha.writePixel(data, x, y, Color.FromArgb((int)lista[i].getRXmin(),
                                (int)lista[i].getGYmin(), (int)lista[i].getBZmin()));
                        }
                        z += inczx;
                        ++x;
                    }
                }
                for (int i = 0; i < aet.getList().Count; ++i)
                {
                    aet.getList()[i].setXmin(aet.getList()[i].getXmin() +
                        aet.getList()[i].getIncX());
                    aet.getList()[i].setZmin(aet.getList()[i].getZmin() + aet.getList()[i].getIncZY());
                }
                ++y;
            } while (aet.getList().Count > 0); // tem pontos na AET
        }

        public void scanLineGouraud(Bitmap bmp, Forma obj, int tx, int ty, Ponto Luz, Ponto Eye, int n,
        Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke)
        {
            int height = bmp.Height, width = bmp.Width;

            double[,] zbuffer = gerarZBuffer(width, height);
            ET et;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizarVetoresNormaisFaces();
                obj.atualizarVetoresNormaisVertices();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFaceGouraud(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFaceGouraud(data, et, zbuffer);
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        private void scanLineFaceGouraud(BitmapData data, ET et, double[,] zbuffer)
        {
            List<No> lista;
            double z, inczx;
            int y = 0;
            AET aet = new AET(), aetAux;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.getAET(y) != null)
                    aet.add(et.getAET(y).getList()); // adicionando novos nodos

                aetAux = new AET();
                foreach (No no in aet.getList()) // removendo nodos com Ymax == Y
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
                // desenhando linhas
                lista = aet.getList();
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    z = lista[i].getZmin();
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].getRXmin();
                    g = lista[i].getGYmin();
                    b = lista[i].getBZmin();
                    incrx = (lista[i + 1].getRXmin() - lista[i].getRXmin()) / dx;
                    incgx = (lista[i + 1].getGYmin() - lista[i].getGYmin()) / dx;
                    incbx = (lista[i + 1].getBZmin() - lista[i].getBZmin()) / dx;

                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / dx;
                    while (x <= x2)
                    {
                        if (desenha.inImage(data, x, y) && z > zbuffer[x, y])
                        {
                            zbuffer[x, y] = z;
                            desenha.writePixel(data, x, y, Color.FromArgb((int)r, (int)g, (int)b));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (No no in aet.getList())
                {
                    no.setXmin(no.getXmin() + no.getIncX());
                    no.setZmin(no.getZmin() + no.getIncZY());
                    no.setRXmin(no.getRXmin() + no.getIncRX());
                    no.setGYmin(no.getGYmin() + no.getIncGY());
                    no.setBZmin(no.getBZmin() + no.getIncBZ());
                }
                ++y;
            } while (aet.getList().Count > 0); // tem pontos na AET
        }

        public void scanLinePhong(Bitmap bmp, Forma obj, int tx, int ty, Ponto Luz, Ponto Eye, int n,
        Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke)
        {
            int height = bmp.Height, width = bmp.Width;
            double[,] zbuffer = gerarZBuffer(width, height);
            ET et;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizarVetoresNormaisFaces();
                obj.atualizarVetoresNormaisVertices();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFacePhong(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFacePhong(data, et, zbuffer, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                    }
                }
            }
            bmp.UnlockBits(data);
        }

        private void scanLineFacePhong(BitmapData data, ET et, double[,] zbuffer, Ponto Luz, Ponto Eye, int n,
            Ponto ia, Ponto id, Ponto ie, Ponto ka, Ponto kd, Ponto ke)
        {
            List<No> lista;
            double z, inczx;
            int y = 0;
            Ponto cor;
            AET aet = new AET(), aetAux;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.getAET(y) != null)
                    aet.add(et.getAET(y).getList()); // adicionando novos nodos

                aetAux = new AET();
                foreach (No no in aet.getList()) // removendo nodos com Ymax == Y
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
                // desenhando linhas
                lista = aet.getList();
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    z = lista[i].getZmin();
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].getRXmin();
                    g = lista[i].getGYmin();
                    b = lista[i].getBZmin();
                    incrx = (lista[i + 1].getRXmin() - lista[i].getRXmin()) / dx;
                    incgx = (lista[i + 1].getGYmin() - lista[i].getGYmin()) / dx;
                    incbx = (lista[i + 1].getBZmin() - lista[i].getBZmin()) / dx;

                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / dx;
                    while (x <= x2)
                    {
                        if (desenha.inImage(data, x, y) && z > zbuffer[x, y])
                        {
                            cor = corPhong(Luz, Eye, new Ponto(r, g, b), n, ia, id, ie, ka, kd, ke);
                            zbuffer[x, y] = z;
                            desenha.writePixel(data, x, y, Color.FromArgb((int)cor.getX(), (int)cor.getY(), (int)cor.getZ()));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (No no in aet.getList())
                {
                    no.setXmin(no.getXmin() + no.getIncX());
                    no.setZmin(no.getZmin() + no.getIncZY());
                    no.setRXmin(no.getRXmin() + no.getIncRX());
                    no.setGYmin(no.getGYmin() + no.getIncGY());
                    no.setBZmin(no.getBZmin() + no.getIncBZ());
                }
                ++y;
            } while (aet.getList().Count > 0); // tem pontos na AET
        }



    }
}
