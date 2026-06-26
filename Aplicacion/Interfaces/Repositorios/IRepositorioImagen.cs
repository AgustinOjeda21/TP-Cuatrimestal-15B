using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using Aplicacion.Busqueda;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioImagen
    {
        Task<List<Imagen>> ObtenerImagenes();

        Task InsertarImagen(Imagen aut);
        Task<List<Imagen>> Buscar(Busqueda<Imagen> busqueda);

        Task<Imagen> CapturarImagen(int id);

        Task Actualizar(Imagen obj);
       
    }
}
