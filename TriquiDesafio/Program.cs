namespace TriquiDesafio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jugador = 2;
            int ingreso = 0;
            bool ingresoCorrecto = true;

            do
            {
                if (jugador == 2)
                {
                    jugador = 1;
                    identificarJugador(jugador, ingreso);
                }
                else if (jugador == 1)
                {
                    jugador = 2;
                    identificarJugador(jugador, ingreso);
                }

                Tablero();

                //codigo que verifica si hay un ganador
                #region
                char[] cadaSigno = { 'X', 'O' };
                foreach (char signo in cadaSigno)
                {
                    if ((tableroJuego[0, 0] == signo) && (tableroJuego[0, 1] == signo) && (tableroJuego[0, 2] == signo)
                        || (tableroJuego[1, 0] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[1, 2] == signo)
                        || (tableroJuego[2, 0] == signo) && (tableroJuego[2, 1] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 0] == signo) && (tableroJuego[1, 0] == signo) && (tableroJuego[2, 0] == signo)
                        || (tableroJuego[0, 1] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 1] == signo)
                        || (tableroJuego[0, 2] == signo) && (tableroJuego[1, 2] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 0] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 2] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 0] == signo))
                    {
                        if (signo == 'X')
                        {
                            Console.WriteLine("Felicitaciones, Ha ganado el jugador 2");
                        }
                        else
                        {
                            Console.WriteLine("Felicitaciones, Ha ganado el jugador 1");
                        }
                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego: ");
                        Console.Read();
                        ingreso = 0;
                        Resetear();
                        break;
                    }
                    else if (turnos == 10)
                    {
                        Console.WriteLine("\n¡Empate!");
                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego: ");
                        Console.Read();
                        ingreso = 0;
                        Resetear();
                        break;
                    }
                   
                }
                #endregion

                //codigo que verifica si el valor ingresado en valido
                #region
                do
                {
                    Console.WriteLine("\nJugador {0}: Por favor escoja una casilla...", jugador);
                    try
                    {
                        ingreso = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Por favor, ingre un numero y no una letra");
                    }

                    if ((ingreso == 1) && (tableroJuego[0, 0] == '1'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 2) && (tableroJuego[0, 1] == '2'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 3) && (tableroJuego[0, 2] == '3'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 4) && (tableroJuego[1, 0] == '4'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 5) && (tableroJuego[1, 1] == '5'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 6) && (tableroJuego[1, 2] == '6'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 7) && (tableroJuego[2, 0] == '7'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 8) && (tableroJuego[2, 1] == '8'))
                    {
                        ingresoCorrecto = true;
                    }
                    else if ((ingreso == 9) && (tableroJuego[2, 2] == '9'))
                    {
                        ingresoCorrecto = true;
                    }
                    else
                    {
                        Console.WriteLine("\nPor favor, ingrese otro numero");
                        ingresoCorrecto = false;
                    }
                } while (!ingresoCorrecto);
                #endregion

            } while (true);
        }

        //Metodo para identificar jugador
        public static void identificarJugador(int jugador, int ingreso)
        {
            char signo = ' ';

            if (jugador == 1)
            {
                signo = 'X';
            }
            else if (jugador == 2)
            {
                signo = 'O';
            }

            switch (ingreso)
            {
                case 1:
                    tableroJuego[0, 0] = signo; break;
                case 2:
                    tableroJuego[0, 1] = signo; break;
                case 3:
                    tableroJuego[0, 2] = signo; break;
                case 4:
                    tableroJuego[1, 0] = signo; break;
                case 5:
                    tableroJuego[1, 1] = signo; break;
                case 6:
                    tableroJuego[1, 2] = signo; break;
                case 7:
                    tableroJuego[2, 0] = signo; break;
                case 8:
                    tableroJuego[2, 1] = signo; break;
                case 9:
                    tableroJuego[2, 2] = signo; break;
            }
        }

        //Array que contiene las variables del juego
        static char[,] tableroJuego =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        //Array que contiene las variables del juego inicial
        static char[,] tableroJuegoInicial =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        //varaible para saber si hay un empate
        static int turnos = 0;

        //Metodo que crea el Tablero 
        public static void Tablero()
        {
            Console.Clear();
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tableroJuego[0,0], tableroJuego[0, 1], tableroJuego[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tableroJuego[1, 0], tableroJuego[1, 1], tableroJuego[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tableroJuego[2, 0], tableroJuego[2, 1], tableroJuego[2, 2]);
            Console.WriteLine("     |     |");
            turnos++;
        }

        //Metodo que reinicia todo el juego
        public static void Resetear()
        {
            tableroJuego = tableroJuegoInicial;
            Tablero();
            turnos = 0;
        }
    }
}
