// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Services;
using TatakelolaKesMas.Core.Services.Interfaces;
using TatakelolaKesMas.Core.Services.Items;
using TatakelolaKesMas.Core.Services.Items.Interfaces;
using TatakelolaKesMas.Core.Services.Shop;
using TatakelolaKesMas.Services.Email;
using TatakelolaKesMas.ViewModels.Shop;

namespace TatakelolaKesMas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IRegionService _regionService;

        public RegionController(IMapper mapper, ILogger<RegionController> logger, IRegionService regionService)
        {
            _mapper = mapper;
            _logger = logger;
            _regionService = regionService;
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(string id)
        {
            try
            {
                return Ok( await  _regionService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the items.");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("parent/{id}")]
        public  async Task<IActionResult> GetByParentId(string id)
        {
            try
            {
                return Ok( await  _regionService.GetByParentId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the items.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
