using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMain.Funciones_de_Validaciones
{
    public class Validacion
    {
        public int SoloNumero(int tecla)
        {
            switch (tecla)
            {
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 46:
                case 08:
                case 13:
                    return tecla;
                    
                default:
                    break;

            }

            return tecla = 0;
        }
    }
}
