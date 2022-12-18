using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_SP_2022
{
    public partial class Form1 : Form
    {
        DataAccess dataAcc = new DataAccess();

        public Form1()
        {
            InitializeComponent();

            dataAcc.form1 = this;
            //Test_dataGridView.DataSource = dataAcc.context.Test_Table.ToList();
        }

        private void func11a_button_Click(object sender, EventArgs e)
        {
            dataAcc.Task11a_Example(textBox11_1.Text, textBox11_2.Text);
        }

        private void func12button_Click(object sender, EventArgs e)
        {
            dataAcc.Task12(textBox12_1.Text, textBox12_2.Text);
        }

        private void func11b_button_Click(object sender, EventArgs e)
        {
            dataAcc.Task11b_Example(textBox11b_1.Text, textBox11b_2.Text);
        }

        private void func13button_Click(object sender, EventArgs e)
        {
            dataAcc.Task13(textBox13_1.Text, textBox13_2.Text);
        }

        private void func31button_Click(object sender, EventArgs e)
        {
            dataAcc.Task31(textBox31_1.Text, textBox31_2.Text, textBox31_3.Text);
            label_out21.Text = dataAcc.OutValue31.ToString();
        }

        private void func32button_Click(object sender, EventArgs e)
        {
            dataAcc.Task32(textBox32_1.Text, textBox32_2.Text);
            label_out22.Text = dataAcc.OutValue32.ToString();
        }

        private void func21button_Click(object sender, EventArgs e)
        {
            dataAcc.Task21(textBox21_1.Text, textBox21_2.Text);
        }

        private void func22button_Click(object sender, EventArgs e)
        {
            dataAcc.Task22(textBox22_1.Text, textBox22_2.Text);
        }
    }
}
