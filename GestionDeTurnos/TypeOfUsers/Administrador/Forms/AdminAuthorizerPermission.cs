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

namespace GestionDeTurnos.TypeOfUsers.Administrador.Forms
{
    public partial class AdminAuthorizerPermission : Form
    {
        public AdminAuthorizerPermission()
        {
            InitializeComponent();
        }

        private void AdminAuthorizerPermission_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            // Consulta para obtener datos de solicitudes de cambio de turno
            string query = @"
    SELECT 
        sct.id AS SolicitudID,
        sct.idUsuarioSolicitante AS UsuarioSolicitanteID,
        CONCAT(es.nombre, ' ', es.apellidoPaterno, ' ', es.apellidoMaterno) AS NombreSolicitante,
        e.id AS UsuarioAfectadoID,
        CONCAT(e.nombre, ' ', e.apellidoPaterno, ' ', e.apellidoMaterno) AS NombreAfectado,
        tActual.iniciaTurno + ' - ' + tActual.finalizaTurno AS TurnoActual,
        tSolicitado.iniciaTurno + ' - ' + tSolicitado.finalizaTurno AS TurnoSolicitado,
        sct.fechaSolicitud AS FechaSolicitud,
        CASE sct.estatusSolicitud 
            WHEN 1 THEN 'Pendiente'
            WHEN 0 THEN 'Procesada'
        END AS EstatusSolicitud,
        CASE sct.fueAprobada 
            WHEN 1 THEN 'Aprobada'
            WHEN 0 THEN 'Rechazada'
        END AS Resultado,
        sct.comentarioAdmin AS ComentarioAdmin,
        sct.fechaRespuesta AS FechaRespuesta,
        sct.idUsuarioAdmin AS UsuarioAdminID
    FROM 
        SolicitudesCambioTurno sct
    INNER JOIN 
        Empleados e ON sct.idEmpleado = e.id
    INNER JOIN 
        Turnos tActual ON sct.idTurnoActual = tActual.id
    INNER JOIN 
        Turnos tSolicitado ON sct.idTurnoSolicitado = tSolicitado.id
    LEFT JOIN 
        Empleados es ON sct.idUsuarioSolicitante = es.id
    ORDER BY 
        sct.fechaSolicitud DESC";

            // Obtener los datos
            DataTable dt = Connection.GetDataTable(query);

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;

            // Ajustar automáticamente el tamaño de las columnas al contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una solicitud para autorizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la solicitud seleccionada
            int solicitudId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SolicitudID"].Value);

            // Consulta para autorizar la solicitud
            string queryAutorizar = @"
    UPDATE SolicitudesCambioTurno
    SET estatusSolicitud = 0, 
        fueAprobada = 1, 
        comentarioAdmin = @ComentarioAdmin,
        fechaRespuesta = GETDATE(), 
        idUsuarioAdmin = @UsuarioAdmin
    WHERE id = @SolicitudID";

            SqlParameter[] updateParams = {
        new SqlParameter("@ComentarioAdmin", "Solicitud autorizada"),
        new SqlParameter("@UsuarioAdmin", SessionManager.idCurrentUser),
        new SqlParameter("@SolicitudID", solicitudId)
    };

            try
            {
                // Ejecutar la consulta de actualización
                Connection.ExecuteQuery(queryAutorizar, updateParams);

                // Registrar en auditoría
                string queryAuditoria = @"
        INSERT INTO Auditoria (entidad, accion, fechaCreacion, fechaActualizacion, estatus, IdUsuarioCreador, IdUsuarioActualizador)
        VALUES ('SolicitudesCambioTurno', 'Autorizar', GETDATE(), GETDATE(), 1, @UsuarioCreador, @UsuarioActualizador)";

                SqlParameter[] auditoriaParams = {
            new SqlParameter("@UsuarioCreador", SessionManager.idCurrentUser),
            new SqlParameter("@UsuarioActualizador", SessionManager.idCurrentUser),
        };

                Connection.ExecuteQuery(queryAuditoria, auditoriaParams);

                MessageBox.Show("La solicitud ha sido autorizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar datos
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al autorizar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una solicitud para rechazar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la solicitud seleccionada
            int solicitudId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SolicitudID"].Value);

            // Consulta para rechazar la solicitud
            string queryDenegar = @"
    UPDATE SolicitudesCambioTurno
    SET estatusSolicitud = 0, 
        fueAprobada = 0, 
        comentarioAdmin = @ComentarioAdmin,
        fechaRespuesta = GETDATE(), 
        idUsuarioAdmin = @UsuarioAdmin
    WHERE id = @SolicitudID";

            SqlParameter[] updateParams = {
        new SqlParameter("@ComentarioAdmin", "Solicitud rechazada"),
        new SqlParameter("@UsuarioAdmin", SessionManager.idCurrentUser),
        new SqlParameter("@SolicitudID", solicitudId)
    };

            try
            {
                // Ejecutar la consulta de actualización
                Connection.ExecuteQuery(queryDenegar, updateParams);

                // Registrar en auditoría
                string queryAuditoria = @"
        INSERT INTO Auditoria (entidad, accion, fechaCreacion, fechaActualizacion, estatus, IdUsuarioCreador, IdUsuarioActualizador)
        VALUES ('SolicitudesCambioTurno', 'Rechazar', GETDATE(), GETDATE(), 1, @UsuarioCreador, @UsuarioActualizador)";

                SqlParameter[] auditoriaParams = {
            new SqlParameter("@UsuarioCreador", SessionManager.idCurrentUser),
            new SqlParameter("@UsuarioActualizador", SessionManager.idCurrentUser)
        };

                Connection.ExecuteQuery(queryAuditoria, auditoriaParams);

                MessageBox.Show("La solicitud ha sido rechazada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar datos
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rechazar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
