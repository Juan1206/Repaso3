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
        List<P> l4 = new List<P>();
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
            for (int i = 0; i < lista1.Count; i++)
            {
                for (int j = 0; j < lista2.Count; j++)
                {
                    if (lista1[i].Dpi == lista2[j].Dpi_Propietario)
                    {
                        Dato dato = new Dato();
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
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista3 = lista3.OrderBy(c => c.Cuota_de_Mantenimiento).ToList();
            mostrar();
   

        }
        private void prop_mas_propiedades()
        {
           
          

        }
    }
}
