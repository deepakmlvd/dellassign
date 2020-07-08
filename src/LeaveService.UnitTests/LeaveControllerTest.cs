using LeaveService.API.Business;
using LeaveService.API.Controllers;
using LeaveService.API.DataAccess;
using management.models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace LeaveService.UnitTests
{
    public class LeaveControllerTest
    {
        private readonly ILeave _leaveBO;
        private readonly Mock<ILeaveDA> _leaveDA;
        private LeaveController leaveController = null;

        public LeaveControllerTest()
        {
            _leaveDA = new Mock<ILeaveDA>();
            _leaveBO = new LeaveHandler(_leaveDA.Object);
        }

        [Fact]
        public void ApplyLeaveTest()
        {
            leaveController = new LeaveController(_leaveBO);
            var leave = new Leave();
            var actionResult=leaveController.ApplyLeave(leave);
            var status= (((ObjectResult)actionResult.Result).Value as LeaveResponse).Status;
            Assert.Equal(status.ToString(), LeaveStatus.Applied.ToString());
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
