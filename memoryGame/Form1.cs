using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memoryGame
{
    public partial class Form1 : Form
    {
        int[] arr = new int[10];
        private Button[] buttons;
        private Element[] elements = new Element[10];
        int lastChoice;
        public Form1()
        {
            InitializeComponent();
        }

        async private void gameStart()
        {
            buttons = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
            this.lastChoice = -1;
            resetGame();
            int cont = 0;
            Random r = new Random();
            while (cont < 10)
            {
                this.arr[cont] = r.Next(0, 10);
                if (arr.Count(x => x == arr[cont]) <= 1 || cont == 0)
                {
                    cont++;
                }
            }

            setButtons();
            desactivateButtons();
            await Task.Delay(3000);
            resetButtons();
            activateButtons();
        }

        private void setButtons()
        {
            Color[] color = { Color.Red, Color.Red, Color.Blue, Color.Blue, Color.Green, Color.Green, Color.Yellow, Color.Yellow, Color.Brown, Color.Brown };
            int cont = 0;
            for(int i=0; i<10; i++)
            {
                this.buttons[this.arr[i]].BackColor = color[i];
                if (cont == 0)
                {
                    elements[this.arr[i]] = new Element(color[i], i, i + 1);
                    cont++;
                }
                else if(cont >= 1)
                {
                    elements[this.arr[i]] = new Element(color[i], i, i - 1);
                    cont = 0;
                }
            }
        }

        private void resetButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                this.buttons[i].BackColor = Color.White;
            }
        }

        public void activateButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                if (this.buttons[i].BackColor == Color.White)
                {
                    this.buttons[i].Enabled = true;
                }
            }
        }

        public void desactivateButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                if (this.buttons[i].BackColor == Color.White)
                {
                    this.buttons[i].Enabled = false;
                }
            }
        }

        async public void checkUserEvent(int actualChoice)
        {
            bool badChoice = false;
            
            desactivateButtons();
            if ( this.lastChoice != -1)
            {
                Refresh();
                Color actualColor = elements[actualChoice].Color;
                Color lastColor = elements[lastChoice].Color;
                if (actualColor == lastColor)
                {
                    buttons[actualChoice].BackColor = elements[actualChoice].Color;
                    this.buttons[actualChoice].Enabled = false;
                    Console.WriteLine("great!");
                    this.lastChoice = -1;
                }
                else
                {
                    Console.WriteLine("grong");
                    resetGame();
                    badChoice = true;
                }
            }
            else
            {
                lastChoice = actualChoice;
                buttons[actualChoice].BackColor = elements[actualChoice].Color;
                this.buttons[actualChoice].Enabled = false;
            }
            await Task.Delay(500);
            if (!badChoice) activateButtons();
        }
        private void resetGame()
        {
            resetButtons();
            desactivateButtons();
            this.arr = new int[10];
            this.elements = new Element[10];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gameStart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkUserEvent(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkUserEvent(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkUserEvent(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkUserEvent(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkUserEvent(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkUserEvent(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkUserEvent(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkUserEvent(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkUserEvent(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkUserEvent(9);
        }
    }

    public class Element
    {
        Color _color;
        int _ownPosition;
        int _parPosition;
       
        public int OwnPosition { get => _ownPosition; set => _ownPosition = value; }
        public int ParPosition { get => _parPosition; set => _parPosition = value; }
        public Color Color { get => _color; set => _color = value; }

        public Element(Color color, int ownPosition, int parPosition)
        {
            this._color = color;
            this._ownPosition = ownPosition;
            this._parPosition = parPosition;
        }
    }
}
