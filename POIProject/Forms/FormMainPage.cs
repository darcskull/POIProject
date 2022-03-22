using POIProject.Objects;
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
        Questions question = new Questions();
        Player playerHelper = new Player();
        public FormMainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonQuiz_Click(object sender, EventArgs e)
        {
            List<Questions> questions = question.readQuestions();
            List<Player> players = playerHelper.mockData();
            if (players.Count() > 4)
            {
                if (questions.Count() > 5)
                {
                    Questions[] quizQuestions = question.generateQuizQuestions(questions);

                    FormQuiz formQuiz = new FormQuiz(quizQuestions, players);
                    this.Hide();
                    formQuiz.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Няма достатъчен брой въпроси за стартиране на игра!");
            }
            else
                MessageBox.Show("Няма достатъчен брой играчи, за да бъде стартирана игра!");
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
