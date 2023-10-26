using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIWinFormsApp
{
    public partial class FormBuscarCliente : Form
    {
        public FormBuscarCliente()
        {
            InitializeComponent();
        }

        private void labelBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxBuscarPor.SelectedIndex)
                {
                    case 0:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorNome(textBoxBuscarPor.Text);
                        break;
                    case 1:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorId(Convert.ToInt32(textBoxBuscarPor.Text));
                        break;
                    default:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarTodos();
                        break;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
