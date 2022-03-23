using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIProject
{
    public class Questions 
    {

        // Променете D:\uni\6семестър\POIProject\POIProject\POIProject\dataBase\DatabaseQuestions.mdf с пътя на локалната ви база
        public const string connString = @"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename= D:\uni\6семестър\POIProject\POIProject\POIProject\dataBase\DatabaseQuestions.mdf; Integrated Security=True;";
        public SqlConnection conn = new SqlConnection(connString);

        private string question;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private string answertrue;
        public string Question { get { return question; } set { question = value; } }
        public string Answer1 { get { return answer1; } set { answer1 = value; } }
        public string Answer2 { get { return answer2; } set { answer2 = value; } }
        public string Answer3 { get { return answer3; } set { answer3 = value; } }
        public string Answer4 { get { return answer4; } set { answer4 = value; } }
        public string AnswerTrue { get { return answertrue; } set { answertrue = value; } }

        public void setAnswer(Questions q)
        {
            switch (q.AnswerTrue)
            {
                case "а":
                    q.AnswerTrue = q.Answer1;
                    break;
                case "б":
                    q.AnswerTrue = q.Answer2;
                    break;
                case "в":
                    q.AnswerTrue = q.Answer3;
                    break;
                case "г":
                    q.AnswerTrue = q.Answer4;
                    break;
                default:
                    Console.WriteLine("В записът няма отбелязана буква на отговор");
                    break;
            }
        }
        public bool checkValidQuestion(Questions q)
        {
            if (q.AnswerTrue == q.Answer1 || q.AnswerTrue == q.Answer2 || q.AnswerTrue == q.Answer3 || q.Answer4 == q.AnswerTrue)
                return true;
            return false;
        }

        public void InsertQuestion(Questions question)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into Questions values(N'{question.Question}',N'{question.Answer1}',N'{question.Answer2}',N'{question.Answer3}'," +
                $"N'{question.Answer4}',N'{question.AnswerTrue}');", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool checkForQuestion(string q)
        {
            bool bol = true;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Questions";
                var cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetValue(1).ToString() == q)
                    {
                        bol = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Грешка при търсене на въпрос: " + exc.Message);
            }

            conn.Close();
            return bol;
        }

        public List<Questions> readQuestions()
        {
            List<Questions> questions = new List<Questions>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Questions";
                var cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   
                        Questions q = new Questions();
                        q.Question = rdr.GetValue(1).ToString();
                        q.Answer1 = rdr.GetValue(2).ToString();
                        q.Answer2 = rdr.GetValue(3).ToString();
                        q.Answer3 = rdr.GetValue(4).ToString();
                        q.Answer4 = rdr.GetValue(5).ToString();
                        q.AnswerTrue = rdr.GetValue(6).ToString();
                        questions.Add(q);
                   
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Грешка при търсене на въпрос: " + exc.Message);
            }

            conn.Close();
            return questions;
        }

        public Questions[] generateQuizQuestions(List<Questions> questions)
        {
            Questions[] quizQuestions = new Questions[5];
            Random random = new Random();
            int counter = random.Next(0, questions.Count() - 5);
            for(int i = 0; i < 5; ++i)
            {
                quizQuestions[i] = questions.ElementAt(counter + i);
            }

            return quizQuestions;
        }
    }
}
