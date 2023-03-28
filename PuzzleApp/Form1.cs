using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleApp
{
    public partial class Form1 : Form
    {
        static public string s;
        public State test = new State();

        public Form1()
        {

            InitializeComponent();
        }

        private void ind00_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind01_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind02_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind10_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind11_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind12_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind20_TextChanged(object sender, EventArgs e)
        {
        }

        private void ind21_TextChanged(object sender, EventArgs e)
        {
        }


        private void ind22_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EightPuzzleSolver.solutionFound = true;
            // Get the input text from the textBox1 control.
            s = textBox1.Text;

            // Check if the input string has exactly 9 characters. If not, display an error message and return.
            if (s.Length != 9)
            {
                textBox1.Text = "##wrong input##";
                return;
            }

            // Check if the input string contains only digits from 0 to 8. If not, display an error message and return.
            for (int i = 0; i < 9; i++)
            {
                if (s[i] < '0' || s[i] > '8')
                {
                    textBox1.Text = "##wrong input##";
                    return;
                }
            }

            // Check if the input string contains exactly 9 digits. If not, display an error message and return.
            int numbercount = 0;
            int num = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((int)s[j] == 48 + num)
                    {
                        numbercount++;
                        break;
                    }
                }
                num++;
            }
            if (numbercount != 9)
            {
                textBox1.Text = "##wrong input##";
                return;
            }

            // Convert the input string into a 2D array that represents the puzzle board.
            int[,] board = new int[3, 3];
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = (int)s[k] - '0';
                    k++;
                }
            }

            // Create a new State object based on the puzzle board, and use the EightPuzzleSolver class to solve the puzzle.
            test = new State(board);
            EightPuzzleSolver.Solve(test);

            // If a solution is found, display it on the GUI of the program by calling the PrintAsync method.
            if (EightPuzzleSolver.solutionFound == true)
            {
                this.PrintAsync();
                EightPuzzleSolver.solutionPath = new List<Node>();
            }
            else
            {
                // If a solution is not found, display an error message.
                textBox1.Text = "solution not found";
            }
        }
            // This method is called when a solution is found, and it displays the solution path on the GUI.
            public async Task PrintAsync()
            {
                foreach (Node node in EightPuzzleSolver.solutionPath)
                {
                    // Delay for 1 second to slow down the printing process.
                    await Task.Delay(1000);

                    // Display each element of the puzzle board on the GUI.
                    ind00.Text = NotPrintZero(node.State.board[0, 0].ToString());
                    ind01.Text = NotPrintZero(node.State.board[0, 1].ToString());
                    ind02.Text = NotPrintZero(node.State.board[0, 2].ToString());
                    ind10.Text = NotPrintZero(node.State.board[1, 0].ToString());
                    ind11.Text = NotPrintZero(node.State.board[1, 1].ToString());
                    ind12.Text = NotPrintZero(node.State.board[1, 2].ToString());
                    ind20.Text = NotPrintZero(node.State.board[2, 0].ToString());
                    ind21.Text = NotPrintZero(node.State.board[2, 1].ToString());
                    ind22.Text = NotPrintZero(node.State.board[2, 2].ToString());
                }
            }
        //print  blank's square empty
        string NotPrintZero(string s)
        {
            if (s != "0") return s;
            return " ";
        }

    }
}
