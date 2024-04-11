using System;


namespace ProjetoBanco
{
    class Program
    {
        static Cliente[] clientes = new Cliente[100];
        static Conta[] contas = new Conta[100];

        static void Main(string[] args)
        {
            ExibirMenuBanco();
        }

        static void ExibirMenuBanco()
        {
            while (true)
            {
                Console.WriteLine("———————————————MENU———————————————");
                Console.WriteLine("1. Cadastrar nova Conta");
                Console.WriteLine("2. Transferir Dinheiro");
                Console.WriteLine("3. Depositar Dinheiro");
                Console.WriteLine("4. Consultar Saldo");
                Console.WriteLine("5. Sair");

                Console.Write("Opção: ");
                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarNovaConta();
                        break;
                    case 2:
                        Transferir();
                        break;
                    case 3:
                        FazerDeposito();
                        break;
                    case 4:
                        ConsultarSaldo();
                        break;
                    case 5:
                        Console.WriteLine("Sistema finalizado.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }


            static void CadastrarNovaConta()
            {
                Cliente cliente = new Cliente();

                {

                    Console.WriteLine("CPF de cadastro (11 dígitos sem pontos ou traços): ");
                    string CPF = Console.ReadLine();

                    // Verifica se o CPF tem exatamente 11 caracteres e se todos os caracteres são dígitos
                    if (CPF.Length != 11 || !CPF.All(char.IsDigit))
                    {
                        Console.WriteLine("CPF inválido. Por favor, insira um CPF com 11 dígitos numéricos.");
                        continue;
                    }
                    if (ClienteJaCadastrado(CPF))
                    {
                        Console.WriteLine("CPF já cadastrado. Por favor, insira um CPF diferente.");
                        continue;
                    }
                    cliente.CpfCliente = CPF;
                    Console.WriteLine("Nome de cadastro: ");
                    string Nome = Console.ReadLine();
                    cliente.NomeCliente = Nome;

                    while (true)
                    {
                        Console.WriteLine("Qual o tipo da conta? (ContaCorrente ou ContaPoupanca): ");
                        string inputTipoConta = Console.ReadLine();

                        if (Enum.TryParse<TipoConta>(inputTipoConta, out TipoConta tipoConta))
                        {
                            Conta novaConta;
                            switch (tipoConta)
                            {
                                case TipoConta.ContaCorrente:
                                    novaConta = new Conta(tipoConta);
                                    break;
                                case TipoConta.ContaPoupanca:
                                    novaConta = new Conta(tipoConta);
                                    break;
                                default:
                                    Console.WriteLine("Tipo de conta inválido. Por favor, escolha um tipo válido.");
                                    continue;
                            }

                            cliente.Conta = novaConta;
                            cliente.AtualizarTipoCliente();
                            AdicionarCliente(cliente);
                            Console.WriteLine("Cliente cadastrado com sucesso!");
                            Console.WriteLine($"Número da conta: {novaConta.NumeroConta}");
                            Console.WriteLine($"Tipo de conta: {tipoConta}");
                            Console.WriteLine($"Saldo: {cliente.Conta.SaldoConta}");
                            return; 
                        }
                        else
                        {
                            Console.WriteLine("Tipo de conta inválido. Por favor, escolha um tipo válido.");
                        }
                    }
                }
            }

            static bool ClienteJaCadastrado(string cpf)
            {
                foreach (var cliente in clientes)
                {
                    if (cliente != null && cliente.CpfCliente == cpf)
                    {
                        return true;
                    }
                }
                return false;
            }

            static void AdicionarCliente(Cliente cliente)
            {

                for (int i = 0; i < clientes.Length; i++)
                {
                    if (clientes[i] == null)
                    {
                        clientes[i] = cliente;
                        break;
                    }
                }
            }
        }
        static void Transferir()
        {
            Console.WriteLine("Digite o CPF do remetente: ");
            string cpfRemetente = Console.ReadLine();
            Cliente remetente = EncontrarCliente(cpfRemetente);

            Console.WriteLine("Digite o CPF do destinatário: ");
            string cpfDestinatario = Console.ReadLine();
            Cliente destinatario = EncontrarCliente(cpfDestinatario);

            if (remetente == null || destinatario == null)
            {
                Console.WriteLine("CPF de remetente ou destinatário não encontrado.");
                return;
            }

            Console.WriteLine("Digite o valor a ser transferido: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Saldo insuficiente! O valor de transferência é maior que o Saldo em conta.");
                return;
            }
            if (valor > remetente.Conta.SaldoConta)
            {
                Console.WriteLine("Saldo insuficiente! O valor de transferência é maior que o saldo em conta.");
                Console.WriteLine($"Seu saldo é: R${remetente.Conta.SaldoConta}");
                return;
            }

            remetente.Conta.Transferir(valor);
            destinatario.Conta.Depositar(valor);

            Console.WriteLine("Transferência concluída com sucesso!");
            Console.WriteLine($"Saldo atual: {remetente.Conta.SaldoConta.ToString("C2")}");
        }

        static Cliente EncontrarCliente(string cpf)
        {
            foreach (var cliente in clientes)
            {
                if (cliente != null && cliente.CpfCliente == cpf)
                {
                    return cliente;
                }
            }
            return null;
        }

        static void FazerDeposito()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();
            Cliente cliente = EncontrarCliente(cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.WriteLine("Digite o valor a ser depositado: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido. Digite um valor numérico válido.");
                return;
            }
            else
            {

                cliente.Conta.Depositar(valor);
                Console.WriteLine("Depósito concluído com sucesso!");
                Console.WriteLine($"Saldo atual: {cliente.Conta.SaldoConta.ToString("C2")}");
                return;
            }
        }

        static void ConsultarSaldo()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();
            Cliente cliente = EncontrarCliente(cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }
            cliente.AtualizarTipoCliente();
            Console.WriteLine($"Nome: {cliente.NomeCliente.ToUpper()}");
            Console.WriteLine($"Tipo de conta: {cliente.Conta.Tipo}");
            Console.WriteLine($"Número da conta: {cliente.Conta.NumeroConta}");
            Console.WriteLine($"Saldo atual: {cliente.Conta.SaldoConta.ToString("C2")}");
            Console.WriteLine($"Cliente do tipo: {cliente.Tipo}");


        }
    }
}

