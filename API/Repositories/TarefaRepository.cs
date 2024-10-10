using API.Data;
using API.Domain.Entitites;
using API.Repositories.Interfaces;
using Dapper;

namespace API.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private DbSession _db;

        public TarefaRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Tarefas";
                List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
                return tarefas;
            }
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Tarefas WHERE Id = @id";
                var tarefa = await conn.QueryFirstOrDefaultAsync<Tarefa>(query, new { Id = id});
                return tarefa;
            }
        }

        public async Task<int> SaveAsync(Tarefa tarefa)
        {
            using (var conn = _db.Connection)
            {
                string command = "INSERT INTO Tarefas(Descricao, IsCompleta) VALUES(@Descricao, @IsCompleta)";
                int response = await conn.ExecuteAsync(command, tarefa);
                return response;
            }
        }

    }
}
