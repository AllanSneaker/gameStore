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

        [SetUp]
        public void Initialize()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _gameRepository = new Mock<IGameRepository>();
            _mapper = new Mock<IMapper>();

            _unitOfWork.Setup(x => x.GameRepository).Returns(_gameRepository.Object);

            _gameService = new GameService(_mapper.Object, _unitOfWork.Object);
        }

        #region GetAllAsync
        //[Test]
        //public void GetAllGamesAsync_should_get_all_games()
        //{
        //    //Arrange
        //    _gameRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Game>() as IOrderedQueryable<Game>);

        //    //Act
        //    var games = _gameService.GetAllGamesAsync();

        //    //Assert
        //    games.Should().NotBeNull(); 
        //}

        #endregion

        #region GetAsync

        [Test]
        public void GetAsync_should_get_game_by_id()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Game() { Name = It.IsAny<string>() });

            //Act
            var game = _gameService.GetAsync(It.IsAny<int>());

            //Assert
            _gameRepository.Verify(x => x.GetAsync(It.IsAny<int>()));

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
        public void CreateAsync_repository_should_be_created_once()
        {
            //Arrange
            var game = new GameDto() { Name = It.IsAny<string>() };

            //Act
            _gameService.CreateAsync(game);

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
        public void UpdateAsync_should_edit_game()
        {
            //Arrange
            var game = new GameDto() { Name = It.IsAny<string>() };
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Game() { Name = It.IsAny<string>() });

            //Act
            _gameService.UpdateAsync(game);

            //Assert
            _gameRepository.Verify(x => x.Update(It.IsAny<Game>()));
        }

        #endregion

        #region DeleteAsync

        [Test]
        public void DeleteAsync_should_delete_game()
        {
            //Arrange
            _gameRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Game() { Name = It.IsAny<string>() });

            //Act
            _gameService.DeleteAsync(It.IsAny<int>());

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
