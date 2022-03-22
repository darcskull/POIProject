using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POIProject.Objects
{
    public class ThreadRun
    {
        static int Max_Execution_Time = 1000;
        public static void runQuiz(Player player, Player last, TextBox textBox, Questions question)
        {
            WriteTextSafe(Environment.NewLine + player.Name + " започва да анализира въпроса.", textBox);
            Random random = new Random();
            int time = random.Next(100, Max_Execution_Time);

            try
            {
                Thread.Sleep(time);
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            last = player;

            WriteTextSafe(Environment.NewLine + player.Name + " отговори " + question.AnswerTrue, textBox);
        }

        public static void WriteTextSafe(string text, TextBox textBox1)
        {
            if (textBox1.InvokeRequired)
            {
                Action safeWrite = delegate { WriteTextSafe($"{text}", textBox1); };
                textBox1.Invoke(safeWrite);
            }
            else
                textBox1.Text =textBox1.Text + text;
        }
    }
}
