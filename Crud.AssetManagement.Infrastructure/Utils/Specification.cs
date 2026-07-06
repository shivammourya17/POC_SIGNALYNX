using System;
using System.Linq.Expressions;

namespace Crud.AssetManagement.Infrastructure.Utils
{
    // Lightweight stand-in for the shared Crud Specification<T> base class.
    public abstract class Specification<TModel>
    {
        public abstract Expression<Func<TModel, bool>> ToExpression();
    }
}
