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
using TatakelolaKesMas.Core.Services.PublicHealthCentre;
using TatakelolaKesMas.Core.Services.PublicHealthCentre.Interfaces;
using TatakelolaKesMas.Core.Services.Shop;
using TatakelolaKesMas.Services.Email;
using TatakelolaKesMas.ViewModels.Shop;

namespace TatakelolaKesMas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHealthCentreController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPublicHealthCenterService _clinicService;

        public PublicHealthCentreController(ILogger<PublicHealthCentreController> logger, IPublicHealthCenterService clinicService)
        {
            _logger = logger;
            _clinicService = clinicService;
        }
        
        [HttpGet("get-list")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _clinicService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the items.");
                return StatusCode(500, "Internal server error");
            }
            
        }
        
        [HttpPost]
        public async Task<IActionResult> AddClinic([FromBody]PublicHealthCenter body)
        {
            try
            {
                await _clinicService.AddItem(body);
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
