using POIProject.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POIProject
{
    public partial class FormQuiz : Form
    {
        Questions[] quizQuestions;
        List<Player> players;
        Player lastPlayer;
        int counter;
        
        public FormQuiz(Questions[] questions, List<Player> users)
        {
            InitializeComponent();
            quizQuestions = questions;
            players = users;
            counter = 4;
            lastPlayer = new Player();
            setQuestion();
            runThreads();

            Thread.Sleep(1100);
            textBoxAnswers.Text = textBoxAnswers.Text + Environment.NewLine + "Отпаднал участник: " + lastPlayer.Name
               + " " + lastPlayer.Age;

            players.Remove(lastPlayer);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMainPage main = new FormMainPage();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void FormQuiz_Load(object sender, EventArgs e)
        {

        }

        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            counter--;
            textBoxAnswers.Text = "";
            if (counter < 0)
            {
                MessageBox.Show("Победител " + players.ElementAt(0).Name + " " + players.ElementAt(0).Age);
            }
            else
            {
                setQuestion();
                runThreads();


                Thread.Sleep(1100);
                textBoxAnswers.Text = textBoxAnswers.Text + Environment.NewLine + "Отпаднал участник: " + lastPlayer.Name
               + " " + lastPlayer.Age;

                players.Remove(lastPlayer);
            }

        }

        public void runThreads()
        {
            foreach(Player pl in players)
            {
               Thread thread = new Thread(()=>ThreadRun.runQuiz(pl, lastPlayer, textBoxAnswers, quizQuestions[counter]));
                thread.Start();
            }
        }

        public void setQuestion()
        {
            textBoxQuestion.Text = quizQuestions[counter].Question;
            textBoxA.Text = quizQuestions[counter].Answer1;
            textBoxB.Text = quizQuestions[counter].Answer2;
            textBoxC.Text = quizQuestions[counter].Answer3;
            textBoxD.Text = quizQuestions[counter].Answer4;
        }
    }
}
