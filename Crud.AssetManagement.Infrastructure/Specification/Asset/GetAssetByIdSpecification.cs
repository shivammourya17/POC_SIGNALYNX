using System;
using System.Linq.Expressions;
using Crud.AssetManagement.Infrastructure.Models.Asset;
using Crud.AssetManagement.Infrastructure.Utils;

namespace Crud.AssetManagement.Infrastructure.Specification.Asset
{
    public class GetAssetByIdSpecification : Specification<AssetModel>
    {
        private readonly int _id;

        public GetAssetByIdSpecification(int id)
        {
            _id = id;
        }

        public override Expression<Func<AssetModel, bool>> ToExpression()
        {
            return model => model.AssetId == _id && model.DeletedDate == null;
        }
    }
}
