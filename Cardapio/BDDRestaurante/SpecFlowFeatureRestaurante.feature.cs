﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.5.0.0
//      SpecFlow Generator Version:3.5.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BDDRestaurante
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class VendaRefeicoesEmUmRestauranteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private string[] _featureTags = new string[] {
                "venda_refeicoes_restaurante"};
        
#line 1 "SpecFlowFeatureRestaurante.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "", "Venda refeicoes em um restaurante", "Fluxo de um atendimento no restaurante, pedido, entrega e pagamento", ProgrammingLanguage.CSharp, new string[] {
                        "venda_refeicoes_restaurante"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Venda refeicoes em um restaurante")))
            {
                global::BDDRestaurante.VendaRefeicoesEmUmRestauranteFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void ClienteRealizaUmPedido(string confirmacao, string statusPedido, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "realiza_pedido"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("confirmacao", confirmacao);
            argumentsOfScenario.Add("status pedido", statusPedido);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cliente realiza um pedido", null, tagsOfScenario, argumentsOfScenario);
#line 8
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
    testRunner.Given("Que existem itens no cardapio", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 10
    testRunner.And("Que o cliente tem acesso a esses itens", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 11
    testRunner.When(string.Format("o cliente escolher os itens do seu pedido {0}", confirmacao), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 12
    testRunner.Then(string.Format("o cozinheiro sera avisado da escolha {0}", statusPedido), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cliente realiza um pedido: \"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("realiza_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:confirmacao", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pedido", "\"pedido confirmado\"")]
        public virtual void ClienteRealizaUmPedido_Sim()
        {
#line 8
    this.ClienteRealizaUmPedido("\"sim\"", "\"pedido confirmado\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cliente realiza um pedido: \"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("realiza_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:confirmacao", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pedido", "\"pedido pendente\"")]
        public virtual void ClienteRealizaUmPedido_Nao()
        {
#line 8
    this.ClienteRealizaUmPedido("\"nao\"", "\"pedido pendente\"", ((string[])(null)));
#line hidden
        }
        
        public virtual void CozinheiroExecutaOPedido(string finalizado, string pedidoDisponivel, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "executa_pedido"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("finalizado", finalizado);
            argumentsOfScenario.Add("pedido disponivel", pedidoDisponivel);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cozinheiro executa o pedido", null, tagsOfScenario, argumentsOfScenario);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 20
    testRunner.Given("Que o cozinheiro recebeu a informacao de um pedido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 21
    testRunner.And("Que esse pedido e o proximo na fila de execucao", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 22
    testRunner.When(string.Format("sua producao estiver concluida {0}", finalizado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 23
    testRunner.Then(string.Format("O cozinheiro entregara o pedido ao garcom {0}", pedidoDisponivel), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cozinheiro executa o pedido: \"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("executa_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:finalizado", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:pedido disponivel", "\"pedido disponivel\"")]
        public virtual void CozinheiroExecutaOPedido_Sim()
        {
#line 19
this.CozinheiroExecutaOPedido("\"sim\"", "\"pedido disponivel\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cozinheiro executa o pedido: \"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("executa_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:finalizado", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:pedido disponivel", "\"pedido pendente\"")]
        public virtual void CozinheiroExecutaOPedido_Nao()
        {
#line 19
this.CozinheiroExecutaOPedido("\"nao\"", "\"pedido pendente\"", ((string[])(null)));
#line hidden
        }
        
        public virtual void GarcomEntregaOPedidoNaMesa(string recebidoGarcom, string mesa, string recebidoCliente, string finalizadoCliente, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "entrega_pedido"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("recebido garcom", recebidoGarcom);
            argumentsOfScenario.Add("mesa", mesa);
            argumentsOfScenario.Add("recebido cliente", recebidoCliente);
            argumentsOfScenario.Add("finalizado cliente", finalizadoCliente);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Garcom entrega o pedido na mesa", null, tagsOfScenario, argumentsOfScenario);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
    testRunner.Given(string.Format("Que o cozinheiro entregou o pedido ao garcom {0}", recebidoGarcom), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 32
    testRunner.And(string.Format("Que no pedido ha informacoes de qual mesa deve ser entregue {0}", mesa), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 33
    testRunner.When(string.Format("garcom entregar o pedido ao cliente {0}", recebidoCliente), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 34
    testRunner.Then(string.Format("o pedido estara de acordo com o esperado e podera ser consumido pelo cliente {0}", finalizadoCliente), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Garcom entrega o pedido na mesa: Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("entrega_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido garcom", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:mesa", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido cliente", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:finalizado cliente", "\"finalizado\"")]
        public virtual void GarcomEntregaOPedidoNaMesa_Variant0()
        {
#line 30
this.GarcomEntregaOPedidoNaMesa("\"sim\"", "12", "\"sim\"", "\"finalizado\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Garcom entrega o pedido na mesa: Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("entrega_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido garcom", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:mesa", "01")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido cliente", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:finalizado cliente", "\"pedido pendente\"")]
        public virtual void GarcomEntregaOPedidoNaMesa_Variant1()
        {
#line 30
this.GarcomEntregaOPedidoNaMesa("\"sim\"", "01", "\"nao\"", "\"pedido pendente\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Garcom entrega o pedido na mesa: Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("entrega_pedido")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido garcom", "\"sim\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:mesa", "0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:recebido cliente", "\"nao\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:finalizado cliente", "\"pedido pendente\"")]
        public virtual void GarcomEntregaOPedidoNaMesa_Variant2()
        {
#line 30
this.GarcomEntregaOPedidoNaMesa("\"sim\"", "0", "\"nao\"", "\"pedido pendente\"", ((string[])(null)));
#line hidden
        }
        
        public virtual void PagamentoDaConta(string valor, string tipoPagamento, string statusPagamento, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "pagamento_conta"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("valor", valor);
            argumentsOfScenario.Add("tipo pagamento", tipoPagamento);
            argumentsOfScenario.Add("status pagamento", statusPagamento);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pagamento da conta", null, tagsOfScenario, argumentsOfScenario);
#line 42
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 43
    testRunner.Given("Que o cliente deseja realizar o pagamento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 44
    testRunner.And(string.Format("Que sabe que o valor final do seu consumo foi: {0}", valor), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 45
    testRunner.When(string.Format("o cliente executar o pagamento no: {0}", tipoPagamento), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 46
    testRunner.Then(string.Format("O valor deve ser creditado no caixa do restaurante: {0}", statusPagamento), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pagamento da conta: Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("pagamento_conta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:valor", "50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tipo pagamento", "\"cartao credito\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pagamento", "\"Finalizado ok\"")]
        public virtual void PagamentoDaConta_Variant0()
        {
#line 42
this.PagamentoDaConta("50", "\"cartao credito\"", "\"Finalizado ok\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pagamento da conta: Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("pagamento_conta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:valor", "100")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tipo pagamento", "\"cartao credito\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pagamento", "\"Finalizado ok\"")]
        public virtual void PagamentoDaConta_Variant1()
        {
#line 42
this.PagamentoDaConta("100", "\"cartao credito\"", "\"Finalizado ok\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pagamento da conta: Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("pagamento_conta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:valor", "150")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tipo pagamento", "\"cartao debito\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pagamento", "\"Finalizado ok\"")]
        public virtual void PagamentoDaConta_Variant2()
        {
#line 42
this.PagamentoDaConta("150", "\"cartao debito\"", "\"Finalizado ok\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pagamento da conta: Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("pagamento_conta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:valor", "150")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tipo pagamento", "\"dinheiro\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pagamento", "\"Pagamento nao autorizado\"")]
        public virtual void PagamentoDaConta_Variant3()
        {
#line 42
this.PagamentoDaConta("150", "\"dinheiro\"", "\"Pagamento nao autorizado\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Pagamento da conta: Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Venda refeicoes em um restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("venda_refeicoes_restaurante")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("pagamento_conta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:valor", "0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:tipo pagamento", "\"cartao debito\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:status pagamento", "\"Pagamento nao autorizado\"")]
        public virtual void PagamentoDaConta_Variant4()
        {
#line 42
this.PagamentoDaConta("0", "\"cartao debito\"", "\"Pagamento nao autorizado\"", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
