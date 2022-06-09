using Application;
using Application.DTOs;
using Application.Repositories;
using Application.Searches;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Implementation
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieRepository _repository;
        private readonly AddMovieValidation _addValidation;
        private readonly UpdateMovieValidation _updateValidation;

        public MovieLogic(IMovieRepository repository, AddMovieValidation addValidation, UpdateMovieValidation updateValidation)
        {
            _repository = repository;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IOperationResult Add(Movie movie)
        {
            try
            {
                _addValidation.ValidateAndThrow(movie);

                Thread tPoster = new Thread(() => Poster(movie));

                Thread tCover = new Thread(() => CoverImg(movie));

                return _repository.Add(movie);
            }
            catch(Exception ex)
            {
                return new OperationResult
                {
                    Result = false,
                    Message = ex.Message
                };
            }
            
        }

        public void CoverImg(Movie movie)
        {
            var guidCover = Guid.NewGuid();
            var extensionCover = Path.GetExtension(movie.CoverImg.FileName);
            var newImageCover = guidCover + extensionCover;
            var pathCover = Path.Combine("wwwroot", "images", newImageCover);
            using (var fileStream = new FileStream(pathCover, FileMode.Create))
            {
                movie.CoverImg.CopyTo(fileStream);
            }
        }

        public void Poster(Movie movie)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(movie.Poster.FileName);
            var newImage = guid + extension;
            var path = Path.Combine("wwwroot", "images", newImage);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                movie.Poster.CopyTo(fileStream);
            }
        }

        public IOperationResult Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IOperationResult GetMovie(int Id)
        {
            return _repository.GetMovie(Id);
        }

        public IOperationResult GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<ShowMovie> GetMoviesBackground(DateTime date)
        {
            return _repository.GetMoviesBackground(date);
        }

        public IOperationResult Search(MovieSearch search)
        {
            return _repository.Search(search);
        }

        public IOperationResult Update(Movie movie)
        {
            try
            {
                _updateValidation.ValidateAndThrow(movie);

                Thread tPoster = new Thread(() => Poster(movie));

                Thread tCover = new Thread(() => CoverImg(movie));

                return _repository.Update(movie);
            }
            catch(Exception ex)
            {
                return new OperationResult
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}
