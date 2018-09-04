using System;
using System.Threading.Tasks;
using aboutRPGs.Models;

namespace aboutRPGs.Services {
    public interface IPartidaService {
        Task<Partida[]> getPartidasAsync();
    }
}