using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        // Ara fem servir una List, aixi no hi ha limit de vols
        List<FlightPlan> vector = new List<FlightPlan>();

        public int AddFlightPlan(FlightPlan p)
        {
            vector.Add(p);
            return 0;
        }

        // Torna quants vols hi ha a la llista
        public int GetNumber()
        {
            return vector.Count;
        }

        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= vector.Count)
            { return null; }
            else
            {
                return vector[i];
            }
        }

        public void Mover(double tiempo)
        {
            int i = 0;
            while (i < vector.Count)
            {
                vector[i].Move(tiempo);
                i++;
            }
        }

        public void EscribeConsola()
        {
            int i = 0;
            while (i < vector.Count)
            {
                vector[i].EscribeConsola();
                i++;
            }
        }

        // Llegeix els vols d'un fitxer de text. Una linia per vol, separat per espais:
        // id aerolinia xInicial yInicial xFinal yFinal velocitat
        // Si hi ha algun error en el fitxer salta una excepcio i la llista es queda com estava
        public void LoadFromFile(string path)
        {
            string[] lineas = File.ReadAllLines(path);
            List<FlightPlan> nuevos = new List<FlightPlan>();

            int i = 0;
            while (i < lineas.Length)
            {
                // les linies en blanc no es tenen en compte
                if (lineas[i].Trim() != "")
                {
                    string[] trozos = lineas[i].Trim().Split(' ');

                    if (trozos.Length != 7)
                    {
                        throw new Exception("Linea " + (i + 1) + ": hay que poner 7 datos separados por un espacio.");
                    }

                    int id = Convert.ToInt32(trozos[0]);
                    string aerolinea = trozos[1];
                    double ix = Convert.ToDouble(trozos[2]);
                    double iy = Convert.ToDouble(trozos[3]);
                    double fx = Convert.ToDouble(trozos[4]);
                    double fy = Convert.ToDouble(trozos[5]);
                    double velocidad = Convert.ToDouble(trozos[6]);

                    nuevos.Add(new FlightPlan(id, aerolinea, ix, iy, fx, fy, velocidad));
                }
                i++;
            }

            if (nuevos.Count == 0)
            {
                throw new Exception("El archivo esta vacio.");
            }

            vector = nuevos;
        }

        // Ordena els vols per id (de petit a gran) amb selection sort
        public void SortById()
        {
            int i = 0;
            while (i < vector.Count - 1)
            {
                // busquem el vol amb l'id mes petit de tots els que queden
                int posMin = i;
                int j = i + 1;
                while (j < vector.Count)
                {
                    if (vector[j].GetId() < vector[posMin].GetId())
                    {
                        posMin = j;
                    }
                    j++;
                }

                // el posem a la posicio i (intercanviem)
                FlightPlan aux = vector[i];
                vector[i] = vector[posMin];
                vector[posMin] = aux;
                i++;
            }
        }

        // Ordena els vols pel nom de l'aerolinia (alfabeticament) amb bubble sort
        public void SortByAirline()
        {
            int i = 0;
            while (i < vector.Count - 1)
            {
                int j = 0;
                while (j < vector.Count - 1 - i)
                {
                    // si estan al reves els intercanviem
                    if (string.Compare(vector[j].GetAirline(), vector[j + 1].GetAirline(), true) > 0)
                    {
                        FlightPlan aux = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = aux;
                    }
                    j++;
                }
                i++;
            }
        }
    }
}