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
        private static String statusPagamento;

        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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

        [When(@"o cliente executar o pagamento no: ""(.*)""")]
        public void QuandoOClienteExecutarOPagamentoNo(string p0)
        {
            StepDefinitions.tipoPagamento = p0;
        }

        [Then(@"O valor deve ser creditado no caixa do restaurante: ""(.*)""")]
        public void EntaoOValorDeveSerCreditadoNoCaixaDoRestaurante(string p0)
        {
            if((StepDefinitions.tipoPagamento == "cartao credito" || StepDefinitions.tipoPagamento == "cartao credito") && StepDefinitions.valor > 0){
                StepDefinitions.statusPagamento = "Finalizado ok";
            }else
            {
                StepDefinitions.statusPagamento = "Pagamento nao autorizado";
            }

        }
    }
}
