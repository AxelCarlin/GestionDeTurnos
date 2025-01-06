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
    }
}
