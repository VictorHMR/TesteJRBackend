using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                List<TarefaDTO> lstTarefas = new List<TarefaDTO>();

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                });

                return lstTarefas;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TarefaDTO> InserirTarefa(TarefaDTO Request)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas();
                lstResponse.Add(Request);
                return lstResponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                List<TarefaDTO> lstResponse = lstTarefas(); // Está sendo feito a chamado do método, para que a lista seja populada.
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA); // É feito a chamada de um método para que seja retornado apenas a Tarefa com o ID_TAREFA igual ao ID_TAREFA passado na request.
                //TarefaDTO Tarefa2 = lstResponse.Where(x=> x.ID_TAREFA == Tarefa.ID_TAREFA).FirstOrDefault(); // O método tem o retorno igual ao anterior porém na pratica eles funcionam de formas diferentes.
                if (Tarefa != null)
                {
                    lstResponse.Remove(Tarefa); // A tarefa relativa ao ID_TAREFA passado na request é removida da lista.
                    return lstResponse; // A nova lista é retornada na response.
                }
                else
                    return null; //Caso não seja excluido nada, retorna null.

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TarefaDTO> AtualizarTarefa(TarefaDTO Request)
        {
            List<TarefaDTO> lstResponse = lstTarefas();
            lstResponse.Where(x => x.ID_TAREFA == Request.ID_TAREFA).ToList().ForEach(s => s.DS_TAREFA = Request.DS_TAREFA);

            return lstResponse;
        }

    }
}
