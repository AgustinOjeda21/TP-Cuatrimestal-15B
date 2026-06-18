using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorCategoria
    {

        Task<Result<Categoria>> CargarCategoria(Categoria edi);

        Task<Categoria> CapturarCategoria(int id);

        Task<List<Categoria>> DevolverCategorias();

        Task<Result<Categoria>> ModificarNombre(string Nombre, int id);


        Task<Result<Categoria>> ModificarDescripcion(string Descripcion, int id);

        Task<bool> ValidarCategoria(int id);

        Task<Result<Categoria>> ExisteCategoria(int id);
        Task EliminarCategoria(int id);

    }
}

