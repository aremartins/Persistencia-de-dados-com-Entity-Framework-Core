using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            GravarUsandoEntity();            
            //RemoverProdutos();
            RecuperarProdutos();
            //AtualizarProduto();

            Console.ReadLine();

        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Senhor dos Anéis";
            p.Categoria = "Livros";
            p.Preco = 50.90;

            using (var contexto = new ProdutoDaoEntity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void RemoverProdutos()
        {
            using (var repo = new ProdutoDaoEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach (var produto in produtos)
                {
                    repo.Remover(produto);
                }

            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDaoEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("Foram encontrados {0} produtos.", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();

            using (var repo = new ProdutoDaoEntity())
            {
                Produto primeiroProduto = repo.Produtos().First();
                primeiroProduto.Nome = "Senhor dos Anéis";
                repo.Atualizar(primeiroProduto);

            }
            RecuperarProdutos();
        }
    }
}
