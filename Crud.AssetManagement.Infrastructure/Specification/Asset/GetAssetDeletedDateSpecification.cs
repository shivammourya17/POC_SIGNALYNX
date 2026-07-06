using System;
using System.Linq.Expressions;
using Crud.AssetManagement.Infrastructure.Models.Asset;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Specification.Asset
{
    public class GetAssetDeletedDateSpecification : Specification<AssetModel>
    {
        public override Expression<Func<AssetModel, bool>> ToExpression()
        {
            return model => model.DeletedDate != null;
        }
    }
}
