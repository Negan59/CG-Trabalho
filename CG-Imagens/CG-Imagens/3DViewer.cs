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
        private Bitmap bmpPrincipal, bmpPlanta, bmpFrontal, bmpLateral;
        private Desenhar draw;
        private Random random;
        private Objeto3D obj;
        private int x1, y1, x2, y2, tx, ty;
        private bool mvluz = false;
        private string txd = "0";
        private Ponto3D ia, id, ie, ka, kd, ke, Eye, Luz;

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

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedTab == tabPageVistas)
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
        // intensidade
        private void scIAmbR_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setX(scIAmbR.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }
        private void atualizaCorLabel(Label lb, Ponto3D vc)
        {
            int c; Color cor;
            lb.BackColor = cor = Color.FromArgb((int)(vc.getX() * 255), (int)(vc.getY() * 255), (int)(vc.getZ() * 255));
            lb.ForeColor = Color.FromArgb(c = getContraste(cor.R, cor.G, cor.B), c, c);
            refreshObjeto();
        }

        private void scIAmbG_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setY(scIAmbG.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }

        private void scIAmbB_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setZ(scIAmbB.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }

        private void scIMatR_Scroll(object sender, ScrollEventArgs e)
        {
            id.setX(scIMatR.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void scIMatG_Scroll(object sender, ScrollEventArgs e)
        {
            id.setY(scIMatG.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void scIMatB_Scroll(object sender, ScrollEventArgs e)
        {
            id.setZ(scIMatB.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void scIBrilhoR_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setX(scIBrilhoR.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }

        private void scIBrilhoG_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setY(scIBrilhoG.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }

        private void scIBrilhoB_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setZ(scIBrilhoB.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }
        // cor
        private void scCAmbR_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setX(scCAmbR.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void scCAmbG_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setY(scCAmbG.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void scCAmbB_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setZ(scCAmbB.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void scCMatR_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setX(scCMatR.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void scCMatG_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setY(scCMatG.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void scCMatB_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setZ(scCMatB.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void scCBrilhoR_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setX(scCBrilhoR.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void scCBrilhoG_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setY(scCBrilhoG.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void rbFlat_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void rbGouraud_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void txN_ValueChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void rbWireframe_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void lbIAmb_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                ia = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scIAmbR.Value = (int)(ia.getX() * 91);
                scIAmbG.Value = (int)(ia.getY() * 91);
                scIAmbB.Value = (int)(ia.getZ() * 91);
                atualizaCorLabel(lbIAmb, ia);
            }
        }

        private void lbIMat_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                id = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scIMatR.Value = (int)(id.getX() * 91);
                scIMatG.Value = (int)(id.getY() * 91);
                scIMatB.Value = (int)(id.getZ() * 91);
                atualizaCorLabel(lbIMat, id);
            }
        }

        private void lbIBrilho_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                ie = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scIBrilhoR.Value = (int)(ie.getX() * 91);
                scIBrilhoG.Value = (int)(ie.getY() * 91);
                scIBrilhoB.Value = (int)(ie.getZ() * 91);
                atualizaCorLabel(lbIBrilho, ie);
            }
        }

        private void lbCAmb_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                ka = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scCAmbR.Value = (int)(ka.getX() * 91);
                scCAmbG.Value = (int)(ka.getY() * 91);
                scCAmbB.Value = (int)(ka.getZ() * 91);
                atualizaCorLabel(lbCAmb, ka);
            }
        }

        private void lbCMat_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                kd = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scCMatR.Value = (int)(kd.getX() * 91);
                scCMatG.Value = (int)(kd.getY() * 91);
                scCMatB.Value = (int)(kd.getZ() * 91);
                atualizaCorLabel(lbCMat, kd);
            }
        }

        private void lbCBrilho_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog.Color;
                ke = new Ponto3D(c.R / 255.0, c.G / 255.0, c.B / 255.0);
                scCBrilhoR.Value = (int)(ke.getX() * 91);
                scCBrilhoG.Value = (int)(ke.getY() * 91);
                scCBrilhoB.Value = (int)(ke.getZ() * 91);
                atualizaCorLabel(lbCBrilho, ke);
            }
        }

        private void btLuz_MouseDown(object sender, MouseEventArgs e)
        {
            mvluz = obj != null && e.Button == MouseButtons.Left;
            if (mvluz)
                atualizarBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
        }

        private void btLuz_MouseUp(object sender, MouseEventArgs e)
        {
            if (mvluz)
                atualizarBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
            mvluz = false;
        }

        private void btLuz_MouseMove(object sender, MouseEventArgs e)
        {
            if (mvluz)
            {
                atualizarBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
                refreshObjeto();
            }
        }

        private void atualizarBotaoLuz(int x, int y)
        {
            if (x < pbPrincipal.Location.X)
                x = pbPrincipal.Location.X;
            else if (x > (pbPrincipal.Location.X + pbPrincipal.Width) - btLuz.Width)
                x = (pbPrincipal.Location.X + pbPrincipal.Width) - btLuz.Width;
                //x = MousePosition.X - (btLuz.Width >> 1);
            if (y < pbPrincipal.Location.Y)
                y = pbPrincipal.Location.Y;
            else if (y > (pbPrincipal.Location.Y + pbPrincipal.Height) - btLuz.Height)
                y = (pbPrincipal.Location.Y + pbPrincipal.Height) - btLuz.Height;
           
                //y = MousePosition.Y - (btLuz.Height >> 1);
            btLuz.Location = new Point(x, y);
            x = x + (btLuz.Width >> 1) - pbPrincipal.Location.X;
            y = y + (btLuz.Height >> 1) - pbPrincipal.Location.Y;
            
            w("Posicao: Luz: " + x + ", " + y + "; Obj: " + (obj.getCentro().getX() + tx) + ", " + (obj.getCentro().getY()+ty));
            Luz = new Ponto3D(x - (obj.getCentro().getX() + tx), y - (obj.getCentro().getY() + ty), 1);
            w("Luz : " + Luz.getX() + ", " + Luz.getY() + ", " + Luz.getZ());
            Luz = Luz.normalizar();
            Luz.setZ(1);
            w("Luz : " + Luz.getX() + ", " + Luz.getY() + ", " + Luz.getZ());
            btLuz.Refresh();
            //pbPrincipal.Refresh();
        }

        private void scCBrilhoB_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setZ(scCBrilhoB.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void novaCorBotao(Button b)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color cor;
                int c;
                b.BackColor = cor = colorDialog.Color;
                b.ForeColor = Color.FromArgb(c = getContraste(cor.R, cor.G, cor.B), c, c);
            }
        }

        private int getContraste(int r, int g, int b)
        {
            return (0.3 * r + 0.59 * g + 0.11 * b) > 120 ? 0 : 255;
        }


        private void rbPhong_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }



        private void ckFlat_CheckedChanged(object sender, EventArgs e)
        {

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
                bmpPlanta = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                bmpFrontal = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                bmpLateral = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                draw.paint(bmpPlanta, lbCAmb.BackColor);
                draw.paint(bmpFrontal, lbCAmb.BackColor);
                draw.paint(bmpLateral, lbCAmb.BackColor);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    pbPrincipal.Image = bmpPrincipal;
                    pbPlanta.Image = bmpPlanta;
                    pbFrontal.Image = bmpFrontal;
                    pbLateral.Image = bmpLateral;
                    // intensidade
                    ia = new Ponto3D(0, 0, 0);
                    id = new Ponto3D(0, 0, 0.9);
                    scIMatB.Value = (int)(0.9 * 91);
                    atualizaCorLabel(lbIMat, id);
                    ie = new Ponto3D(0.7, 0.7, 0.7);
                    scIBrilhoR.Value = (int)(0.7 * 91);
                    scIBrilhoG.Value = (int)(0.7 * 91);
                    scIBrilhoB.Value = (int)(0.7 * 91);
                    atualizaCorLabel(lbIBrilho, ie);
                    // cor
                    ka = new Ponto3D(0.2, 0.2, 0.2);
                    scCAmbR.Value = (int)(0.2 * 91);
                    scCAmbG.Value = (int)(0.2 * 91);
                    scCAmbB.Value = (int)(0.2 * 91);
                    atualizaCorLabel(lbCAmb, ka);
                    kd = new Ponto3D(0, 0, 0.5);
                    scCMatB.Value = (int)(0.5 * 91);
                    atualizaCorLabel(lbCMat, kd);
                    ke = new Ponto3D(0.8, 0.8, 0.8);
                    scCBrilhoR.Value = (int)(0.8 * 91);
                    scCBrilhoG.Value = (int)(0.8 * 91);
                    scCBrilhoB.Value = (int)(0.8 * 91);
                    atualizaCorLabel(lbCBrilho, ke);
                    Eye = new Ponto3D(0, 0, 1);
                    Luz = new Ponto3D(-1, -1, 1);
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
                atualizarBotaoLuz(btLuz.Location.X, btLuz.Location.Y);
                // setando vetores
                double d;
                string proj = cbProjecao.SelectedItem.ToString().ToLower();
                double.TryParse(tbD.Text, out d);
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                if (cbProjecao.Text == "Perspectiva")
                {
                    draw.writeObjeto3DPerspectivaXY(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked, (d = double.Parse(tbD.Text)));
                    pbPrincipal.Refresh();
                    if (tabControl.SelectedTab == tabPageVistas)
                    {
                        //new Thread(() =>
                        {
                            double s = (double)pbLateral.Width / pbPrincipal.Width;
                            Objeto3D obj2 = obj.getCopia();
                            obj2.escala(s, s, s);
                            // planta
                            draw.paint(bmpPlanta, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaZX(bmpPlanta, obj2, lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            //frontal
                            draw.paint(bmpFrontal, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaXY(bmpFrontal, obj2, bmpFrontal.Width >> 1, bmpFrontal.Height >> 1,
                                lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            //lateral
                            draw.paint(bmpLateral, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaZY(bmpLateral, obj2, lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            pbPlanta.Refresh();
                            pbFrontal.Refresh();
                            pbLateral.Refresh();
                        }//).Start();

                    }
                }
                else if (cbProjecao.Text[0] == 'C')
                {
                    // Cavaleira: L = 1;
                    // Cabinet: L = 0.5;
                    double L;// projeções oblíquas
                             // x = x+z * L * cos 45
                             // y = y+z * L * sin 45
                    L = cbProjecao.Text[2] == 'v' ? 1 : 0.5;
                    draw.writeObjeto3DObliqua(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked, L);
                    pbPrincipal.Refresh();
                    if (tabControl.SelectedTab == tabPageVistas)
                    {

                    }
                }
                else
                { // Paralela
                    if (rbWireframe.Checked)
                        draw.writeObjeto3DParalelaXY(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked);
                    else
                    {
                        if (rbFlat.Checked)
                        {
                            draw.scanLineFlat(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                        }
                        else if (rbGouraud.Checked)
                        {
                            draw.scanLineGouraud(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                        }
                        else // Phong
                            draw.scanLinePhong(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                    }
                    pbPrincipal.Refresh();
                    if (tabControl.SelectedTab == tabPageVistas) // vistas
                    {
                        //new Thread(() =>
                        {
                            double s = (double)pbLateral.Width / pbPrincipal.Width;
                            Objeto3D obj2 = obj.getCopia();
                            draw.paintVistas(bmpPlanta, bmpFrontal, bmpLateral, lbCAmb.BackColor);
                            obj2.escala(s, s, s);
                            //*// planta
                            draw.writeObjeto3DParalelaZX(bmpPlanta, obj2, lbCMat.BackColor, ckFacesOcultas.Checked);
                            //frontal
                            draw.writeObjeto3DParalelaXY(bmpFrontal, obj2, bmpFrontal.Width >> 1, bmpFrontal.Height >> 1,
                                lbCMat.BackColor, ckFacesOcultas.Checked);
                            //lateral
                            draw.writeObjeto3DParalelaZY(bmpLateral, obj2, lbCMat.BackColor, ckFacesOcultas.Checked);
                            /*/
                            draw.writeVistasParalela(bmpPlanta, bmpFrontal, bmpLateral, obj2, btCor.BackColor, ckFacesOcultas.Checked);
                            //*/
                            pbPlanta.Refresh();
                            pbFrontal.Refresh();
                            pbLateral.Refresh();
                        }//).Start();

                    }
                }



            }
            else if (bmpPrincipal != null)
            {
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                pbPrincipal.Refresh();
            }
        }

        private void w(string s)
        {
            Console.WriteLine(s);
        }

        private void exibeVetoresCor()
        {
            w("ia: " + ia.getX() + ", " + ia.getY() + ", " + ia.getZ());
            w("id: " + id.getX() + ", " + id.getY() + ", " + id.getZ());
            w("ie: " + ie.getX() + ", " + ie.getY() + ", " + ie.getZ());
            w("ka: " + ka.getX() + ", " + ka.getY() + ", " + ka.getZ());
            w("kd: " + kd.getX() + ", " + kd.getY() + ", " + kd.getZ());
            w("ke: " + ke.getX() + ", " + ke.getY() + ", " + ke.getZ());
        }
    }
    /*new Thread(() =>
            {
                int i = 0;
                while (i++ < 100)
                {
                    draw.paint(bmp, Color.FromArgb(random.Next(0, 255),
                        random.Next(0, 255), random.Next(0, 255)));
                    try
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                              pictureBox.Refresh();
                        }));
                    }
                    catch (Exception) { break; }
                    Thread.Sleep(500);
                }
            }).Start();
            */
}
