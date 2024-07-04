// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Services;
using TatakelolaKesMas.Core.Services.Items;
using TatakelolaKesMas.Core.Services.Shop;
using TatakelolaKesMas.Services.Email;
using TatakelolaKesMas.ViewModels.Shop;

namespace TatakelolaKesMas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IItemService _itemService;

        public ItemController(IMapper mapper, ILogger<ItemController> logger, IItemService itemService)
        {
            _mapper = mapper;
            _logger = logger;
            _itemService = itemService;
        }
        
        [HttpGet("get-list")]
        public async Task<IActionResult> GetListItem()
        {
            try
            {
                return Ok(await _itemService.GetListItems());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the items.");
                return StatusCode(500, "Internal server error");
            }
            
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody]ItemReference body)
        {
            try
            {
                await _itemService.AddItem(body);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the items.");
                return StatusCode(500, "Internal server error");
            }
            
        }
    }
}
