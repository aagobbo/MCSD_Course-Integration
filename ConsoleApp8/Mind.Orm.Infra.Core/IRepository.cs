using System;
using System.Collections.Generic;
using System.Text;

namespace Mind.Orm.Infra.Core
{
    public interface IRepository<T> where T : IEntity
    {
        void Insert(T instance);
        IEnumerable<T> SelectAll();
    }
}
