using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2bimestre.entidades
{
    class NoAET
    {
        private int ymax;
        private double incx, xmin;
        private double zmin, inczy;
        private double rxmin, gymin, bzmin;
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
