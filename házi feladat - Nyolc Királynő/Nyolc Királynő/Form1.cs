/*  Házi Feladat -backtrack gyakorlása -8 királynő probléma
 *  Grafikus alkalmazás - 8 királynő felhelyezése egy sakktáblára, hogy a sakk szabályai szerint ne üssék egymást
 */

using System;
using System.Windows.Forms;

namespace Nyolc_Királynő
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = 40;
            pictureBox3.Top = pictureBox2.Top;
            pictureBox4.Top = pictureBox2.Top + pictureBox2.Height + 20;
            pictureBox5.Top = pictureBox4.Top;
            pictureBox6.Top = pictureBox4.Top + pictureBox2.Height + 20;
            pictureBox7.Top = pictureBox6.Top;
            pictureBox8.Top = pictureBox6.Top + pictureBox2.Height + 20;
            pictureBox9.Top = pictureBox8.Top;
            pictureBox2.Left = 850;
            pictureBox4.Left = pictureBox2.Left;
            pictureBox6.Left = pictureBox2.Left;
            pictureBox8.Left = pictureBox2.Left;
            pictureBox3.Left = pictureBox2.Left + pictureBox2.Width + 20;
            pictureBox5.Left = pictureBox3.Left;
            pictureBox7.Left = pictureBox3.Left;
            pictureBox9.Left = pictureBox3.Left;
        }

        static int[] utolsópozi = new int[2];
        static int[,] tábla = new int[8, 8];
        static int darabkirálynő = 0;

        static bool sorbanjó(int i)
        {
            bool valami = true;

            for (int j = 0; j < 8; j++)
            {
                if (tábla[i, j] == 1)
                {
                    valami = false;
                }
            }
            return valami;
        }

        static bool oszlopbanjó(int j)
        {
            bool valami = true;

            for (int i = 0; i < 8; i++)
            {
                if (tábla[i, j] == 1)
                {
                    valami = false;
                    break;
                }
            }
            return valami;
        }

        static bool felsőkereszt(int i, int j)
        {
            bool valami = true;
            int kivonó = 1;

            for (int f = 0; f < j; f++)
            {
                if (kivonó > j || kivonó > i)
                {
                    break;
                }
                if (tábla[i - kivonó, j - kivonó] == 1)
                {
                    valami = false;
                }
                kivonó++;
            }
            return valami;
        }

        static bool alsókereszt(int i, int j)
        {
            bool valami = true;

            if (j > 7 - i)
            {
                for (int c = 1; c < (7 - i) + 1; c++)
                {
                    if (i == 0 || j == 0)
                    {
                        break;
                    }
                    if (tábla[i + c, (j - c)] == 1)
                    {
                        valami = false;
                    }
                }
            }
            if (j <= 7 - i)
            {
                for (int c = 1; c <= j; c++)
                {
                    if (i == 0 || j == 0)
                    {
                        break;
                    }
                    if (tábla[i + c, j - c] == 1)
                    {
                        valami = false;
                    }
                }
            }
            return valami;
        }
        static int[] rek_bt()   //utolsó vezér pozíciója
        {
            int[] vezérkoord = new int[2];
            int valami = 0;
            for (int j = 7; j >= 0; j--)
            {
                for (int i = 7; i >= 0; i--)
                {
                    if (tábla[i, j] == 1)
                    {
                        vezérkoord[0] = i;
                        vezérkoord[1] = j;
                        valami = 1;
                        break;
                    }
                }
                if (valami == 1)
                {
                    break;
                }
            }
            return vezérkoord;
        }
        static void próba(int i)
        {
            if (i == 7)
            {
                utolsópozi[0] = rek_bt()[0];    //i
                utolsópozi[1] = rek_bt()[1];    //j

                tábla[utolsópozi[0], utolsópozi[1]] = 0;
                darabkirálynő--;

                if (utolsópozi[0] == 7)
                {
                    próba(i);
                }
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            while (j != 8)
            {
                while (i != 8)
                {
                    if (oszlopbanjó(j) && sorbanjó(i) && felsőkereszt(i, j) && alsókereszt(i, j))
                    {
                        tábla[i, j] = 1;
                        darabkirálynő++;
                        
                        i = 8;
                    }
                    else
                    {
                        if (i == 7)
                        {
                            próba(i);
                            i = utolsópozi[0];
                            j = utolsópozi[1];
                        }
                        if (i != 7)
                        {
                            i++;
                        }
                    }
                }
                i = 0;
                j++;
            }
            int lerakott = 0;
            for (int k = 0; k < 8; k++)
            {
                for (int n = 0; n < 8; n++)
                {
                    if (tábla[k,n]==1)
                    {
                        lerakott++;
                        switch (lerakott)
                        {
                            case 1: pictureBox2.Top =k*100+15;
                                    pictureBox2.Left = n*100+10;
                                break;
                            case 2:
                                pictureBox3.Top = k * 100 + 15;
                                pictureBox3.Left = n * 100 + 10;
                                break;
                            case 3:
                                pictureBox4.Top = k * 100 + 15;
                                pictureBox4.Left = n * 100 + 10;
                                break;
                            case 4:
                                pictureBox5.Top = k * 100 + 15;
                                pictureBox5.Left = n * 100 + 10;
                                break;
                            case 5:
                                pictureBox6.Top = k * 100 + 15;
                                pictureBox6.Left = n * 100 + 10;
                                break;
                            case 6:
                                pictureBox7.Top = k * 100 + 15;
                                pictureBox7.Left = n * 100 + 10;
                                break;
                            case 7:
                                pictureBox8.Top = k * 100 + 15;
                                pictureBox8.Left = n * 100 + 10;
                                break;
                            case 8:
                                pictureBox9.Top = k * 100 + 15;
                                pictureBox9.Left = n * 100 + 10;
                                break;
                        }
                    }
                }
            }  
        }
    }
}
