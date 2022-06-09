using Application;
using Application.DTOs;
using Application.Interfaces;
using DataAccess;
using Implementation.Repositories;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Implementation.Test
{
    [TestFixture]
    public class CommentTest 
    {
        public IApplicationActor actor { get; private set; }

        [Test]
        public void Test_Add()
        {
            MoviesContext context = new MoviesContext();
            var add = new CommentRepository(context, actor);

            Comment comment = new Comment
            {
                Id = 1,
                MovieId = 1,
                CommentText = "Comment"
            };

            Assert.IsNotNull(comment);


            var result = add.Add(comment);
            Assert.IsInstanceOf<OperationResult>(result);
            Assert.True(result.Result);
        }

        [Test]
        public void Test_Add_Multiple()
        {
            MoviesContext context = new MoviesContext();
            var add = new CommentRepository(context, actor);

            Comment comment = new Comment
            {
                Id = 1,
                MovieId = 1,
                CommentText = "Comment"
            };

            Comment comment1 = new Comment
            {
                Id = 2,
                MovieId = 1,
                CommentText = "Comment 2"
            };

            Assert.AreNotEqual(comment.Id, comment1.Id);

            var result = add.Add(comment);
            var result1 = add.Add(comment1);
            Assert.IsInstanceOf<OperationResult>(result);
            Assert.IsInstanceOf<OperationResult>(result1);
            Assert.True(result.Result);
            Assert.True(result1.Result);
        }

        [Test]
        public void Test_Delete()
        {
            MoviesContext context = new MoviesContext();
            var delete = new CommentRepository(context, actor);
            var id = 156;

            Assert.Catch<Exception>(() => delete.Delete(id));

            var result = delete.Delete(id);
            Assert.IsInstanceOf<OperationResult>(result);
            Assert.True(result.Result);
        }

        [Test]
        public void Test_Update()
        {
            MoviesContext context = new MoviesContext();
            var update = new CommentRepository(context, actor);

            Comment comment = new Comment
            {
                Id = 250,
                MovieId = 1,
                CommentText = "Comment update"
            };

            Assert.Catch<Exception>(() => update.Update(comment));

            var result = update.Update(comment);
            Assert.True(result.Result);
        }
    }
}
