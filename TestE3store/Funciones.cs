using System;
using System.Collections.Generic;
using System.Text;

namespace TestE3store
{
    public class Funciones
    {
        public bool validName(string nombre)
        {
            var nombreEspacios = nombre.Split(" ");

            //c. dos nombres y un apellido
            if (nombreEspacios.Length != 2 && nombreEspacios.Length != 3)
                return false;

            //d. nunca inicial primer nombre y no el segundo
            if (nombreEspacios.Length == 3 && (nombreEspacios[1].Length != 2 || !nombreEspacios[1].EndsWith(".")))
                return false;

            //e. apellido siempre es una palabra
            if (nombreEspacios.Length == 3 && (nombreEspacios[2].Length < 2 || nombreEspacios[2].EndsWith(".")))
                return false;

            foreach (var x in nombreEspacios)
            {
                //a. debe empezar con mayuscula 
                if (!Char.IsUpper(x, 0))
                    return false;

                //b. terminar en .
                if (x.Length < 2 || (x.Length == 2 && !x.EndsWith(".")))
                    return false;
            }

            return true;
        }

        public string simplificar(string fraccion)
        {
            var f = fraccion.Split("/");
            var primos = new int[] { 2, 3, 5, 7 };

            var n = Convert.ToInt32(f[0]);
            var d = Convert.ToInt32(f[1]);

            int n1 = n;
            int d1 = d;

            int cont = 0;

            foreach(var p in primos)
            {
                try
                {
                    while (cont <= primos.Length)
                    {
                        fraccion = $"{n}/{d}";

                        n1 = n;
                        d1 = d;

                        int r1, r2;

                        n1 = Math.DivRem(n, p, out r1);
                        d1 = Math.DivRem(d, p, out r2);

                        if (r1 != 0 || r2 != 0)
                            throw new Exception();

                        n = n1;
                        d = d1;
                    }
                }
                catch
                {
                    cont++;

                    continue;
                }

            }

            return fraccion;
        }
    }
}
