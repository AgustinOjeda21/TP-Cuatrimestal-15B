using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Repositorios
{
    public interface IRepositorioMarca
    {
        Task<List<Marca>> ObtenerMarcas();

        Task InsertarMarca(Marca aut);

        Task QuitarImagen(int marca, int IdImagen);
        Task AgregarImagen(int marca, Imagen imagen);

        Task <Marca> CapturarMarca(int id);

        Task Actualizar(Marca obj);
        
    }
}
