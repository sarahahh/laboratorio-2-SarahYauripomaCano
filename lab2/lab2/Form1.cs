using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ESTO ES UN ERROR QUE NO PUEDO ELIMINAR
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //ESTO ES UN ERROR QUE NO PUEDO ELIMINAR
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //ESTO ES UN ERROR QUE NO PUEDO ELIMINAR
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // INICIO DE FUNCIONES 

        // asignacion de tipo de funcion a la variable "seleccion"

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String seleccion = comboBox1.SelectedItem.ToString();
        }

        // encontrar datos por medio de string

        private void button1_Click(object sender, EventArgs e)
        {
            // variables
            String ec1;
            int indexM1;
            int indexX1;
            String pendiente1;
            int indexB1;
            String intercep1;
            //
            String ec2;
            int indexM2;
            int indexX2;
            String pendiente2;
            int indexB2;
            String intercep2;
            //
            int indexB12;
            int indexB22;

            // seleccion = y = mx + b

            if (comboBox1.SelectedItem.ToString() == "y =mx + b")
            {
                // rango de ec1 (y =mx + b)

                ec1 = textBox1.Text;

                indexM1 = ec1.IndexOf('=') + 1;
                indexX1 = ec1.IndexOf('x') - 2;

                pendiente1 = ec1.Substring(indexM1, indexX1);

                indexB1 = ec1.IndexOf('+') + 1;

                intercep1 = ec1.Substring(indexB1);

                // rango de ec2 (y = mx + b)

                ec2 = textBox2.Text;

                indexM2 = ec2.IndexOf('=') + 1;
                indexX2 = ec2.IndexOf('x') - 2;

                pendiente2 = ec2.Substring(indexM2, indexX2);

                indexB2 = ec2.IndexOf('+') + 1;

                intercep2 = ec2.Substring(indexB2);

                // llamar funcion

                float pendiente1Float = float.Parse(pendiente1.Trim()[0].ToString());
                float pendiente2Float = float.Parse(pendiente2.Trim()[0].ToString());
                var intercep1Float = float.Parse(intercep1.Trim());
                float intercep2Float = float.Parse(intercep2.Trim());

                operaciones1(pendiente1Float, pendiente2Float, intercep1Float, intercep2Float);

            }

            // seleccion = y - y1 = m (x - x1 )

            else if (comboBox1.SelectedItem.ToString() == "y – y1 =m (x – x1)")
            {
                // rango de ec1 ( y - y1 = m (x - x1 ) )

                ec1 = textBox1.Text;

                indexB1 = ec1.IndexOf('-') + 1;
                indexB12 = ec1.IndexOf('=') - 2;

                intercep1 = ec1.Substring(indexB1, indexB12);

                indexM1 = ec1.IndexOf('=') + 1;
                indexX1 = ec1.IndexOf('(') - 2;

                pendiente1 = ec1.Substring(indexM1, indexX1);

                //rango de ec2 ( y - y1 = m (x - x1 ) )

                ec2 = textBox2.Text;

                indexB2 = ec1.IndexOf('-') + 1;
                indexB22 = ec1.IndexOf('=') - 2;

                intercep2 = ec2.Substring(indexB2, indexB22);

                indexM2 = ec1.IndexOf('=') + 1;
                indexX2 = ec1.IndexOf('(') - 2;

                pendiente2 = ec2.Substring(indexM2, indexX2);

                // llamar funcion 
                float pendiente1Float = float.Parse(pendiente1.Trim()[0].ToString());
                float pendiente2Float = float.Parse(pendiente2.Trim()[0].ToString());
                float intercep1Float = float.Parse(intercep1.Trim());
                float intercep2Float = float.Parse(intercep2.Trim());

                operaciones2(pendiente1Float, pendiente2Float, intercep1Float, intercep2Float);

            }
        }

        // funcion para hallar solucion de la forma (y = mx + b)

        public void operaciones1(float pendiente1, float intercep1, float pendiente2, float intercep2)
        {
            if (pendiente1 == pendiente2)
            {
                MessageBox.Show("Las rectas son paralelas");
            }
            else if (pendiente1 != pendiente2)
            {
                float result1 = pendiente1 * pendiente2;
                float result2 = (intercep2 - intercep1) / (pendiente1 - pendiente2);
                float result3 = (pendiente1 * result2) + intercep1;

                if (result1 == -1)
                {
                    MessageBox.Show("Las rectas son perpendiculares");

                }
                else
                {
                    MessageBox.Show("Las rectas se cruzan en :" + "(" + result2 + "," + result3 + ")");

                }
            }

        }

        // funcion para hallar solucion de la forma ( y - y1 = m (x - x1 ) )

        public void operaciones2(float pendiente1, float intercep1, float pendiente2, float intercep2)
        {
            float result1 = pendiente1 * pendiente2;
            float result2 = (intercep2 - intercep1) / (pendiente1 - pendiente2);
            float result3 = (pendiente1 * result2) + intercep1;

            if (pendiente1 == pendiente2)
            {
                MessageBox.Show("Las rectas son paralelas");
            }
            else if (pendiente1 != pendiente2)
            {
                if (result1 == -1)
                {
                    MessageBox.Show("Las rectas son perpendiculares");
                }
                else
                {
                    MessageBox.Show("Las rectas se cruzan en :" + "(" + result2 + "," + result3 + ")");
                }
            }
        }
    }
}

