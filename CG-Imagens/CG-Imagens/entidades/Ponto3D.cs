using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Imagens.entidades
{
    class Ponto3D
    {
        private double x, y, z;

        public Ponto3D()
        {
            x = y = z = 0;
        }
        public Ponto3D(double x, double y, double z)
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

        public Ponto3D mais(Ponto3D p)
        {
            return new Ponto3D(x + p.getX(), y + p.getY(), z + p.getZ());
        }
        public Ponto3D menos(Ponto3D p)
        {
            return new Ponto3D(x - p.getX(), y - p.getY(), z - p.getZ());
        }

        public double getNorma()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Ponto3D normalizar()
        {
            double norma = getNorma();
            if (norma != 0)
                return new Ponto3D(x / norma, y / norma, z / norma);
            return new Ponto3D(1, 1, 1);
        }

        public double produtoEscalar(Ponto3D p)
        {
            return x * p.getX() + y * p.getY() + z * p.getZ();
        }

        public Ponto3D produtoVetorial(Ponto3D v)
        {
            /*
             i  j   k  | i   j  
             ux uy  uz | ux  uy
             vx vy  vz | vx  vy
             */
            Ponto3D r = new Ponto3D();
            r.setX(y * v.getZ() - (z * v.getY()));
            r.setY(z * v.getX() - (x * v.getZ()));
            r.setZ(x * v.getY() - (y * v.getX()));
            return r;
        }

        public Ponto3D divide(double d)
        {
            return new Ponto3D(x / d, y / d, z / d);
        }
    }
}
