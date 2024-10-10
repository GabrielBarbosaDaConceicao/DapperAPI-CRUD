using API.Domain.Entitites;

namespace API.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        //Task<TarefaContainer> GetTarefasEContainerAsync();
        Task<int> SaveAsync(Tarefa novaTarefa);
        //Task<int> UpdateTarefaStatusAsync(Tarefa atualizaTarefa);
        //Task<int> DeleteAsync(int id);
    }
}
