using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication3.WindowsFormsApplication3;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int CR, CG, CB;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int x, y, mR=0, mG=0, mB=0;
            x = e.X; y = e.Y;
            c = bmp.GetPixel(e.X, e.Y);

            for (int i = x; i < x + 10; i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;

            CR = mR;
            CG = mG;
            CB = mB;

            textBox4.Text = CR.ToString();
            textBox5.Text = CG.ToString();
            textBox6.Text = CB.ToString();

            int k = 0; int l = 0;
            for (int i = e.X; i <e.X+10; i++)
            {
                for (int j = e.Y; j < e.Y+10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(k, l, c);
                    l=l+1;
                }
                k = k + 1;
                l = 0;
            }
            pictureBox2.Image = cpoa;
            
        }

       
        private void button8_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            byte[] aByte = ms.ToArray();

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                SqlCommand comando = new SqlCommand("INSERT INTO IMAGEN VALUES(@imagen)",conexionBD);
                comando.Parameters.AddWithValue("imagen", aByte);
                comando.ExecuteNonQuery();
                MessageBox.Show("Imagen Guardada");
                pictureBox2.Image = null;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = "select IMG from imagen where id = '"+textBox1.Text+"'";

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                SqlCommand comando = new SqlCommand(sql, conexionBD);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["IMG"]);
                    Bitmap bm = new Bitmap(ms);
                    pictureBox2.Image = bm;
                }
                else
                {
                    MessageBox.Show("no archivos");
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Bitmap cap = new Bitmap(pictureBox2.Image);
            Color c = new Color();


            Bitmap bmp1 = new Bitmap(pictureBox2.Image);
            int mR = 0, mG = 0, mB = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;

            int CR1 = mR;
            int CG1 = mG;
            int CB1 = mB;

            Bitmap bmp2 = new Bitmap(pictureBox4.Image);
            int mR1 = 0, mG1 = 0, mB1 = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp2.GetPixel(i, j);
                    mR1 = mR1 + c.R;
                    mG1 = mG1 + c.G;
                    mB1 = mB1 + c.B;
                }

            mR1 = mR1 / 100;
            mG1 = mG1 / 100;
            mB1 = mB1 / 100;

            int CR2 = mR1;
            int CG2 = mG1;
            int CB2 = mB1;

            Bitmap bmp3 = new Bitmap(pictureBox5.Image);
            int mR2 = 0, mG2 = 0, mB2 = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp3.GetPixel(i, j);
                    mR2 = mR2 + c.R;
                    mG2 = mG2 + c.G;
                    mB2 = mB2 + c.B;
                }

            mR2 = mR2 / 100;
            mG2 = mG2 / 100;
            mB2 = mB2 / 100;

            int CR3 = mR2;
            int CG3 = mG2;
            int CB3 = mB2;

            textBox1.Text = CR3.ToString();
            textBox2.Text = CG3.ToString();
            textBox3.Text = CB3.ToString();

            
            
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    
                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;



                    if (((CR1 - 10) < meR) && (meR < (CR1 + 10)) && ((CG1 - 10) < meG) && (meG < (10 + CG1)) && ((CB1 - 10) < meB) && (meB < (10 + CB1)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Yellow);
                            }
                    }
                    else if (((CR2 - 10) < meR) && (meR < (CR2 + 10)) && ((CG2 - 10) < meG) && (meG < (10 + CG2)) && ((CB2 - 10) < meB) && (meB < (10 + CB2)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Black);
                            }
                    }
                    else if (((CR3 - 10) < meR) && (meR < (CR3 + 10)) && ((CG3 - 10) < meG) && (meG < (10 + CG3)) && ((CB3 - 10) < meB) && (meB < (10 + CB3)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.White);
                            }
                    }
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }

                    }
                                       
                }
            pictureBox3.Image = cpoa;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string sql = "select IMG from imagen where id = '"+textBox2.Text+"'";

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                SqlCommand comando = new SqlCommand(sql, conexionBD);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["IMG"]);
                    Bitmap bm = new Bitmap(ms);
                    pictureBox4.Image = bm;
                }
                else
                {
                    MessageBox.Show("no archivos");
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sql = "select IMG from imagen where id = '"+textBox3.Text+"'";

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                SqlCommand comando = new SqlCommand(sql, conexionBD);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    MemoryStream ms = new MemoryStream((byte[])reader["IMG"]);
                    Bitmap bm = new Bitmap(ms);
                    pictureBox5.Image = bm;
                }
                else
                {
                    MessageBox.Show("no archivos");
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Bitmap cap = new Bitmap(pictureBox2.Image);
            Color c = new Color();


            Bitmap bmp1 = new Bitmap(pictureBox2.Image);
            int mR = 0, mG = 0, mB = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;

            int CR1 = mR;
            int CG1 = mG;
            int CB1 = mB;

            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }

                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;



                    if (((CR1 - 10) < meR) && (meR < (CR1 + 10)) && ((CG1 - 10) < meG) && (meG < (10 + CG1)) && ((CB1 - 10) < meB) && (meB < (10 + CB1)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Yellow);
                            }
                    }
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }

                    }

                }
            pictureBox3.Image = cpoa;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            Bitmap bmp2 = new Bitmap(pictureBox4.Image);
            int mR1 = 0, mG1 = 0, mB1 = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp2.GetPixel(i, j);
                    mR1 = mR1 + c.R;
                    mG1 = mG1 + c.G;
                    mB1 = mB1 + c.B;
                }

            mR1 = mR1 / 100;
            mG1 = mG1 / 100;
            mB1 = mB1 / 100;

            int CR2 = mR1;
            int CG2 = mG1;
            int CB2 = mB1;

            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }

                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;



                    if (((CR2 - 10) < meR) && (meR < (CR2 + 10)) && ((CG2 - 10) < meG) && (meG < (10 + CG2)) && ((CB2 - 10) < meB) && (meB < (10 + CB2)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Black);
                            }
                    }
                
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }

                    }

                }
            pictureBox3.Image = cpoa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            Bitmap bmp3 = new Bitmap(pictureBox5.Image);
            int mR2 = 0, mG2 = 0, mB2 = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    c = bmp3.GetPixel(i, j);
                    mR2 = mR2 + c.R;
                    mG2 = mG2 + c.G;
                    mB2 = mB2 + c.B;
                }

            mR2 = mR2 / 100;
            mG2 = mG2 / 100;
            mB2 = mB2 / 100;

            int CR3 = mR2;
            int CG3 = mG2;
            int CB3 = mB2;



            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }

                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;



                    if (((CR3 - 10) < meR) && (meR < (CR3 + 10)) && ((CG3 - 10) < meG) && (meG < (10 + CG3)) && ((CB3 - 10) < meB) && (meB < (10 + CB3)))
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.White);
                            }
                    }
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }

                    }

                }
            pictureBox3.Image = cpoa;
        }

    }
}
