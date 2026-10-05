using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        FlightPlan[] vector = new FlightPlan[10];
        int number = 0;

        public int AddFlightPlan(FlightPlan p)
        {
            if (number == 10)
            { return -1; }
            else
            {
                vector[number] = p;
                number++;
                return 0;
            }

        }

        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= number)
            { return null; }
            else
            {
                return vector[i];

            }
        }

        public void Move(double tiempo)
        {
            int i = 0;
            while (i < number)
            {
                vector[i].Move(tiempo);   // abans era Mover(), pero a la Fase 1 l'hem canviat a Move() com demana l'enunciat
                i++;
            }
        }

        public void EscribeConsola()
        {
            int i = 0;
            while (i < number)
            {
                vector[i].EscribeConsola();
                i++;
            }
        }
    }
}
