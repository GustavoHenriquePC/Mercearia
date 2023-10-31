using BLL;

namespace UIWinFormsApp
{
    public partial class FormLogin : Form
    {
        public bool Autenticou;
        public FormLogin()
        {
            InitializeComponent();
            Autenticou = false;
        }
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                new UsuarioBLL().Autenticar(textBoxNomeDeUsuario.Text, textBoxSenha.Text);                    
                Autenticou = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
