using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Aplicacion.Interfaces.Gestores;
using Aplicacion.Interfaces.Repositorios;

namespace Aplicacion.Gestores
{
    public class GestorProveedor : IGestorProveedor
    {
        IRepositorioProveedor repo;
        IGestorDireccion gestorDireccion;

        public GestorProveedor(IRepositorioProveedor repo, IGestorDireccion gestorDireccion)
        {
            this.repo = repo;
            this.gestorDireccion = gestorDireccion;
        }

        public async Task<Result<Proveedor>> CargarProveedor(Proveedor edi,Direccion direccion) //Deberia crear un dto para pasar una sola entidad que contenga la info del proveedor y de la direccion a crear
        {
            await gestorDireccion.CargarDireccion(direccion);
            edi.Direccion = direccion;
            await repo.InsertarProveedor(edi);
            return Result<Proveedor>.EjecucionCorrecta();
        }

        public async Task<Proveedor> CapturarProveedor(int id)
        {
            var edi = await repo.CapturarProveedor(id);
            return edi;
        }
        public async Task<List<Proveedor>> DevolverProveedores()
        {
            return await repo.ObtenerProveedores();
        }

        public async Task<Result<Proveedor>> ModificarNombre(string Nombre, int id)
        {
            var resultado = await ExisteProveedor(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Nombre = Nombre;
            await repo.Actualizar(edi);
            return Result<Proveedor>.EjecucionCorrecta();
        }
        public async Task<Result<Proveedor>> ModificarTelefono(string Telefono, int id)
        {
            var resultado = await ExisteProveedor(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Telefono = Telefono;
            await repo.Actualizar(edi);
            return Result<Proveedor>.EjecucionCorrecta();
        }
        public async Task<Result<Proveedor>> ModificarMail(string Mail, int id)
        {
            var resultado = await ExisteProveedor(id);
            if (!resultado.Success)
            {
                return resultado;
            }
            var edi = resultado.Value;
            edi.Mail = Mail;
            await repo.Actualizar(edi);
            return Result<Proveedor>.EjecucionCorrecta();
        }
       
        public async Task<bool> ValidarProveedor(int id)
        {
            return await repo.CapturarProveedor(id) != null;
        }
        public async Task<Result<Proveedor>> DarDeBajaAlta(int ID, bool Estado)
        {
            var resultado = await ExisteProveedor(ID);
            if (!resultado.Success)
            {
                return resultado;
            }
            var pro = resultado.Value;
            if (pro.Estado == Estado)
            {
                return Result<Proveedor>.Fail("El Proveedor ya se encuentra en ese estado");
            }
            pro.Estado = Estado;
            await repo.Actualizar(pro);
            return Result<Proveedor>.EjecucionCorrecta();
        }
        public async Task<Result<Proveedor>> ExisteProveedor(int id)
        {
            Proveedor obj = await repo.CapturarProveedor(id);
            if (obj is null)
            {
                return Result<Proveedor>.Fail("El Proveedor ingresado no existe");
            }
            return Result<Proveedor>.Ok(obj);
        }
    }
}
