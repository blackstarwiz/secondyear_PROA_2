using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdmin
{
    internal enum WorkType
    {
        Constultant,
        Loondienst,
        Zelfstandige
    }

    internal class CareerInfo
    {
        //constuctor
        public CareerInfo(string company, string position, WorkType typeOfWork, int years)
        {
            Company = company;
            Position = position;
            TypeOfWork = typeOfWork;
            YearsOfExperience = years;
        }

        private string company;
        private string position;
        private WorkType typeOfWork;
        private int yearsOfExperience;

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public WorkType TypeOfWork
        {
            get
            {
                return typeOfWork;
            }
            set
            {
                typeOfWork = value;
            }
        }

        public int YearsOfExperience
        {
            get
            {
                return yearsOfExperience;
            }
            set
            {
                yearsOfExperience = value;
            }
        }

        public override string ToString()
        {
            WorkType type = typeOfWork;

            switch (type)
            {
                case WorkType.Constultant:
                    return $"Werkt als consultant bij {Company} als {Position} - {YearsOfExperience} jaar ervaring";

                case WorkType.Loondienst:
                    return $"Werkt in loondienst bij {Company} als {Position} - {YearsOfExperience} jaar ervaring";

                case WorkType.Zelfstandige:
                    return $"Werkt asl zelfstandigen bij {Company} als {Position} - {YearsOfExperience} jaar ervaring";

                default:
                    throw new Exception("geen workType");
            }
        }
    }
}