using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TesteWiPro.Models;

namespace TesteWiPro
{
    public class Principal
    {
        static void Main(string[] args)
        {

            var caminhoPlanilhaMoeda = $"{Directory.GetCurrentDirectory()}\\Arquivos\\DadosMoeda.csv";

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

            var a = "";
           

        }
    }
}
