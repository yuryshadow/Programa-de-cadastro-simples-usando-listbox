using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1: Form
    {

        private Pessoa pessoa;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adicionando os itens ao ComboBox
            string[]items = new string[] {"Solteiro", "Casado", "Divorciado"};
            comboEC.Items.AddRange(items);

        }

        public void limparCampos()
        {
            txtNome.Clear();
            txtData.Value = DateTime.Now;
            comboEC.SelectedIndex = -1;
            txtTelefone.Clear();
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = false;
            radioF.Checked = false;
            radioO.Checked = false;
        }
        
        public void cadastrarPessoa()
        {
            pessoa = new Pessoa();

            pessoa.Nome = txtNome.Text;
            pessoa.DataNascimento = txtData.Text;
            pessoa.EstadoCivil = comboEC.Text;
            pessoa.Telefone = txtTelefone.Text;
            pessoa.casaPropria = checkCasa.Checked;
            pessoa.Veiculo = checkVeiculo.Checked;

            if (radioM.Checked)
            {
                pessoa.Sexo = 'M';
            }
            else if (radioF.Checked)
            {
                pessoa.Sexo = 'F';
            }
            else
            {
                pessoa.Sexo = 'O';
            }
        }
        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int indiceParaAlterar = lista.SelectedIndex;
            pessoa = new Pessoa();


            if (lista.SelectedIndex == -1)
            {
                cadastrarPessoa();
                limparCampos();

                // Exibir os dados cadastrados em um listbox
                lista.Items.Add($"{pessoa.Nome} | {pessoa.DataNascimento} | {pessoa.EstadoCivil} | {pessoa.Telefone} | {pessoa.casaPropria}" +
                    $" | {pessoa.Veiculo} | {pessoa.Sexo} |");

            }
            else
            {

                cadastrarPessoa();
                limparCampos();

                //Atualizar nova informação no listbox
                lista.Items.RemoveAt(lista.SelectedIndex);
                lista.Items.Insert(indiceParaAlterar, ($"{pessoa.Nome} | {pessoa.DataNascimento} | {pessoa.EstadoCivil} | {pessoa.Telefone} | {pessoa.casaPropria}" +
                    $" | {pessoa.Veiculo} | {pessoa.Sexo} |"));
            }
        }
 
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Verificando se tem algum item selecionado
            if (lista.SelectedIndex != -1)
            {
                lista.Items.RemoveAt(lista.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item para excluir.");
            }

            //Excluindo o objeto do item selecionado:
            if (lista.SelectedItem != null)
            {
                lista.Items.Remove(lista.SelectedItem);              
            }

            //Limpar os campos
            limparCampos();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lista.Items.Clear();
        }

        private void lista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lista.SelectedIndex != -1)
            {
                string itemSelecionado = lista.SelectedItem.ToString();
                string[] partes = itemSelecionado.Split('|');
                
                if(partes.Length >= 7)
                {
                    txtNome.Text = partes[0].Trim();
                    txtData.Text = partes[1].Trim();
                    comboEC.Text = partes[2].Trim();
                    txtTelefone.Text = partes[3].Trim();
                    checkCasa.Checked = partes[4].Trim() == "True";
                    checkVeiculo.Checked = partes[5].Trim() == "True";
                    string sexo = partes[6].Trim();

                    radioM.Checked = sexo == "M";
                    radioF.Checked = sexo == "F";
                    radioO.Checked = sexo == "O";

                }
            }
        }
    }
}
