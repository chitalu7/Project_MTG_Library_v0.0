using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGArenaWebAPI.Data;
using MTGArenaWebAPI.Data.Entities;

namespace MTGArenaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MTGArenaCardsController : ControllerBase
    {
        private readonly MTGArenaCardLibraryContext _reactContext;

        public MTGArenaCardsController(MTGArenaCardLibraryContext reactContext)
        {
            _reactContext = reactContext;
        }

        
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var mtgCards = await _reactContext.MTGArenaCards.ToListAsync();
            return Ok(mtgCards);
        }
        
        

        
        [HttpGet("{page}")]
        
        public async Task<ActionResult<List<MTGArenaCards>>> GetMTGArenaCards(int page)
        {
            if (_reactContext.MTGArenaCards == null)
                return NotFound();

            var pageResults = 5f;
            var pageCount = Math.Ceiling(_reactContext.MTGArenaCards.Count() / pageResults);



            var mtgCards = await _reactContext.MTGArenaCards
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new MTGArenaCardsResponse
            {
                MTGArenaCards = mtgCards,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }
        
        

        [HttpPost]
        public async Task<IActionResult> Post(MTGArenaCards newMTGArenaCards)
        {
            _reactContext.MTGArenaCards.Add(newMTGArenaCards);
            await _reactContext.SaveChangesAsync();
            return Ok(newMTGArenaCards);
        }
    }

  
}
