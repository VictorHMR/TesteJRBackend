﻿using apiToDo.DTO;
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
        [HttpGet("buscarTarefa")]
        public ActionResult buscarTarefa([FromQuery] int ID_TAREFA)
        {
            try
            {
                Tarefas Tarefas = new Tarefas();
                TarefaDTO Tarefa = Tarefas.buscarTarefa(ID_TAREFA);
                return StatusCode(200, Tarefa == null ? new {msg = "ID_TAREFA Não existe na base."} : Tarefa);
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
                Tarefas Tarefas = new Tarefas();
                return StatusCode(200, Tarefas.lstTarefas());
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
                Tarefas Tarefas = new Tarefas();
                return StatusCode(200, Tarefas.InserirTarefa(Request));
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromBody] int ID_TAREFA)
        {
            try
            {
                Tarefas Tarefas = new Tarefas();
                var lstTarefas = Tarefas.DeletarTarefa(ID_TAREFA);
                return StatusCode(200, lstTarefas == null ? new {msg= "O ID_TAREFA informado não existe na base, favor inserir um id existente." }: lstTarefas);
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
                Tarefas Tarefas = new Tarefas();
                return StatusCode(200, Tarefas.AtualizarTarefa(Request));
            }
            catch(Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
