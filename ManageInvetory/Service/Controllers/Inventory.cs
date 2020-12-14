using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Domain.Service;

namespace Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Manage : ControllerBase
    {
        public ManageStock eita = new ManageStock();
        public Manage()
        {
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            bool res = eita.addToStock(new Produto() {
                Codigo = 01,
                Nome = "Cadeira",
                Preco = 45.6,
                Estoque = 6
            });

            if (res)
                return "Ok";
            else
                return "não Ok";
        }

        [HttpGet("List")]
        public ActionResult<Produto[]> GetList()
        {
            return eita.db.Produtos.ToArray();
        }

        [HttpGet("updateProductInStock")]
        public ActionResult<bool> updateProductInStock()
        {
            Produto prod = new Produto() {
                Codigo = 01,
                Nome = "Cadeiras",
                Preco = 49.6 
            };
            return eita.updateProductInStock(prod.Codigo, prod);
        }
        [HttpGet("UpdateStock/{code}/{up}")]
        public ActionResult<bool> UpdateStock(string code,int up)
        {
            return eita.UpdateStock(code,up);
        }
    }
}
