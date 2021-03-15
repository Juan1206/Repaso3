using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso3
{
    public partial class Form1 : Form
    {
        List<Propietario> lista1 = new List<Propietario>();
        List<Propiedad> lista2 = new List<Propiedad>();
        List<Dato> lista3 = new List<Dato>();
      
        public Form1()
        {
            InitializeComponent();
            Leer1();
            Leer2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos();
            lista3 = lista3.OrderBy(n => n.Numero_de_Casa).ToList();
            mostrar();
            prop_mas_propiedades();
            cuotas();
            cuotaMasAlta();

        }
        private void Leer1()
        {
            FileStream stream = new FileStream("propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propietario propietarioTemp = new Propietario();

                propietarioTemp.Dpi = Int32.Parse(reader.ReadLine());
                propietarioTemp.Nombre = reader.ReadLine();
                propietarioTemp.Apellido = reader.ReadLine();
                lista1.Add(propietarioTemp);
            }
            reader.Close();
        }
        private void Leer2()
        {
            FileStream stream = new FileStream("propiedades.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propiedad propiedadTemp = new Propiedad();

               propiedadTemp.No_Casa = Int32.Parse(reader.ReadLine());
                propiedadTemp.Dpi_Propietario = Int32.Parse(reader.ReadLine());
                propiedadTemp.Cuota_de_Mantenimiento = float.Parse(reader.ReadLine());
                lista2.Add(propiedadTemp);
            }
            reader.Close();
        }
        private void datos()
        {
            lista3.Clear();
            for (int i = 0; i < lista1.Count; i++)
            {
                for (int j = 0; j < lista2.Count; j++)
                {
                    if (lista1[i].Dpi == lista2[j].Dpi_Propietario)
                    {
                        Dato dato = new Dato();
                        dato.Dpi =
                        dato.Nombre = lista1[i].Nombre + " " + lista1[i].Apellido;
                        dato.Numero_de_Casa = lista2[j].No_Casa;
                        dato.Cuota_de_Mantenimiento = lista2[j].Cuota_de_Mantenimiento;
                        lista3.Add(dato);
                    }
                }
            }

        }
       private void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista3;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista3 = lista3.OrderBy(c => c.Cuota_de_Mantenimiento).ToList();
            mostrar();
   

        }
        private void prop_mas_propiedades()
        {
            var repetidos = lista3.GroupBy(r => r.Dpi);

            int max = 0;
         
            int pos = 0;

            for (int i = 0; i < repetidos.Count(); i++)
            {
                if (repetidos.ToList()[i].Count() > max)
                {
                    max = repetidos.ToList()[i].Count();
                    pos = i;
                }
            }

            label2.Text ="El propietario con mas propiedades es: " +repetidos.ToList()[pos].Key+ ", el cual tiene " + max.ToString() + " Propiedades";
            



        }
        private void cuotas()
        {
            button2.PerformClick();
            int cuantos = lista3.Count();
            label3.Text = "Las cuotas más Bajas son : " + lista3[0].Cuota_de_Mantenimiento.ToString() + "," + lista3[1].Cuota_de_Mantenimiento.ToString() + "," + lista3[2].Cuota_de_Mantenimiento.ToString();
            label4.Text = "Las cuotas más Altas son : " + lista3[cuantos - 1].Cuota_de_Mantenimiento.ToString() + "," + lista3[cuantos - 2].Cuota_de_Mantenimiento.ToString() + "," + lista3[cuantos - 3].Cuota_de_Mantenimiento.ToString();


        }
        private void cuotaMasAlta()
        {
            var agrupado = lista3.GroupBy(r => r.Dpi);

            double maxCuota = 0;
            string maxNombre = "";

            foreach (var grupo in agrupado)
            {

                double sumaCuota = 0;
                string nombre = "";

                foreach (var p in grupo)
                {
                    sumaCuota += p.Cuota_de_Mantenimiento;
                    nombre = p.Nombre;
                }

                if (sumaCuota > maxCuota)
                {
                    maxCuota = sumaCuota;
                    maxNombre = nombre ;
                }
            }
            label5.Text ="El propietario con la Cuota mas alta es: "+maxNombre+", quien tiene una cuota de "+ maxCuota.ToString();

        }

    }
}
