using ClosedXML.Excel;
using GestionDeTurnos.NewFolder;
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
    public partial class UserHistory : Form
    {
        public UserHistory()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Ejecutar la consulta y llenar el DataTable
            string query = @"
    SELECT 
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
        t.fechaActualizacion AS FechaActualizacionTurno,
        st.id AS SolicitudID,
        st.idTurnoActual AS TurnoActualID,
        st.idTurnoSolicitado AS TurnoSolicitadoID,
        st.fechaSolicitud AS FechaSolicitud,
        st.estatusSolicitud AS EstatusSolicitud,
        st.fueAprobada AS FueAprobada,
        st.comentarioAdmin AS ComentarioAdmin,
        st.fechaRespuesta AS FechaRespuesta,
        st.idUsuarioAdmin AS UsuarioAdminID
    FROM 
        Empleados e
    INNER JOIN 
        Turnos t ON e.idTurno = t.id
    LEFT JOIN 
        SolicitudesCambioTurno st ON e.id = st.idEmpleado
    WHERE 
        e.estatus = 1 AND t.estatus = 1
    ORDER BY 
        e.id";

            // Obtener los datos
            DataTable dt = Connection.GetDataTable(query);

            // Crear el libro de Excel
            using (var workbook = new XLWorkbook())
            {
                // Crear la hoja de trabajo
                var worksheet = workbook.Worksheets.Add("Solicitudes de Cambio de Turno");

                // Cargar los datos del DataTable en la hoja de trabajo
                worksheet.Cell(1, 1).Value = "EmpleadoID";
                worksheet.Cell(1, 2).Value = "NombreCompleto";
                worksheet.Cell(1, 3).Value = "Telefono";
                worksheet.Cell(1, 4).Value = "CorreoElectronico";
                worksheet.Cell(1, 5).Value = "TurnoID";
                worksheet.Cell(1, 6).Value = "InicioTurno";
                worksheet.Cell(1, 7).Value = "FinTurno";
                worksheet.Cell(1, 8).Value = "FechaCreacionEmpleado";
                worksheet.Cell(1, 9).Value = "FechaActualizacionEmpleado";
                worksheet.Cell(1, 10).Value = "FechaCreacionTurno";
                worksheet.Cell(1, 11).Value = "FechaActualizacionTurno";
                worksheet.Cell(1, 12).Value = "SolicitudID";
                worksheet.Cell(1, 13).Value = "TurnoActualID";
                worksheet.Cell(1, 14).Value = "TurnoSolicitadoID";
                worksheet.Cell(1, 15).Value = "FechaSolicitud";
                worksheet.Cell(1, 16).Value = "EstatusSolicitud";
                worksheet.Cell(1, 17).Value = "FueAprobada";
                worksheet.Cell(1, 18).Value = "ComentarioAdmin";
                worksheet.Cell(1, 19).Value = "FechaRespuesta";
                worksheet.Cell(1, 20).Value = "UsuarioAdminID";

                // Llenar las celdas con los datos del DataTable
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dt.Rows[i][j].ToString();
                    }
                }

                // Ajustar el tamaño de las columnas automáticamente
                worksheet.Columns().AdjustToContents();

                // Guardar el archivo Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                    FileName = "SolicitudesCambioTurno_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("El archivo se ha exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadData()
        {
            // Ejecutar la consulta y llenar el DataTable
            string query = @"
    SELECT 
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
        t.fechaActualizacion AS FechaActualizacionTurno,
        st.id AS SolicitudID,
        st.idTurnoActual AS TurnoActualID,
        st.idTurnoSolicitado AS TurnoSolicitadoID,
        st.fechaSolicitud AS FechaSolicitud,
        st.estatusSolicitud AS EstatusSolicitud,
        st.fueAprobada AS FueAprobada,
        st.comentarioAdmin AS ComentarioAdmin,
        st.fechaRespuesta AS FechaRespuesta,
        st.idUsuarioAdmin AS UsuarioAdminID
    FROM 
        Empleados e
    INNER JOIN 
        Turnos t ON e.idTurno = t.id
    LEFT JOIN 
        SolicitudesCambioTurno st ON e.id = st.idEmpleado
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

        private void UserHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
