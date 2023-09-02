using FakeItEasy;
using FluentAssertions;
using ISP.API.Controllers;
using ISP.BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPBackEnd.Tests.Controller;

public class ClientControllerTests
{
    private IClientservice _ClientService;
    public ClientControllerTests()
    {
        _ClientService = A.Fake<IClientservice>();
    }




    [Fact]
    public async Task ClientController_GetCentrals_ReturnsOk()
    {

        //arrange

        var Clientexpectedlist = new List<ReadClientDTO>
            {

                new ReadClientDTO {Name = "client1" , SSID="12345678912"   },

            };

        var fakeClientService = A.Fake<IClientservice>();

        //configure the mock object
        A.CallTo(() => fakeClientService.GetAll()).Returns(Clientexpectedlist);

        var controller = new ClientController(fakeClientService);

        // act
        var result = await controller.GetAll();

        // assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadClientDTO>>>(result);

        var actualClientList = Assert.IsAssignableFrom<List<ReadClientDTO>>(okObjectResult.Value);

        actualClientList.Should().BeEquivalentTo(Clientexpectedlist);

    }

    [Fact]

    public async Task ClientController_GetClientByssn_ReturnsOk()
    {
        string ssn = "12345678912";
        var expectedClient = new ReadClientDTO { Name = "client1", SSID = "12345678912" };

        var fakeClientService = A.Fake<IClientservice>();


        //configure the mock object
        A.CallTo(() => fakeClientService.GetById(ssn)).Returns(expectedClient);

        var controller = new ClientController(fakeClientService);

        //act
        var result = await controller.GetById(ssn);

        // assert

        var okobject = Assert.IsAssignableFrom<ActionResult<ReadClientDTO>>(result);

        var actualClient = Assert.IsAssignableFrom<ReadClientDTO>(okobject.Value);

        actualClient.Should().BeEquivalentTo(expectedClient);
    }






    [Fact]
    public async Task ClientController_Add_ReturnsOk()
    {
        //arrange

        WriteClientDTO writeClientDTO = new WriteClientDTO{ SSID = "5555" , contractFee = 150 , installationFee = 100 , name ="ali"  };
        ReadClientDTO expectedClient = new ReadClientDTO { Name = "ali" };

        var fakeClientService = A.Fake<IClientservice>();

        A.CallTo(() =>fakeClientService.AddClient(writeClientDTO)).Returns(expectedClient);

        var controller = new ClientController(fakeClientService);


        // act
        var result = await controller.Add(writeClientDTO);

        // assert

        var Okobjectresult = Assert.IsType<ActionResult<ReadClientDTO>>(result);

        var actualresault = Assert.IsAssignableFrom<ReadClientDTO>(Okobjectresult.Value);

        actualresault.Should().BeEquivalentTo(expectedClient);

    }

    [Fact]
    public async Task CentralController_Add_ReturnsBadRequest()
    {
        // Arrange
        WriteClientDTO writeClientDTO = new WriteClientDTO { SSID = null, contractFee = 150, installationFee = 100, name = null };

        var fakeClientService = A.Fake<IClientservice>();
        var controller = new ClientController(fakeClientService);

        controller.ModelState.AddModelError("Name", "The Name field is required.");

        // Act
        var result = await controller.Add(writeClientDTO);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    //[Fact]
    //public async Task ClientController_Edit_ReturnsobjectresultResult()
    //{
    //    // arrange
    //    string ssn = "55";
    //    UpdateClientDTO updateClientDTO = new UpdateClientDTO { SSID = "55", PackageId = 5 };

    //    var expectedClientDto = new ReadClientDTO { Name = "mahmoud", PackageName = "55" };


    //    //create fake iproviderservice
    //    var fakevClientService = A.Fake<IClientservice>();

    //    //configure the mock object

    //    A.CallTo(() => fakevClientService.UpdateClient(ssn, updateClientDTO)).Returns(expectedClientDto);

    //    var controller = new ClientController(fakevClientService);

    //    //act
    //    var result = await fakevClientService.UpdateClient(ssn, updateClientDTO);

    //    // assert
    //    Assert.IsType<ObjectResult>(result);

    //}



    [Fact]
    public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
    {
        // Arrange
        var ssn = "55";
        var expectedReadClientDTO = new ReadClientDTO { Name = "ali" };

        var fakeclientrService = A.Fake<IClientservice>();
        A.CallTo(() => fakeclientrService.DeleteClient(ssn)).Returns(expectedReadClientDTO);

        var controller = new ClientController(fakeclientrService);

        // Act
        var result = await controller.Delete(ssn);

        // Assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<ReadClientDTO>>(result);

        var actualClientList = Assert.IsAssignableFrom<ReadClientDTO>(okObjectResult.Value);

        actualClientList.Should().BeEquivalentTo(expectedReadClientDTO);

    }

}
