using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ejercicio1
{
    public class LoginForm : Form
    {
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new TextBox();
            this.txtPassword = new TextBox();
            this.btnIngresar = new Button();

            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Location = new System.Drawing.Point(12, 12);
            this.txtUsuario.Width = 200;

            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Location = new System.Drawing.Point(12, 40);
            this.txtPassword.Width = 200;
            this.txtPassword.UseSystemPasswordChar = true;

            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Location = new System.Drawing.Point(12, 70);
            this.btnIngresar.Click += new EventHandler(this.btnIngresar_Click);

            this.ClientSize = new System.Drawing.Size(230, 110);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnIngresar);
            this.Text = "Login";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // TODO: validar credenciales utilizando la cadena de conexión
                connection.Open();
            }
        }
    }
}

