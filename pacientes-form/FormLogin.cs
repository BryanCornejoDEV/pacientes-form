namespace Desafio01
{
    public partial class FormLogin : Form
    {

        private string usuario = "admin";
        private string contraseña = "admin";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == usuario && txtpassword.Text == contraseña)
            {
                FormMenu formmenu = new FormMenu();
                formmenu.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Error en las credenciales, verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
