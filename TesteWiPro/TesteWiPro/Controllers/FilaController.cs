using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteWiPro.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteWiPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaController : ControllerBase
    {
        [HttpGet("PegarLista")]
        public Fila GetItemFila(List<Fila> fila)
        {
            if (fila.Count() > 0) 
            {
                var ultimo = fila.Last();
                return ultimo;
                DeletarDaFila(fila, ultimo);
            }

            return null; //Não encontrado
        }

        [HttpPost ("AdicionarItem")]
        public void AddItemFila([FromBody] JsonResult json)
        {
            string jsonEntrada = @"
            [
             {
             ""moeda"": ""USD"",
             ""data_inicio"": ""2010 -01-01"",
             ""data_fim"": ""2010-12-01""
             },
             {
             ""moeda"": ""EUR"",
             ""data_inicio"": ""2020 -01-01"",
             ""data_fim"": ""2010-12-01""
             },
             {
             ""moeda"": ""JPY"",
             ""data_inicio"": ""2000-03-11"",
             ""data_fim"": ""2000-03-30""
             }
            ]";

            var listaFila = JsonConvert.DeserializeObject<List<Fila>>(jsonEntrada);

            GetItemFila(listaFila);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public void DeletarDaFila(List<Fila> fila, Fila ultimo)
        {
            fila.Remove(ultimo);
        }
    }
}
