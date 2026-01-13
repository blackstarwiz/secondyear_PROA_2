using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    //Het is een Ketel met functies(Verwarmen,Afkoelen,Doseren) deze komen van de interface's die het verplicht maken dat stoomketel moet implementeren en afhandelt op zijn eigen manier
    internal class StoomKetel : Ketel, IStoomVerwarmen, IAfkoelen, IWaterDoseren
    {
        public StoomKetel(int maxInhoud)
        {
            Temperatuur = 0;
            MaxInhoudInMiliter = maxInhoud;
            InhoudInMiliter = 0;
        }

        public override int InhoudInMiliter
        {
            get => base.InhoudInMiliter;
            set => base.InhoudInMiliter = value;
        }

        public override int MaxInhoudInMiliter
        {
            get => base.MaxInhoudInMiliter;
            set => base.MaxInhoudInMiliter = value;
        }

        public override int Temperatuur
        {
            get => base.Temperatuur;
            set => base.Temperatuur = value;
        }

        public void Afkoelen(int doelTemperatuur)
        {
        }

        public void WaterDoseren(int hoeveelheid)
        {
        }
    }
}