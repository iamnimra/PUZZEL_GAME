using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int movesNumber = 0, labelIndex = 0;
        private void shuffleButtons()
        {
            List<int> labelList = new List<int>();
            Random rand = new Random();

            foreach (Button btn in this.pnl.Controls)
            {
                while (labelList.Contains(labelIndex))
                    labelIndex = rand.Next(16);

                btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLight);
                labelList.Add(labelIndex);
            }
            movesNumber = 0;
            lblNoOfMoves.Text = "Number of Moves :" + movesNumber;
        }

        private void swapLabel(Object sender,EventArgs e )
        {
            Button btn = (Button)sender;
            if (btn.Text == "")
                return;
           Button whitebtn = null;
            foreach(Button bt in this.pnl.Controls)
            {
                if(bt.Text == "")
                {
                    whitebtn = bt;
                    break;
                }

            }
            if(btn.TabIndex == (whitebtn.TabIndex -1)||
                btn.TabIndex == (whitebtn.TabIndex - 4)||
                btn.TabIndex == (whitebtn.TabIndex + 1)||
                btn.TabIndex == (whitebtn.TabIndex + 4))
            {
                whitebtn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btn.BackColor = Color.White;
                whitebtn.Text = btn.Text;
                btn.Text = "";
                movesNumber++;
                lblNoOfMoves.Text = "Number of Moves :" + movesNumber;
            }
            checkOrder();
          }

        private void checkOrder()
        {
            int index = 0;
            foreach (Button btn in this.pnl.Controls)
            {
                if(btn.Text!="" && Convert.ToInt16(btn.Text)!=index)
                {
                    return;
                }
                index++;
            }
            MessageBox.Show("Congratulations!!! You did it in" + movesNumber +" moves");

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            shuffleButtons();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shuffleButtons();
        }
    }
}
