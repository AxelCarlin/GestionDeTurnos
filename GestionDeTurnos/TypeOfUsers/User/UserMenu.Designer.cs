namespace GestionDeTurnos
{
    partial class UserMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMenu));
            panel1 = new Panel();
            btnCambioTurno = new Button();
            btnUserViewTurn = new Button();
            button1 = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.BackColor = Color.Indigo;
            panel1.Controls.Add(btnCambioTurno);
            panel1.Controls.Add(btnUserViewTurn);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(69, 672);
            panel1.TabIndex = 0;
            // 
            // btnCambioTurno
            // 
            btnCambioTurno.BackgroundImage = (Image)resources.GetObject("btnCambioTurno.BackgroundImage");
            btnCambioTurno.BackgroundImageLayout = ImageLayout.Stretch;
            btnCambioTurno.FlatAppearance.BorderSize = 0;
            btnCambioTurno.FlatStyle = FlatStyle.Flat;
            btnCambioTurno.Location = new Point(4, 79);
            btnCambioTurno.Name = "btnCambioTurno";
            btnCambioTurno.Size = new Size(60, 60);
            btnCambioTurno.TabIndex = 3;
            btnCambioTurno.UseVisualStyleBackColor = true;
            btnCambioTurno.Click += btnCambioTurno_Click;
            // 
            // btnUserViewTurn
            // 
            btnUserViewTurn.BackgroundImage = (Image)resources.GetObject("btnUserViewTurn.BackgroundImage");
            btnUserViewTurn.BackgroundImageLayout = ImageLayout.Stretch;
            btnUserViewTurn.FlatAppearance.BorderSize = 0;
            btnUserViewTurn.FlatStyle = FlatStyle.Flat;
            btnUserViewTurn.Location = new Point(4, 145);
            btnUserViewTurn.Name = "btnUserViewTurn";
            btnUserViewTurn.Size = new Size(60, 60);
            btnUserViewTurn.TabIndex = 2;
            btnUserViewTurn.UseVisualStyleBackColor = true;
            btnUserViewTurn.Click += btnUserViewTurn_Click;
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
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(65, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1334, 669);
            panel2.TabIndex = 1;
            // 
            // UserMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 666);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserMenu";
            Text = "UserMenu";
            WindowState = FormWindowState.Maximized;
            Load += UserMenu_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button btnUserViewTurn;
        private Button btnCambioTurno;
        private Panel panel2;
    }
}