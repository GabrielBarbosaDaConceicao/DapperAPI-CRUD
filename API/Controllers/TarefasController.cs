using API.Domain.Entitites;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepo;

        public TarefasController(ITarefaRepository tarefaRepo)
        {
            _tarefaRepo = tarefaRepo;
        }

        [HttpGet]
        [Route("tarefas")]
        public async Task<IActionResult> GetTarefasAsync()
        {
            var result = await _tarefaRepo.GetTarefasAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("tarefa/{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefaRepo.GetTarefaByIdAsync(id);
            if (id != tarefa.Id)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        [Route("tarefa/save")]
        public async Task<IActionResult> SaveAsync([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest();
            }

            int response = await _tarefaRepo.SaveAsync(tarefa);

            return Ok(response);
        }
    }
}
