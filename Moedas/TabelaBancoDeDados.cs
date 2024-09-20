using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moedas
{
    public partial class TabelaBancoDeDados : Form
    {
        public TabelaBancoDeDados()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numismatico");

        private void TabelaBancoDeDados_Load(object sender, EventArgs e)
        {
            FillDGV();
        }

        public void FillDGV()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `moedas`", conn);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView1.RowTemplate.Height = 60;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = table;

            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            imgcol = (DataGridViewImageColumn)dataGridView1.Columns[13];
            imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
