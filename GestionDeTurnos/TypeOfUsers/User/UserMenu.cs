using GestionDeTurnos.TypeOfUsers.User.Forms;

namespace GestionDeTurnos
{
    public partial class UserMenu : Form
    {
        private Login main;
        public UserMenu(Login main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void btnUserViewTurn_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<UserHistory>().Any()) return;

            ShowFormInPanel<UserHistory>();
        }

        private void btnCambioTurno_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.OfType<UserChangeTurn>().Any()) return;

            ShowFormInPanel<UserChangeTurn>();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            main.Show();
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
