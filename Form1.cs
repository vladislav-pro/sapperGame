using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miner
{
    public partial class Form1 : Form
    {
        int height = 10;
        int width = 10;
        int spaceBetwenButton = 35;
        ButtonExtended[,] allButtons;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create two-dimensional array
            allButtons = new ButtonExtended[width, height];
            Random random = new Random();
            // create button for play
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    ButtonExtended button = new ButtonExtended();
                    button.Location = new Point(x * spaceBetwenButton, y * spaceBetwenButton);
                    button.Size = new Size(spaceBetwenButton, spaceBetwenButton);

                    if (random.Next(0, 100) < 20)
                    {
                        button.boomb = true;
                    }
                    allButtons[x,y] = button;
                    Controls.Add(button);
                    button.Click += new EventHandler(FieldsClick);
                }
            }

        }

        void FieldsClick(object sender, EventArgs e)
        {
            ButtonExtended button = (ButtonExtended)sender;
            if (button.boomb)
            {
                Explode(button);
            }
            else
            {
                EmptyFieldClick(button);
            }
        }

        void Explode(ButtonExtended button)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (allButtons[x, y].boomb)
                    {
                        allButtons[x, y].Text = "*";
                    }

                }
            }
            MessageBox.Show("Game Ower");
            Application.Restart();
        }

        void EmptyFieldClick(ButtonExtended button)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (allButtons[x, y] == button)
                    {
                        button.Text = "" + CountBomsAround(x, y);
                    }
                }
            }
        }

        int CountBomsAround(int xB, int yB)
        {
            int bombCount = 0;
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {

                    if (x >=0 && x < width && y >=0 && y < height)
                    {

                        if (allButtons[x, y].boomb)
                        {
                            bombCount++;
                        }
                    }

                }
            }
            return bombCount;
        }

        class ButtonExtended : Button
        {
            public bool boomb;
        }

    }
}
