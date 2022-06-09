using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Repositories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MoviesContext _context;
        private readonly IApplicationActor _actor;

        public CommentRepository(MoviesContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public IOperationResult Add(Comment comment)
        {
            try
            {
                var newComment = new CommentEntity
                {
                    CommentText = comment.CommentText,
                    MovieId = comment.MovieId,
                    UserId = 1,
                    CreatedAt = DateTime.Now
                };

                _context.Comments.Add(newComment);
                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }

        public IOperationResult Delete(int id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if (comment == null)
            {
                //return OperationResult.Error("Comment not found.");
                throw new Exception("Comment not found.");
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return new OperationResult()
            {
                Result = true
            };
        }

        public IOperationResult Update(Comment comment)
        {
            try
            {
                var commentUpdate = _context.Comments.FirstOrDefault(x => x.Id == comment.Id);

                if(commentUpdate == null)
                {
                    //return OperationResult.Error("Comment not found.");
                    throw new Exception("Comment not found.");
                }

                commentUpdate.CommentText = comment.CommentText;
                commentUpdate.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return new OperationResult()
                {
                    Result = true
                };
            }
            catch(Exception ex)
            {
                return new OperationResult(ex);
            }
        }
    }
}
