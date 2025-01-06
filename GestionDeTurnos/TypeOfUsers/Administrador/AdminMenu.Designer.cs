namespace GestionDeTurnos.TypeOfUsers.Administrador
{
    partial class AdminMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenu));
            panel1 = new Panel();
            btnValidate = new Button();
            btnSalir = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btnValidate);
            panel1.Controls.Add(btnSalir);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(69, 669);
            panel1.TabIndex = 1;
            // 
            // btnValidate
            // 
            btnValidate.BackgroundImage = (Image)resources.GetObject("btnValidate.BackgroundImage");
            btnValidate.BackgroundImageLayout = ImageLayout.Stretch;
            btnValidate.FlatAppearance.BorderSize = 0;
            btnValidate.FlatStyle = FlatStyle.Flat;
            btnValidate.Location = new Point(5, 74);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(60, 60);
            btnValidate.TabIndex = 2;
            btnValidate.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.BackgroundImage = (Image)resources.GetObject("btnSalir.BackgroundImage");
            btnSalir.BackgroundImageLayout = ImageLayout.Stretch;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(5, 8);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(60, 60);
            btnSalir.TabIndex = 1;
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(62, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1338, 669);
            panel2.TabIndex = 2;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 666);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminMenu";
            Text = "AdminMenu";
            WindowState = FormWindowState.Maximized;
            Load += AdminMenu_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnValidate;
        private Button btnSalir;
        private Panel panel2;
    }
}