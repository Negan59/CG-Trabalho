using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DViewer
{
    class NoAET
    {
        private int ymax;
        private double incx, xmin;
        //-------------------------------------------------//
        private double zmin, inczy;
        //-------------------------------------------------//
        private double rxmin, gymin, bzmin;
        //-------------------------------------------------//
        private double incrx, incgy, incbz;

        public NoAET(int ymax, double xmin, double incx, double zmin, double inczy, double rxmin, double gymin, double bzmin, double incrx, double incgy, double incbz)
        {
            this.ymax = ymax;
            this.incx = incx;
            this.xmin = xmin;
            this.zmin = zmin;
            this.inczy = inczy;
            this.rxmin = rxmin;
            this.gymin = gymin;
            this.bzmin = bzmin;
            this.incrx = incrx;
            this.incgy = incgy;
            this.incbz = incbz;
        }

        /*
Arestas são ordenadas 
Chave primária: y mínimo
Chave secundária: x mín

Dada uma aresta, (x1,y1) e (x2,y2)
definimos os pontos mínimos e máximos,
sendo o ponto mínimo aquele com o menor valor de Y.
x1 = 2, y1 = 9
x2 = 3, y2 = 7

O Incremento de X é dado por:

𝐼𝑛𝑐𝑟𝑋=1/𝑚     sendo     𝑚=𝑑𝑦/𝑑𝑥=  (𝑌𝑚𝑎𝑥−𝑌𝑚𝑖𝑛)/(𝑋𝑚𝑎𝑥−𝑋𝑚𝑖𝑛)

Para simplificar, podemos então calcular direto

𝐼𝑛𝑐𝑟𝑋=𝑑𝑥/𝑑𝑦

*/

        public double getXmin()
        {
            return xmin;
        }

        public int getYmax()
        {
            return ymax;
        }

        public double getIncX()
        {
            return incx;
        }
        public void setXmin(double x)
        {
            xmin = x;
        }
        public void setYmax(int y)
        {
            ymax = y;
        }
        public void setIncX(double inc)
        {
            incx = inc;
        }

        /*
        //-------------------------------------------------//
        private double zmin, inczy;
        */

        public double getZmin()
        {
            return zmin;
        }

        public void setZmin(double zmin)
        {
            this.zmin = zmin;
        }

        public double getIncZY()
        {
            return inczy;
        }

        public void setIncZY(double inczy)
        {
            this.inczy = inczy;
        }

        /*
        //-------------------------------------------------//
        private double rxmin, gymin, bzmin;
        */

        public double getRXmin()
        {
            return rxmin;
        }

        public void setRXmin(double rxmin)
        {
            this.rxmin = rxmin;
        }

        public double getGYmin()
        {
            return gymin;
        }

        public void setGYmin(double gymin)
        {
            this.gymin = gymin;
        }

        public double getBZmin()
        {
            return bzmin;
        }

        public void setBZmin(double bzmin)
        {
            this.bzmin = bzmin;
        }

        /*
        //-------------------------------------------------//
        private double incrx, incgy, incbz;
        */

        public double getIncRX()
        {
            return incrx;
        }
        public void setIncRX(double inc)
        {
            incrx = inc;
        }
        public double getIncGY()
        {
            return incgy;
        }
        public void setIncGY(double inc)
        {
            incgy = inc;
        }
        public double getIncBZ()
        {
            return incbz;
        }
        public void setIncBZ(double inc)
        {
            incbz = inc;
        }

    }
}
