using API.Domain.Entitites;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/Tarefa")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepo;

        public TarefasController(ITarefaRepository tarefaRepo)
        {
            _tarefaRepo = tarefaRepo;
        }

        [HttpGet]
        [Route("TodasAsTarefas")]
        public async Task<IActionResult> GetTarefasAsync()
        {
            var result = await _tarefaRepo.GetTarefasAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarTarefaPorId/{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefaRepo.GetTarefaByIdAsync(id);

            if (tarefa == null)
            {
                return NotFound("Id invalido");
            }

            return Ok(tarefa);
        }

        [HttpPost]
        [Route("CriarTarefa")]
        public async Task<IActionResult> SaveAsync([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest();
            }

            int response = await _tarefaRepo.SaveAsync(tarefa);

            return Ok(response);
        }

        [HttpPut]
        [Route("AtualizarTarefa")]
        public async Task<IActionResult> UpdateteTarefaAsync([FromBody] Tarefa tarefa)
        {
            var response = await _tarefaRepo.UpdateTarefaAsync(tarefa);

            if (response == 0)
            {
                return NotFound("Id invalido");
            }

            return Ok(tarefa);
        }
    }
}
