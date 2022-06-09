using Application;
using Application.DTOs;
using Application.Repositories;
using BusinessLogic.Implementation;
using BusinessLogic.Validation;
using DataAccess;
using Implementation.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace BusinessLogic.Test
{
    [TestFixture]
    public class CommentLogicTest
    {
        [Test]
        public void Test_Add()
        {
            Comment comment = new Comment
            {
                Id = 2,
                MovieId = 1,
                CommentText = "Comment"
            };

            OperationResult operationResult = new OperationResult
            {
                Result = true
            };

            MoviesContext context = new MoviesContext();

            var validation = new Mock<CommentValidation>(context);

            var commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(c => c.Add(comment)).Returns(operationResult);

            var addLogic = new CommentLogic(commentRepositoryMock.Object, validation.Object);

            var resultLogic = addLogic.Add(comment);
            Assert.True(resultLogic.Result);
        }

        [Test]
        public void Test_Update()
        {
            Comment comment = new Comment
            {
                Id = 2,
                MovieId = 1,
                CommentText = "Comment update"
            };

            OperationResult operationResult = new OperationResult
            {
                Result = true
            };

            MoviesContext context = new MoviesContext();

            var validation = new Mock<CommentValidation>(context);

            var commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(c => c.Update(comment)).Returns(operationResult);

            var addLogic = new CommentLogic(commentRepositoryMock.Object, validation.Object);

            var resultLogic = addLogic.Update(comment);
            Assert.True(resultLogic.Result);
        }

        [Test]
        public void Test_Delete()
        {
            OperationResult operationResult = new OperationResult
            {
                Result = true
            };

            MoviesContext context = new MoviesContext();

            var validation = new Mock<CommentValidation>(context);

            var commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(c => c.Delete(1)).Returns(operationResult);

            var addLogic = new CommentLogic(commentRepositoryMock.Object, validation.Object);

            var resultLogic = addLogic.Delete(1);
            Assert.True(resultLogic.Result);
        }
    }
}
