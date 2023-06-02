using ControleTarefas.API.Data;
using ControleTarefas.API.Models;
using ControleTarefas.API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TarefasRepositorio : ITarefasRepositorio
{
    private readonly ControleTarefasDBContext _dbContext;
    public TarefasRepositorio(ControleTarefasDBContext controleTarefasDBContext)
    {
        _dbContext = controleTarefasDBContext;
    }

    public async Task<Tarefa> Adicionar(Tarefa tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> Apagar(int id)
    {
        Tarefa tarefaId = await BuscarPorId(id);
        if (tarefaId == null) throw new Exception("Tarefa para o Id " + id.ToString() + " não foi encontrado.");

        _dbContext.Tarefas.Remove(tarefaId);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Tarefa> Atualizar(Tarefa tarefa, int id)
    {
        Tarefa tarefaPorId = await BuscarPorId(id);
        if (tarefaPorId == null) throw new Exception("Tarefa para o Id " + id.ToString() + " não foi encontrado.");

        tarefaPorId.Nome = tarefa.Nome;
        tarefaPorId.Descricao = tarefa.Descricao;
        tarefaPorId.UsuarioId = tarefa.UsuarioId;
        tarefaPorId.Status = tarefa.Status;
        tarefaPorId.Usuario = tarefa.Usuario;

        _dbContext.Tarefas.Update(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return tarefaPorId;
    }

    public async Task<Tarefa> BuscarPorId(int id)
    {
        return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Tarefa>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas.ToListAsync();
    }
}