using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POIProject
{
    public partial class FormMainPage : Form
    {
        public FormMainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonQuiz_Click(object sender, EventArgs e)
        {
            FormQuiz formQuiz = new FormQuiz();
            this.Hide();
            formQuiz.ShowDialog();
            this.Close();
        }

        private void buttonAddQuestions_Click(object sender, EventArgs e)
        {
            FormAddQuestions formQuestions = new FormAddQuestions();
            this.Hide();
            formQuestions.ShowDialog();
            this.Close();
        }
    }
}
