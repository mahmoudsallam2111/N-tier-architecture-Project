using FakeItEasy;
using FluentAssertions;
using ISP.API.Controllers;
using ISP.BL;
using Microsoft.AspNetCore.Mvc;

namespace ISPBackEnd.Tests.Controller
{
    public class ProviderControllerTest
    {
        private IProviderService _ProviderService;


        public ProviderControllerTest()
        {
          _ProviderService = A.Fake<IProviderService>();
        }


        [Fact]
        public async Task ProviderController_GetProviders_ReturnsOk()
        {

            //arrange

            var providerexpectedlist = new List<ReadProviderDTO>
            {

                new ReadProviderDTO {Name = "we"  },
                new ReadProviderDTO {Name = "etsilat"  },
                new ReadProviderDTO {Name = "vodafone" }

            };

            var fakeProviderService = A.Fake<IProviderService>();

            //configure the mock object
            A.CallTo(() => fakeProviderService.GetAll()).Returns(providerexpectedlist);

            var controller = new ProviderController(fakeProviderService);

            // act
            var result = await controller.GetAll();

            // assert
            var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadProviderDTO>>>(result);

            var actualProviderList = Assert.IsAssignableFrom<List<ReadProviderDTO>>(okObjectResult.Value);

            actualProviderList.Should().BeEquivalentTo(providerexpectedlist);

        }

        [Fact]

        public async Task providerController_GetproviderByID_ReturnsOk()
        {
            int id = 5;
            var expectedprovider = new ReadProviderDTO() { Name = "we"};

            var fakeProviderService = A.Fake<IProviderService>();


            //configure the mock object
            A.CallTo(() => fakeProviderService.GetById(id)).Returns(expectedprovider);

            var controller = new ProviderController(fakeProviderService);

            //act
            var result = await controller.GetById(id);

            // assert

            var okobject = Assert.IsAssignableFrom<ActionResult<ReadProviderDTO>>(result);

            var actualprovider = Assert.IsAssignableFrom<ReadProviderDTO>(okobject.Value);

            actualprovider.Should().BeEquivalentTo(expectedprovider);
        }


        [Fact]
        public async Task providerController_Add_ReturnsOk()
        {
            //arrange

            WriteProviderDTO writeProviderDTO = new WriteProviderDTO { Name = "we" };
            ReadProviderDTO expectedProvider = new ReadProviderDTO { Name = "we"};

            var fakeproviderService = A.Fake<IProviderService>();

            A.CallTo(() => fakeproviderService.Insert(writeProviderDTO)).Returns(expectedProvider);

            var controller = new ProviderController(fakeproviderService);


            // act
            var result = await controller.Add(writeProviderDTO);

            // assert

            var Okobjectresult = Assert.IsType<ActionResult<ReadProviderDTO>>(result);

            var actualresault = Assert.IsAssignableFrom<ReadProviderDTO>(Okobjectresult.Value);

            actualresault.Should().BeEquivalentTo(expectedProvider);

        }

        [Fact]
        public async Task ProviderController_Add_ReturnsBadRequest()
        {
            // Arrange
            WriteProviderDTO writeProviderDTO = new WriteProviderDTO { Name = null };

            var fakeProviderService = A.Fake<IProviderService>();
            var controller = new ProviderController(fakeProviderService);

            controller.ModelState.AddModelError("Name", "The Name field is required.");

            // Act
            var result = await controller.Add(writeProviderDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task ProviderController_Edit_ReturnsNoContentResult()
        {
            // arrange
            int id = 5;
            UpdateProviderDTO updateProviderDTO = new UpdateProviderDTO { Id = 5, Name = "ma" };

            var expectedProviderDto = new ReadProviderDTO { Name = "ma" };


            //create fake iproviderservice
            var fakeproviderService = A.Fake<IProviderService>();

            //configure the mock object

            A.CallTo(() => fakeproviderService.Edit(id, updateProviderDTO)).Returns(expectedProviderDto);

            var controller = new ProviderController(fakeproviderService);

            //act
            var result = await controller.Edit(id, updateProviderDTO);

            // assert
            Assert.IsType<NoContentResult>(result.Result);  

        }



        [Fact]
        public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
        {
            // Arrange
            var Id = 5 ;
            var expectedReadproviderDTO = new ReadProviderDTO {  Name = "we" };

            var fakeProviderService = A.Fake<IProviderService>();
            A.CallTo(() => fakeProviderService.Remove(Id)).Returns(expectedReadproviderDTO);

            var controller = new ProviderController(fakeProviderService);

            // Act
            var result = await controller.Delete(Id);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var readproviderDTO = Assert.IsType<ReadProviderDTO>(okObjectResult.Value);

            Assert.Equal(expectedReadproviderDTO.Name , readproviderDTO.Name);
         
       
        }







    }
}
