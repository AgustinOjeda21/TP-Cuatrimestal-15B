using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioProveedor
    {
        Task<List<Proveedor>> ObtenerProveedores();

        Task InsertarProveedor(Proveedor aut);
        

        Task<Proveedor> CapturarProveedor(int id);

        Task Actualizar(Proveedor obj);
        
    }
}
