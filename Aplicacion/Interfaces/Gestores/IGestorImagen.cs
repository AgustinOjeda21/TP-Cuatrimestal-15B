using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Aplicacion.Interfaces.Gestores
{
    public interface IGestorImagen
    {
        Task<Result<Imagen>> CargarImagen(Imagen edi);

        Task<Imagen> CapturarImagen(int id);


        Task<List<Imagen>> DevolverImagenes();


        Task<Result<Imagen>> ModificarNombre(string Nombre, int id);



        Task<Result<Imagen>> ModificarDescripcion(string Descripcion, int id);


        Task<Result<Imagen>> ModificarURL(string URL, int id);


        Task<bool> ValidarImagen(int id);



        Task<Result<Imagen>> ExisteImagen(int id);
       
    }
}

