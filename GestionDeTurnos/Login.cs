using GestionDeTurnos.NewFolder;
using GestionDeTurnos.Properties;
using GestionDeTurnos.SessionOfUser;
using GestionDeTurnos.TypeOfUsers.Administrador;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GestionDeTurnos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Se convierte en un arreglo de bytes todo el archivo para poder cargarse
            // y reproducirse en el formulario

            byte[] archivoBytes = Resources.picturaTuArca;
            string rutaTemp = Path.Combine(Path.GetTempPath(), "picturaTuArca.mp3");

            File.WriteAllBytes(rutaTemp, archivoBytes);

            player.URL = rutaTemp;
            player.settings.setMode("loop", true);
            player.settings.volume = 30;
            player.Ctlcontrols.play();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Nombre", txtNombre.Text),
                new SqlParameter("@Clave", txtClave.Text)
            };

            string query = "SELECT * FROM Usuarios WHERE nombre = @Nombre AND clave = @Clave";
            DataTable dt = Connection.GetDataTable(query, sqlParameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Las credenciales proporcionadas no concuerdan con ningun usuario en la base de datos", "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (DataRow fila in dt.Rows)
            {
                SessionManager.SetUserSession(Convert.ToInt32(fila["id"]), Convert.ToInt32(fila["idTipoUsuario"]));
            }

            this.Hide();

            switch (SessionManager.idTipoUsuario)
            {
                case 1:
                    new AdminMenu(this).Show();
                    break;
                case 2:
                    new UserMenu(this).Show();
                    break;
            }
        }
    }
}
