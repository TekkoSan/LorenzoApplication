using LorenzoApplication.ModeloDto;
using LorenzoApplication.Modelos;
using LorenzoApplication.Servicios;
using Microsoft.EntityFrameworkCore;

namespace LorenzoApplication.Servicio;

public interface IClientesServicio
{
    public Task<List<ClienteDto>> CargarCombo();
    public Task<List<Cliente>> Listar();
    public Task<bool> Agregar(Cliente cliente);
    public Task<Cliente?> Leer(string cliente);
    public Task<bool> Eliminar(string codigo);
    public Task<bool> Modificar(Cliente cliente);
}
public class ClientesServicio : IClientesServicio
{
    private readonly LorenzoContexto Db;
    private readonly INumerarServicio _numerarServicio;

    public ClientesServicio(LorenzoContexto lorenzoContexto, INumerarServicio numerarServicio)
    {
        Db = lorenzoContexto;
        _numerarServicio = numerarServicio;
    }




    public async Task<bool> Agregar(Cliente cliente)
    {

        cliente.Codigo = await _numerarServicio.NuevoCodigo("Cliente");

        var respuesta = await Db.Clientes.Where(X => X.Codigo.Equals(cliente.Codigo)).FirstOrDefaultAsync();
        if (respuesta != null) return false;
        else
        {
            cliente = Normalizar(cliente);
            Db.Clientes.Add(cliente);
            await Db.SaveChangesAsync();
            return true;
        }
    }

    public async Task<List<Cliente>> Listar()
    {
        var respuesta = await Db.Clientes.ToListAsync();
        return respuesta;
    }

    public async Task<Cliente?> Leer(string cliente)
    {
        var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(cliente)).FirstOrDefaultAsync();
        return respuesta;

    }

    public async Task<bool> Eliminar(string codigo)
    {
        var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(codigo)).FirstOrDefaultAsync();
        if (respuesta == null) return false;
        else
        {
            Db.Clientes.Remove(respuesta);
            await Db.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> Modificar(Cliente cliente)
    {
        var respuesta = await Db.Clientes.Where(x => x.Codigo.Equals(cliente.Codigo)).FirstOrDefaultAsync();
        if (respuesta == null) return false;
        else
        {
            respuesta = Normalizar(respuesta);
            Db.Clientes.Update(respuesta);
            await Db.SaveChangesAsync();
            return true;
        }
    }

    static private Cliente Normalizar(Cliente dato)
    {
        dato.Nombre = dato.Nombre.ToUpper();
        return dato;
    }

    public async Task<List<ClienteDto>> CargarCombo()
    {
        List<ClienteDto> respuesta = new List<ClienteDto>();
        var Lista = await Listar();
        foreach(var X in Lista)
        {
            respuesta.Add(new ClienteDto() { Codigo = X.Codigo, Nombre = X.Nombre });
        }
        return respuesta;
    }
}