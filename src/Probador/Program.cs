using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitori;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego(10, 1, 20);

            juego.run();
            
        }
        
    }
}
