using Mind.Orm.Infra;
using Mind.Orm.Infra.Core;
using Mind.Orm.Infra.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Orm.Infra.Tests.Integration.Mocks
{
    [Table("Usuario")]
    public class UsuarioMock : IEntity
    {
        [Column("Id", ColumnType.Number, 100)]
        public int Id { get; private set; }

        [Column("Nome", ColumnType.Text, 50)]
        public string Nome { get; set; }

        [Column("DataNascimento", ColumnType.DateTime, 0)]
        public DateTime DataNascimento { get; set; }

        public UsuarioMock()
        {

        }

        public UsuarioMock(int id, string nome, DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public UsuarioMock(string nome, DateTime dataNascimento) : this(default(int), nome, dataNascimento)
        {

        }
        
    }
}
