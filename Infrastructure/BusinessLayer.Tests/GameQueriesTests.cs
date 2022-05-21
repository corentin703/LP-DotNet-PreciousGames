using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;

namespace PreciousGames.Verot.Morin.BusinessLayer.Tests
{
    [TestClass]
    public class GameQueriesTests
    {
        [TestMethod]
        public void GetAll()
        {
            Assert.AreEqual(0, BusinessManager.Instance.GetAllGames().Count);
        }
    }
}
