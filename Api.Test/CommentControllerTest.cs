using Api.Controllers;
using Application;
using Application.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;

namespace Api.Test
{
    [TestFixture]
    public class CommentControllerTest
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

            var commentLogicMock = new Mock<ICommentLogic>();
            commentLogicMock.Setup(c => c.Add(comment)).Returns(operationResult);

            var response = "Microsoft.AspNetCore.Mvc.OkObjectResult";

            var add = new CommentsController(commentLogicMock.Object);
            var result = add.Post(comment);
            Assert.AreEqual(result.ToString(), response);
        }

        [Test]
        public void Test_Update()
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

            var commentLogicMock = new Mock<ICommentLogic>();
            commentLogicMock.Setup(c => c.Update(comment)).Returns(operationResult);

            var response = "Microsoft.AspNetCore.Mvc.OkObjectResult";

            var update = new CommentsController(commentLogicMock.Object);
            var result = update.Put(1, comment);
            Assert.AreEqual(result.ToString(), response);
        }

        [Test]
        public void Test_Delete()
        {
            OperationResult operationResult = new OperationResult
            {
                Result = true
            };

            var commentLogicMock = new Mock<ICommentLogic>();
            commentLogicMock.Setup(c => c.Delete(1)).Returns(operationResult);

            var response = "Microsoft.AspNetCore.Mvc.OkObjectResult";

            var delete = new CommentsController(commentLogicMock.Object);
            var result = delete.Delete(1);
            Assert.AreEqual(result.ToString(), response);
        }
    }
}
