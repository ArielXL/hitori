using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hitori;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Hitori_Visual
{
    public partial class frmHitori : Form
    {
        Juego game;
        bool gana;
        int d, r;

        public frmHitori()
        {
            InitializeComponent();
            d = (int)(nudCount.Value);
            r = (int)(nudrange.Value);
            gana = false;
            game = new Juego(d, 1, r);
            
        }

        private void btnNuevoJuego_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres empezar un nuevo juego?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                d = (int)(nudCount.Value);
                r = (int)(nudrange.Value);
                game = new Juego(d, 1, r);
                gana = false;
                pbxTablero.Invalidate();
            }
        }

        private void pbxTablero_Paint(object sender, PaintEventArgs e)
        {
            int[,] matriz = game.Numeros;
            bool[,] marc = game.Soluble;
            Graphics g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, e.ClipRectangle);
            Pen p = new Pen(Color.Black);
            int width = pbxTablero.Width / d;
            for (int i = 0; i < d; i++)
                for (int j = 0; j < d; j++)
                {
                    PointF cP = new PointF(i * width, j * width);
                    var cSize = new SizeF(width, width);
                    int value = matriz[i, j];
                    var cRect = new RectangleF(cP, cSize);
                    var brush = new SolidBrush(Color.White);
                    if (marc[i, j]) brush = new SolidBrush(Color.Black);
                    var bString = new SolidBrush(Color.Black); 
                    e.Graphics.FillRectangle(brush, cRect);
                    var format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    var font = new Font(Font.FontFamily,d * (width / 22));
                    e.Graphics.DrawString(value.ToString(), font, bString, cRect, format);
                }
            for (int i = 0; i < d; i++)
            {
                g.DrawLine(p, i * width - 1, 0, i * width - 1, pbxTablero.Height);
                g.DrawLine(p, 0, i * width - 1, pbxTablero.Width, i * width - 1);
            }
        }

        private void pbxTablero_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gana)
            {
                int i = e.X * d / pbxTablero.Height;
                int j = e.Y * d / pbxTablero.Height;
                if (!game.Soluble[i, j])
                {
                    if (!game.TacharBien(i, j))
                        Console.Beep();
                    else
                        game.Soluble[i, j] = true;
                }
                else
                    game.Soluble[i, j] = false;

                pbxTablero.Refresh();

                if (game.JuegoTerminado())
                {
                    gana = true;
                    MessageBox.Show("Felicidades, haz ganado.", "Juego terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            game.SaveGame();
            MessageBox.Show("Juego salvado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres reiniciar este juego?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                game.ReiniciarJuego();
                gana = false;
                pbxTablero.Invalidate();
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quieres salir del juego?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
        }

        private void btnCargar_Click (object sender, EventArgs e)
        {
            game.CargarGame();
            d = game.Numeros.GetLength(0);
            r = GetMaximum(game.Numeros);
            gana = false;
            pbxTablero.Invalidate();
            MessageBox.Show("Juego cargado exitosamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static int GetMaximum(int[,] matriz)
        {
            int mayor = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    mayor = Math.Max(mayor, matriz[i, j]);
                }
            }
            return mayor;
        }
    }
}
