using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        //atributs

        string id;           
        Position initialPosition; 
        Position currentPosition; 
        Position finalPosition;  
        double velocidad;        

        const double TOLERANCIA = 0.001;


        //constructor
        public FlightPlan(string id, double ipx, double ipy, double fpx, double fpy, double velocidad)
        {
            this.id = id;

            this.initialPosition = new Position(ipx, ipy);

            this.currentPosition = new Position(ipx, ipy);

            this.finalPosition = new Position(fpx, fpy);

            this.velocidad = velocidad;
        }


        //gets i sets

        public string GetId()
        {
            return this.id;               
        }

        public void SetId(string id)
        {
            this.id = id;                 
        }

        public Position GetInitialPosition()
        {
            return this.initialPosition;  
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;   
        }

        public Position GetCurrentPosition()
        {
            return this.currentPosition;  
        }

        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;   
        }

        public Position GetFinalPosition()
        {
            return this.finalPosition;  
        }

        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;      
        }

        public double GetVelocidad()
        {
            return this.velocidad;      
        }

        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;   
        }


        //metodes
        public void Move(double time)
        {
            if (this.HasArrived())
            {
                return;
            }

            double distanciaRecorrida = time * this.velocidad / 60;

            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);

            if (distanciaRecorrida >= distanciaQueFalta)
            {
                this.currentPosition = new Position(this.finalPosition.GetX(), this.finalPosition.GetY());
            }
            else
            {
                //cosinus en direccio X i el sinus en direccio Y
                double coseno = (this.finalPosition.GetX() - this.currentPosition.GetX()) / distanciaQueFalta;
                double seno = (this.finalPosition.GetY() - this.currentPosition.GetY()) / distanciaQueFalta;

                double x = this.currentPosition.GetX() + distanciaRecorrida * coseno;
                double y = this.currentPosition.GetY() + distanciaRecorrida * seno;

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
            this.currentPosition = new Position(this.initialPosition.GetX(), this.initialPosition.GetY());
        }

        public double Distance(FlightPlan plan)
        {
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
