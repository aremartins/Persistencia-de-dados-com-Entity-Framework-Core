using System;
using System.Collections.Generic;
using System.Linq;


namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoDaoEntity : IProdutoDao, IDisposable
    {
        public ProdutoDaoEntity()
        {
            this.contexto = new LojaContext();
        }

        private LojaContext contexto;
        public void Adicionar(Produto p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.Update(p);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }
    }
}
