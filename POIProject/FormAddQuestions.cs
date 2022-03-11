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
    public partial class FormAddQuestions : Form
    {
        public FormAddQuestions()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMainPage main = new FormMainPage();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void FormAddQuestions_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            if (textBoxQuestion.Text != "" && textBoxA.Text != "" && textBoxB.Text != "" && textBoxG.Text != "" && textBoxTrue.Text != "" && textBoxV.Text != "" )
            {
                if (textBoxA.Text != textBoxB.Text && textBoxA.Text != textBoxG.Text && textBoxV.Text != textBoxA.Text &&
                    textBoxB.Text != textBoxG.Text && textBoxV.Text != textBoxB.Text && textBoxV.Text != textBoxG.Text)
                {
                    Questions qu = new Questions();
                    if (qu.checkForQuestion(textBoxQuestion.Text))
                    {
                        qu.Question = textBoxQuestion.Text;
                        qu.Answer1 = textBoxA.Text;
                        qu.Answer2 = textBoxB.Text;
                        qu.Answer3 = textBoxV.Text;
                        qu.Answer4 = textBoxG.Text;
                        qu.AnswerTrue = textBoxTrue.Text;
                        qu.setAnswer(qu);
                        if (qu.checkValidQuestion(qu))
                        {
                            try
                            {
                                qu.InsertQuestion(qu);
                                MessageBox.Show("Въпросът беше записан успешно");
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show("Заявката не беше изпълнена поради следната грешка: " + exc.Message);
                            }
                            finally
                            {
                                textBoxQuestion.Text = string.Empty;
                                textBoxA.Text = string.Empty;
                                textBoxB.Text = string.Empty;
                                textBoxG.Text = string.Empty;
                                textBoxTrue.Text = string.Empty;
                                textBoxV.Text = string.Empty;
                            }
                        }
                        else
                            MessageBox.Show("Въпросът не е валиден, моля задайте въпрос с 4 отговора, от които 1 е верен");
                    }
                    else
                        MessageBox.Show("Въпросът вече съществува");
                }
                else
                    MessageBox.Show("Въпросът трябва да има 4 различни отговора");
            }
            else
                MessageBox.Show("Моля попълнете всички празни полета");
        }
    }
}
