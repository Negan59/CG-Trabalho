using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CG_Imagens.entidades;

namespace _3DViewer
{
    public partial class FormPrincipal : Form
    {
        private static bool ctrlPress;
        private Bitmap bmpPrincipal;
        private Desenhar draw;
        private Random random;
        private Forma obj;
        private int x1, y1, x2, y2, tx, ty;
        private string txd = "0";


        private void pictureBox_mouseWheel(Object sender, MouseEventArgs e)
        {
            double delta;
            if (e.Delta > 0)
            {
                delta = 1.1;
            }
            else 
            {
                delta = 0.9;
            }
            obj.escala(delta, delta, delta);
            atualizarObjeto();
        }

        private double graus2Radianos(double g)
        {
            return g * Math.PI / 180;
        }

        private void movimentaMouse(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            if (e.Button == MouseButtons.Left)
            { 
                if (ctrlPress)
                {
                    double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                    obj.rotacaoZ(graus2Radianos(g), ckFacesOcultas.Checked);
                }
                else
                {
                    obj.rotacaoX(graus2Radianos(-(y2 - y1)), ckFacesOcultas.Checked);
                    obj.rotacaoY(graus2Radianos(x2 - x1), ckFacesOcultas.Checked);
                }
                atualizarObjeto();
            }
            else if (e.Button == MouseButtons.Right)
            { 
                tx += x2 - x1;
                ty += y2 - y1;
                atualizarObjeto();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                obj.rotacaoZ(graus2Radianos(g), ckFacesOcultas.Checked);
                atualizarObjeto();
            }
            x1 = x2;
            y1 = y2;
        }

        private void mudarFace(object sender, EventArgs e)
        {
            atualizarObjeto();
        }

        private void mudaTexto(object sender, EventArgs e)
        {
            tbD.Text = tbD.Text.Trim();
            if (tbD.Text.Length == 0)
                txd = "0";
            double d;
            if (double.TryParse(tbD.Text, out d))
                txd = tbD.Text;
            tbD.Text = txd;
        }

        private void selecionaProjecao(object sender, EventArgs e)
        {
            string proj = cbProjecao.Text;
            tbD.Enabled = proj == "Perspectiva";
            atualizarObjeto();
        }

        private void pressionaBotao(object sender, KeyEventArgs e)
        {
            ctrlPress = e.KeyCode == Keys.ControlKey;
        }

        private void soltaBotao(object sender, KeyEventArgs e)
        {
            ctrlPress = false;
        }

        private void mouseDesce(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }

        private void carregarDados()
        {
            pbPrincipal.Enabled = false;
            cbProjecao.SelectedIndex = 0;
            draw = new Desenhar();
            new Thread(() =>
            {
                Thread.Sleep(200);
                bmpPrincipal = new Bitmap(pbPrincipal.Width, pbPrincipal.Height);
                draw.paint(bmpPrincipal, Color.Black);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    pbPrincipal.Image = bmpPrincipal;
                    tx = bmpPrincipal.Width >> 1;
                    ty = bmpPrincipal.Height >> 1;
                }));
            }).Start();
        }


            




        private void abrirArquivo(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "objetos3D (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tx = pbPrincipal.Width >> 1;
                ty = pbPrincipal.Height >> 1;
                obj = new Forma(openFileDialog.FileName);
                double s = (pbPrincipal.Width >> 2) / Math.Abs(obj.getMatrizTransformacaoxX() - obj.getMinX());
                obj.escala(s, s, s);
                atualizarObjeto();
                pbPrincipal.Enabled = true;
            }
        }

        public FormPrincipal()
        {
            InitializeComponent();
            carregarDados();
            this.KeyPreview = true;
            random = new Random();
            pbPrincipal.MouseWheel += new MouseEventHandler(pictureBox_mouseWheel);

        }
    


        private void atualizarObjeto()
        {

            if (obj != null)
            {
                double d;
                double.TryParse(tbD.Text, out d);
                draw.paint(bmpPrincipal, Color.Black);
                if (cbProjecao.Text == "Perspectiva")
                {
                    draw.projecaoPerspectivaXY(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked, (d = double.Parse(tbD.Text)));
                    pbPrincipal.Refresh();

                }
                else if (cbProjecao.Text[0] == 'C')
                {
                    double L;
                    L = cbProjecao.Text[2] == 'v' ? 1 : 0.5;
                    draw.projecaoObliqua(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked, L);
                    pbPrincipal.Refresh();
                }
                else
                { // Paralela
                    draw.projecaoParalelaXY(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked);
                    pbPrincipal.Refresh();

                }



            }
            else if (bmpPrincipal != null)
            {
                draw.paint(bmpPrincipal, Color.White);
                pbPrincipal.Refresh();
            }
        }


    }
}
