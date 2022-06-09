using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWatchlistRepository
    {
        IOperationResult Add(Watchlist watchlist);
        IOperationResult Delete(int id);
        IOperationResult Get();
    }
}
