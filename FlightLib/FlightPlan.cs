using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    // Aquesta classe es un pla de vol: guarda tot lo que hem de saber d'un avio
    // (com es diu, d'on surt, on es ara, on va i a quina velocitat) i les coses que pot fer
    public class FlightPlan
    {
        // ========================= ATRIBUTS =========================
        // Son les dades que te cada pla de vol. Com que no posem "public" davant,
        // nomes es poden tocar desde dins d'aquesta classe. Per aixo despres fem els Gets i Sets.

        string id; // identificador
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            // "this.id" es l'atribut de la classe i "id" a seques es el parametre que ens passen
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);

            // guardem la velocitat
            this.velocidad = velocidad;
        }


        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;   // canviem la velocitat (aquest ja hi era, l'hem deixat igual)
        }


        // ========================= METODES =========================

        // MOVE: mou l'avio lo que avançaria durant el temps "time", anant en linia recta cap al desti
        public void Move(double time)
        {
            // si l'avio ja ha arribat no el movem. El "return" fa sortir del metode sense fer res mes.
            // Aixi no es passa de llarg i tampoc dividim per 0 mes avall (si ja hi es, falta 0)
            if (this.HasArrived())
            {
                return;
            }

            // lo que avança en aquest moviment: distancia = velocitat * temps.
            // El /60 ja hi era al codi dels videos: la velocitat va per hora i el temps en minuts
            double distanciaRecorrida = time * this.velocidad / 60;

            // quant li falta per arribar, fent servir el metode Distancia que ja te la classe Position
            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        public bool EstaDestino()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;

            return resultado;
        }

        // CONFLICTO (ja hi era): torna true si l'altre avio esta mes a prop que la distancia de seguretat
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;

            return conflicto;                             // tornem la resposta
        }

        // ESCRIBECONSOLA (ja hi era): escriu per la consola les dades del vol, va be per fer proves
        public void EscribeConsola()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.EstaDestino())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }
    }
}
