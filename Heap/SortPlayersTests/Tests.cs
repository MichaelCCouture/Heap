using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCoutureAssignment3;
using NUnit.Framework;
using System.IO;

namespace SortPlayersTest
{
    public class Tests
    {
        SortRoster sr;

        
        [SetUp]
        public void Initialize()
        {
            sr = new SortRoster(10, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Players1.xml");
            //sr = new SortRoster(10, "C:/Users/Michael/Desktop/MCoutureAssignment3/Players1.xml");
        }

        [Test]
        public void FindLowestPlayer()
        {
            sr.ReadRoster();

            Player temp = sr.Fetch();
            Assert.AreEqual(05, temp.getNumber());
        }

        [Test]
        public void FindSecondLowestPlayer()
        {
            sr.ReadRoster();

            sr.Fetch();
            Player temp = sr.Fetch();
            Assert.AreEqual(12, temp.getNumber());            
        }

        [Test]
        public void AlternateXMLFile()
        {
            sr.SetFileName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Players2.xml");
            sr.ReadRoster();

            Player temp = sr.Fetch();
            Assert.AreEqual(05, temp.getNumber());
        }

        [Test]
        public void AlternateXMLFileGetLastPlayer()
        {
            sr.SetFileName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Players2.xml");
            sr.ReadRoster();

            sr.Fetch();
            sr.Fetch();
            sr.Fetch();
            sr.Fetch();

            Player temp = sr.Fetch();
            Assert.AreEqual(99, temp.getNumber());
        }

        [Test]
        public void LoadEmptyXMLFile()
        {
            sr.SetFileName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/PlayersEmpty.xml");
           Assert.Throws<ApplicationException>(() => sr.ReadRoster());
        }

        [Test]
        public void LoadXMLWithIncorrectTags()
        {
            sr.SetFileName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/PlayersInvalid.xml");
            Assert.Throws<ApplicationException>(() => sr.ReadRoster());
        }

        [Test]
        public void LoadXMLFileThatDoesntExist()
        {
            sr.SetFileName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/ThisFileDoesntExist.xml");
            Assert.Throws<ApplicationException>(() => sr.ReadRoster());
        }
    }
}
