using Application;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IWatchlistLogic
    {
        IOperationResult Add(Watchlist watchlist);
        IOperationResult Delete(int id);
        IOperationResult Get();
    }
}
