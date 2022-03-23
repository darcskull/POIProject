using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIProject.Objects
{
    public class Player: Data
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

        public List<Player> mockData()
        {
            List<Player> players = new List<Player>();
            for(int i =0; i < 6; ++i)
            {
                Player player = new Player();
                player.Name = "Име " + i;
                player.Age = i + 10;
                players.Add(player);
            }

            return players;
        }

        public void InsertPlayer(Player player)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into Players values(N'{player.Name}',N'{player.Age}');", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool checkForPlayer(string text, int age)
        {
            bool bol = true;
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Players";
                var cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetValue(1).ToString() == text && int.Parse(rdr.GetValue(2).ToString()) == age)
                    {
                        bol = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Грешка при търсене на участници: " + exc.Message);
            }

            conn.Close();
            return bol;
        }

        public List<Player> readPlayers()
        {
            List<Player> players = new List<Player>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Players";
                var cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    Player pl = new Player();
                    pl.Name = rdr.GetValue(1).ToString();
                    pl.Age = int.Parse(rdr.GetValue(2).ToString());
                    players.Add(pl);

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Грешка при търсене на участници: " + exc.Message);
            }

            conn.Close();
            return players;
        }

        public List<Player> generateQuizPlayers(List<Player> allPlayers)
        {
            List<Player> players = new List<Player>();
            Random random = new Random();
            int counter = random.Next(0, allPlayers.Count() - 6);
            for (int i = counter; i < counter + 6; ++i)
            {
                players.Add(allPlayers.ElementAt(i));
            }

            return players;
        }
    }
}
