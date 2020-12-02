using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDRestaurante
{
    [Binding]
    public class StepDefinitions
    {
        private static String tipoPagamento;
        private static float valor;
        private static String confirmacao;
        private static String finalizado;
        private static String recebidoGarcom;
        private static int mesa;
        private static String recebidoCliente;


        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Que existem itens no cardapio")]
        public void DadoQueExistemItensNoCardapio()
        {
            //cliente acessa cardapio no aplicativo
        }

        [Given(@"Que o cliente tem acesso a esses itens")]
        public void DadoQueOClienteTemAcessoAEssesItens()
        {
            // cliente acessa os itens do cardapio
        }

        [Given(@"Que o cozinheiro recebeu a informacao de um pedido")]
        public void DadoQueOCozinheiroRecebeuAInformacaoDeUmPedido()
        {
           // pedido enviado a cozinha com sucesso
        }

        [Given(@"Que esse pedido e o proximo na fila de execucao")]
        public void DadoQueEssePedidoEOProximoNaFilaDeExecucao()
        {
            //pedido será executado
        }

        [Given(@"Que o cozinheiro entregou o pedido ao garcom (.*)")]
        public void DadoQueOCozinheiroEntregouOPedidoAoGarcom(string p0)
        {
            StepDefinitions.recebidoGarcom = p0;
        }

        [Given(@"Que no pedido ha informacoes de qual mesa deve ser entregue (.*)")]
        public void DadoQueNoPedidoHaInformacoesDeQualMesaDeveSerEntregue(int mesa0)
        {
            StepDefinitions.mesa = mesa0;
        }

        [Given(@"Que o cliente deseja realizar o pagamento")]
        public void DadoQueOClienteDesejaRealizarOPagamento()
        {
            //garcom recebeu alerta do cliente no aplicativo
        }

        [Given(@"Que sabe que o valor final do seu consumo foi: (.*)")]
        public void DadoQueSabeQueOValorFinalDoSeuConsumoFoi(float p0)
        {
            StepDefinitions.valor = p0;
        }


        [When(@"o cliente escolher os itens do seu pedido ""(.*)""")]
        public void QuandoOClienteEscolherOsItensDoSeuPedido(string status)
        {
            StepDefinitions.confirmacao= status;
        }

        [When(@"sua producao estiver concluida (.*)")]
        public void QuandoSuaProducaoEstiverConcluida(string finalizado0)
        {
            StepDefinitions.finalizado = finalizado0;
        }

        [When(@"garcom entregar o pedido ao cliente (.*)")]
        public void QuandoGarcomEntregarOPedidoAoCliente(string recebido0)
        {
            StepDefinitions.recebidoCliente = recebido0;
        }

        [When(@"o cliente executar o pagamento no: ""(.*)""")]
        public void QuandoOClienteExecutarOPagamentoNo(string p0)
        {
            StepDefinitions.tipoPagamento = p0;
        }

        [Then(@"o cozinheiro sera avisado da escolha ""(.*)""")]
        public void EntaoOCozinheiroSeraAvisadoDaEscolha(string p0)
        {
            if (StepDefinitions.confirmacao == "sim") 
            {
                p0 = "pedido confirmado"; 
            }else
            {
                p0 = "pedido pendente";
            }
        }

        [Then(@"O cozinheiro entregara o pedido ao garcom (.*)")]
        public void EntaoOCozinheiroEntregaraOPedidoAoGarcom(string p0)
        {
            if (StepDefinitions.finalizado == "sim")
            {
                p0 = "pedido disponivel";
            }
            else
            {
                p0 = "pedido pendente";
            }
        }

        [Then(@"o pedido estara de acordo com o esperado e podera ser consumido pelo cliente (.*)")]
        public void EntaoOPedidoEstaraDeAcordoComOEsperadoEPoderaSerConsumidoPeloCliente(string p0)
        {
          if ((recebidoGarcom == "sim") &&  (recebidoCliente == "sim") && (mesa != 0)) {
                p0 = "finalizado";
            }
            else
            {
                p0 = "pedido pendente";
            }
        }

        [Then(@"O valor deve ser creditado no caixa do restaurante: ""(.*)""")]
        public void EntaoOValorDeveSerCreditadoNoCaixaDoRestaurante(string p0)
        {
            if((StepDefinitions.tipoPagamento == "cartao credito" || StepDefinitions.tipoPagamento == "cartao credito") && StepDefinitions.valor > 0){
                p0 = "Finalizado ok";
            }else
            {
                p0 = "Pagamento nao autorizado";
            }

        }
    }
}
