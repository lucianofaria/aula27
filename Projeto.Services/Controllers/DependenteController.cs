using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Data.Entities; // importando
using Projeto.Data.Repositories; // importando
using Projeto.Services.Models; // importando

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/Dependente")]
    public class DependenteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(DependenteCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dependente dependente = new Dependente();
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = model.DataNascimento;
                    dependente.IdFuncionario = model.IdFuncionario;

                    DependenteRepository repository = new DependenteRepository();
                    repository.Inserir(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK, "Dependente cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    // Internal server error -> status http 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                // bad request -> status http 400
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação");
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(DependenteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dependente dependente = new Dependente();
                    dependente.IdDependente = model.IdDependente;
                    dependente.Nome = model.Nome;
                    dependente.DataNascimento = model.DataNascimento;
                    dependente.IdFuncionario = model.IdFuncionario;

                    DependenteRepository repository = new DependenteRepository();
                    repository.Alterar(dependente);

                    return Request.CreateResponse(HttpStatusCode.OK, "Dependente alterado com sucesso.");
                }
                catch (Exception e)
                {
                    // Internal server error -> status http 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                // bad request -> status http 400
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Ocorreram erros de validação");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                DependenteRepository repository = new DependenteRepository();
                Dependente dependente = repository.ObterPorId(id);

                //excluindo
                repository.Excluir(dependente);

                return Request.CreateResponse(HttpStatusCode.OK, "Dependente excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<DependenteConsultaModel> lista = new List<DependenteConsultaModel>();

                DependenteRepository repository = new DependenteRepository();
                foreach (var item in repository.ObterTodo())
                {
                    DependenteConsultaModel model = new DependenteConsultaModel();
                    model.IdDependente = item.IdDependente;
                    model.Nome = item.Nome;
                    model.DataNascimento = item.DataNascimento;
                    model.IdFuncionario = item.IdFuncionario;

                    lista.Add(model);
                }
                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}