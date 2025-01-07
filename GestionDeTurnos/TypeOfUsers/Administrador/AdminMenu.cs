using GestionDeTurnos.TypeOfUsers.Administrador.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeTurnos.TypeOfUsers.Administrador
{
    public partial class AdminMenu : Form
    {
        private Login main;
        public AdminMenu(Login main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<AdminAuthorizerPermission>().Any()) { return; }
            ShowFormInPanel<AdminAuthorizerPermission>();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            main.Show();
            Close();
        }

        private void ShowFormInPanel<T>() where T : Form
        {
            if (panel2.Controls.OfType<T>().Any()) return;

            foreach (Control control in panel2.Controls)
            {
                Form prevControl = control as Form;
                prevControl?.Close();
                control.Dispose();
            }
            panel2.Controls.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            var form = Activator.CreateInstance(typeof(T)) as T;

            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                panel2.Controls.Add(form);
                form.Show();
            }
        }
    }
}
