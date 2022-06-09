using Application;
using Application.DTOs;
using Application.Repositories;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class WatchlistLogic : IWatchlistLogic
    {
        private readonly IWatchlistRepository _repository;
        private readonly WatchlistValidation _validation;

        public WatchlistLogic(IWatchlistRepository repository, WatchlistValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public IOperationResult Add(Watchlist watchlist)
        {
            try
            {
                _validation.ValidateAndThrow(watchlist);
                return _repository.Add(watchlist);
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }

        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IOperationResult Get()
        {
            return _repository.Get();
        }
    }
}
