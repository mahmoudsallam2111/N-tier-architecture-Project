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

namespace ISPBackEnd.Tests.Controller
{
   public class PackageControllerTests
    {

        private IPackageService _PackageService;
        public PackageControllerTests()
        {
            _PackageService = A.Fake<IPackageService>();
        }


        [Fact]

        public async Task PackageController_GetPackages_ReturnsOk()
        {
            //arrange
            var expectedPackagelist = new List<ReadPackageDTO>
        //{
        {
            new ReadPackageDTO {Id =  1, Name = "p1" , IsActive = true , Price = 500 , ProviderName = "we" , Type="hhh" },
            new ReadPackageDTO {Id =  2, Name = "p2" , IsActive = true , Price = 500 , ProviderName = "we" , Type="hhh" },
           

        };

            var fakePackageservice = A.Fake<IPackageService>();

            //congigure the mock object
            A.CallTo(() => fakePackageservice.GetAll()).Returns(expectedPackagelist);

            var controller = new PackageController(fakePackageservice);

            //act
            var result = await controller.GetAll();

            // assert
            var okObjectResult = Assert.IsAssignableFrom<ActionResult<List<ReadPackageDTO>>>(result);
            var actualPackagelist = Assert.IsAssignableFrom<List<ReadPackageDTO>>(okObjectResult.Value);

            actualPackagelist.Should().BeEquivalentTo(expectedPackagelist);


        }

        [Fact]

        public async Task PackageController_GetPackageID_ReturnsOk()
        {
            int id = 5;
          var expectespackage =   new ReadPackageDTO { Id = 5, Name = "p1", IsActive = true, Price = 500, ProviderName = "we", Type = "hhh" };


            var fakepackageService = A.Fake<IPackageService>();


            //configure the mock object
            A.CallTo(() => fakepackageService.GetById(id)).Returns(expectespackage);

            var controller = new PackageController(fakepackageService);

            //act
            var result = await controller.GetById(id);

            // assert

            var okobject = Assert.IsAssignableFrom<ActionResult<ReadPackageDTO>>(result);

            var actualPackage = Assert.IsAssignableFrom<ReadPackageDTO>(okobject.Value);

            actualPackage.Should().BeEquivalentTo(expectespackage);
        }



        [Fact]
        public async Task PackageController_Add_ReturnsOk()
        {
            //arrange

            WritePackageDTO writePackageDTO = new WritePackageDTO { Name = "p2"  , Price = 500 , ProviderId = 5};
            ReadPackageDTO expectedPackage = new ReadPackageDTO { Id = 5, Name = "p2", IsActive = true, Price = 500, ProviderName = "we", Type = "hhh" };


            var fakePackageService = A.Fake<IPackageService>();

            A.CallTo(() => fakePackageService.AddPackage(writePackageDTO)).Returns(expectedPackage);

            var controller = new PackageController(fakePackageService);


            // act
            var result = await controller.Add(writePackageDTO);

            // assert

            var Okobjectresult = Assert.IsType<ActionResult<ReadPackageDTO>>(result);

            var actualresault = Assert.IsAssignableFrom<ReadPackageDTO>(Okobjectresult.Value);

            actualresault.Should().BeEquivalentTo(expectedPackage);

        }

     

        [Fact]
        public async Task  PackageController_Edit_ReturnsNoContentResult()
        {
            // arrange
            int id = 5;
            UpdatePackageDTO updatePackageDTO = new UpdatePackageDTO { Id = 1, Name = "p1" };

            var expectedPackageDto = new ReadPackageDTO { Id = 1, Name = "p1", IsActive = true, Price = 500, ProviderName = "we", Type = "hhh" };


            //create fake iBranchservice
            var fakePackageService = A.Fake<IPackageService>();

            //configure the mock object

            A.CallTo(() => fakePackageService.UpdatePackage(id, updatePackageDTO)).Returns(expectedPackageDto);

            var controller = new PackageController(fakePackageService);

            //act
            var result = await controller.Edit(id, updatePackageDTO);

            // assert
            Assert.IsType<ObjectResult>(result.Result);

        }



        [Fact]
        public async Task Delete_ReturnsOkObjectResult_When_ObjectExists()
        {
            // Arrange
            var Id = 1;
            var expectedReadBranchDTO = new ReadPackageDTO { Id = 1, Name = "p1", IsActive = true, Price = 500, ProviderName = "we", Type = "hhh" };

            var fakePackageService = A.Fake<IPackageService>();
            A.CallTo(() => fakePackageService.DeletePackage(Id)).Returns(expectedReadBranchDTO);

            var controller = new PackageController(fakePackageService);

            // Act
            var result = await controller.Delete(Id);

            // Assert
            var okObjectResult = Assert.IsAssignableFrom<ActionResult<ReadPackageDTO>>(result);

            var actualPackage = Assert.IsAssignableFrom<ReadPackageDTO>(okObjectResult.Value);

            actualPackage.Should().BeEquivalentTo(expectedReadBranchDTO);

        }



    }
}
