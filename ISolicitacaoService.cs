using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceDeskFiscal.SoapService
{
    [ServiceContract]
    public interface ISolicitacaoService
    {

        [OperationContract]
        CriarSolicitacaoResponse CriarSolicitacao(CriarSolicitacaoRequest request);

        [OperationContract]
        ObterSolicitacaoResponse ObterSolicitacao(ObterSolicitacaoRequest request);

        [OperationContract]
        ListarSolicitacoesResponse ListarSolicitacoes();

        [OperationContract]
        ProcessarSolicitacaoResponse ProcessarSolicitacao(ProcessarSolicitacaoRequest request);

    }

    /// <summary>
    /// Classe criada contendo propriedades para representar a resposta da operação CriarSolicitacao
    /// Segue o padrão de nomenclatura de Request e Response para as operações do serviço, como no trecho comentado abaixo.
    /// </summary>
    [DataContract]
    public class CriarSolicitacaoRequest
    {
        [DataMember]
        public string TipoSolicitacao { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string UsuarioSolicitante { get; set; }
    }

    [DataContract]
    public class CriarSolicitacaoResponse
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Mensagem { get; set; }
    }

    [DataContract]
    public class ObterSolicitacaoRequest
    {
        [DataMember]
        public string Id { get; set; }        
    }

    [DataContract]
    public class ObterSolicitacaoResponse
    {
        [DataMember]
        public SolicitacaoDto Solicitacao { get; set; }
        [DataMember]
        public string Mensagem { get; set; }
    }

    [DataContract]
    public class ListarSolicitacoesResponse
    {
        [DataMember]
        public List<SolicitacaoDto> Solicitacoes { get; set; }
    }

    [DataContract]
    public class ProcessarSolicitacaoRequest
    {
        [DataMember]
        public string Id { get; set; }
    }

    [DataContract]
    public class ProcessarSolicitacaoResponse
    {
        [DataMember]
        public string Id { get; set; }
        
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string ResultadoProcessamento { get; set; }
        [DataMember]
        public string Mensagem { get; set; }
    }

    [DataContract]
    public class SolicitacaoDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string TipoSolicitacao { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string UsuarioSolicitante { get; set; }
        [DataMember]
        public DateTime DataCriacao { get; set; }
        [DataMember]
        public DateTime? DataProcessamento { get; set; }
        [DataMember]
        public string ResultadoProcessamento { get; set; }
    }
    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}    

}
