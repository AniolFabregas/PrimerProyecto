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
            if (distanciaQueFalta <= tolerancia)
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
        //DERIVADA 
        public Position PosicionFutura(double t)
        {
            // si la velocidad es 0 (o negativa) el avión no avanza: estará donde está ahora
            if (this.velocidad <= 0)
            {
                return new Position(this.currentPosition.GetX(), this.currentPosition.GetY());
            }

            double distanciaRecorrida = t * this.velocidad / 60;                            
            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);   

            // si en ese tiempo ya habría llegado, estará justo en el destino
            if (distanciaRecorrida >= distanciaQueFalta)
            {
                return new Position(this.finalPosition.GetX(), this.finalPosition.GetY());
            }

            // si no, avanza en línea recta hacia el destino, también igual que en Move
            double coseno = (this.finalPosition.GetX() - this.currentPosition.GetX()) / distanciaQueFalta;  
            double seno = (this.finalPosition.GetY() - this.currentPosition.GetY()) / distanciaQueFalta;     
            double x = this.currentPosition.GetX() + distanciaRecorrida * coseno;                       
            double y = this.currentPosition.GetY() + distanciaRecorrida * seno;                           
            return new Position(x, y);                                                                    
        }

        // TIEMPOPARALLEGAR
        public double TiempoParaLlegar()
        {
            if (this.HasArrived() || this.velocidad <= 0)
            {
                return 0;                                                                
            }

            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);  
            return distanciaQueFalta * 60 / this.velocidad;                                  
        }

        // DERIVADADISTANCIA: cómo está cambiando AHORA la distancia entre este avión y el otro
        public double DerivadaDistancia(FlightPlan otro)
        {
            double h = 0.001;                                                                      
            double distanciaAhora = this.Distance(otro);                                            
            double distanciaDespues = this.PosicionFutura(h).Distancia(otro.PosicionFutura(h));    
            return (distanciaDespues - distanciaAhora) / h;                                        
        }

        // DISTANCIAMINIMA
        public double DistanciaMinima(FlightPlan otro, double tiempo)
        {
            // Cada avión va en línea recta y a velocidad constante hasta que llega
            double llegaPrimero = Math.Min(this.TiempoParaLlegar(), otro.TiempoParaLlegar());  
            double llegaSegundo = Math.Max(this.TiempoParaLlegar(), otro.TiempoParaLlegar());   

            // si solo nos piden mirar un rato (por ejemplo, un ciclo), cortamos los tramos en ese tiempo
            double finTramo1 = Math.Min(llegaPrimero, tiempo);
            double finTramo2 = Math.Min(llegaSegundo, tiempo);

            double minimoTramo1 = this.DistanciaMinimaTramo(otro, 0, finTramo1);           
            double minimoTramo2 = this.DistanciaMinimaTramo(otro, finTramo1, finTramo2);  

            return Math.Min(minimoTramo1, minimoTramo2);                                 
        }

        // DISTANCIAMINIMATRAMO
        // Aquí es donde usamos la DERIVADA para encontrar el punto de máximo acercamiento.
        private double DistanciaMinimaTramo(FlightPlan otro, double t0, double t1)
        {
            Position a0 = this.PosicionFutura(t0);
            Position b0 = otro.PosicionFutura(t0);
            Position a1 = this.PosicionFutura(t1);
            Position b1 = otro.PosicionFutura(t1);

            double rx = b0.GetX() - a0.GetX();
            double ry = b0.GetY() - a0.GetY();

            double wx = (b1.GetX() - a1.GetX()) - rx;
            double wy = (b1.GetY() - a1.GetY()) - ry;



            double w2 = wx * wx + wy * wy;          
            double s = 0;                         vale cualquier s
            if (w2 > 0)
            {
                s = -(rx * wx + ry * wy) / w2;      // el instante (de 0 a 1) en que la derivada vale 0
            }

            // ese instante tiene que estar DENTRO del tramo
            if (s < 0)
            {
                s = 0;      // la derivada ya es positiva al principio: se alejan, y lo más cerca es el principio
            }
            if (s > 1)
            {
                s = 1;      // la derivada aún es negativa al final: se siguen acercando, y lo más cerca es el final
            }

            double dx = rx + wx * s;                // el vector entre los dos aviones en el momento más cercano
            double dy = ry + wy * s;
            return Math.Sqrt(dx * dx + dy * dy);    // su longitud (Pitágoras) es la distancia mínima del tramo
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
