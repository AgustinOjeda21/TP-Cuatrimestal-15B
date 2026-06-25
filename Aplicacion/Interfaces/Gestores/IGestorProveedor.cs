using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorProveedor
    {
        Task<Result<Proveedor>> CargarProveedor(Proveedor edi, Direccion direccion);
        Task<Proveedor> CapturarProveedor(int id);
        Task<List<Proveedor>> DevolverProveedores();
        Task<Result<Proveedor>> ModificarNombre(string Nombre, int id);
        Task<Result<Proveedor>> ModificarTelefono(string Telefono, int id);
        Task<Result<Proveedor>> ModificarMail(string Mail, int id);
        Task<bool> ValidarProveedor(int id);
        Task<Result<Proveedor>> DarDeBajaAlta(int ID, bool Estado);
        Task<Result<Proveedor>> ExisteProveedor(int id);
       
    }
}