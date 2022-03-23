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
        int counter;
        
        public FormQuiz(Questions[] questions, List<Player> users)
        {
            InitializeComponent();
            quizQuestions = questions;
            players = users;
            counter = 5;
            setPlayers();
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
            if(textBoxSlowest.Text != "")
            {
                for(int i=0; i < players.Count(); ++i)
                {
                    if (players.ElementAt(i).Name == textBoxSlowest.Text)
                    {
                        players.Remove(players.ElementAt(i));
                        break;
                    }
                }
                textBoxSlowest.Text = "";
            }

            counter--;
            textBoxAnswers.Text = "";
            if (counter < 0)
            {
                textBoxPlayers.Text = "";
                resetQuestion();
                MessageBox.Show("Победител - Име: " + players.ElementAt(0).Name + " Години: " + players.ElementAt(0).Age);
            }
            else
            {
                setPlayers();
                setQuestion();
                runThreads();
            }

        }

        public void runThreads()
        {
            foreach(Player pl in players)
            {
               Thread thread = new Thread(()=>ThreadRun.runQuiz(pl, textBoxSlowest, textBoxAnswers, quizQuestions[counter]));
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
            textBoxCounter.Text = (counter + 1).ToString();
        }

        public void resetQuestion()
        {
            textBoxQuestion.Text = "";
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxD.Text = "";
            textBoxCounter.Text = "";
        }

        public void setPlayers()
        {
            textBoxPlayers.Text = "Брой участници: " + players.Count();
            for(int i=0; i<players.Count(); i++)
            {
                textBoxPlayers.Text = textBoxPlayers.Text + Environment.NewLine + "Име: " + players.ElementAt(i).Name + " Години: " + players.ElementAt(i).Age;
            }
        }
    }
}
