using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAlunos
{
    public partial class Editar : Form
    {
        private Estudante selecionado { get; set; }

        

        public Editar(string estudanteSelecionado)
        {
            Estudante registro = Estudante.lista_Estudantes.Where
                (x => x.Nome == estudanteSelecionado).First();

            selecionado = registro;

            InitializeComponent(); 
            comboBox1.Items.AddRange(Estudante.series);

            textBox1.Text = registro.Nome;
            textBox2.Text = registro.email;
            textBox3.Text = registro.telefone;
            textBox4.Text = registro.Idade.ToString();
            comboBox1.SelectedItem= comboBox1.Items[comboBox1.Items.IndexOf(registro.Serie)] ; 
            switch (registro.Sexo)
            {
                case 'M':
                    radioButton1.Checked = true;
                    break;
                case 'F':
                    radioButton2.Checked = true;
                    break;
                case 'O':
                    radioButton3.Checked = true;
                    break;
            }

            textBox1.Enabled = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Estudante.lista_Estudantes.ForEach(x =>
            {
                if(x == selecionado)
                {
                    x.Nome = textBox1.Text;
                    x.email = textBox2.Text;
                    x.telefone = textBox3.Text;
                    x.Idade = int.Parse(textBox4.Text);
                    x.Serie = comboBox1.SelectedItem.ToString();

                    if (radioButton1.Checked)
                        x.Sexo = 'M';
                    if (radioButton2.Checked)
                        x.Sexo = 'F';
                    if (radioButton3.Checked)
                        x.Sexo = 'O';
                }
            });
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        
