using Mind.Orm.Infra.Core;
using Mind.Orm.Infra.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mind.Orm.Infra.Tests.Unit.Mocks
{
    [Table("Pessoa")]
    public class PessoaMock : IEntity
    {
        [PrimaryKey("PkPessoaId")]
        [Column("Id", ColumnType.Number, 1000)]
        public int Id { get; set; }

        [Column("Nome", ColumnType.Text, 50)]
        public string Nome { get; set; }

        [Column("DataNascimento", ColumnType.DateTime, 0)]
        public DateTime DataNascimento { get; set; }
    }
}
