using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class KetelMetDoseren : Ketel, IVerwarmen, IWaterDoseren
    {
        public KetelMetDoseren(int maxInhoud)
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

        public void Verwarmen(int doelTemperatuur)
        {
        }

        public void WaterDoseren(int hoeveelheid)
        {
        }
    }
}