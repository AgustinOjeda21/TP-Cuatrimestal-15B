using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioDireccion
    {
        Task<List<Direccion>> ObtenerDirecciones();

        Task InsertarDireccion(Direccion aut);


        Task<Direccion> CapturarDireccion(int id);

        Task Actualizar(Direccion obj);
       
    }
}
