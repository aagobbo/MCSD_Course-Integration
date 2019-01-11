using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mind.Orm.Infra.Core.Builders;
using Mind.Orm.Infra.Tests.Unit.Mocks;

namespace Mind.Orm.Infra.Tests.Unit.Specs
{
    [TestClass]
    public class SqlServerBuilderSpec
    {
        [TestMethod]
        public void DeveGerarScriptSelecao()
        {
            // Arrange
            var builder = new SqlServerBuilder<PessoaMock>();

            // Act
            var select = builder.BuildSelect().ToLower();

            // Assert
            Assert.AreEqual("select id, nome, datanascimento from pessoa", select);
        }

        // ToDo: Implementar todos os testes
    }
}
