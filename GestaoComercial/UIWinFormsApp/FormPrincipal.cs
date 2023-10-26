namespace UIWinFormsApp
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarUsuario frm = new FormBuscarUsuario())
            {
                frm.ShowDialog();
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarProduto frm = new FormBuscarProduto())
            {
                frm.ShowDialog();
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarCliente frm = new FormBuscarCliente())
            {
                frm.ShowDialog();
            }
        }
    }
}