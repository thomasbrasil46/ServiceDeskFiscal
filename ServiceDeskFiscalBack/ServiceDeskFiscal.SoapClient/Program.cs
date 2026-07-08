using ServiceDeskFiscal.SoapClient.SolicitacaoServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDeskFiscal.SoapClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new SolicitacaoServiceClient();

            var criarResponse = client.CriarSolicitacao(new CriarSolicitacaoRequest
            {
                TipoSolicitacao = "Cancelamento",
                Descricao = "Cancelar documento 12345 por erro de dados.",
                UsuarioSolicitante = "Thomas"
            });

            Console.WriteLine("Criada:");
            Console.WriteLine("Id: " + criarResponse.Id);
            Console.WriteLine("Status: " + criarResponse.Status);
            Console.WriteLine("Mensagem: " + criarResponse.Mensagem);

            var processarResponse = client.ProcessarSolicitacao(new ProcessarSolicitacaoRequest
            {
                Id = criarResponse.Id
            });

            Console.WriteLine();
            Console.WriteLine("Processamento:");
            Console.WriteLine("Id: " + processarResponse.Id);
            Console.WriteLine("Status: " + processarResponse.Status);
            Console.WriteLine("Resultado: " + processarResponse.ResultadoProcessamento);
            Console.WriteLine("Mensagem: " + processarResponse.Mensagem);

            Console.ReadLine();
        }
    }
}
