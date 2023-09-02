using FakeItEasy;
using FluentAssertions;
using ISP.API.Controllers;
using ISP.BL;
using ISP.BL.Dtos.Offer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPBackEnd.Tests.Controller;

public class CentalControlerTests
{
    private ICentalService _CentralService;
    public CentalControlerTests()
    {
        _CentralService = A.Fake<ICentalService>();

    }


    [Fact]
    public async Task CentralController_GetCentrals_ReturnsOk()
    {

        //arrange

        var Centralexpectedlist = new List<ReadCentralWithGovernarateDTO>
            {

                new ReadCentralWithGovernarateDTO {Name = "central1" , Id = 1   },
               

            };

        var fakeCentralService = A.Fake<ICentalService>();

        //configure the mock object
        A.CallTo(() => fakeCentralService.GetAllwithgov()).Returns(Centralexpectedlist);

        var controller = new CentralController(fakeCentralService);

        // act
        var result = await controller.getallwithgov();

        // assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadCentralWithGovernarateDTO>>>(result);

        var actualCentralList = Assert.IsAssignableFrom<List<ReadCentralWithGovernarateDTO>>(okObjectResult.Value);

        actualCentralList.Should().BeEquivalentTo(Centralexpectedlist);

    }

    [Fact]

    public async Task providerController_GetCentralByID_ReturnsOk()
    {
        int id = 5;
        var expectedCentral = new ReadCentralDTO() { Name = "central1" };

        var fakeCentralService = A.Fake<ICentalService>();


        //configure the mock object
        A.CallTo(() =>fakeCentralService.GetById(id)).Returns(expectedCentral);

        var controller = new CentralController(fakeCentralService);

        //act
        var result = await controller.GetById(id);

        // assert

        var okobject = Assert.IsAssignableFrom<ActionResult<ReadCentralDTO>>(result);

        var actualCentral = Assert.IsAssignableFrom<ReadCentralDTO>(okobject.Value);

        actualCentral.Should().BeEquivalentTo(expectedCentral);
    }





    [Fact]

    public async Task CentralController_GetCentralByName_ReturnsOk()
    {
        string name = "cen1";
        var expectedCentral = new ReadCentralDTO() { Name = "central1" };

        var fakeCentralService = A.Fake<ICentalService>();


        //configure the mock object
        A.CallTo(() => fakeCentralService.GetByName(name)).Returns(expectedCentral);

        var controller = new CentralController(fakeCentralService);

        //act
        var result = await controller.GetByName(name);

        // assert

        var okobject = Assert.IsAssignableFrom<ActionResult<ReadCentralDTO>>(result);

        var actualCentral = Assert.IsAssignableFrom<ReadCentralDTO>(okobject.Value);

        actualCentral.Should().BeEquivalentTo(expectedCentral);
    }


    [Fact]
    public async Task CentralController_Add_ReturnsOk()
    {
        //arrange

        WriteCentralDTO writeCentralDTO = new WriteCentralDTO { Name = "central1" , GovernorateCode=55 };
        ReadCentralDTO expectedCentral = new ReadCentralDTO { Name = "central1" };

        var fakeCentralService = A.Fake<ICentalService>();

        A.CallTo(() => fakeCentralService.Insert(writeCentralDTO)).Returns(expectedCentral);

        var controller = new CentralController(fakeCentralService);


        // act
        var result = await controller.Add(writeCentralDTO);

        // assert

        var Okobjectresult = Assert.IsType<ActionResult<ReadCentralDTO>>(result);

        var actualresault = Assert.IsAssignableFrom<ReadCentralDTO>(Okobjectresult.Value);

        actualresault.Should().BeEquivalentTo(expectedCentral);

    }

    [Fact]
    public async Task CentralController_Add_ReturnsBadRequest()
    {
        // Arrange
        WriteCentralDTO writeCentralDTO = new WriteCentralDTO { Name = null , GovernorateCode=55 };

        var fakeCentralService = A.Fake<ICentalService>();
        var controller = new CentralController(fakeCentralService);

        controller.ModelState.AddModelError("Name", "The Name field is required.");

        // Act
        var result = await controller.Add(writeCentralDTO);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task CentralController_Edit_ReturnsNoContentResult()
    {
        // arrange
        int id = 5;
        UpdateCentralDTO updateCentralDTO = new UpdateCentralDTO { Id = 5, Name = "ma" };

        var expectedCentralDto = new ReadCentralDTO { Name = "ma" };


        //create fake iproviderservice
        var fakeCentralService = A.Fake<ICentalService>();

        //configure the mock object

        A.CallTo(() => fakeCentralService.Edit(id, updateCentralDTO)).Returns(expectedCentralDto);

        var controller = new CentralController(fakeCentralService);

        //act
        var result = await controller.Edit(id, updateCentralDTO);

        // assert
        Assert.IsType<NoContentResult>(result.Result);

    }



    [Fact]
    public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
    {
        // Arrange
        var Id = 5;
        var expectedReadCentralDTO = new ReadCentralDTO { Name = "we" };

        var fakeCentralrService = A.Fake<ICentalService>();
        A.CallTo(() => fakeCentralrService.Delete(Id)).Returns(expectedReadCentralDTO);

        var controller = new CentralController(fakeCentralrService);

        // Act
        var result = await controller.Delete(Id);

        // Assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<ReadCentralDTO>>(result);

        var actualcentralList = Assert.IsAssignableFrom<ReadCentralDTO>(okObjectResult.Value);

        actualcentralList.Should().BeEquivalentTo(expectedReadCentralDTO);


    }

}


  

