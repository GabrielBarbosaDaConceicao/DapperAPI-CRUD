using API.Domain.Entitites;

namespace API.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        //Task<TarefaContainer> GetTarefasEContainerAsync();
        Task<int> SaveAsync(Tarefa novaTarefa);
        Task<int> UpdateTarefaAsync(Tarefa tarefa);
        //Task<int> DeleteAsync(int id);
    }
}
