using AutoMapper;
using FakeItEasy;
using ISP.BL;
using ISP.DAL;

namespace ISPBackEnd.Tests.Services
{
    public class ProviderServicesTests
    {
        private IMapper _mapper;
        private ProviderService _providerService;
        private IProviderRepository _providerRepository;

        public ProviderServicesTests()
        {
            _providerRepository = A.Fake<IProviderRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
            _providerService = new ProviderService(_providerRepository, _mapper);
        }


        [Fact]
        public async Task GetAll_Returns_Mapped_ProviderDto_List()
        {
            // Arrange
            var providers = new List<Provider>
            {
            new Provider { Id = 1, Name = "Provider 1" },
            new Provider { Id = 2, Name = "Provider 2" },
            new Provider { Id = 3, Name = "Provider 3" }
            };


            // configure the moke object
            A.CallTo(() => _providerRepository.GetAll()).Returns(providers);

            // Act
            var result = await _providerService.GetAll();

            // Assert
            Assert.IsType<List<ReadProviderDTO>>(result);
            Assert.Equal(providers.Count, result.Count);
            Assert.Equal(providers.Select(p => p.Name), result.Select(p => p.Name));

            // Verify that the GetAll method was called once on the provider repository
            A.CallTo(() => _providerRepository.GetAll()).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GetAllById_Returns_Mapped_OfferDto()
        {
            int id = 5;
            var providerobj = new Provider { Id = 1, Name = "we"  , IsActive = true};

            A.CallTo(() => _providerRepository.GetByID(id)).Returns(providerobj);


            // act
            var result = await _providerService.GetById(id);

            // assert
            Assert.IsType<ReadProviderDTO>(result);
            Assert.Equal(providerobj.Name, result.Name);
          
            A.CallTo(() => _providerRepository.GetByID(id)).MustHaveHappenedOnceExactly();



        }

        [Fact]
        public async Task Insert_Returns_Mapped_ReadProviderDTO()
        {
            // Arrange
            var writeProviderDTO = new WriteProviderDTO { Name = "Provider 1" };
            var providerToAdd = _mapper.Map<Provider>(writeProviderDTO);
            var providerAdded = _mapper.Map<Provider>(writeProviderDTO);
            providerAdded.Id = 1;

            A.CallTo(() => _providerRepository.Add(providerToAdd)).Invokes(() => providerToAdd.Id = 1);
            A.CallTo(() => _providerRepository.SaveChange()).DoesNothing();

            // Act
            var result = await _providerService.Insert(writeProviderDTO);

            // Assert

            Assert.IsType<ReadProviderDTO>(result);
           // Assert.Equal(providerAdded.Id, result.Id);
            Assert.Equal(providerAdded.Name, result.Name);

          
            // Verify that the SaveChange method was called once on the provider repository
            A.CallTo(() => _providerRepository.SaveChange()).MustHaveHappenedOnceExactly();
        }


        [Fact]
        public async Task Edit_ExistingProvider_Returns_Mapped_ReadProviderDTO()
        {
            // Arrange
            var providerToEdit = new Provider { Id = 1, Name = "Provider 1", IsActive = false };

            var updateProviderDTO = new UpdateProviderDTO { Id = 1 , Name = "we"  };

            var expectedProvider = new Provider { Id = 1, Name = "we", IsActive = true };

            // map to return readdto 
            var expectedReadProviderDTO = _mapper.Map<ReadProviderDTO>(expectedProvider);


            A.CallTo(() => _providerRepository.GetByID(providerToEdit.Id)).Returns(providerToEdit);

            // Act
            var result = await _providerService.Edit(providerToEdit.Id, updateProviderDTO);

            // Assert
              Assert.NotNull(result);
             Assert.Equal(expectedReadProviderDTO.Name, result.Name);
          

            // Verify that the GetByID method was called once on the provider repository with the correct ID
            A.CallTo(() => _providerRepository.GetByID(providerToEdit.Id)).MustHaveHappenedOnceExactly();

            // Verify that the SaveChange method was called once on the provider repository
            A.CallTo(() => _providerRepository.SaveChange()).MustHaveHappenedOnceExactly();
        }


        [Fact]
        public async Task Edit_NonExistingProvider_Returns_Null()
        {
            // Arrange
            var invalidProviderId = 999;

            var updateProviderDTO = new UpdateProviderDTO  { Id = 1 ,  Name = "Edited Provider 1"};

            A.CallTo(() => _providerRepository.GetByID(invalidProviderId)).Returns<Provider?>(null);

            // Act
            var result = await _providerService.Edit(invalidProviderId, updateProviderDTO);

            // Assert
            Assert.Null(result);

            // Verify that the GetByID method was called once on the provider repository with the correct ID
            A.CallTo(() => _providerRepository.GetByID(invalidProviderId)).MustHaveHappenedOnceExactly();
            // Verify that the Update method and SaveChange method were not called on the provider repository
            A.CallTo(() => _providerRepository.Update(A<Provider>._)).MustNotHaveHappened();

            A.CallTo(() => _providerRepository.SaveChange()).MustNotHaveHappened();
        }



        [Fact]
        public async Task Remove_ExistingProvider_Returns_Mapped_ReadProviderDTO()
        {
            // Arrange
            var Id = 1 ;

            var providerFromDB = new Provider { Id = 1, Name = "Provider 1", IsActive = true };
            var expectedProvider = new Provider { Id = 1, Name = "Provider 1", IsActive = false };
            var expectedReadProviderDTO = _mapper.Map<ReadProviderDTO>(expectedProvider);

            A.CallTo(() => _providerRepository.GetByID(Id)).Returns(providerFromDB);

            // Act
            var result = await _providerService.Remove(Id);

            // Assert
            Assert.NotNull(result);
          //  Assert.Equal(expectedReadProviderDTO.Id, result.Id);
            Assert.Equal(expectedReadProviderDTO.Name, result.Name);
           

            // Verify that the GetByID method was called once on the provider repository with the correct ID
            A.CallTo(() => _providerRepository.GetByID(Id)).MustHaveHappenedOnceExactly();
         


            // Verify that the SaveChange method was called once on the provider repository
            A.CallTo(() => _providerRepository.SaveChange()).MustHaveHappenedOnceExactly();
        }


        [Fact]
        public async Task Remove_NonExistingProvider_Returns_Null()
        {
            // Arrange
            var  Id = 999 ;

            A.CallTo(() => _providerRepository.GetByID(Id)).Returns<Provider?>(null);

            // Act
            var result = await _providerService.Remove(Id);

            // Assert
            Assert.Null(result);

            // Verify that the GetByID method was called once on the provider repository with the correct ID
            A.CallTo(() => _providerRepository.GetByID(Id)).MustHaveHappenedOnceExactly();
            // Verify that the Update method and SaveChange method were not called on the provider repository
            A.CallTo(() => _providerRepository.Update(A<Provider>._)).MustNotHaveHappened();
            A.CallTo(() => _providerRepository.SaveChange()).MustNotHaveHappened();
        }




    }

    
}
