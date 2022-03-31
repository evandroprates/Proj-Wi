using Desafio2.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Desafio2
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpClient client;
            Uri usuarioUri;


             client = new HttpClient();
             client.BaseAddress = new Uri("https://localhost:44378/");
             client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("Fila/PegarLista").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                usuarioUri = response.Headers.Location;

                //Pegando os dados do Rest e armazenando na variável usuários
                var Fila = response.Content.ReadAsStringAsync<IEnumerable<Fila>>().Result;

            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var caminhoPlanilhaMoeda = "\\Arquivos\\DadosMoeda.csv";

            var arquivoExcelMoeda = new ExcelPackage(new FileInfo(caminhoPlanilhaMoeda));

            ExcelWorksheet planilhaMoeda = arquivoExcelMoeda.Workbook.Worksheets["DadosMoeda"];

            List<Moeda> listaMoedas = new List<Moeda>();

            int indice = 2;

            for (int i = 0; i < 380452; i++)
            {
                listaMoedas.Add(new Moeda
                {
                    IdMoeda = planilhaMoeda.Cells[indice, 1].Value.ToString(),
                    DataRef = planilhaMoeda.Cells[indice, 2].Value.ToString()
                });

                indice++;
            }

            var caminhoSalvar = "\\Arquivos\\Resultado_aaaammdd_HHmmss.csv";

            FileInfo arquivo = new FileInfo(caminhoSalvar);
            arquivoExcelMoeda.SaveAs(arquivo);

        }
    }
}
