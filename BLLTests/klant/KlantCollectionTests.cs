using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Text;
using CL;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class KlantCollectionTests
    {
        [TestMethod()]
        public void GetAllKlanten_ExecuteMethod_ShouldBeTrue()
        {
            //assign
            IKlantCollectionDAL _klantCollectionDAL = new KlantDALTest();
            KlantCollection _klantCollection = new KlantCollection(_klantCollectionDAL);

            //act
            IEnumerable<Klant> klanten = _klantCollection.GetAllKlanten();
            List<Klant> klantenList = new List<Klant>();
            foreach (var klant in klanten)
            {
                klantenList.Add(klant);
            }

            //assert
            Assert.IsTrue(klantenList.Count == 4);
        }

        [TestMethod()]
        public void GetKlantById_ExecuteUsingID_ShouldBeTrue()
        {
            //assign
            IKlantCollectionDAL _klantCollectionDAL = new KlantDALTest();
            KlantCollection _klantCollection = new KlantCollection(_klantCollectionDAL);
            int ID = 5;

            //act
            Klant klant = _klantCollection.GetKlantById(ID);

            //assert
            Assert.IsTrue(klant.ID == 7);
        }
    }
}