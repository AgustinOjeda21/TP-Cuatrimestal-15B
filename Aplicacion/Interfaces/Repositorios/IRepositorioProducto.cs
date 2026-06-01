using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioProducto
    {
        Task<List<Producto>> ObtenerProductoes();

        Task InsertarProducto(Producto aut);


        Task<Producto> CapturarProducto(int id);

        Task Actualizar(Producto obj);
       
    }
}
