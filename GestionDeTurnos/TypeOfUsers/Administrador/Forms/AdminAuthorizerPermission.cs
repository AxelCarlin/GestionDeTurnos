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

            int solicitudId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SolicitudID"].Value);

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
                Connection.ExecuteQuery(queryAutorizar, updateParams);

                // Insertar registro en la tabla Auditoria
                string queryAuditoria = @"
        INSERT INTO Auditoria (accion, tablaAfectada, idRegistro, usuarioEjecutor, descripcion)
        VALUES ('UPDATE', 'SolicitudesCambioTurno', @IdRegistro, @UsuarioEjecutor, @Descripcion)";

                SqlParameter[] auditoriaParams = {
            new SqlParameter("@IdRegistro", solicitudId),
            new SqlParameter("@UsuarioEjecutor", SessionManager.idCurrentUser),
            new SqlParameter("@Descripcion", "Solicitud autorizada por el administrador.")
        };

                Connection.ExecuteQuery(queryAuditoria, auditoriaParams);

                MessageBox.Show("La solicitud ha sido autorizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Por favor, selecciona una solicitud para reactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int solicitudId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SolicitudID"].Value);

            string queryReactivar = @"
    UPDATE SolicitudesCambioTurno
    SET estatusSolicitud = 1, -- Marcar como pendiente nuevamente
        fueAprobada = 0, -- Reiniciar estado de aprobación
        comentarioAdmin = @ComentarioAdmin,
        fechaRespuesta = NULL, -- Eliminar fecha de respuesta
        idUsuarioAdmin = NULL -- Eliminar registro del administrador
    WHERE id = @SolicitudID";

            SqlParameter[] updateParams = {
        new SqlParameter("@ComentarioAdmin", "Solicitud reactivada"),
        new SqlParameter("@SolicitudID", solicitudId)
    };

            try
            {
                // Ejecutar la actualización de la solicitud
                Connection.ExecuteQuery(queryReactivar, updateParams);

                // Insertar registro en la tabla Auditoria
                string queryAuditoria = @"
        INSERT INTO Auditoria (accion, tablaAfectada, idRegistro, usuarioEjecutor, descripcion)
        VALUES ('UPDATE', 'SolicitudesCambioTurno', @IdRegistro, @UsuarioEjecutor, @Descripcion)";

                SqlParameter[] auditoriaParams = {
            new SqlParameter("@IdRegistro", solicitudId),
            new SqlParameter("@UsuarioEjecutor", SessionManager.idCurrentUser),
            new SqlParameter("@Descripcion", "Solicitud reactivada por el administrador.")
        };

                Connection.ExecuteQuery(queryAuditoria, auditoriaParams);

                MessageBox.Show("La solicitud ha sido reactivada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Recargar las solicitudes para reflejar el cambio
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reactivar la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
