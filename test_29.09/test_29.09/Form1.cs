using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test_29._09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\cisla.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);

            Random rnd = new Random();

            for (int i = 1; i <= 10; i++)
            {
                bw.Write(rnd.Next(-10, 11).ToString() + Environment.NewLine);
            }

            fs.Close();
            bw.Close();

            FileStream fs2 = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs2);

            br.BaseStream.Position = 0;

            bool suda = false;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox1.AppendText(br.ReadString());

                if (br.BaseStream.Position == (br.BaseStream.Length - 1))
                {
                    if (Convert.ToInt32(br.ReadString()) % 2 == 0)
                    {
                        suda = true;
                    }
                }
            }

            fs2.Close();
            br.Close();

            FileStream fs3 = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.ReadWrite);

            BinaryReader br2 = new BinaryReader(fs3);
            BinaryWriter bw2 = new BinaryWriter(fs3);

            bw2.BaseStream.Position = 0;
            while (bw2.BaseStream.Position < bw2.BaseStream.Length)
            {
                int cislo = br2.ReadInt32();

                if (suda == true)
                {
                    if (cislo % 2 == 0 || cislo % -2 == 0)
                    {
                        cislo++;
                    }
                }
                else
                {
                    if (cislo % 2 != 0)
                    {
                        cislo *= 2;
                    }
                }

                bw2.Write(cislo + Environment.NewLine);
                textBox2.AppendText(cislo + Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\znaky.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);

            for (int i = 0; i < textBox3.Lines.Count(); i++)
            {
                if ((i + 1) % 10 == 0)
                {
                    bw.Write("*" + Environment.NewLine);
                }
                else
                {
                    bw.Write(textBox3.Lines[i].ToString() + Environment.NewLine);
                }
            }

            bw.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"..\..\znaky.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs2);

            br.BaseStream.Position = 0;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox4.AppendText(br.ReadChar().ToString());
            }

            fs2.Close();
            br.Close();
        }
    }
}
