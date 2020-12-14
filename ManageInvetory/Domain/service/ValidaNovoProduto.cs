using System.Linq;
using Domain.Models;

namespace Domain.Service
{
    public class ValidaNovoProduto
    {
        public bool ValidaEntradasNaLista(Produto[] stock, int cod, string nome)
        {
            if (cod == 0 || nome == "") return false;
            try
            {
                if (stock.Where(x => x.Codigo == cod || x.Nome == nome ).ToArray().Length > 0)
                {
                    System.Console.WriteLine("A lista Possui itens repetidos, Verifice a sua Estrutura");
                    return false;
                }
                else
                    return true;
            }
            catch (System.Exception erro)
            {
                System.Console.WriteLine("ValidaNovoProduto.Id. Ocoreu um erro inesperado: ");
                System.Console.WriteLine(erro.Message);

                return false;
                throw;
            }
        }
    }
}