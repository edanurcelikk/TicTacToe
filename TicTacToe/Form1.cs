using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true for 'X' false for 'O'
        int turnCount=0;
        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayersName(String p1,String p2)
        {
            player1 = p1;
            player2 = p2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Players player = new Players();
            player.ShowDialog();
            x_win_count.Text = player1;
            o_win_count.Text = player2;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ınfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The game board is in the shape of a 3x3 square grid. Two players take turns placing X and O symbols in these squares. The objective is to align three of one's own symbols in a row, either vertically, horizontally, or diagonally.","Info",MessageBoxButtons.OK);
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;

            b.Enabled = false;
            turnCount++;

            checkForWinner();

        }

        private void checkForWinner()
        {
            bool winner = false;

            //horizontal
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                winner = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
                winner = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
                winner = true;

            //vertical
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                winner = true;

            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                winner = true;

            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                winner = true;

            //diagonal
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                winner = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
                winner = true;

            if (winner)
            {
                disableButtons();
                String whowon = "";
                if (turn)
                {
                    whowon = player2;
                    oWinC.Text = (Int32.Parse(oWinC.Text) + 1).ToString();
                }
                else
                {
                    whowon = player1; //player1 is always X
                    xWinC.Text = (Int32.Parse(xWinC.Text) + 1).ToString();
                }

                MessageBox.Show(whowon + " " + "you won!", "Congratulations!");

            }

            else
            {
                if (turnCount == 9)
                {
                    drawC.Text = (Int32.Parse(drawC.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Game Over");
                }
            }

        }//end checkForWinner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }

            catch { }
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

           
                foreach (Control c in Controls)
                {
                   try
                    {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    } //try end

                catch { }

                } // foreach end
            
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xWinC.Text = "0";
            drawC.Text = "0";
            oWinC.Text="0";
        }
    }
}
