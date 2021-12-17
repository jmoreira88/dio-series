#pragma warning disable CS8600

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string [] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        OpcaoUsuario = ObterOpcaoUsuario();

                        break;

                    case "2":
                        InserirSerie();
                        OpcaoUsuario = ObterOpcaoUsuario();

                        break;

                    case "3":
                        AtualizarSerie();
                        OpcaoUsuario = ObterOpcaoUsuario();

                    break;

                    case "4":
                        ExcluirSerie();
                        OpcaoUsuario = ObterOpcaoUsuario();
                    break;

                    case "5":
                        VisualizarSerie();
                        OpcaoUsuario = ObterOpcaoUsuario();
                        break;

                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }
        } 
                    
        private static string ObterOpcaoUsuario()
        {
            // Lê a hora do PC e dá bom dia, boa tarde ou boa noite de acordo com o horário.

            string cumprimento = "";
            string momento =  DateTime.Now.ToString("HH:mm:ss");
            string[] hora = momento.Split(':');
            
            int inthora = Convert.ToInt32(hora[0]);

            if(inthora>6 && inthora<12)
            {
                 cumprimento = "Bom dia!";
            }
            else if(inthora>12 && inthora < 18)
            {
                cumprimento = "Boa tarde!";
            }

            else

            {
                cumprimento = "Boa noite!";
            }

            Console.WriteLine($"{cumprimento} Bem vindo à DIOflix!");
        

            Console.WriteLine(" ");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                Console.WriteLine(" ");
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {3}", serie.retornaId(), serie.retornaTitulo(), excluido ? "(excluído)":"");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            var enumType = typeof(Genero);
            foreach (int i in Enum.GetValues(enumType))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(enumType, i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            return;

        }

        private static void AtualizarSerie()
        {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            var enumType = typeof(Genero);
			foreach (int i in Enum.GetValues(enumType))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(enumType, i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = Convert.ToInt32(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = Convert.ToInt32(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie() //TODO ANALISAR ERRO DE NÃO EXCLUIR. SÓ TROCA O ATRIBUTO Excluido
        // por true
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = Convert.ToInt32(Console.ReadLine());
            
            var lista = repositorio.Lista();
            var serie = lista [indiceSerie];
            Console.WriteLine("Tem certeza que deseja excluir a série " + serie.retornaTitulo()  +"? (s/n)");
            string confirmacao = Console.ReadLine();
            Console.Write(confirmacao);

            if (confirmacao.Equals("s"))
            {
                repositorio.Exclui(indiceSerie);
            }
            
            else
            {
                return;
            }
        }
        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = Convert.ToInt32(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

		
    }   

}

#pragma warning restore CS8600
