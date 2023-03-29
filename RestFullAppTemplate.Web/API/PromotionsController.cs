using Microsoft.AspNetCore.Mvc;
using RestFullAppTemplate.Core.Models;
using RestFullAppTemplate.Core.Services;
using RestFullAppTemplate.Web.Models;

namespace RestFullAppTemplate.Web.Controllers
{
    [ApiController]
    [Route("promo")]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionsService _promotionsService;
        private readonly IParticipantsService _participantsService;
        private readonly IPrizesService _prizesService;

        public PromotionsController(IPromotionsService promotionsService,
            IParticipantsService participantsService, IPrizesService prizesService)
        {
            _promotionsService = promotionsService;
            _participantsService = participantsService;
            _prizesService = prizesService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PromotionDto promotionDto)
        {
            if (promotionDto == null)
            {
                return BadRequest(promotionDto);
            }
            var promotion = await _promotionsService.Create(promotionDto.Name, promotionDto.Description);
            return CreatedAtRoute("GetPromo", new { id = promotion.Id }, promotion.Id);
        }

        [HttpPost("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPromo(int id)
        {
            var promotion = await _promotionsService.Get(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPromotions()
        {
            var promotions = await _promotionsService.GetAll();
            return Ok(promotions);
        }
    }
}