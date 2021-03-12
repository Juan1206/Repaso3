using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso3
{
    class Propiedad
    {
        int no_Casa;
        int dpi_Propietario;
        float cuota_de_Mantenimiento;

        public int No_Casa { get => no_Casa; set => no_Casa = value; }
        public int Dpi_Propietario { get => dpi_Propietario; set => dpi_Propietario = value; }
        public float Cuota_de_Mantenimiento { get => cuota_de_Mantenimiento; set => cuota_de_Mantenimiento = value; }
    }
}
