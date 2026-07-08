using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceDeskFiscal.SoapService
{
    public class SolicitacaoService : ISolicitacaoService
    {
        private static readonly List<SolicitacaoDto> _solicitacoes = new List<SolicitacaoDto>();
        public CriarSolicitacaoResponse CriarSolicitacao(CriarSolicitacaoRequest request)
        {
            var solicitacao = new SolicitacaoDto
            {
                Id = Guid.NewGuid().ToString(),
                TipoSolicitacao = request.TipoSolicitacao,
                Descricao = request.Descricao,
                UsuarioSolicitante = request.UsuarioSolicitante,
                Status = "Pendente",
                DataCriacao = DateTime.Now,
                ResultadoProcessamento = null
            };

            _solicitacoes.Add(solicitacao);

            return new CriarSolicitacaoResponse
            {
                Id = solicitacao.Id,
                Status = solicitacao.Status,
                Mensagem = "Solicitação criada com sucesso."
            };
        }
       
        public ObterSolicitacaoResponse ObterSolicitacao(ObterSolicitacaoRequest request)
        {
            var solicitacao = _solicitacoes.FirstOrDefault(x => x.Id == request.Id);

            if(solicitacao == null)
            {
                return new ObterSolicitacaoResponse
                {
                    Solicitacao = null,
                    Mensagem = "Solicitação não encontrada."
                };
            }

            return new ObterSolicitacaoResponse
            {
                Solicitacao = solicitacao,
                Mensagem = "Solicitação obtida com sucesso."
            };
        }

        public ListarSolicitacoesResponse ListarSolicitacoes()
        {
            return new ListarSolicitacoesResponse
            {
                Solicitacoes = _solicitacoes
            };
        }

        public ProcessarSolicitacaoResponse ProcessarSolicitacao(ProcessarSolicitacaoRequest request)
        {
            var solicitacao = _solicitacoes.FirstOrDefault(x => x.Id == request.Id);

            if (solicitacao == null)
            {
                return new ProcessarSolicitacaoResponse
                {
                    Id = request.Id,
                    Status = "Erro",
                    ResultadoProcessamento = null,
                    Mensagem = "Solicitação não encontrada."
                };
            }

            if (solicitacao.Status == "Processada")
            {
                return new ProcessarSolicitacaoResponse
                {
                    Id = solicitacao.Id,
                    Status = solicitacao.Status,
                    ResultadoProcessamento = solicitacao.ResultadoProcessamento,
                    Mensagem = "Solicitação já estava processada."
                };
            }

            solicitacao.Status = "Processada";
            solicitacao.DataProcessamento = DateTime.Now;
            solicitacao.ResultadoProcessamento = "Processamento concluído pela engine fake.";

            return new ProcessarSolicitacaoResponse
            {
                Id = solicitacao.Id,
                Status = solicitacao.Status,
                ResultadoProcessamento = solicitacao.ResultadoProcessamento,
                Mensagem = "Solicitação processada com sucesso."
            };
        }    
    }
}
