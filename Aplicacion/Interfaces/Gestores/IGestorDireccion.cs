using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.Gestores
{
    interface IGestorDireccion
    {
        Task<Result<Direccion>> CargarDireccion(Direccion edi);
        Task<Direccion> CapturarDireccion(int id);
        Task<List<Direccion>> DevolverDirecciones();
        Task<Result<Direccion>> ModificarCalle(string Calle, int id);
        Task<Result<Direccion>> ModificarCodigoPostal(string CodigoPostal, int id);

        Task<Result<Direccion>> ModificarNumero(string Numero, int id);

        Task<Result<Direccion>> ModificarLocalidad(string Localidad, int id);

        Task<Result<Direccion>> ModificarObservaciones(string Observaciones, int id);

        Task<bool> ValidarDireccion(int id);
        Task<Result<Direccion>> ExisteDireccion(int id);
        
    }
}
