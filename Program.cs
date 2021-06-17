using System;

namespace cad_series
{
    class Program
    {
        static SRepositorio repositorio = new SRepositorio();
        
        static void Main(string[] args)
        {
            string opcaoSelect = ObterOpcao();

            while (opcaoSelect.ToUpper() != "X"){
                
                switch (opcaoSelect){

                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break; 
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default: 
                    throw new ArgumentOutOfRangeException();
                }
                opcaoSelect = ObterOpcao();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();

        }

        #region Métodos Listar, Inserir, Alterar, Excluir, Visualizar 

        private static void Listar(){

            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista){

                var excluido = serie.retornBaixado();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retId(), serie.retTitulo(), excluido ? "Excluído" : "");
                
            }
        }

        private static void Inserir()
		{
			Console.WriteLine("Inserir nova série");
            
            #region Retorna a lista com os gêneros
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            #endregion

			Console.Write("Informe o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Informe o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Informe a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(codigo: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Inserir(novaSerie);
		}

        private static void Excluir()
		{
			Console.Write("Informe o código da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceSerie);
		}

        private static void Visualizar()
		{
			Console.Write("Informe o código da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void Atualizar()
		{
			Console.Write("Digite o código da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            #region Retorna a lista com os gêneros
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
            #endregion

			Console.Write("Informe o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Informe o título da série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Informe o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Informe a descrição da série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(codigo: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Alterar(indiceSerie, atualizaSerie);
		}
        
        #endregion

        #region Menu

        private static string ObterOpcao(){
            Console.WriteLine();
            Console.WriteLine("Plataforma com as melhores séries!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("L- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;

        }

        #endregion

    }
}
