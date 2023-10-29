using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidacaoCampos(textBox1.Text, textBox2.Text))
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                decimal valor1 = decimal.Parse(textBox1.Text);
                decimal valor2 = decimal.Parse(textBox2.Text);
                decimal resultado = valor1 + valor2;
                textBox3.Text = resultado.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!ValidacaoCampos(textBox1.Text, textBox2.Text))
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                decimal valor1 = decimal.Parse(textBox1.Text);
                decimal valor2 = decimal.Parse(textBox2.Text);
                decimal resultado = valor1 - valor2;
                textBox3.Text = resultado.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!ValidacaoCampos(textBox1.Text, textBox2.Text))
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                decimal valor1 = decimal.Parse(textBox1.Text);
                decimal valor2 = decimal.Parse(textBox2.Text);

                if (valor2 == 0)
                {
                    MessageBox.Show("NÃO É POSSIVEL DIViDIR POR ZERO");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    decimal resultado = valor1 / valor2;
                    textBox3.Text = resultado.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (!ValidacaoCampos(textBox1.Text, textBox2.Text))
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                decimal valor1 = decimal.Parse(textBox1.Text);
                decimal valor2 = decimal.Parse(textBox2.Text);

                if (valor2 == 0)
                {
                    MessageBox.Show("NÃO É POSSIVEL MULTIPLICAR POR ZERO");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {

                    decimal resultado = valor1 * valor2;
                    textBox3.Text = resultado.ToString();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private bool ValidacaoCampos(string x, string y)
        {
            try
            {
                Convert.ToDecimal(x);
                Convert.ToDecimal(y);
                return true;
            }
            catch
            {
                MessageBox.Show("INSIRA DOIS NUMEROS PARA CALCULAR");
                return false;
            }

        }
    }
}
