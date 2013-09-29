using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            int val1 ;
            int val2;
            int solution;

            try
            {
                val1 = System.Convert.ToInt32(this.val1Txt.Text);
                val2 = System.Convert.ToInt32(this.val2Txt.Text);

                solution = val1 + val2;

                this.solutionLbl.Text = System.Convert.ToString(" = " + solution);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error:" + ex.GetBaseException());
            }

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.eventInfoLbl.Text = "Resizing...";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.eventInfoLbl.Text = "Loading form...";
        }

        private void mouseOverEvent(object sender, EventArgs e)
        {
            try
            {
                this.eventInfoLbl.Text = "Mouse over control id= " + ((Label)sender).Name;
            }
            catch (Exception ex)
            {
                this.eventInfoLbl.Text = "Error during mouse over this control";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            




            FormCloseWindowQuestionair fcwq = new FormCloseWindowQuestionair();
            fcwq.Show();
            e.Cancel = true;
            /*
            DialogResult dialogResult;

            dialogResult = FormCloseWindowQuestionair.

            dialogResult = MessageBox.Show("Do you really want to close?", "App name", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;

                this.eventInfoLbl.Text = "Canceled close of the form";
            }
            */
        }
    }
}
