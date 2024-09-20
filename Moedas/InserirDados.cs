using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Moedas
{
    public partial class InserirDados : Form
    {
        public InserirDados()
        {
            InitializeComponent();
        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        private void InserirDados_Load(object sender, EventArgs e)
        {
            lblErro.Text = "";

            tcInsercao.Appearance = TabAppearance.FlatButtons; tcInsercao.ItemSize = new Size(0, 1); tcInsercao.SizeMode = TabSizeMode.Fixed;
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTabela_Click(object sender, EventArgs e)
        {
            TabelaBancoDeDados tabelaBancoDeDados = new TabelaBancoDeDados();
            tabelaBancoDeDados.Show();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Choose Image(*.JPG;*.PNG;)|*.JPG;*.PNG";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                imagemCarregada.img = (Bitmap)pictureBox1.Image;  // Armazena a imagem carregada na variável global
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }


        //BOTÃO PROXIMO


        private void btnProximo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Os dados inseridos estão Corretos", "Revisão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                if (string.IsNullOrWhiteSpace(dtpDataAqui.Text) ||
                    string.IsNullOrWhiteSpace(nupValorAqui.Text) ||
                    string.IsNullOrWhiteSpace(txbLocalAqui.Text) ||
                    string.IsNullOrWhiteSpace(txbConservacao.Text) ||
                    string.IsNullOrWhiteSpace(txbCertificados.Text))
                {
                    // Exibe uma mensagem informando que todos os campos devem ser preenchidos
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return; // Interrompe a execução da ação
                }
                else
                {

                    try
                    {
                        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numismatico");

                        conn.Open();

                        MySqlCommand command = new MySqlCommand("INSERT INTO `colecao` (`dataAquisicao`, `valorAquisicao`, `localAquisicao`, `condicaoConservacao`, `certificadosAutenticidade`) VALUES (@DataAqui,@ValorAqui,@LocalAqui,@Conservacao,@Certificados)", conn);

                        command.Parameters.AddWithValue("@DataAqui", dtpDataAqui.Value.ToString("dd-MM-yyyy"));

                        command.Parameters.AddWithValue("@ValorAqui", Convert.ToDecimal(nupValorAqui.Value));

                        command.Parameters.AddWithValue("@LocalAqui", txbLocalAqui.Text);

                        command.Parameters.AddWithValue("@Conservacao", txbConservacao.Text);

                        command.Parameters.AddWithValue("@Certificados", txbCertificados.Text);

                        command.ExecuteNonQuery();

                        MySqlCommand puxar = new MySqlCommand("SELECT LAST_INSERT_ID() AS last_id FROM `colecao`;", conn);

                        object idPuxar = puxar.ExecuteScalar();

                        if (idPuxar != null)
                        {
                            AcharID.id = Convert.ToInt32(idPuxar);
                        }

                        conn.Close();
                    }
                    catch (Exception ex)
                    { lblErro.Text = ex.Message; }
                    finally
                    {

                        tcInsercao.SelectTab(1);
                        btnProximo.Enabled = false;
                        btnProximo.Visible = false;

                        btnSalvar.Enabled = true;
                        btnSalvar.Visible = true;
                    }
                }
            }
        }


        //BOTÃO SALVAR


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Os dados inseridos estão Corretos", "Revisão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                if (string.IsNullOrWhiteSpace(txbNome.Text) ||
                    string.IsNullOrWhiteSpace(txbPaisDeOrigem.Text) ||
                    string.IsNullOrWhiteSpace(dtpDataEmissao.Text) ||
                    string.IsNullOrWhiteSpace(nupValorFacial.Text) ||
                    string.IsNullOrWhiteSpace(txbMetal.Text) ||
                    string.IsNullOrWhiteSpace(txbPeso.Text) ||
                    string.IsNullOrWhiteSpace(txbDiametro.Text) ||
                    string.IsNullOrWhiteSpace(txbVariedades.Text) ||
                    string.IsNullOrWhiteSpace(txbDescricao.Text)) 
                {
                    // Exibe uma mensagem informando que todos os campos devem ser preenchidos
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return; // Interrompe a execução da ação
                }

                if (pictureBox1.Image == null)
                {
                    // Exibe uma mensagem informando que a imagem deve ser selecionada
                    MessageBox.Show("Por favor, selecione uma imagem.");
                    return; // Interrompe a execução da ação
                }
                else
                {

                    try
                    {
                        using (Bitmap bitmap = new Bitmap(imagemCarregada.img))
                        {

                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitmap.Save(ms, imagemCarregada.img.RawFormat); // Usa o formato correto da imagem
                                byte[] imageBytes = ms.ToArray();

                                int id = AcharID.id;

                                MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=numismatico");

                                conn.Open();
                                MessageBox.Show("Conexão estabelecida com sucesso!");

                                MySqlCommand command = new MySqlCommand("INSERT INTO `moedas`(`nome`,`paisDeOrigem`, `dataDeEmissao`, `valorFacial`, `metal`, `peso`, `diametro`, `variedades`, `descricaoDetalhada`, `marcaDagua`, `numeracaoDeSerie`, `errosDeCunhagem`, `outrosDetalhes`, `image`, `chaveEstrangeira`) VALUES (@Nome,@PaisOrigem,@DataEmissao,@ValorFacial,@Metal,@Peso,@Diametro,@Variedades,@Descricao,@MarcaDaAgua,@NumeracaoSerie,@ErrosCunhagem,@OutrosDetalhes,@Image,@ChaveEstrangeira)", conn);

                                command.Parameters.AddWithValue("@Nome", txbNome.Text);

                                command.Parameters.AddWithValue("@PaisOrigem", txbPaisDeOrigem.Text);

                                command.Parameters.AddWithValue("@DataEmissao", dtpDataEmissao.Value.ToString("dd-MM-yyyy"));

                                command.Parameters.AddWithValue("@ValorFacial", Convert.ToDecimal(nupValorFacial.Value));

                                command.Parameters.AddWithValue("@Metal", txbMetal.Text);

                                command.Parameters.AddWithValue("@Peso", txbPeso.Text);

                                command.Parameters.AddWithValue("@Diametro", txbDiametro.Text);

                                command.Parameters.AddWithValue("@Variedades", txbVariedades.Text);

                                command.Parameters.AddWithValue("@Descricao", txbDescricao.Text);

                                command.Parameters.AddWithValue("@MarcaDaAgua", txbMarcaDaAgua.Text);

                                command.Parameters.AddWithValue("@NumeracaoSerie", tbNumeracaoSerie.Text);

                                command.Parameters.AddWithValue("@ErrosCunhagem", txbErrosCunhagem.Text);

                                command.Parameters.AddWithValue("@OutrosDetalhes", txbOutrosDetalhes.Text);

                                command.Parameters.AddWithValue("@Image", imageBytes);

                                command.Parameters.AddWithValue("@ChaveEstrangeira", id);

                                command.ExecuteNonQuery();

                                conn.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    { lblErro2.Text = ex.Message; }
                    finally
                    {
                        tcInsercao.SelectTab(0);
                        btnProximo.Enabled = true;
                        btnProximo.Visible = true;

                        btnSalvar.Enabled = false;
                        btnSalvar.Visible = false;


                        //Tabela Coleção
                        dtpDataAqui.Text = "";
                        nupValorAqui.Value = 0;
                        txbLocalAqui.Text = "";
                        txbConservacao.Text = "";
                        txbCertificados.Text = "";

                        //Tabela Moedas
                        txbNome.Text = "";
                        txbPaisDeOrigem.Text = "";
                        dtpDataEmissao.Text = "";
                        nupValorFacial.Text = "";
                        txbMetal.Text = "";
                        txbPeso.Text = "";
                        txbDiametro.Text = "";
                        txbVariedades.Text = "";
                        txbDescricao.Text = "";

                        pictureBox1.Image = null;
                    }
                }

               
            }
        }
    }
}

        
    
    

