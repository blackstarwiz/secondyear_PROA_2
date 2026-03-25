using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDependencies
{
    public class NumberGame
    {
        private readonly IDie _die;

        //Custom Constructor die klasse Die iInitialiseert
        public NumberGame(IDie die)
        {
            _die = die;
        }

        public int RateGuess(int guess)
        {
            //we rollen met de die
            int roll = _die.Roll();
            //als speler juist gokt geef 2 punten
            if(guess == roll)
            {
                return 2;
            }

            //als speler er 1 voor of 1 na raad krijgt hij 1 punt
            if(roll-1 == guess || roll+1 == guess)
            {
                return 1;
            }

            return 0;
            //anders 0
        }
    }
}
