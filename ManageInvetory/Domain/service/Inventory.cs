using Domain.Models; 
using System.Collections.Generic;
using System.Linq;
using System;
using Domain.Infra;

namespace Domain.Service
{
    public class ManageStock
    {
        public ServiceDbContext db = new ServiceDbContext();
        public bool addToStock(Domain.Models.Produto prod)
        {
            Produto[] data = db.Produtos.Where(x => x.Id > 0).ToArray();
            bool res = new ValidaNovoProduto().ValidaEntradasNaLista(data,prod.Codigo,prod.Nome);
            if(res is true) 
                db.Produtos.AddAsync(prod);
            
            db.SaveChangesAsync(); 
            return res;
        }

        public bool updateProductInStock(int CodToFind, Produto prod)
        {
            Produto data;
            if(prod.Codigo is not 0)
                data = db.Produtos.First(x => x.Codigo == CodToFind);
            else 
                return false;
            if(data is not null)
            {
                data.Nome = prod.Nome;
                data.Preco = prod.Preco;
                db.SaveChangesAsync(); 
                return true;
            } 
            else return false;
            
        }
        
        public bool UpdateStock(string code, int updatedStock)
        {
            try
            {
                Produto stock = db.Produtos.First<Produto>(x => x.Nome == code);

                if (updatedStock <= 0)
                    return false;
                else if (updatedStock > stock.Estoque)
                    return false;
                else
                    stock.Estoque = updatedStock;
                
                db.SaveChangesAsync(); 
            }
            catch (System.Exception)
            {
                Console.WriteLine("Produto Inexistente");
                return false;
            }
            return true;
        }
    }
}