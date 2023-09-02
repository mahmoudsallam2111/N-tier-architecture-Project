using FakeItEasy;
using FluentAssertions;
using ISP.API.Controllers;
using ISP.BL;
using ISP.BL.Dtos.Offer;
using ISP.BL.Services.OfferService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPBackEnd.Tests.Controller;
public class OfferControllerTests
{
    private IOfferService _OfferService;

    public OfferControllerTests()
    {
        _OfferService = A.Fake<IOfferService>();
    }



    [Fact]
    public async Task OfferController_GetOffers_ReturnsOk()
    {

        //arrange

        var Offerexpectedlist = new List<ReadOfferDto>
         {

                new ReadOfferDto {Name = "offer1" , Id = 1   },
                 new ReadOfferDto {Name = "offer2" , Id = 2   },


         };

        var fakeOfferService = A.Fake<IOfferService>();

        //configure the mock object
        A.CallTo(() => fakeOfferService.GetAll()).Returns(Offerexpectedlist);

        var controller = new OfferController(fakeOfferService);

        // act
        var result = await controller.GetAll();

        // assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadOfferDto>>>(result);

        var actualOfferList = Assert.IsAssignableFrom<List<ReadOfferDto>>(okObjectResult.Value);

        actualOfferList.Should().BeEquivalentTo(Offerexpectedlist);

    }

    [Fact]

    public async Task OfferController_GetCentralByID_ReturnsOk()
    {
        int id = 5;
        var expectedoffer = new ReadOfferDto { Name = "offer1", Id = 1 };

        var fakeOfferService = A.Fake<IOfferService>();


        //configure the mock object
        A.CallTo(() => fakeOfferService.GetById(id)).Returns(expectedoffer);

        var controller = new OfferController(fakeOfferService);

        //act
        var result = await controller.GetById(id);

        // assert

        var okobject = Assert.IsAssignableFrom<ActionResult<ReadOfferDto>>(result);

        var actualOffer = Assert.IsAssignableFrom<ReadOfferDto>(okobject.Value);

        actualOffer.Should().BeEquivalentTo(expectedoffer);
    }





   

    [Fact]
    public async Task OfferController_Add_ReturnsOk()
    {
        //arrange

       WriteOfferDto writeOfferDTO = new WriteOfferDto { Name = "central1" };
        ReadOfferDto expectedoffer = new ReadOfferDto { Name = "offer1", Id = 1 };

        var fakeOfferService = A.Fake<IOfferService>();

        A.CallTo(() => fakeOfferService.Insert(writeOfferDTO)).Returns(expectedoffer);

        var controller = new OfferController(fakeOfferService);


        // act
        var result = await controller.Add(writeOfferDTO);

        // assert

        var Okobjectresult = Assert.IsType<ActionResult<ReadOfferDto>>(result);

        var actualresault = Assert.IsAssignableFrom<ReadOfferDto>(Okobjectresult.Value);

        actualresault.Should().BeEquivalentTo(expectedoffer);

    }

    [Fact]
    public async Task CentralController_Add_ReturnsBadRequest()
    {
        // Arrange
        WriteOfferDto writeOfferDTO = new WriteOfferDto { Name =null };

        var fakeofferService = A.Fake<IOfferService>();
        var controller = new OfferController(fakeofferService);

        controller.ModelState.AddModelError("Name", "The Name field is required.");

        // Act
        var result = await controller.Add(writeOfferDTO);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public async Task CentralController_Edit_ReturnsNoContentResult()
    {
        // arrange
        int id = 5;
        UpdataOfferDto updataOfferDto = new UpdataOfferDto { Id = 5 };

        var expectedOfferDto = new ReadOfferDto{ Name = "off1" };


        //create fake iproviderservice
        var fakeOfferService = A.Fake<IOfferService>();

        //configure the mock object

        A.CallTo(() => fakeOfferService.Edit(id, updataOfferDto)).Returns(expectedOfferDto);

        var controller = new OfferController(fakeOfferService);

        //act
        var result = await controller.Edit(id, updataOfferDto);

        // assert
        Assert.IsType<NoContentResult>(result.Result);

    }



    [Fact]
    public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
    {
        // Arrange
        var Id = 5;
        var expectedReadOfferDTO = new ReadOfferDto { Name = "off1" };

        var fakeOfferrService = A.Fake<IOfferService>();
        A.CallTo(() => fakeOfferrService.Delete(Id)).Returns(expectedReadOfferDTO);

        var controller = new OfferController(fakeOfferrService);

        // Act
        var result = await controller.Delete(Id);

        // Assert
        var okObjectResult = Assert.IsAssignableFrom<ActionResult<ReadOfferDto>>(result);

        var actualOfferList = Assert.IsAssignableFrom<ReadOfferDto>(okObjectResult.Value);

        actualOfferList.Should().BeEquivalentTo(expectedReadOfferDTO);


    }









}
