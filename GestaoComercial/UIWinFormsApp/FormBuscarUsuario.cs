using BLL;
using Models;

namespace UIWinFormsApp
{
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxBuscarPor.SelectedIndex)
                {
                    case 0:
                        bindingSourceUsuario.DataSource = new UsuarioBLL().BuscarPorNome(textBoxBuscarPor.Text);
                        break;
                    case 1:
                        bindingSourceUsuario.DataSource = new UsuarioBLL().BuscarPorNomeUsuario(textBoxBuscarPor.Text);
                        break;
                    default:
                        bindingSourceUsuario.DataSource = new UsuarioBLL().BuscarTodos();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonInserir_Click(object sender, EventArgs e)
        {
            using (FormCadastrarUsuario frm = new FormCadastrarUsuario())
            {
                frm.ShowDialog();
            }
        }
        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)bindingSourceUsuario.Current).Id;

            using (FormCadastrarUsuario frm = new FormCadastrarUsuario(id))
            {
                frm.ShowDialog();
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esse registro?","Atenção", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            int id = ((Usuario)bindingSourceUsuario.Current).Id;
            new UsuarioBLL().Excluir(id);
            bindingSourceUsuario.RemoveCurrent();
            MessageBox.Show("REgistro excluido com sucesso!");
        }

        private void comboBoxBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormBuscarUsuario_Load(object sender, EventArgs e)
        {
            comboBoxBuscarPor.SelectedIndex = 0;
            buttonBuscar_Click(null, null);
        }
    }
}
