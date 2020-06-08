using System;
using System.Reflection;
using Moq;
using NUnit.Framework;
using Portable;
using Portable.IViews.Interface;
using Portable.Presenters.Implement;
using Portable.Presenters.Interfaces;

namespace Tests
{
    [TestFixture]
    public class PresenterViewStartTests
    {
        private Mock<IViewStartPage> _viewStartMock;
        private Mock<IRepository> _repositoryMock;
        private IPresenterViewStart _presenter;
        Repository _repository;
        LocalApi _localApi;

        [SetUp]
        public void SetUp()
        {
            _viewStartMock = new Mock<IViewStartPage>(MockBehavior.Strict);
            _repositoryMock = new Mock<IRepository>(MockBehavior.Strict);
            _presenter = new PresenterViewStart(_viewStartMock.Object, _repositoryMock.Object);
            _localApi = LocalApi.GetLocalAPI();
            _repository = Repository.GetRepository();            
        }

        [Test]
        public void CtorPresenterTestViewStart()
        {
            var field = typeof(PresenterViewStart)
                .GetField("_viewStart", BindingFlags.NonPublic | BindingFlags.Instance)?
                .GetValue(_presenter);

            Assert.AreEqual(_viewStartMock.Object, field);
        }

        [Test]
        public void CtorPresenterTestRepository()
        {
            var field = typeof(PresenterViewStart)
                .GetField("_repository", BindingFlags.NonPublic | BindingFlags.Instance)?
                .GetValue(_presenter);

            Assert.AreEqual(_repositoryMock.Object, field);
        }

        [Test]
        public void AddUserTest()
        {
            User user = new User("Tom", "+380672345678", "image.jpg");
            
            var actual = _repository.AddUser(user);

            Assert.IsTrue(actual);
        }

        [Test]
        public void RemoveUserTest()
        {
            int index = 2;

            var actual = _repository.RemoveUser(index);

            Assert.IsTrue(actual);
        }
    }
}
