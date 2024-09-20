namespace Moedas
{
    partial class searchResultControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchResultControl));
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMetal = new System.Windows.Forms.Label();
            this.lblDataAquisicao = new System.Windows.Forms.Label();
            this.roundedPicturebox1 = new Moedas.roundedPicturebox();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPicturebox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(64, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nome Moeda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(181)))), ((int)(((byte)(0)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 43);
            this.panel1.TabIndex = 2;
            // 
            // lblMetal
            // 
            this.lblMetal.AutoSize = true;
            this.lblMetal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetal.Location = new System.Drawing.Point(64, 21);
            this.lblMetal.Name = "lblMetal";
            this.lblMetal.Size = new System.Drawing.Size(40, 16);
            this.lblMetal.TabIndex = 3;
            this.lblMetal.Text = "Metal";
            // 
            // lblDataAquisicao
            // 
            this.lblDataAquisicao.AutoSize = true;
            this.lblDataAquisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAquisicao.ForeColor = System.Drawing.Color.Silver;
            this.lblDataAquisicao.Location = new System.Drawing.Point(193, 21);
            this.lblDataAquisicao.Name = "lblDataAquisicao";
            this.lblDataAquisicao.Size = new System.Drawing.Size(63, 16);
            this.lblDataAquisicao.TabIndex = 4;
            this.lblDataAquisicao.Text = "DataAqui";
            // 
            // roundedPicturebox1
            // 
            this.roundedPicturebox1.Image = ((System.Drawing.Image)(resources.GetObject("roundedPicturebox1.Image")));
            this.roundedPicturebox1.Location = new System.Drawing.Point(15, 0);
            this.roundedPicturebox1.Name = "roundedPicturebox1";
            this.roundedPicturebox1.Size = new System.Drawing.Size(43, 43);
            this.roundedPicturebox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundedPicturebox1.TabIndex = 5;
            this.roundedPicturebox1.TabStop = false;
            // 
            // searchResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundedPicturebox1);
            this.Controls.Add(this.lblDataAquisicao);
            this.Controls.Add(this.lblMetal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblName);
            this.Name = "searchResultControl";
            this.Size = new System.Drawing.Size(259, 43);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPicturebox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMetal;
        private System.Windows.Forms.Label lblDataAquisicao;
        private roundedPicturebox roundedPicturebox1;
    }
}
