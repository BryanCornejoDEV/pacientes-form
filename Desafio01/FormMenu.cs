using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desafio01
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddPaciente formpaciente = new FormAddPaciente(this);
            formpaciente.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoPacientes formlistado = new ListadoPacientes(this);
            formlistado.Show();
            this.Hide();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
