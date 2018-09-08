using System;
using System.Threading.Tasks;
using aboutRPGs.Models;
using aboutRPGs.Services;

class AdventureService : IAdventureService
{
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
}