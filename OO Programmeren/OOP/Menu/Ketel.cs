using System.Collections.Immutable;

namespace Menu
{
    internal abstract class Ketel
    {
        public virtual int Temperatuur { get; set; }

        public virtual int InhoudInMiliter { get; set; }

        public virtual int MaxInhoudInMiliter { get; set; }

        //Constructor voor ketel => all ketels bij houden in de superKlasse Ketel
        public Ketel(List<Ketel> allKetels)
        {
        }

        public Ketel()
        {
        }
    }
}