namespace SOVD
{
    partial class frmEditarConta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkvisu = new System.Windows.Forms.CheckBox();
            this.btnnovasenha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkvisu2 = new System.Windows.Forms.CheckBox();
            this.txtnovasenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtagain = new System.Windows.Forms.TextBox();
            this.lblNewMail = new System.Windows.Forms.Label();
            this.txtNewMail = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkvisu
            // 
            this.chkvisu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkvisu.AutoSize = true;
            this.chkvisu.Location = new System.Drawing.Point(325, 23);
            this.chkvisu.Name = "chkvisu";
            this.chkvisu.Size = new System.Drawing.Size(104, 17);
            this.chkvisu.TabIndex = 21;
            this.chkvisu.Text = "Visualizar Senha";
            this.chkvisu.UseVisualStyleBackColor = true;
            this.chkvisu.CheckedChanged += new System.EventHandler(this.chkvisu_CheckedChanged);
            // 
            // btnnovasenha
            // 
            this.btnnovasenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnnovasenha.Enabled = false;
            this.btnnovasenha.Location = new System.Drawing.Point(180, 275);
            this.btnnovasenha.Name = "btnnovasenha";
            this.btnnovasenha.Size = new System.Drawing.Size(74, 29);
            this.btnnovasenha.TabIndex = 20;
            this.btnnovasenha.Text = "Alterar";
            this.btnnovasenha.UseVisualStyleBackColor = true;
            this.btnnovasenha.Click += new System.EventHandler(this.btnnovasenha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Digite sua senha:";
            // 
            // btnlogin
            // 
            this.btnlogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlogin.Location = new System.Drawing.Point(180, 63);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(74, 30);
            this.btnlogin.TabIndex = 15;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtsenha
            // 
            this.txtsenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsenha.Location = new System.Drawing.Point(104, 21);
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.Size = new System.Drawing.Size(206, 20);
            this.txtsenha.TabIndex = 13;
            this.txtsenha.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblNewMail);
            this.groupBox1.Controls.Add(this.txtNewMail);
            this.groupBox1.Controls.Add(this.chkvisu2);
            this.groupBox1.Controls.Add(this.txtnovasenha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtagain);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 169);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novas Informações";
            // 
            // chkvisu2
            // 
            this.chkvisu2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkvisu2.AutoSize = true;
            this.chkvisu2.Location = new System.Drawing.Point(270, 55);
            this.chkvisu2.Name = "chkvisu2";
            this.chkvisu2.Size = new System.Drawing.Size(109, 17);
            this.chkvisu2.TabIndex = 27;
            this.chkvisu2.Text = "Visualizar Senhas";
            this.chkvisu2.UseVisualStyleBackColor = true;
            this.chkvisu2.CheckedChanged += new System.EventHandler(this.chkvisu2_CheckedChanged);
            // 
            // txtnovasenha
            // 
            this.txtnovasenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnovasenha.Enabled = false;
            this.txtnovasenha.Location = new System.Drawing.Point(49, 37);
            this.txtnovasenha.Name = "txtnovasenha";
            this.txtnovasenha.Size = new System.Drawing.Size(206, 20);
            this.txtnovasenha.TabIndex = 26;
            this.txtnovasenha.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Digite uma nova Senha";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Digite novamente a senha:";
            // 
            // txtagain
            // 
            this.txtagain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtagain.Enabled = false;
            this.txtagain.Location = new System.Drawing.Point(49, 86);
            this.txtagain.Name = "txtagain";
            this.txtagain.Size = new System.Drawing.Size(206, 20);
            this.txtagain.TabIndex = 23;
            this.txtagain.UseSystemPasswordChar = true;
            // 
            // lblNewMail
            // 
            this.lblNewMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNewMail.AutoSize = true;
            this.lblNewMail.Location = new System.Drawing.Point(46, 114);
            this.lblNewMail.Name = "lblNewMail";
            this.lblNewMail.Size = new System.Drawing.Size(108, 13);
            this.lblNewMail.TabIndex = 29;
            this.lblNewMail.Text = "Digite um novo email:";
            // 
            // txtNewMail
            // 
            this.txtNewMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewMail.Enabled = false;
            this.txtNewMail.Location = new System.Drawing.Point(49, 135);
            this.txtNewMail.Name = "txtNewMail";
            this.txtNewMail.Size = new System.Drawing.Size(249, 20);
            this.txtNewMail.TabIndex = 28;
            // 
            // frmEditarConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkvisu);
            this.Controls.Add(this.btnnovasenha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtsenha);
            this.Name = "frmEditarConta";
            this.Text = "Editar Conta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkvisu;
        private System.Windows.Forms.Button btnnovasenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtsenha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNewMail;
        private System.Windows.Forms.TextBox txtNewMail;
        private System.Windows.Forms.CheckBox chkvisu2;
        private System.Windows.Forms.TextBox txtnovasenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtagain;
    }
}