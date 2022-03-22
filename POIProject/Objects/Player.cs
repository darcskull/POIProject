using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIProject.Objects
{
    public class Player
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
    }
}
