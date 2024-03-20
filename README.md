• Parte 1 do projeto final da FourCamp2024, da Foursys em parceria com o Educ360.

Desenvolvendo um projeto simples de banco.

![image](https://github.com/imlverdan/ProjetoBanco/assets/154383154/29656919-d664-461f-a991-962e237517fc)




**Você vai desenvolver um software para uma empresa que deseja oferecer uma 
solução financeira a seus clientes.**

**Os requisitos dessa parte são:**
• Desenvolver um projeto do tipo Console na linguagem C# \
• Criar as classes conforme a ilustração do diagrama UML \
• Desenvolver o funcionamento de todas as opções com as regras 

**Deverá haver um menu onde o usuário poderá selecionar as opções:**
1. Cadastrar nova Conta 
2. Transferir Dinheiro 
3. Depositar Dinheiro 
4. Consultar Saldo 
5. Sair

**Opção 1 (Cadastrar nova Conta com cliente):**
Cadastrar uma nova conta referente ao tipo da conta informado pelo cliente. 
Cadastrar o cliente com cpf, nome completo e tipo. 

O cliente deve informar o CPF com 11 dígitos sem pontos ou traços. Atenção, o 
programa deve validar se foram digitados 11 números. Dígitos acima ou abaixo 
de 11 devem desencadear uma mensagem de erro orientando o usuário a 
tentar novamente sem terminar com o programa. Após o usuário digitar 11 
dígitos, o programa deve retornar ao menu principal. 

O número da conta pode ser construído diretamente no código. O usuário não 
escolhe o número da conta e não é necessário elaborar lógica para gerar esse 
número. 

Ao criar uma conta, o valor do saldo já recebe automaticamente o valor de 
ZERO. O valor de um saldo só pode ser alterado por Depósito ou Transferência, 
devendo a propriedade Saldo ser protegida de modificação de outras classes 
que não a classe Conta Corrente ou Poupanca. 

**Opção 2 (Transferir Dinheiro):**
O programa deve perguntar a quantia que o usuário quer transferir. Se o saldo 
for insuficiente, uma mensagem deve aparecer na tela informando ao usuário 
que o saldo é insuficiente e o valor do Saldo atual na conta. Se houver saldo 
suficiente, uma mensagem avisando que a transferência foi realizada com 
sucesso. O valor do saldo deve aparecer após a transferência. Após o término 
dessa operação, o programa deve retornar automaticamente ao menu principal. 

**Opção 3 (Depositar Dinheiro):**
O programa pergunta a quantia que o usuário quer depositar. Uma mensagem 
de sucesso aparece e o valor do saldo após o depósito também. Após o término 
dessa operação, o programa deve retornar automaticamente ao menu principal. 

**Opção 4 (Consultar Saldo):**
As seguintes informações devem aparecer: 
• Dados do cliente (nome, tipo); 
• Dados da conta do cliente (número, saldo, tipo); 
Ao término da operação, o programa deve retornar automaticamente ao menu 
principal; 

**Opção 5 (Sair):**
O programa deve ser encerrado com uma mensagem ao usuário indicando que 
o sistema foi finalizado. Atenção: essa é a única opção viável para que o usuário 
encerre o programa ativamente. 

** Regras gerais do sistema: **

O sistema deverá guardar as informações do Cliente e Conta dentro de objetos 
criados dentro do Program. 

A classe Conta deve ser abstrata, então ContaCorrente e ContaPoupanca devem 
fazer herança dela. 

A Operação de transferência e deposito devem ser feitas pela classe 
ContaCorrente ou ContaPoupanca (depende de qual o tipo da conta que o 
cliente informou), e as taxas incidirão no Saldo. A mudança no comportamento 
desses métodos para as regras de manipulação do saldo deve ser feita por 
polimorfismo. 

Um cliente deve ter seu Tipo classificado de acordo com o saldo na sua conta. 
• Se o saldo for maior ou igual a R$ 15.000,00, ele automaticamente se 
torna um cliente Premium;  

• Se o saldo estiver entre R$ 5.000,00 e R$ 14.999,00, ele 
automaticamente se torna um cliente Super;  

• Se o saldo estiver abaixo de R$ 5.000,00, ele automaticamente se torna 
um cliente Comum; 

Ao criar um cliente com uma conta, o Tipo dele por padrão é Comum. O Tipo 
só pode ser alterado automaticamente segundo as regras descritas acima. 
