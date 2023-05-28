using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2bimestre.entidades
{
    class Ponto
    {
        private double x, y, z;

        public Ponto(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double getX()
        {
            return x;
        }
        public double getY()
        {
            return y;
        }
        public double getZ()
        {
            return z;
        }
        public void setX(double x)
        {
            this.x = x;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        public void setZ(double z)
        {
            this.z = z;
        }

        public Ponto mais(Ponto ponto)
        {
            return new Ponto(x + ponto.getX(), y + ponto.getY(), z + ponto.getZ());
        }
        public Ponto menos(Ponto ponto)
        {
            return new Ponto(x - ponto.getX(), y - ponto.getY(), z - ponto.getZ());
        }

        public double getNorma()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Ponto normalizar()
        {
            double norma = getNorma();
            if (norma != 0)
                return new Ponto(x / norma, y / norma, z / norma);
            return new Ponto(1, 1, 1);
        }

        public double produtoEscalar(Ponto ponto)
        {
            return x * ponto.getX() + y * ponto.getY() + z * ponto.getZ();
        }

        public Ponto produtoVetorial(Ponto ponto)
        {
            return new Ponto(y * ponto.getZ() - (z * ponto.getY()), z * ponto.getX() - (x * ponto.getZ()), x * ponto.getY() - (y * ponto.getX()));
        }

        public Ponto divide(double d)
        {
            return new Ponto(x / d, y / d, z / d);
        }


    }
}
