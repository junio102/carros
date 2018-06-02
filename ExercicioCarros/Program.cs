using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercicioCarros
{
    class Program
    {
        public static List<Marca> marcas = new List<Marca>();
        public static List<Carro> carros = new List<Carro>();

        static void Main(string[] args)
        {

            Marca volkswagen = new Marca(1001, "Volkswagen", "Alemanhã");
            Marca GE = new Marca(1002, "General Motors", "Estados Unidos");
            marcas.Add(volkswagen);
            marcas.Add(GE);

            volkswagen.carros.Add(new Carro(101, "Fusca", 1980, 5000.00, volkswagen));
            volkswagen.carros.Add(new Carro(102, "Golf", 2016, 60000.00, volkswagen));
            volkswagen.carros.Add(new Carro(103, "Fox", 2017, 30000, volkswagen));

            GE.carros.Add(new Carro(104, "Cruze", 2016, 30000.00, GE));
            GE.carros.Add(new Carro(105, "Cobalt", 2015, 25000.00, GE));
            GE.carros.Add(new Carro(106, "Cobalt", 2017, 35000.00, GE));

            carros.Add(new Carro(101, "Fusca", 1980, 5000.00, volkswagen));
            carros.Add(new Carro(102, "Golf", 2016, 60000.00, volkswagen));
            carros.Add(new Carro(103, "Fox", 2017, 30000.00, volkswagen));
            carros.Add(new Carro(104, "Cruze", 2016, 30000.00, GE));
            carros.Add(new Carro(105, "Cobalt", 2015, 25000.00, GE));
            carros.Add(new Carro(106, "Cobalt", 2017, 35000.00, GE));


            int opcao = 0;

            while(opcao != 7)
            {
                Console.Clear();
                Console.Write("\n1 - LISTAR MARCAS");
                Console.Write("\n2 - LISTAR CARROS DE UMA MARCA ORDENADAMENTE");
                Console.Write("\n3 - CADASTRAR MARCA");
                Console.Write("\n4 - CADASTRAR CARRO");
                Console.Write("\n5 - CADASTRAR ACESSORIO");
                Console.Write("\n6 - MOSTRAR DETALHES DE UM CARRO");
                Console.Write("\n7 - SAIR");
                Console.Write("\nDigite uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                if(opcao<1 || opcao>7)
                {
                    Console.Write("\nOPÇÃO INVÁLIDA");
                }
                
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\nLISTAGEM DE MARCAS: ");
                      
                        foreach (Marca listaMarcas in marcas)
                        {
                            Console.WriteLine(listaMarcas.codigo + ", " + listaMarcas.nome + ", País: " + listaMarcas.pais + ", Número de carros: " + listaMarcas.carros.Count);
                        }

                        break;

                    case 2:
                        Console.Write("\nDigite o código da marca: ");

                        try
                        {
                            int codMarca = int.Parse(Console.ReadLine());
                            int pos = marcas.FindIndex(m => m.codigo == codMarca);
                            Console.Write(marcas[pos]);
                        }
                        catch(Exception e)
                        {
                            Console.Write("Marca não encontrada");
                        }
                        
                        break;

                    case 3:
                        Console.Write("\nDigite os dados da marca: ");
                        Console.Write("\nCódigo: ");
                        int codigoMarca = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nomeMarca = Console.ReadLine();
                        Console.Write("País de origem: ");
                        string paisMarca = Console.ReadLine();
                        marcas.Add(new Marca(codigoMarca, nomeMarca, paisMarca));

                        break;

                    case 4:
                        Console.Write("\nDigite os dados do carro: ");
                        Console.Write("\nMarca (código): ");

                        try
                        {
                            int codM = int.Parse(Console.ReadLine());
                            int posicao = marcas.FindIndex(m => m.codigo == codM);
                            if(posicao == -1)
                            {
                                throw new Exception();
                            }

                            Console.Write("Código do carro: ");
                            int codC = int.Parse(Console.ReadLine());
                            Console.Write("Modelo: ");
                            string modC = (Console.ReadLine());
                            Console.Write("Ano: ");
                            int anoC = int.Parse(Console.ReadLine());
                            Console.Write("Preço básico: ");
                            double precoBC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            //Estou criando um novo carro e dizendo que esse carro pertence a marca(posição encontrada)
                            Carro novoCarro = new Carro(codC, modC, anoC, precoBC, marcas[posicao]);
                            //Estou dizendo que essa marca(posição encontrada) vai ter agora na lista de carros dela esse novo carro
                            marcas[posicao].carros.Add(novoCarro);
                            //Estou adicionando tbm esse novo carro a uma lista de carros caso precise saber todos os carros existentes
                            carros.Add(novoCarro);
                        }
                        catch(Exception e)
                        {
                            Console.Write("Marca não encontrada");
                        }
                        
                        break;

                    case 5:
                        Console.Write("\nDigite os dados do acessório: ");
                        Console.Write("\nCarro (código): ");
                        try
                        {
                            int codAceCarro = int.Parse(Console.ReadLine());
                            int posicaoAceCarro = carros.FindIndex(m => m.codigo == codAceCarro);
                            if(posicaoAceCarro == -1)
                            {
                                throw new Exception();
                            }

                            Console.Write("Descrição: ");
                            string desc = Console.ReadLine();
                            Console.Write("Preço: ");
                            double precoAce = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            //Estou criando um novo acessorio e dizendo que esse acessorio pertence ao carro na(posição encontrada)
                            Acessorio novoAce = new Acessorio(desc, precoAce, carros[posicaoAceCarro]);
                            //Estou dizendo que esse carro(posição encontrada) vai ter agora na lista de acessorios dele esse novo acessorio
                            carros[posicaoAceCarro].acessorios.Add(novoAce);
                        }
                        catch(Exception e)
                        {
                            Console.Write("Carro não encontrado");
                        }
                        

                        break;


                    case 6:
                        Console.Write("\nDigite o código do carro: ");

                        try
                        {
                            int codDoCarro = int.Parse(Console.ReadLine());
                            int posCarro = carros.FindIndex(m => m.codigo == codDoCarro);
                            if(posCarro == -1)
                            {
                                throw new Exception();
                            }
                            
                            Console.Write(carros[posCarro]);
                        }
                        catch(Exception e)
                        {
                            Console.Write("Carro não encontrado");
                        }
                        

                        break;

                }

                Console.ReadLine();
            }
        }
    }
}
