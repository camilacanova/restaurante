﻿#language: pt-br

@venda_refeicoes_restaurante
Funcionalidade: Venda refeicoes em um restaurante
Fluxo de um atendimento no restaurante, pedido, entrega e pagamento

@realiza_pedido
    Cenario: Cliente realiza um pedido
    Dado Que existem itens no cardapio
    E Que o cliente tem acesso a esses itens
    Quando o cliente escolher os itens do seu pedido <confirmacao>
    Entao o cozinheiro sera avisado da escolha <status pedido>
     Exemplos: 
    | confirmacao | status pedido       |
    | "sim"       | "pedido confirmado" |
    | "nao"       | "pedido pendente"   |

@executa_pedido
Cenario: Cozinheiro executa o pedido
    Dado Que o cozinheiro recebeu a informacao de um pedido
    E Que esse pedido e o proximo na fila de execucao
    Quando sua producao estiver concluida <finalizado>
    Entao O cozinheiro entregara o pedido ao garcom <pedido disponivel>
    Exemplos: 
    | finalizado | pedido disponivel  |
    |"sim"   | "pedido disponivel" |
    |"nao"   | "pedido pendente"  |

@entrega_pedido
Cenario: Garcom entrega o pedido na mesa
    Dado Que o cozinheiro entregou o pedido ao garcom <recebido garcom>
    E Que no pedido ha informacoes de qual mesa deve ser entregue <mesa>
    Quando garcom entregar o pedido ao cliente <recebido cliente>
    Entao o pedido estara de acordo com o esperado e podera ser consumido pelo cliente <finalizado cliente>
    Exemplos: 
    | recebido garcom | mesa  | recebido cliente | finalizado cliente |
    | "sim"           | 12 | "sim"            | "finalizado"              |
    | "sim"           | 01 | "nao"            | "pedido pendente"              |
    | "sim"           | 0 | "nao"            | "pedido pendente"              |

@pagamento_conta
Cenario: Pagamento da conta
    Dado Que o cliente deseja realizar o pagamento
    E Que sabe que o valor final do seu consumo foi: <valor>
    Quando o cliente executar o pagamento no: <tipo pagamento>
    Entao O valor deve ser creditado no caixa do restaurante: <status pagamento>
    Exemplos: 
    | valor | tipo pagamento   | status pagamento           |
    | 50    | "cartao credito" | "Finalizado ok"            |
    | 100   | "cartao credito"  | "Finalizado ok" |
    | 150   | "cartao debito" | "Finalizado ok"            |
    | 150   | "dinheiro" | "Pagamento nao autorizado"            |
    | 0   | "cartao debito" | "Pagamento nao autorizado"            |

