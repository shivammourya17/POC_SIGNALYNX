using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Crud.AssetManagement.Commands.Asset;
using Crud.AssetManagement.Commands.Extensions;
using Crud.AssetManagement.DTOs.Asset;
using Crud.AssetManagement.Queries.Asset.GetAssetById;
using Crud.AssetManagement.Queries.Asset.GetAssetList;
using Crud.AssetManagement.Queries.Extensions;
using Crud.AssetManagement.Utils;

namespace Crud.AssetManagement.Controllers
{
    public class AssetController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AssetController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetAsync([FromBody] AssetDto dto)
        {
            var result = await _mediator.CommandDispatchAsync<AddAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssetAsync(int id, [FromBody] AssetDto dto)
        {
            dto.AssetId = id;
            var result = await _mediator.CommandDispatchAsync<UpdateAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetAsync(int id)
        {
            var dto = new AssetDto { AssetId = id };
            var result = await _mediator.CommandDispatchAsync<DeleteAssetCommand, string>(_mapper, dto);
            return FromResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetByIdAsync(int id)
        {
            var query = new GetAssetByIdQuery(id);
            var result = await _mediator.QueryDispatchAsync(query);
            return FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetListAsync([FromQuery] int perPage, [FromQuery] int page, [FromQuery] string q = null, [FromQuery] int? clientId = null)
        {
            var query = new GetAssetListQuery(perPage, page, q, clientId);
            var result = await _mediator.QueryDispatchAsync(query);
            return FromResult(result);
        }
    }
}
