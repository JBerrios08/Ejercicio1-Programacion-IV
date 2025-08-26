using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        private readonly List<ItemVenta> items = new List<ItemVenta>();
        private const decimal IVA_RATE = 0.13m;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            button1.Click += button1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            var productos = new List<Producto>();
            using (var cn = new MySqlConnection("server=localhost;database=restaurante;uid=root;pwd=;"))
            {
                cn.Open();
                var cmd = new MySqlCommand("SELECT id,nombre,precio FROM productos", cn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        productos.Add(new Producto
                        {
                            Id = dr.GetInt32("id"),
                            Nombre = dr.GetString("nombre"),
                            Precio = dr.GetDecimal("precio")
                        });
                    }
                }
            }

            comboBox1.DataSource = productos;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Producto prod)
            {
                items.Add(new ItemVenta(prod, 1));
            }

            RegistrarVenta();
        }

        private void RegistrarVenta()
        {
            if (items.Count == 0)
                return;

            decimal subtotal = items.Sum(i => i.Subtotal);
            decimal iva = subtotal * IVA_RATE;
            decimal total = subtotal + iva;

            textBox2.Text = subtotal.ToString("0.00");
            textBox1.Text = total.ToString("0.00");

            using (var cn = new MySqlConnection("server=localhost;database=restaurante;uid=root;pwd=;"))
            {
                cn.Open();
                foreach (var item in items)
                {
                    var cmd = new MySqlCommand("INSERT INTO ventas (producto_id, cantidad, subtotal, iva, total) VALUES (@prod,@cant,@sub,@iva,@tot)", cn);
                    cmd.Parameters.AddWithValue("@prod", item.Producto.Id);
                    cmd.Parameters.AddWithValue("@cant", item.Cantidad);
                    cmd.Parameters.AddWithValue("@sub", item.Subtotal);
                    cmd.Parameters.AddWithValue("@iva", iva);
                    cmd.Parameters.AddWithValue("@tot", total);
                    cmd.ExecuteNonQuery();
                }
            }

            items.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
