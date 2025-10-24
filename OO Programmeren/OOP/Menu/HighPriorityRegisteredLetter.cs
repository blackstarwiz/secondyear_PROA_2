namespace Menu
{
    internal class HighPriorityRegisteredLetter : RegisteredLetter
    {
        public override double Distance
        {
            get
            {
                return base.Distance;
            }
            set
            {
                base.Distance = value;
            }
        }

        public override byte Duration
        {
            get
            {
                double checkDays = Math.Ceiling(base.Distance / 200);
                
                return base.Duration = Convert.ToByte(checkDays); ;
            }
        }

        public override double Price
        {
            get
            {
                if (base.Distance > 100)
                {
                    return base.Price = Math.Floor(base.Distance / 100) * 30;
                }
                else
                {
                    return base.Price = 30.00;
                }
            }
        }
    }
}