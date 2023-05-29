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
        private Objeto3D obj;
        private int x1, y1, x2, y2, tx, ty;
        private string txd = "0";

        private void btFacesOcultas_Click(object sender, EventArgs e)
        {
            ckFacesOcultas.Checked = !ckFacesOcultas.Checked;
            refreshObjeto();
        }

        private void cbProjecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proj = cbProjecao.Text;
            tbD.Enabled = proj == "Perspectiva";
            refreshObjeto();
        }

        private void tbD_TextChanged(object sender, EventArgs e)
        {
            tbD.Text = tbD.Text.Trim();
            if (tbD.Text.Length == 0)
                txd = "0";
            double d;
            if (double.TryParse(tbD.Text, out d))
                txd = tbD.Text;
            tbD.Text = txd;
        }

        private void btCor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            //btCor.BackColor = colorDialog.Color;
            refreshObjeto();
        }

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlPress = e.KeyCode == Keys.ControlKey;
        }

        private void FormPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPress = false;
        }




        private void pictureBox_mouseWheel(Object sender, MouseEventArgs e)
        {
            double delta;
            if (e.Delta > 0) // scroll para frente
            {
                delta = 1.1;
            }
            else // scroll para tras
            {
                delta = 0.9;
            }
            obj.escala(delta, delta, delta);
            refreshObjeto();
        }

        private double graus2Radianos(double g)
        {
            return g * Math.PI / 180;
        }

        private void ckFacesOcultas_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }


        private void mouseUp(object sender, MouseEventArgs e)
        {// pictureBox

        }

        private void mouseMove(object sender, MouseEventArgs e)
        {// pictureBox
            //transformando = !transformando;
            //if (transformando)
            {
                x2 = e.X;
                y2 = e.Y;
                if (e.Button == MouseButtons.Left)
                { // rotacionar
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
                    refreshObjeto();
                }
                else if (e.Button == MouseButtons.Right)
                { // transladar
                    tx += x2 - x1;// obj.translacao((x2 - x1), (y2 - y1), 0);
                    ty += y2 - y1;
                    refreshObjeto();
                }
                else if (e.Button == MouseButtons.Middle) // click com scroll
                {
                    double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                    obj.rotacaoZ(graus2Radianos(g), ckFacesOcultas.Checked);
                    refreshObjeto();
                }
                x1 = x2;
                y1 = y2;
            }
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {// pictureBox
            //transformando = true;
            x1 = e.X;
            y1 = e.Y;
        }
        public FormPrincipal()
        {
            InitializeComponent();
            this.KeyPreview = true;
            random = new Random();
            pbPrincipal.MouseWheel += new MouseEventHandler(pictureBox_mouseWheel);

        }
        private void FormPrincipal_Load(object sender, EventArgs e)
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

        private void clkOpen(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "objetos3D (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tx = pbPrincipal.Width >> 1;
                ty = pbPrincipal.Height >> 1;
                obj = new Objeto3D(openFileDialog.FileName);
                double s = (pbPrincipal.Width >> 2) / Math.Abs(obj.getMaxX() - obj.getMinX());
                obj.escala(s, s, s);
                refreshObjeto();
                pbPrincipal.Enabled = true;
            }
        }

        private void refreshObjeto()
        {

            if (obj != null)
            {
                // setando vetores
                double d;
                string proj = cbProjecao.SelectedItem.ToString().ToLower();
                double.TryParse(tbD.Text, out d);
                draw.paint(bmpPrincipal, Color.Black);
                if (cbProjecao.Text == "Perspectiva")
                {
                    draw.writeObjeto3DPerspectivaXY(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked, (d = double.Parse(tbD.Text)));
                    pbPrincipal.Refresh();

                }
                else if (cbProjecao.Text[0] == 'C')
                {
                    // Cavaleira: L = 1;
                    // Cabinet: L = 0.5;
                    double L;// projeções oblíquas
                             // x = x+z * L * cos 45
                             // y = y+z * L * sin 45
                    L = cbProjecao.Text[2] == 'v' ? 1 : 0.5;
                    draw.writeObjeto3DObliqua(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked, L);
                    pbPrincipal.Refresh();
                }
                else
                { // Paralela
                    draw.writeObjeto3DParalelaXY(bmpPrincipal, obj, tx, ty, Color.White, ckFacesOcultas.Checked);
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
