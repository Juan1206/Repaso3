using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso3
{
    class Dato
    {
        string nombre;
        int numero_de_Casa;
        float cuota_de_Mantenimiento;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero_de_Casa { get => numero_de_Casa; set => numero_de_Casa = value; }
        public float Cuota_de_Mantenimiento { get => cuota_de_Mantenimiento; set => cuota_de_Mantenimiento = value; }
    }
}
