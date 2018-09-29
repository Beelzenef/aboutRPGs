using System;
using System.Threading.Tasks;
using aboutRPGs.Models;
using aboutRPGs.Services;
using aboutRPGs.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class AdventureService : IAdventureService
{
    private readonly aboutRPGs.Data.ApplicationDbContext context;
    public AdventureService(aboutRPGs.Data.ApplicationDbContext context)
    {
        this.context = context;
    }

    /* fake method, deprecated like
    public Task<Adventure[]> getAdventuresAsync()
    {
        var adv1 = new Adventure
        {
            title = "La muerte del nigromante",
            game = "Reinos de Hierro",
            meet = DateTimeOffset.Now.AddDays(10)
        };
        var adv2 = new Adventure
        {
            title = "Últimas balas",
            game = "sLAng",
            meet = DateTimeOffset.Now.AddDays(22)
        };
        return Task.FromResult(new[] { adv1, adv2 });

    }
    */

    public async Task<Adventure[]> getOngoingAdventuresAsync()
    {
        return await context.Adventures.Where(x => true).ToArrayAsync();
    }

    public async Task<bool> AddAdventure(Adventure adv)
    {
        adv.id = Guid.NewGuid();
        adv.meet = DateTimeOffset.Now.AddDays(1);

        context.Adventures.Add(adv);
        
        var result = await context.SaveChangesAsync();
        return (result == 1);
    }
}