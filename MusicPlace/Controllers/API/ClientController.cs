using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private MusicPlaceDBConnection connection;

        [HttpPost]
        public async Task<Client> Post(Client client)
        {
            try
            {
                connection = new();
                return await connection.PostClient(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<Client> Put(int id, Client client)
        {
            try
            {
                connection = new();
                return await connection.PutClient(id, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                connection = new();
                return await connection.DeleteClient(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        public async Task<List<Client>> Get()
        {
            try
            {
                connection = new();
                return await connection.GetClientsActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all")]
        public async Task<List<Client>> GetAll()
        {
            try
            {
                connection = new();
                return await connection.GetAllClients();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<Client> GetById(int id)
        {
            try
            {
                connection = new();
                return await connection.GetByIdClient(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
