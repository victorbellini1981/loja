using System;
using System.Collections.Generic;
using System.Linq;
using Loja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteControllers : ControllerBase
    {
        public static List<Cliente> clientes = new List<Cliente>();

        public ClienteControllers() {
            if(clientes.Count <= 0) {
                Cliente cliente = new Cliente() {
                Id = 1, Nome = "João Paulo", Credito = 600.00,
                DataNascimento = Convert.ToDateTime("22/05/1999"), Liberado = true};
                clientes.Add(cliente);
                cliente = new Cliente() {
                Id = 2, Nome = "João Victor", Credito = 400.00, 
                DataNascimento = Convert.ToDateTime("10/05/1981"), Liberado = true};
                clientes.Add(cliente);
                cliente = new Cliente() {
                Id = 3, Nome = "Marcelo", Credito = 500.00, 
                DataNascimento = Convert.ToDateTime("27/11/1995"), Liberado = false};
                clientes.Add(cliente);
                cliente = new Cliente() {
                Id = 4, Nome = "Leonardo", Credito = 700.00, 
                DataNascimento = Convert.ToDateTime("18/03/1998"), Liberado = false};
                clientes.Add(cliente);
                cliente = new Cliente() {
                Id = 5, Nome = "Fernando", Credito = 1000.00, 
                DataNascimento = Convert.ToDateTime("04/03/1988"), Liberado = true};
                clientes.Add(cliente);
            }
        }
        [HttpGet]
        public IActionResult Get() {
            
            return Ok(clientes);
        }
    }
}