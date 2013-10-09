using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiceGame
{
    public partial class frmDiceGame : Form
    {
        int currentDieValue = 0;
        int rollCount = 1;
        int firstNumber;
        int secondNumber;
        int thirdNumber;
        int fourthNumber;
        List<bool> guessHigher = new List<bool>() {false, false, false, false};
        List<bool> isHigher = new List<bool>() {false, false, false, false};

        public frmDiceGame()
        {
            InitializeComponent();
        }

        private void frmDiceGame_Load(object sender, EventArgs e)
        {
           
            // Set the values of the numbers to guess 
            Random values = new Random((int)DateTime.Now.Ticks); 
            firstNumber = values.Next(1, 6);
            secondNumber = values.Next(1, 6);
            thirdNumber = values.Next(1, 6);
            fourthNumber = values.Next(1, 6);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            try
            {
                //Roll a random number
                Random rnd = new Random((int)DateTime.Now.Ticks);
                int roll = rnd.Next(1, 6);

                currentDieValue = roll;
                dice newDice = new dice(roll, rollCount);
                this.Controls.Add(newDice);
                // Update label
                txtMessage.Text = string.Format("You rolled a {0}.", roll.ToString());
                checkNumberMatch(rollCount, roll);

                //Increment Roll Count or enable Reveal;
                rollCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Something went wrong.  Application will restart.\r\n{0}\r\n{1}",ex.Message,ex.StackTrace));
                throw;
            }

        }
        /// <summary>
        /// Checks after a roll to see if there is a match
        /// </summary>
        /// <param name="rollCount">The ordinal number to check</param>
        /// <param name="roll">The value of the roll to check</param>
        private void checkNumberMatch(int rollCount, int roll)
        {
            try
            {
                txtMessage.Text += string.Format("\r\nIs it a {0}?", roll.ToString());
                switch (rollCount)
                {
                    case 1:
                        if (firstNumber == roll)
                        {
                            txtFirst.ForeColor = Color.Yellow;
                            lblFirst.Text = txtFirst.Text = roll.ToString();
                            txtMessage.Text += string.Format("\r\nYes, it's a {0}.", roll.ToString());

                        }
                        else
                        {
                            askHigherOrLower(rollCount, roll);
                        }
                        break;
                    case 2:
                        if (secondNumber == roll)
                        {
                            txtSecond.ForeColor = Color.Yellow;
                            lblSecond.Text = txtSecond.Text = roll.ToString();
                            txtMessage.Text += string.Format("\r\nYes, it's a {0}.", roll.ToString());
                        }
                        else
                        {
                            askHigherOrLower(rollCount, roll);
                        }
                        break;
                    case 3:
                        if (thirdNumber == roll)
                        {
                            txtThird.ForeColor = Color.Yellow;
                            lblThird.Text = txtThird.Text = roll.ToString();
                            txtMessage.Text += string.Format("\r\nYes, it's a {0}.", roll.ToString());
                        }
                        else
                        {
                            askHigherOrLower(rollCount, roll);
                        }
                        break;
                    case 4:
                        if (fourthNumber == roll)
                        {
                            txtFourth.ForeColor = Color.Yellow;
                            lblFourth.Text = txtFourth.Text = roll.ToString();
                            txtMessage.Text += string.Format("\r\nYes, it's a {0}.", roll.ToString());
                            ReadyToReveal();
                        }
                        else
                        {
                            askHigherOrLower(rollCount, roll);
                        }
                        break;
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Something went wrong.  Application will restart.\r\n{0}\r\n{1}",ex.Message,ex.StackTrace));
                throw;
            }

        }

        private void askHigherOrLower(int rollCount, int roll)
        {
            btnHigher.Enabled = true;
            btnLower.Enabled = true;
            btnRoll.Enabled = false;
            btnReveal.Enabled = false;
            try
            {
                switch (roll)
                {
                    case 1:
                        {
                            txtMessage.AppendText(string.Format("\r\nNo...\r\nSince you rolled a {0}, the number must be higher.", roll.ToString()));
                            btnLower.Enabled = false;
                            break;
                        }
                    case 6:
                        {
                            txtMessage.AppendText(string.Format("\r\nNo..\r\nSince you rolled a {0}, the number must be lower.", roll.ToString()));
                            btnHigher.Enabled = false;
                            break;
                        }
                    default:
                        {
                            txtMessage.AppendText(string.Format("\r\nNo...\r\nIs the number higher or lower than {0}?", roll.ToString()));
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Something went wrong.  Application will restart.\r\n{0}\r\n{1}",ex.Message,ex.StackTrace));
                throw;
            }
            
        }

        private void btnHigher_Click(object sender, EventArgs e)
        {
            try
            {
                // did we press the higher or lower button?
                Button btn = sender as Button;
                guessHigher[rollCount - 2] = (btn.Name == btnHigher.Name) ? true : false;
                //Show the label, roll count has already been incremented
                switch (rollCount - 1)
                {
                    case 1: lblFirst.Text = guessHigher[0] ? "Higher" : "Lower";
                        break;
                    case 2: lblSecond.Text = guessHigher[1] ? "Higher" : "Lower";
                        break;
                    case 3: lblThird.Text = guessHigher[2] ? "Higher" : "Lower";
                        break;
                    case 4: lblFourth.Text = guessHigher[3] ? "Higher" : "Lower";
                        break;
                    default:
                        break;
                }


                txtMessage.AppendText(string.Format("\r\nYou think it's {0}.", (btn.Name == btnHigher.Name) ? "higher" : "lower"));
                switch (rollCount - 1)
                {
                    case 1:
                        {
                            isHigher[0] = (firstNumber > currentDieValue) ? true : false;
                            btnRoll.Enabled = true;
                            break;
                        }
                    case 2:
                        {
                            isHigher[1] = (secondNumber > currentDieValue) ? true : false;
                            btnRoll.Enabled = true;
                            break;
                        }
                    case 3:
                        {
                            isHigher[2] = (thirdNumber > currentDieValue) ? true : false;
                            btnRoll.Enabled = true;
                            break;
                        }

                    default:  //4th roll
                        {
                            isHigher[3] = (fourthNumber > currentDieValue) ? true : false;
                            ReadyToReveal();
                            break;
                        }
                }
                btnHigher.Enabled = false;
                btnLower.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Something went wrong.  Application will restart.\r\n{0}\r\n{1}",ex.Message,ex.StackTrace));
                throw;
            }
        }

        private void ReadyToReveal()
        {
            btnRoll.Enabled = false;
            btnReveal.Enabled = true;
            txtMessage.AppendText("\r\nLet's see if you won...");
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            try
            {
                //winning flag
                bool isWinner = true;
                //check first number
                //is it still a mystery
                if (txtFirst.Text == "?")
                {
                    txtFirst.ForeColor = (isHigher[0] == guessHigher[0]) ? Color.Yellow : Color.Red;
                    txtFirst.Text = firstNumber.ToString();
                    isWinner = isWinner && (isHigher[0] == guessHigher[0]);
                }
                //check second number
                //is it still a mystery
                if (txtSecond.Text == "?")
                {
                    txtSecond.ForeColor = (isHigher[1] == guessHigher[1]) ? Color.Yellow : Color.Red;
                    txtSecond.Text = secondNumber.ToString();
                    isWinner = isWinner && (isHigher[1] == guessHigher[1]);
                }
                //check third number
                //is it still a mystery
                if (txtThird.Text == "?")
                {
                    txtThird.ForeColor = (isHigher[2] == guessHigher[2]) ? Color.Yellow : Color.Red;
                    txtThird.Text = thirdNumber.ToString();
                    isWinner = isWinner && (isHigher[2] == guessHigher[2]);
                }
                //check fourth number
                //is it still a mystery
                if (txtFourth.Text == "?")
                {
                    txtFourth.ForeColor = (isHigher[3] == guessHigher[3]) ? Color.Yellow : Color.Red;
                    txtFourth.Text = fourthNumber.ToString();
                    isWinner = isWinner && (isHigher[3] == guessHigher[3]);
                }
                //Should not press reveal twice
                btnReveal.Enabled = false;
                // Did you win?
                txtMessage.Text = (isWinner) ? "You win." : "You lose.";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Something went wrong.  Application will restart.\r\n{0}\r\n{1}",ex.Message,ex.StackTrace));
                throw;
            }
        }
        //Need to scroll to bottom
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            txtMessage.ScrollToCaret();
            txtMessage.SelectionLength = 0;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
