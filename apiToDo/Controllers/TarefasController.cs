using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private Tarefas _tarefas;
        public TarefasController()
        {
            _tarefas = new Tarefas();
        }
        [HttpGet("buscarTarefa")]
        public ActionResult buscarTarefa([FromQuery] int ID_TAREFA)
        {
            try
            {
                TarefaDTO Tarefa = _tarefas.buscarTarefa(ID_TAREFA);
                return StatusCode(200, Tarefa == null ? new {msg = $"Tarefa com id {ID_TAREFA} Não encontrada, favor inserir um id existente." } : Tarefa);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                return StatusCode(200, _tarefas.lstTarefas());
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                return StatusCode(200, _tarefas.InserirTarefa(Request));
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                var lstTarefas = _tarefas.DeletarTarefa(ID_TAREFA);
                return StatusCode(200, lstTarefas == null ? new {msg= $"Tarefa com id {ID_TAREFA} Não encontrada, favor inserir um id existente." } : lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPut("AtualizarTarefa")]
        public ActionResult UpdateTask([FromBody] TarefaDTO Request)
        {
            try
            {
                var lstTarefas = _tarefas.AtualizarTarefa(Request);
                return StatusCode(200, lstTarefas == null ? new {msg = $"Tarefa com id {Request.ID_TAREFA} não encontrada, favor inserir um id existente." } : lstTarefas);
            }
            catch(Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
