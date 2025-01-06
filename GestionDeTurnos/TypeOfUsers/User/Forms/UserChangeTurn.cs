using GestionDeTurnos.NewFolder;
using GestionDeTurnos.SessionOfUser;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeTurnos.TypeOfUsers.User.Forms
{
    public partial class UserChangeTurn : Form
    {
        public UserChangeTurn()
        {
            InitializeComponent();
            LoadData();
           
        }
        private void LoadData()
        {
            // Ejecutar la consulta y llenar el DataTable
            string query = @"SELECT 
                    e.id AS EmpleadoID,
                    CONCAT(e.nombre, ' ', e.apellidoPaterno, ' ', e.apellidoMaterno) AS NombreCompleto,
                    e.telefono AS Telefono,
                    e.correoElectronico AS CorreoElectronico,
                    t.id AS TurnoID,
                    t.iniciaTurno AS InicioTurno,
                    t.finalizaTurno AS FinTurno,
                    e.fechaCreacion AS FechaCreacionEmpleado,
                    e.fechaActualizacion AS FechaActualizacionEmpleado,
                    t.fechaCreacion AS FechaCreacionTurno,
                    t.fechaActualizacion AS FechaActualizacionTurno
                FROM 
                    Empleados e
                INNER JOIN 
                    Turnos t
                ON 
                    e.idTurno = t.id
                WHERE 
                    e.estatus = 1 AND t.estatus = 1
                ORDER BY 
                    e.id";

            DataTable dt = Connection.GetDataTable(query);

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;

            // Ajustar automáticamente el tamaño de las columnas al contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Opcional: Ajustar también las filas automáticamente al contenido
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Opcional: Hacer que el encabezado de las columnas se ajuste al contenido
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        private void btnRequestChange_Click(object sender, EventArgs e)
        {
            string textoTurno = cmbTurns.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(textoTurno))
            {
                MessageBox.Show("Por favor, selecciona un turno válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Obtener el ID del turno solicitado basado en el texto seleccionado
            string queryTurnoId = @"
    SELECT TOP 1 id 
    FROM Turnos 
    WHERE CONCAT(iniciaTurno, ' - ', finalizaTurno) = @TextoTurno";

            SqlParameter turnoParam = new SqlParameter("@TextoTurno", textoTurno);
            object turnoIdResult = Connection.ExecuteScalar(queryTurnoId, turnoParam);

            if (turnoIdResult == null)
            {
                MessageBox.Show("El turno seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int turnoSolicitadoId = Convert.ToInt32(turnoIdResult);

            // 2. Obtener el turno actual del empleado (usando el ID del usuario actual)
            string queryTurnoActualId = @"
    SELECT idTurno 
    FROM Empleados 
    WHERE idUsuario = @UsuarioActual AND estatus = 1";

            SqlParameter[] queryParams = {
        new SqlParameter("@UsuarioActual", SessionManager.idCurrentUser) // Usamos el ID del usuario actual
    };

            object turnoActualResult = Connection.ExecuteScalar(queryTurnoActualId, queryParams);

            if (turnoActualResult == null)
            {
                MessageBox.Show("No se pudo encontrar el turno actual del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int turnoActualId = Convert.ToInt32(turnoActualResult);

            // 3. Insertar la solicitud de cambio de turno en la tabla de SolicitudesCambioTurno
            string queryInsertarSolicitud = @"
    INSERT INTO SolicitudesCambioTurno (idEmpleado, idTurnoActual, idTurnoSolicitado, idUsuarioSolicitante, estatusSolicitud, fueAprobada)
    VALUES (@IdEmpleado, @IdTurnoActual, @IdTurnoSolicitado, @IdUsuarioSolicitante, 1, 0)"; // Estatus 1 para pendiente, fueAprobada 0 para pendiente

            SqlParameter[] insertParams = {
        new SqlParameter("@IdEmpleado", SessionManager.idCurrentUser), // ID del empleado solicitante
        new SqlParameter("@IdTurnoActual", turnoActualId), // Turno actual del empleado
        new SqlParameter("@IdTurnoSolicitado", turnoSolicitadoId), // Turno solicitado
        new SqlParameter("@IdUsuarioSolicitante", SessionManager.idCurrentUser) // ID del usuario que hace la solicitud
    };

            try
            {
                Connection.ExecuteQuery(queryInsertarSolicitud, insertParams);
                MessageBox.Show("La solicitud de cambio de turno fue enviada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al enviar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserChangeTurn_Load(object sender, EventArgs e)
        {

        }
    }
}
