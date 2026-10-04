using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position initialPosition; // posicion inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        const double tolerancia = 0.001;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // Metodos

        public string GetId()
        {
            return this.id;               // tornem el nom del vol a qui ens l'ha demanat
        }

        public void SetId(string id)
        {
            this.id = id;                 // guardem el nom nou que ens passen
        }

        public Position GetInitialPosition()
        {
            return this.initialPosition;  // tornem d'on surt l'avio
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;   // canviem d'on surt l'avio (el Restart el portara aqui)
        }

        public Position GetCurrentPosition()
        {
            return this.currentPosition;  // tornem on es l'avio ara (aixo es lo que fara servir el formulari per pintar-lo)
        }

        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;   // posem l'avio a ma en una posicio que ens passen
        }

        public Position GetFinalPosition()
        {
            return this.finalPosition;    // tornem on ha d'arribar l'avio
        }

        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;       // canviem el desti de l'avio
        }

        public double GetVelocidad()
        {
            return this.velocidad;        // tornem la velocitat
        }

        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public void Move(double time)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distanciaRecorrida = time * this.velocidad / 60;
            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);

            if (distanciaRecorrida >= distanciaQueFalta)
            {
                this.currentPosition = new Position(this.finalPosition.GetX(), this.finalPosition.GetY());
            }
            else
            {
                //Calculamos las razones trigonométricas
                double coseno = (finalPosition.GetX() - currentPosition.GetX()) / distanciaQueFalta;
                double seno = (finalPosition.GetY() - currentPosition.GetY()) / distanciaQueFalta;

                //Caculamos la nueva posición del vuelo
                double x = currentPosition.GetX() + distanciaRecorrida * coseno;
                double y = currentPosition.GetY() + distanciaRecorrida * seno;

                this.currentPosition = new Position(x, y);
            }
        }

           

   

        public bool HasArrived()
        {
            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);
            bool resultado = false;
            if (distanciaQueFalta == tolerancia)
            {
                resultado = true;

                return resultado;
            }
            else
                return false;
        }

        public void Restart()
        {
            // la posicio actual passa a ser una copia de la inicial (fem new per no compartir el mateix objecte)
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
        }

        // DISTANCE: torna la distancia entre aquest avio i l'avio del pla que ens passen
        public double Distance(FlightPlan plan)
        {
            // distancia entre on soc jo ara i on es l'altre ara. El calcul de veritat el fa Position
            return this.currentPosition.Distancia(plan.GetCurrentPosition());
        }


        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.Distance(b) < distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }
        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }
    }
}
