using MTGArenaWebAPI.Data.Entities;

namespace MTGArenaWebAPI
{
    public class MTGArenaCardsResponse
    {
        public List<MTGArenaCards> MTGArenaCards { get; set; } = new List<MTGArenaCards>();
        public int Pages { get; set; }  
        public int CurrentPage { get; set; }    
    }
}
