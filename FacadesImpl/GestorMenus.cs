using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace MeteDatosEventos.FacadesImpl
{
    class GestorMenus
    {
        private int IndiceSeleccionado;
        private string [] Opciones;
        private string Prompt ;
        private string Footer;
      
        public GestorMenus(string prompt,string[] opciones, string footer)
        {
            Prompt = prompt;
            Opciones = opciones;
            Footer = footer;
            IndiceSeleccionado = 0; 

        }
        private void ImprimirOpciones()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n");
            Console.WriteLine(Prompt);
            Console.WriteLine("\n\n");
            Console.WriteLine(Footer);
            Console.WriteLine("");


            for ( int i = 0; i <Opciones.Length; i++)
            {
                string opcionActual = Opciones[i];
                string prefix;
                if(i == IndiceSeleccionado)
                {
                    prefix = "                             >>";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "                              ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }

                Console.WriteLine($"{prefix} {i+1} : {opcionActual} ");
            }
          

        }

        public int Run()
        {
            ConsoleKey teclaPresionada;

            do
            {
                Console.Clear();
                ImprimirOpciones();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                teclaPresionada = keyInfo.Key;


                if (teclaPresionada == ConsoleKey.UpArrow)
                {
                    IndiceSeleccionado--;
                    Console.Beep(frequency: 700, 100);
                    if (IndiceSeleccionado == -1)
                    {
                        IndiceSeleccionado =0;
                    }
                }
                else if (teclaPresionada == ConsoleKey.DownArrow)
                {
                    IndiceSeleccionado++;
                    Console.Beep(700, 100);
                    if (IndiceSeleccionado == Opciones.Length)
                    {
                        IndiceSeleccionado = Opciones.Length-1;
                    }
                }

            } while (teclaPresionada != ConsoleKey.Enter);
            
            return IndiceSeleccionado;
        }
    }
}
