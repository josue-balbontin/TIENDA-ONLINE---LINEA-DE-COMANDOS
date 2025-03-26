using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_Online
{
    class Errores
    {
        public int cin()
        {
            string entrada;
            int n;
            do
            {

                entrada=Console.ReadLine();
                


            } while(!int.TryParse(entrada, out  n));
            return n;

        }











    }
}
