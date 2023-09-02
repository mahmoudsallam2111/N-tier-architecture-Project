using FakeItEasy;
using FluentAssertions;
using ISP.API.Controllers;
using ISP.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPBackEnd.Tests.Controller
{
    public class GovernaratesControllerTest
    {
        private readonly IGovernarateService _governarateService;

        public GovernaratesControllerTest()
        {
            _governarateService = A.Fake<IGovernarateService>();
        }


        [Fact]

        public async Task GovernaratesController_GetGovernarates_ReturnsOk()
        {
            // Arrange
            var expectedGovernaratesList = new List<ReadGovernarateDTO>
            {
                      new ReadGovernarateDTO { Code = 1, Name = "Governarate 1" },
                      new ReadGovernarateDTO { Code = 2, Name = "Governarate 2" },
                      new ReadGovernarateDTO { Code = 3, Name = "Governarate 3" }
            };

            var fakeGovernarateService = A.Fake<IGovernarateService>();
            // configure the mock object 
            A.CallTo(() => fakeGovernarateService.GetAll()).Returns(expectedGovernaratesList);

            var controller = new GovernorateController(fakeGovernarateService);

            // Act
            var result = await controller.GetAll();

            // Assert

            //method to verify that the result variable is an ActionResult object
            var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadGovernarateDTO>>>(result);

            //method to verify that the Value property of the okObjectResult object is a list of ReadGovernarateDTO objects
            var actualGovernaratesList = Assert.IsAssignableFrom<List<ReadGovernarateDTO>>(okObjectResult.Value);

            actualGovernaratesList.Should().BeEquivalentTo(expectedGovernaratesList);

        }



        [Fact]

        public async Task GovernaratesController_GetGovernaratesByID_ReturnsOk()
        {

            // Arrange
            var expectedGovernarate = new ReadGovernarateDTO { Code = 1, Name = "Governarate 1" };
            var fakeGovernarateService = A.Fake<IGovernarateService>();
            A.CallTo(() => fakeGovernarateService.GetById(expectedGovernarate.Code)).Returns(expectedGovernarate);

            var controller = new GovernorateController(fakeGovernarateService);

            // Act
            var result = await controller.GetById(expectedGovernarate.Code);

            // Assert
            var okObjectResult = Assert.IsType<ActionResult<ReadGovernarateDTO>>(result);
            var actualGovernarate = Assert.IsAssignableFrom<ReadGovernarateDTO>(okObjectResult.Value);

            actualGovernarate.Should().BeEquivalentTo(expectedGovernarate);


        }




        [Fact]
        public async Task GovernarateController_Add_ReturnsOk()
        {
            // Arrange
            var writeGovernarateDTO = new WriteGovernarateDTO { Code = 1, Name = "Governarate 1" };

            var expectedGovernarate = new ReadGovernarateDTO { Code = 1, Name = "Governarate 1" };
            var fakeGovernarateService = A.Fake<IGovernarateService>();
            A.CallTo(() => fakeGovernarateService.AddGovernarate(writeGovernarateDTO)).Returns(expectedGovernarate);

            var controller = new GovernorateController(fakeGovernarateService);

            // Act
            var result = await controller.Add(writeGovernarateDTO);

            // Assert
            var okObjectResult = Assert.IsType<ActionResult<ReadGovernarateDTO>>(result);
            var actualGovernarate = Assert.IsAssignableFrom<ReadGovernarateDTO>(okObjectResult.Value);

            actualGovernarate.Should().BeEquivalentTo(expectedGovernarate);
        }

        [Fact]
        public async Task GovernarateController_Add_ReturnsBadRequest()
        {
            // Arrange
            var writeGovernarateDTO = new WriteGovernarateDTO { Code = 55, Name = "" };

            var fakeGovernarateService = A.Fake<IGovernarateService>();
            var controller = new GovernorateController(fakeGovernarateService);
            controller.ModelState.AddModelError("Name", "The Name field is required.");

            // Act
            var result = await controller.Add(writeGovernarateDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }



        [Fact]
        public async Task GovernarateController_Edit_ReturnsOkObjectResult()
        {
            // Arrange
            int code = 1;
            var updateGovernarateDTO = new UpdateGovernarateDTO { Code = 1, Name = "Governarate 1" };

            var expectedReadGovernarateDTO = new ReadGovernarateDTO { Code = 1, Name = "Governarate 1" };
            var fakeGovernarateService = A.Fake<IGovernarateService>();
            A.CallTo(() => fakeGovernarateService.UpdateGovernarate(code, updateGovernarateDTO)).Returns(expectedReadGovernarateDTO);

            var controller = new GovernorateController(fakeGovernarateService);

            // Act
            var result = await controller.Edit(code, updateGovernarateDTO);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);

            var readGovernarateDTO = Assert.IsType<ReadGovernarateDTO>(okObjectResult.Value);

            Assert.Equal(expectedReadGovernarateDTO.Code, updateGovernarateDTO.Code);
            Assert.Equal(expectedReadGovernarateDTO.Name, updateGovernarateDTO.Name);
 
        }

        [Fact]
        public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
        {
            // Arrange
            var Code = 1;
            var expectedReadGovernarateDTO = new ReadGovernarateDTO { Code = 1, Name = "Governarate 1" };
            var fakeGovernarateService = A.Fake<IGovernarateService>();
            A.CallTo(() => fakeGovernarateService.DeleteGovernarate(Code)).Returns(expectedReadGovernarateDTO);

            var controller = new GovernorateController(fakeGovernarateService);

            // Act
            var result = await controller.Delete(Code);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var readGovernarateDTO = Assert.IsType<ReadGovernarateDTO>(okObjectResult.Value);
            Assert.Equal(expectedReadGovernarateDTO.Code, readGovernarateDTO.Code);
            Assert.Equal(expectedReadGovernarateDTO.Name, readGovernarateDTO.Name);

        }








    }


}
