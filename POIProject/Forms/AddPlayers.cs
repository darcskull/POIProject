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

namespace POIProject.Forms
{
    public partial class AddPlayers : Form
    {
        Player playerHelper = new Player();
        public AddPlayers()
        {
            InitializeComponent();
        }

        private void AddPlayers_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAge.Text != "" && textBoxName.Text != "")
            {
                if (int.TryParse(textBoxAge.Text, out int age))
                {
                    if (playerHelper.checkForPlayer(textBoxName.Text, age))
                    {
                        Player dataPlayer = new Player();
                        dataPlayer.Name = textBoxName.Text;
                        dataPlayer.Age = age;
                        try
                        {
                            playerHelper.InsertPlayer(dataPlayer);
                            MessageBox.Show("Играчът е регистриран успешно");
                        }
                        catch(Exception exc)
                        {
                            MessageBox.Show(exc.Message);
                        }
                        finally
                        {
                            textBoxAge.Text = "";
                            textBoxName.Text = "";
                        }
                        
                    }
                    else
                        MessageBox.Show("Играчът с тези данни вече е записан за участие и не може да бъде записан повторно");

                }
                else
                    MessageBox.Show("Моля въведете валидни години на участник");

            }
            else
                MessageBox.Show("Моля попълнете всички празни полета, за да въведете нов потребител");

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMainPage main = new FormMainPage();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
    }
}
