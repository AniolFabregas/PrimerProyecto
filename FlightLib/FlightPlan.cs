using System;
using System.Collections.Generic;
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

        string id;                // el nom o codi del vol, tipo "VY1234"
        Position initialPosition; // d'on surt l'avio. No canvia quan es mou, la guardem per poder fer el Restart
        Position currentPosition; // on esta l'avio ara mateix. Aquesta si que va canviant cada cop que fem Move
        Position finalPosition;   // on ha d'arribar l'avio, o sigui el desti
        double velocidad;         // la velocitat de l'avio (distancia per hora)

        // Marge per dir que un avio "ja ha arribat". Els double tenen decimals i a vegades
        // no dona exactament 0, aixi que si li falta menys que aixo ja diem que ha arribat
        const double TOLERANCIA = 0.001;


        // ========================= CONSTRUCTOR =========================
        // El constructor es lo que s'executa sol quan algu fa "new FlightPlan(...)".
        // Aqui omplim TOTS els atributs amb els valors que ens passen.
        // ipx, ipy = coordenades de la posicio inicial / fpx, fpy = coordenades de la posicio final
        public FlightPlan(string id, double ipx, double ipy, double fpx, double fpy, double velocidad)
        {
            // "this.id" es l'atribut de la classe i "id" a seques es el parametre que ens passen
            this.id = id;

            // creem la posicio inicial amb les coordenades d'on surt
            this.initialPosition = new Position(ipx, ipy);

            // al principi l'avio esta just on surt, pero fem un altre new perque siguin
            // dos objectes diferents (un es queda quiet i l'altre es el que anirem movent)
            this.currentPosition = new Position(ipx, ipy);

            // creem la posicio final, el desti
            this.finalPosition = new Position(fpx, fpy);

            // guardem la velocitat
            this.velocidad = velocidad;
        }


        // ========================= GETS I SETS =========================
        // Els Get serveixen per LLEGIR un atribut desde fora (et tornen el valor)
        // i els Set per CANVIAR-LO (reben el valor nou i el guarden). Igual que a la classe CPerson.

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

            if (distanciaRecorrida >= distanciaQueFalta)
            {
                // si amb aquest moviment arribaria o es passaria del desti, el posem just al desti i au
                this.currentPosition = new Position(this.finalPosition.GetX(), this.finalPosition.GetY());
            }
            else
            {
                // si encara no hi arriba, l'avancem cap al desti.
                // El cosinus diu quina part del cami va en direccio X i el sinus quina part va en direccio Y
                double coseno = (this.finalPosition.GetX() - this.currentPosition.GetX()) / distanciaQueFalta;
                double seno = (this.finalPosition.GetY() - this.currentPosition.GetY()) / distanciaQueFalta;

                // la X nova es la X d'ara mes el tros que avança en X (i igual amb la Y)
                double x = this.currentPosition.GetX() + distanciaRecorrida * coseno;
                double y = this.currentPosition.GetY() + distanciaRecorrida * seno;

                // guardem la posicio nova com a posicio actual de l'avio
                this.currentPosition = new Position(x, y);
            }
        }

        // HASARRIVED: torna true si l'avio ja es al desti i false si encara esta volant
        public bool HasArrived()
        {
            // mirem quanta distancia hi ha entre on es l'avio i on ha d'anar
            double distanciaQueFalta = this.currentPosition.Distancia(this.finalPosition);

            if (distanciaQueFalta < TOLERANCIA)
            {
                return true;     // falta practicament 0, o sigui que ja ha arribat
            }
            else
            {
                return false;    // encara li falta cami
            }
        }

        // RESTART: torna a posar l'avio a la posicio d'on va sortir (per tornar a començar la simulacio)
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

        // CONFLICTO (ja hi era): torna true si l'altre avio esta mes a prop que la distancia de seguretat
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;                       // de primeres diem que no hi ha conflicte
            if (this.Distance(b) < distanciaSeguridad)    // ara fem servir el Distance nou en lloc de fer el calcul aqui
                conflicto = true;                         // si estan massa a prop, llavors si que n'hi ha

            return conflicto;                             // tornem la resposta
        }

        // ESCRIBECONSOLA (ja hi era): escriu per la consola les dades del vol, va be per fer proves
        public void EscribeConsola()
        {
            Console.WriteLine("******************************");          // una ratlla per separar un avio de l'altre
            Console.WriteLine("Datos del vuelo: ");                       // titol
            Console.WriteLine("Identificador: {0}", id);                  // el {0} se substitueix pel valor de id
            Console.WriteLine("Velocidad: {0:F2}", velocidad);            // el :F2 vol dir "amb 2 decimals"
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());   // {0} = la X i {1} = la Y
            if (this.HasArrived())                                        // abans aqui hi havia EstaDestino(), ara es diu HasArrived()
                Console.WriteLine("Ha llegado al destino");               // nomes ho escriu si ja ha arribat
            Console.WriteLine("******************************");          // ratlla de tancar
        }
    }
}
