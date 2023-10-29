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
    public partial class Cadastro : Form
    {
        
        public Cadastro()
        {

            InitializeComponent();
            comboBox1.Items.AddRange(Estudante.series);
            comboBox1.SelectedItem= comboBox1.Items[0];
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                char sexo = ' ';
                if (radioButton1.Checked)
                    sexo = 'M';
                if (radioButton2.Checked)
                    sexo = 'F';
                if (radioButton3.Checked)
                    sexo = 'O';

                Estudante novo = new Estudante(
                    textBox1.Text,
                    Convert.ToInt32(textBox4.Text),
                    comboBox1.SelectedItem.ToString(),
                    sexo,
                    textBox2.Text,
                    textBox3.Text
                    );

                Estudante.lista_Estudantes.Add(novo);
            }
            catch
            {
                MessageBox.Show("Todos os camos são obrigatórios.Tente novamente");
                Close();
            }

            Close();
        }
    }
}
