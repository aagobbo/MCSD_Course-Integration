using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mind.Orm.Infra.Core;
using Mind.Orm.Infra.Core.Builders;
using Mind.Orm.Infra.Tests.Integration.Mocks;

namespace Mind.Orm.Infra.Tests.Integration.Specs
{
    [TestClass]
    public class RepositorySpec
    {
        [TestMethod]
        public void DeveSelecionarTodoRegistros()
        {
            // Arrange
            var builder = new SqlServerBuilder<UsuarioMock>();
            var repository = new Repository<UsuarioMock>(builder);

            // Act
            var select = (List <UsuarioMock> )repository.SelectAll();

            // Assert
            Assert.AreEqual(select.Count, 5);
        }

        // ToDo: Implementar todos os testes
    }
}
