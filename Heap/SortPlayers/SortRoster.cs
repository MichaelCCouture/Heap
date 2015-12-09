using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MCoutureAssignment3
{
    public class SortRoster
    {
        string fileName;
        Heap<Player> h;

        public SortRoster(int MaxSize)
        {
            fileName = "";
            h = new Heap<Player>(MaxSize);
        }
        
        public SortRoster(int MaxSize, string fileName)
        {
            this.fileName = fileName;
            h = new Heap<Player>(MaxSize);
        }

        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public void ReadRoster()
        {
            XDocument doc;
            try
            {
                doc = XDocument.Load(fileName);
            }
            catch
            {
                throw new ApplicationException("File cannot be opened");
            }

            if (doc.Root == null)
            {
                throw new ApplicationException("File is empty");
            }

            Player newPlayer;
            int jerseyNumber;
            string playerName;
            string position;
            
            var players = doc.Descendants("Player");

            foreach (var player in players)
            {
                try
                {
                    jerseyNumber = Int32.Parse(player.Element("Jersey").Value);
                    playerName = player.Element("Name").Value.ToString();
                    position = player.Element("Position").Value.ToString();
                }
                catch
                {
                    throw new ApplicationException("invalid XML tags");
                }

                newPlayer = new Player(jerseyNumber, playerName, position);
                 
                h.Insert(newPlayer);
            }
        }

        public Player Fetch()
        {
            return h.GetMin();
        }
    }
}
