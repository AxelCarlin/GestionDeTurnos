using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeTurnos.SessionOfUser
{
    public static class SessionManager
    {
        public static int idCurrentUser { get; set; }
        public static int idTipoUsuario { get; set; }

        public static void SetUserSession(int id, int idTipoUsuario_)
        {
            idCurrentUser = id;
            idTipoUsuario = idTipoUsuario_;
        }
    }
}
