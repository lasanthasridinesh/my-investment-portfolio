using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPortfolio.Repositories;

namespace MyPortfolio.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            _context.Database.EnsureCreated();
            _context.Users.Add(new Microsoft.AspNetCore.Identity.IdentityUser()
            {
                Id = "user001",
                Email = "user1@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEKMyPj/NNSTruP1Kn5xhZNUovIWBsAxyiUzE2vXEV0gaspWbIrFQQ7WmH0aaCqCigQ==",
                PhoneNumber = "23423423",
                UserName = "user1@gmail.com"
            });
            _context.Trades.Add(new DBModel.DOM.Trade()
            {
                TradeID = 1,
                UserId = "user001",
                Quantity = 10,
                TradeDate = DateTime.Today,
                UnitPrice = 110,
                TotalCost = 1100,
                TradeType = DBModel.Utils.TradeType.Buy
            });

            _context.SaveChanges();
        }
    }
}