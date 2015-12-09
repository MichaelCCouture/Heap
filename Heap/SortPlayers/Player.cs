using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCoutureAssignment3
{
    public class Player : IComparable
    {
        private int Number;
        private string PlayerName;
        private string Position;

        public Player( int newNumber, string newPlayerName, string newPosition )
            : base()
        {
            this.Number = newNumber;
            this.PlayerName = newPlayerName;
            this.Position = newPosition;
        }

        public int Priority()
        {
            return this.Number;
        }

        public int getNumber()
        {
            return this.Number;
        }

        public string getPlayerName()
        {
            return this.PlayerName;
        }

        public string getPosition()
        {
            return this.Position;
        }

        public int CompareTo( Object obj )
        {
            if (obj == null)
            {
                return 1;
            }

            Player otherPlayer = obj as Player;
            if (otherPlayer != null)
            {
                return this.CompareTo(otherPlayer);
            }
            else
            {
                throw new ArgumentException("Object is not a Player");
            }
        }
        public int CompareTo( Player other )
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            if (this.Priority() < other.Priority())
            {
                return -1;
            }
            else if (this.Priority() > other.Priority())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public override int GetHashCode()
        {
            return this.Priority();
        }
        public bool Equals( Player other )
        {
            if (other == null)
            {
                return false;
            }

            if (this.Number == other.Number)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public override bool Equals( Object obj )
        {
            if (obj == null)
            {
                return false;
            }

            Player x = obj as Player;

            if (x == null)
            {
                return false;
            }
            else
            {
                return Equals(x);
            }
        }
        public static bool operator ==( Player player1, Player player2 )
        {
            if ((object)player1 == null || ((object)player2) == null)
            {
                return Object.Equals(player1, player2);
            }

            return player1.Equals( player2 );
        }

        public static bool operator !=( Player player1, Player player2 )
        {
            if (player1 == null || player2 == null)
            {
                return !Object.Equals(player1, player2);
            }

            return !(player1.Equals( player2 ));
        }
    }
}
