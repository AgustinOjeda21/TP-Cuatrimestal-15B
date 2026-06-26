using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioDireccion
    {
        Task<List<Direccion>> ObtenerDirecciones();

        Task InsertarDireccion(Direccion aut);

        Task<List<Direccion>> Buscar(Busqueda<Direccion> busqueda);
        Task<Direccion> CapturarDireccion(int id);

        Task Actualizar(Direccion obj);
       
    }
}
