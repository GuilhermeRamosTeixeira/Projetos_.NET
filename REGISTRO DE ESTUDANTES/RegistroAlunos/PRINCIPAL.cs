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
    public partial class PRINCIPAL : Form
    {
        Cadastro cadastro;


        public PRINCIPAL()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Estudante.series);

        }

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            cadastro = new Cadastro();
            cadastro.ShowDialog();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                Editar editar = new Editar(listView1.SelectedItems[0].Text.ToString());

                editar.Show();
            }
            catch
            {
                MessageBox.Show("Selecione um registro para edittar");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            ListViewItem[] ListaCompleta = BuscaRegistros();

            listView1.Items.AddRange(ListaCompleta);
            
        }

        public List<ListViewItem> BuscaRegistros(string nome, string serie)
        {
            List<ListViewItem> totalRegistrados = new List<ListViewItem>();

            for (int registro = 0; registro < Estudante.lista_Estudantes.Count; registro++)
            {
                string filtroSerie = serie == null ?   Estudante.lista_Estudantes[registro].Serie : serie;
                string filtroNome = nome == null ?  Estudante.lista_Estudantes[registro].Nome : nome;


                if (Estudante.lista_Estudantes[registro].Nome.ToUpper().Contains(filtroNome.ToUpper())&&
                     Estudante.lista_Estudantes[registro].Serie.ToUpper() == filtroSerie.ToUpper())
                {

                    ListViewItem novo = new ListViewItem(Estudante.lista_Estudantes[registro].Nome);
                    novo.SubItems.Add(Estudante.lista_Estudantes[registro].email);
                    novo.SubItems.Add(Estudante.lista_Estudantes[registro].telefone);
                    novo.SubItems.Add(Estudante.lista_Estudantes[registro].Idade.ToString());
                    novo.SubItems.Add(Estudante.lista_Estudantes[registro].Serie);
                    novo.SubItems.Add(Estudante.lista_Estudantes[registro].Sexo.ToString());

                    totalRegistrados.Add( novo);
                }
            }
            return totalRegistrados;
        }

        public ListViewItem[] BuscaRegistros()
        {
            ListViewItem[] totalRegistrados = new ListViewItem[Estudante.lista_Estudantes.Count];

            for (int registro = 0; registro < Estudante.lista_Estudantes.Count; registro++)
            {
                ListViewItem novo = new ListViewItem(Estudante.lista_Estudantes[registro].Nome);
                novo.SubItems.Add(Estudante.lista_Estudantes[registro].email);
                novo.SubItems.Add(Estudante.lista_Estudantes[registro].telefone);
                novo.SubItems.Add(Estudante.lista_Estudantes[registro].Idade.ToString());
                novo.SubItems.Add(Estudante.lista_Estudantes[registro].Serie);
                novo.SubItems.Add(Estudante.lista_Estudantes[registro].Sexo.ToString());

                totalRegistrados[registro] = novo;
            }
            return totalRegistrados;
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                Estudante registroDeletar = Estudante.lista_Estudantes
               .Where(x => x.Nome == listView1.SelectedItems[0].Text.ToString()).First();

                Estudante.lista_Estudantes.Remove(registroDeletar);

                button1_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Selecione um Registro");
            }


        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {

                string nome = textBox2.Text == "" ? null : textBox2.Text;
                string serie = comboBox1.SelectedItem == null ? null :
                               comboBox1.SelectedItem.ToString();

                if (textBox2.Text != null || comboBox1.SelectedItem.ToString() != null)
                {
                    List<ListViewItem> ListaCompleta = BuscaRegistros(nome, serie);

                    if (!ListaCompleta.Any())
                    {
                        MessageBox.Show("Nenhum registro encontrado. Verifique os filtros");
                        textBox2.Text = null;
                    }
                    else
                        listView1.Items.AddRange(ListaCompleta.ToArray());
                }
                comboBox1.Text = null;
            }
            catch
            {
            }
        }
    }
}
