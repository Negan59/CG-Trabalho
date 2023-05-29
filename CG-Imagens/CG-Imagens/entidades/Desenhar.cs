using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class Desenhar
    {
        private const double pi = Math.PI;
        private int CX, CY;


        private double abs(double a)
        {
            return Math.Abs(a);
        }

        private int abs(int a)
        {
            return Math.Abs(a);
        }

        private unsafe byte* gotoxy(BitmapData bmp, int x, int y)
        {
            byte* aux = (byte*)bmp.Scan0.ToPointer();
            aux += y * bmp.Stride;
            aux += 3 * x;
            return aux;
        }

        private unsafe byte* gotoxy(int x, int y, BitmapData bmp)
        {
            return gotoxy(bmp, x, y);
        }
        private unsafe void writePixel(BitmapData bmp, int x, int y, Color cor)
        {
            byte* aux = gotoxy(x, y, bmp);
            *aux = cor.B;
            *(aux + 1) = cor.G;
            *(aux + 2) = cor.R;
        }
        private unsafe void pontoMedio(BitmapData data, int x1, int y1, int x2, int y2, Color cor)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int declive = 1;
            int incE, incNE, d;

            bool shouldSwap = false;

            if (Math.Abs(dx) < Math.Abs(dy))
            {
                (x1, y1, x2, y2) = (y1, x1, y2, x2); // Swap x1 with y1 and x2 with y2
                dx = x2 - x1;
                dy = y2 - y1;
                shouldSwap = true;
            }

            if (dx < 0)
            {
                (x1, x2, y1, y2) = (x2, x1, y2, y1); // Swap x1 with x2 and y1 with y2
                dx = -dx;
                dy = -dy;
            }

            if (y1 > y2)
            {
                declive = -1;
                dy = -dy;
            }

            incE = 2 * dy;
            incNE = 2 * (dy - dx);
            d = incNE;

            int x = x1;
            int y = y1;

            for (int i = 0; i <= dx; i++)
            {
                if (shouldSwap)
                {
                    if (inImage(data, y, x))
                        writePixel(data, y, x, cor);
                }
                else
                {
                    if (inImage(data, x, y))
                        writePixel(data, x, y, cor);
                }

                if (d < 0)
                {
                    d += incE;
                }
                else
                {
                    d += incNE;
                    y += declive;
                }

                x++;
            }
        }


        private bool inImage(BitmapData bmp, int x, int y)
        {
            return x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height;
        }

        public void paint(Bitmap bmp, Color cor)
        {

            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int height = bmp.Height;
                int width = bmp.Width;
                int padding = bmpdata.Stride - width * 3;
                byte* aux = (byte*)bmpdata.Scan0.ToPointer();
                for (int y = 0, x; y < height; ++y)
                {
                    for (x = 0; x < width; ++x)
                    {
                        *(aux++) = cor.B;
                        *(aux++) = cor.G;
                        *(aux++) = cor.R;
                    }
                    aux += padding;
                }
            }
            bmp.UnlockBits(bmpdata);
        }


        public void projecaoObliqua(Bitmap bmp, Forma obj, int tx, int ty, Color cor, bool ocultas, double L)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                this.CX = tx;
                this.CY = ty;
                List<int> f;
                List<List<int>> faces = obj.getFaces();
                List<Ponto> vertices = obj.getVertices();
                if (ocultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNFace(idf).getY() <= 0.0)
                            projetaFaceObliquaXY(data, faces[idf], vertices, L, cor);
                }
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        projetaFaceObliquaXY(data, faces[idf], vertices, L, cor);
            }
            bmp.UnlockBits(data);
        }

        public void projecaoParalelaXY(Bitmap bmp, Forma obj, int tx, int ty, Color corlinha, bool ocultas)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                CX = tx;
                CY = ty;
                List<int> f;
                List<List<int>> faces = obj.getFaces();
                List<Ponto> vertices = obj.getVertices();
                if (ocultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNFace(idf).getZ() >= 0.0)
                            projetaFaceParalelaXY(data, faces[idf], vertices, corlinha);

                }
                else
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        projetaFaceParalelaXY(data, faces[idf], vertices, corlinha);
                }
            }
            bmp.UnlockBits(data);
        }

        private unsafe void projetaFaceParalelaXY(BitmapData data, List<int> f, List<Ponto> vertices, Color cor)
        {

            Ponto p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                pontoMedio(data, (int)p1.getX() + CX, (int)p1.getY() + CY,
                    (int)p2.getX() + CX, (int)p2.getY() + CY, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            pontoMedio(data, (int)p1.getX() + CX, (int)p1.getY() + CY,
                (int)p2.getX() + CX, (int)p2.getY() + CY, cor);
        }

        private unsafe void projetaFaceParalelaZY(BitmapData data, List<int> f, List<Ponto> vertices, Color cor)
        {

            Ponto p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                pontoMedio(data, (int)p1.getZ() + CX, (int)p1.getY() + CY,
                    (int)p2.getZ() + CX, (int)p2.getY() + CY, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            pontoMedio(data, (int)p1.getZ() + CX, (int)p1.getY() + CY,
                (int)p2.getZ() + CX, (int)p2.getY() + CY, cor);
        }

        
        private unsafe void projetaFaceObliquaXY(BitmapData data, List<int> f, List<Ponto> vertices, double L, Color cor)
        {
            Ponto p1, p2;
            int x1, y1, x2, y2;

            for (int i = 0; i < f.Count; i++)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[(i + 1) % f.Count]];
                x1 = (int)(p1.getX() + p1.getZ() * L * Math.Cos(45 * Math.PI / 180));
                y1 = (int)(p1.getY() + p1.getZ() * L * Math.Sin(45 * Math.PI / 180));
                x2 = (int)(p2.getX() + p2.getZ() * L * Math.Cos(45 * Math.PI / 180));
                y2 = (int)(p2.getY() + p2.getZ() * L * Math.Sin(45 * Math.PI / 180));
                pontoMedio(data, x1 + CX, y1 + CY, x2 + CX, y2 + CY, cor);
            }

            p1 = vertices[f[f.Count - 1]];
            p2 = vertices[f[0]];
            x1 = (int)(p1.getX() + p1.getZ() * L * Math.Cos(45 * Math.PI / 180));
            y1 = (int)(p1.getY() + p1.getZ() * L * Math.Sin(45 * Math.PI / 180));
            x2 = (int)(p2.getX() + p2.getZ() * L * Math.Cos(45 * Math.PI / 180));
            y2 = (int)(p2.getY() + p2.getZ() * L * Math.Sin(45 * Math.PI / 180));
            pontoMedio(data, x1 + CX, y1 + CY, x2 + CX, y2 + CY, cor);

        }

        public void projecaoPerspectivaXY(Bitmap bmp, Forma obj, int tx, int ty, Color corlinha, bool ocultas, double d)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.CX = tx;
                this.CY = ty;
                List<List<int>> faces = obj.getFaces();
                List<Ponto> vertices = obj.getVertices();
                if (ocultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNFace(idf).getZ() > 0.0)
                            projetaFacePerspectivaXY(data, faces[idf], vertices, d, corlinha);
                }
                else
                    for (idf = 0; idf < faces.Count; ++idf)
                        projetaFacePerspectivaXY(data, faces[idf], vertices, d, corlinha);
            }
            bmp.UnlockBits(data);
        }


        private unsafe void projetaFacePerspectivaXY(BitmapData data, List<int> f, List<Ponto> vertices, double d, Color cor)
        {
            Ponto p1, p2;
            int i;
            double x1, y1, z1, x2, y2, z2;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                x1 = p1.getX(); y1 = p1.getY(); z1 = p1.getZ();
                x2 = p2.getX(); y2 = p2.getY(); z2 = p2.getZ();
                x1 = x1 * d / (z1 += d);
                y1 = y1 * d / z1;
                x2 = x2 * d / (z2 += d);
                y2 = y2 * d / z2;
                pontoMedio(data, (int)x1 + CX, (int)y1 + CY,
                    (int)x2 + CX, (int)y2 + CY, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            x1 = p1.getX(); y1 = p1.getY(); z1 = p1.getZ();
            x2 = p2.getX(); y2 = p2.getY(); z2 = p2.getZ();
            x1 = x1 * d / (z1 += d);
            y1 = y1 * d / z1;
            x2 = x2 * d / (z2 += d);
            y2 = y2 * d / z2;
            pontoMedio(data, (int)x1 + CX, (int)y1 + CY,
                (int)x2 + CX, (int)y2 + CY, cor);
        }

        

    }
}
