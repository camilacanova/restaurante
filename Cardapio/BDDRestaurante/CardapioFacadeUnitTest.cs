using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Services;
using CardapioService.Util;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace BDDRestaurante
{
    [TestClass]
    public class CardapioFacadeUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            Mock<ICardapioFacade> mock = new Mock<ICardapioFacade>();
            mock.Setup(m => m.Create(new Cardapio())).Returns(new Result<Cardapio>());
            Result<Cardapio> result = mock.Object.Create(new Cardapio());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            var obj = new Result<Cardapio>();
            obj.Entities = new List<Cardapio>();
            obj.Entities.Add(new Cardapio());

            Mock<ICardapioFacade> mock = new Mock<ICardapioFacade>();
            mock.Setup(m => m.Create(new Cardapio())).Returns(obj);
            Result<Cardapio> result = mock.Object.ReadAll(new Cardapio());


            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Entities);
            Assert.IsNotNull(result.Entities[0]);
        }
    }
}
