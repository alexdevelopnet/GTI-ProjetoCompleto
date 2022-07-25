
using GTI.API.Models;
using GTI.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ClienteController : ApiController
    {
        // GET api/cliente
        [Route("cliente-get")]
        public IEnumerable<Cliente> Get()
        {
            ClienteBL clienteBL = new ClienteBL();
            IEnumerable<Cliente> clientes = new List<Cliente>();
            clientes = clienteBL.Listar();
            return clientes;
        }

        // GET api/cliente/5
        [Route("cliente-get{id}")]
        public Cliente Get(int id)
        {
            ClienteBL clienteBL = new ClienteBL();

            return clienteBL.Obter(id); ;
        }

        // POST api/values
        [Route("cliente-post")]
        public HttpResponseMessage Post([System.Web.Http.FromBody]Cliente cliente)
        {
            ClienteBL clienteBL = new ClienteBL();
            clienteBL.Iserir(cliente);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "cliente", id = cliente.Id });
            response.Headers.Location = new Uri(location) ;
            return response;
        }

        // PUT api/values/5
        [Route("cliente-Put{id}")]
        public HttpResponseMessage Put(Cliente cli, [System.Web.Http.FromBody]Cliente cliente)
        {
            ClienteBL clienteBL = new ClienteBL();

            clienteBL.Atualizar(cli);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "cliente", id = cliente.Id });
            response.Headers.Location = new Uri(location);
            return response;
        }

        //DELETE api/values/5
        /// <summary>
        ///DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("cliente-delete{id}")]
        public HttpResponseMessage Delete(int id, [System.Web.Http.FromBody]Cliente cliente)
        {
            ClienteBL clienteBL = new ClienteBL();

            clienteBL.Excluir(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            string location = Url.Link("DefaultApi", new { controller = "cliente", id = cliente.Id });
            response.Headers.Location = new Uri(location);
            return response;
        }
    }
}