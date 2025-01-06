namespace GestionDeTurnos.TypeOfUsers.User.Forms
{
    partial class UserChangeTurn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserChangeTurn));
            label1 = new Label();
            cmbTurns = new ComboBox();
            label2 = new Label();
            panel1 = new Panel();
            btnRequestChange = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(315, 50);
            label1.TabIndex = 1;
            label1.Text = "Cambio de turno";
            // 
            // cmbTurns
            // 
            cmbTurns.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbTurns.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTurns.FormattingEnabled = true;
            cmbTurns.Items.AddRange(new object[] { "08:00 AM - 02:00 PM", "02:00 PM - 08:00 PM", "08:00 PM - 12:00 AM", "10:00 AM - 06:00 PM", "12:00 PM - 08:00 PM" });
            cmbTurns.Location = new Point(990, 187);
            cmbTurns.Name = "cmbTurns";
            cmbTurns.Size = new Size(356, 38);
            cmbTurns.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(990, 159);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 5;
            label2.Text = "Turnos Disponibles";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(34, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 33);
            panel1.TabIndex = 6;
            // 
            // btnRequestChange
            // 
            btnRequestChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRequestChange.BackColor = Color.FromArgb(78, 197, 151);
            btnRequestChange.FlatAppearance.BorderColor = Color.Black;
            btnRequestChange.FlatStyle = FlatStyle.Flat;
            btnRequestChange.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRequestChange.ForeColor = Color.Black;
            btnRequestChange.Location = new Point(990, 231);
            btnRequestChange.Name = "btnRequestChange";
            btnRequestChange.Size = new Size(356, 53);
            btnRequestChange.TabIndex = 12;
            btnRequestChange.Text = "Solicitar cambio";
            btnRequestChange.UseVisualStyleBackColor = false;
            btnRequestChange.Click += btnRequestChange_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(46, 187);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(910, 251);
            dataGridView1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(46, 159);
            label3.Name = "label3";
            label3.Size = new Size(270, 25);
            label3.TabIndex = 14;
            label3.Text = "Turnos asignados esta semana";
            // 
            // UserChangeTurn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 666);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(btnRequestChange);
            Controls.Add(label2);
            Controls.Add(cmbTurns);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "UserChangeTurn";
            Text = "UserChangeTurn";
            WindowState = FormWindowState.Maximized;
            Load += UserChangeTurn_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbTurns;
        private Label label2;
        private Panel panel1;
        private Button btnRequestChange;
        private DataGridView dataGridView1;
        private Label label3;
    }
}