﻿using CardapioService.Data;
using CardapioService.Model;
using CardapioService.Services;
using CardapioService.Util;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BDDRestaurante
{
    //Testes integrados com o BD 
    [TestClass]
    public class CardapioFacadeIntegrateTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var connectionstring = "Host=localhost;Port=5432;Pooling=true;Database=CardapioDB;User Id=postgres;Password=admin";

            var optionsBuilder = new DbContextOptionsBuilder<CardapioServiceContext>();
            optionsBuilder.UseNpgsql(connectionstring);
            CardapioServiceContext dbContext = new CardapioServiceContext(optionsBuilder.Options);
            CardapioFacade cardapioFacade = new CardapioFacade(dbContext);


            Cardapio cardapio = new Cardapio();
            cardapio.Nome = "Café da manhã";
            //cardapio.Restaurante = new Restaurante() { Nome = "Teste" };
            Result<Cardapio> result = cardapioFacade.Create(cardapio);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReadAllTest()
        {
            var connectionstring = "Host=localhost;Port=5432;Pooling=true;Database=CardapioDB;User Id=postgres;Password=admin";

            var optionsBuilder = new DbContextOptionsBuilder<CardapioServiceContext>();
            optionsBuilder.UseNpgsql(connectionstring);
            CardapioServiceContext dbContext = new CardapioServiceContext(optionsBuilder.Options);
            CardapioFacade cardapioFacade = new CardapioFacade(dbContext);


            Result<Cardapio> result = cardapioFacade.ReadAll(new Cardapio());

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Entities);
            Assert.IsNotNull(result.Entities[0]);
        }

        [TestMethod]
        public void ReadTest()
        {
            var connectionstring = "Host=localhost;Port=5432;Pooling=true;Database=CardapioDB;User Id=postgres;Password=admin";

            var optionsBuilder = new DbContextOptionsBuilder<CardapioServiceContext>();
            optionsBuilder.UseNpgsql(connectionstring);
            CardapioServiceContext dbContext = new CardapioServiceContext(optionsBuilder.Options);
            CardapioFacade cardapioFacade = new CardapioFacade(dbContext);


            Result<Cardapio> result = cardapioFacade.Read(new Cardapio() { Id = 2 });

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Entities);
            Assert.IsNotNull(result.Entities[0]);
            Assert.AreEqual(2, result.Entities[0].Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var connectionstring = "Host=localhost;Port=5432;Pooling=true;Database=CardapioDB;User Id=postgres;Password=admin";

            var optionsBuilder = new DbContextOptionsBuilder<CardapioServiceContext>();
            optionsBuilder.UseNpgsql(connectionstring);
            CardapioServiceContext dbContext = new CardapioServiceContext(optionsBuilder.Options);
            CardapioFacade cardapioFacade = new CardapioFacade(dbContext);


            Result<Cardapio> result = cardapioFacade.ReadAll(new Cardapio());



            if (result != null && result.Entities != null && result.Entities[0] != null)
            {
                Cardapio cardapio = result.Entities[0];

                cardapio.Nome = "TESTE";
                result = cardapioFacade.Update(cardapio);


                result = cardapioFacade.Read(new Cardapio() { Id = result.Entities[0].Id });

                Assert.AreEqual("TESTE", result.Entities[0].Nome);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            var connectionstring = "Host=localhost;Port=5432;Pooling=true;Database=CardapioDB;User Id=postgres;Password=admin";

            var optionsBuilder = new DbContextOptionsBuilder<CardapioServiceContext>();
            optionsBuilder.UseNpgsql(connectionstring);
            CardapioServiceContext dbContext = new CardapioServiceContext(optionsBuilder.Options);
            CardapioFacade cardapioFacade = new CardapioFacade(dbContext);


            Result<Cardapio> result = cardapioFacade.Delete(new Cardapio() { Id = 3 });
        }
    }
}
