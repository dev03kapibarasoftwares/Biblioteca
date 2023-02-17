using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Leitores;

namespace Teste.Authorization
{
    public class PermissionByLevel
    {
        private static List<string> Funcionario = new List<string>()
        {
            PermissionNames.Users,
            PermissionNames.Users_Create,
            PermissionNames.Users_Edit,
            PermissionNames.Users_Delete,
            PermissionNames.Users_View,

            PermissionNames.Roles,
            PermissionNames.Roles_Create,
            PermissionNames.Roles_Edit,
            PermissionNames.Roles_Delete,
            PermissionNames.Roles_View,

            PermissionNames.Livros,
            PermissionNames.Livros_Create,
            PermissionNames.Livros_Edit,
            PermissionNames.Livros_Delete,
            PermissionNames.Livros_View,

            PermissionNames.PedidoDeRetirada,
            PermissionNames.PedidoDeRetirada_Create,
            PermissionNames.PedidoDeRetirada_Edit,
            PermissionNames.PedidoDeRetirada_Delete,
            PermissionNames.PedidoDeRetirada_View,

            PermissionNames.Leitor,
            PermissionNames.Leitor_Create,
            PermissionNames.Leitor_Edit,
            PermissionNames.Leitor_Delete,
            PermissionNames.Leitor_View
        };

        private static List<string> Leitor = new List<string>()
        {
            PermissionNames.Livros_View,
            PermissionNames.PedidoDeRetirada_View,
            PermissionNames.Leitor_View
        };

        public static List<string> GetPermissions(NivelPermissao nivelPermissao)
        {
            if (NivelPermissao.Funcionario == nivelPermissao)
                return Funcionario;
            else
                return Leitor;
        }
    }
}
