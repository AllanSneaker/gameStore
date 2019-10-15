using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.BLL.Exceptions;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Services;
using GameStore.DAL.Entity.Interfaces;
using GameStore.DAL.Entity.Models.Game;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Tests.Services
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IGameRepository> _gameRepository;
        private IGameService _gameService;
        private Mock<IMapper> _mapper;

        private Game _concreteGame;
        private GameDto _gameDto;
        private GameDto _gameDtoUpdated;
        private Game _gameUpdated;

        [SetUp]
        public void Initialize()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _gameRepository = new Mock<IGameRepository>();

            _concreteGame = new Game() { Id = 1, Name = "NFS" };
            _gameDto = new GameDto() { Id = 1, Name = "NFS" };
            _gameDtoUpdated = new GameDto() { Id = 1, Name = "NFS2" };
            _gameUpdated = new Game() { Id = 1, Name = "NFS2" };

            _mapper = new Mock<IMapper>();
            _mapper.Setup(x => x.Map<GameDto>(_concreteGame)).Returns(_gameDto);
            _mapper.Setup(x => x.Map<GameDto>(_gameDtoUpdated)).Returns(_gameDto);

            _unitOfWork.Setup(x => x.GameRepository).Returns(_gameRepository.Object);
            

            _gameService = new GameService(_mapper.Object, _unitOfWork.Object);
        }

        #region GetAllAsync

        [Test]
        public async Task GetAllGamesAsync_should_get_all_games()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Game>() as IOrderedQueryable<Game>);

            //Act
            var games = await _gameService.GetAllGamesAsync();

            //Assert
            Assert.NotNull(games);
        }

        #endregion

        #region GetAsync

        [Test]
        public async Task GetAsync_should_get_game_by_id()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(1)).Returns(Task.FromResult(_concreteGame));

            //Act
            var game = await _gameService.GetAsync(1);

            //Assert
            Assert.AreEqual(_gameDto.Id, game.Id);

        }
        #endregion

        #region CreateAsync
        [Test]
        public void CreateAsync_should_throw_ArgumentNullException_when_input_entity_is_null()
        {
            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _gameService.CreateAsync(null));
        }

        [Test]
        public async Task CreateAsync_repository_should_be_created_once()
        {
            //Arrange
            var game = new GameDto() { Name = It.IsAny<string>() };

            //Act
            await _gameService.CreateAsync(game);

            //Assert
            _gameRepository.Verify(x => x.Create(It.IsAny<Game>()), Times.Once);

        }
        #endregion

        #region EditAsync

        [Test]
        public void UpdateAsync_should_throw_ArgumentNullException_if_input_entity_is_null()
        {
            //Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _gameService.UpdateAsync(null));
        }

        [Test]
        public void UpdateAsync_should_throw_ItemNotFoundException_if_game_with_specified_id_does_not_exist_in_the_database()
        {
            //Arrange
            var game = new GameDto() { Name = It.IsAny<string>() };
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((Game)null));

            //Act & Assert
            Assert.ThrowsAsync<ItemNotFoundException>(() => _gameService.UpdateAsync(game));

        }

        [Test]
        public async Task UpdateAsync_should_edit_game()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(_gameDtoUpdated.Id)).Returns(Task.FromResult(_concreteGame));

            //Act
            await _gameService.UpdateAsync(_gameDtoUpdated);

            //Assert
            _gameRepository.Verify(x => x.Update(_concreteGame));
        }

        #endregion

        #region DeleteAsync

        [Test]
        public async Task DeleteAsync_should_delete_game()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Game() { Name = It.IsAny<string>() });

            //Act
            await _gameService.DeleteAsync(It.IsAny<int>());

            //Assert
            _gameRepository.Verify(x => x.Delete(It.IsAny<Game>()));
        }

        [Test]
        public void DeleteAsync_should_throw_ItemNotFoundException_if_game_with_specified_id_does_not_exist_in_the_database()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((Game)null));

            //Act & Assert
            Assert.ThrowsAsync<ItemNotFoundException>(() => _gameService.DeleteAsync(It.IsAny<int>()));
        }

        #endregion

    }
}
