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
            btnUserViewTurn = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(btnUserViewTurn);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(69, 669);
            panel1.TabIndex = 1;
            // 
            // btnUserViewTurn
            // 
            btnUserViewTurn.BackgroundImage = (Image)resources.GetObject("btnUserViewTurn.BackgroundImage");
            btnUserViewTurn.BackgroundImageLayout = ImageLayout.Stretch;
            btnUserViewTurn.FlatAppearance.BorderSize = 0;
            btnUserViewTurn.FlatStyle = FlatStyle.Flat;
            btnUserViewTurn.Location = new Point(4, 79);
            btnUserViewTurn.Name = "btnUserViewTurn";
            btnUserViewTurn.Size = new Size(60, 60);
            btnUserViewTurn.TabIndex = 2;
            btnUserViewTurn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(4, 13);
            button1.Name = "button1";
            button1.Size = new Size(60, 60);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // AdminMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 666);
            Controls.Add(panel1);
            Name = "AdminMenu";
            Text = "AdminMenu";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnUserViewTurn;
        private Button button1;
    }
}