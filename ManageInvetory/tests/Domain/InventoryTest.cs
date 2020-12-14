using NUnit.Framework;
using Domain.Models;
using Domain.Service;

namespace tests
{
    public class InventoryTest
    {
        ManageStock stock = new ManageStock();
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void TestaRapidao(){

            stock.addToStock(new Produto(){
                Codigo = 01,
                Nome = "Cadeira",
                Preco = 45.6
            });
        }
    }
}