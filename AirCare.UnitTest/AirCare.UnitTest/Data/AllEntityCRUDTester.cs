using System.Text;
using System.Threading.Tasks;
using AirCare.Data.Core;
using System.Configuration;
using AirCare.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirCare.Model.Entities;
using System.Linq;
using System.Security.Cryptography;

namespace AirCare.UnitTest.Data
{
    [TestClass]
    public class AllEntityCRUDTester
    {
        private static UnitOfWork Uow { get; set; }

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var conStr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            UowFactory.ConnectionString = conStr;
            Uow = (UnitOfWork)UowFactory.Create();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Uow.Dispose();
        }

        [TestMethod]
        public void CreateDB()
        {
            SHA1CryptoServiceProvider sha1csp = new SHA1CryptoServiceProvider();
            var user = new User { FirstName = "Admin", LastName = "Admin", UserName = "sysadmin", Sha1Password = sha1csp.ComputeHash(Encoding.Unicode.GetBytes( "sysadmin")), SecurityQuestion = "What is your pet name?", Answer = "jimbo" };
            var repo = Uow.GetEntityRepository<User>().InsertOrUpdate(user);
            Uow.Commit();
        }

        [TestMethod]
        public void CRUTest()
        {
            var userId = Uow.GetEntityRepository<User>()
                    .GetAll()
                    .Where(s => s.UserName.Equals("sysadmin"))
                    .Select(s => s.Id).SingleOrDefault();

            Assert.AreEqual(userId, 2);
        }
    }
}