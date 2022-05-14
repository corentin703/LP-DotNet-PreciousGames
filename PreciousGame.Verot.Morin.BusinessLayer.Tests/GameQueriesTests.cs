using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreciousGame.Verot.Morin.BusinessLayer.Managers;

namespace PreciousGame.Verot.Morin.BusinessLayer.Tests
{
    [TestClass]
    public class GameQueriesTests
    {
        [TestMethod]
        public void GetAll()
        {
            Assert.AreEqual(0, Manager.Instance.GetAllGames().Count);
        }
    }
}
