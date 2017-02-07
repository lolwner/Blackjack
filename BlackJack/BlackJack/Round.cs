using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Round
    {

        public static void StartRound()
        {
            Game game = new Game();
            game.Play();
        }

        public static void BlackJack()
        {
            while (MSG.NewRound())
                StartRound();
        }
    }
}
