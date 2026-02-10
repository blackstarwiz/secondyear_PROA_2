using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingDependencies
{
    public class NumberGame
    {
        private readonly IDie die;
        public NumberGame(IDie die)
        {
            this.die = die;
        }


        public int RateGuess(int guess)
        {
            var result = die.Roll();//Roll een dobbelsteen = aantal ogen 

            if(result == guess)
            {
                return 2;//als gekozen waarde gelijk is aan dobbelsteen
            }
            
            if(result - 1 == guess || result +1 == guess)
            {
                return 1;//als gekozen waarde voor of na juiste keuzen valt
            }

            return 0;//anders dit
        }
    }
}
