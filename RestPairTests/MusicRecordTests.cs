using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestPair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPair.Tests
{
    [TestClass()]
    public class MusicRecordTests
    {
        [TestMethod()]
        public void ValidateTitleTest()
        {
            MusicRecord musicNull = new MusicRecord(null, "AAAA", 1788, "Heavy Metal");
            MusicRecord musicEmpty = new MusicRecord("", "AAAAAA", 1888, "Blues");
            MusicRecord musicGood = new MusicRecord("The One That Works", "AAAAA", 1989, "Prog Rock");

            Assert.ThrowsException<ArgumentNullException>(() => musicNull.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => musicEmpty.ValidateTitle());
            Assert.AreEqual("The One That Works", musicGood.Title);
        }

        [TestMethod()]
        public void ValidateArtistTest()
        {
            MusicRecord artistNull = new MusicRecord("aaa", null, 1892, "Your Favourite Genre");
            MusicRecord artistEmpty = new MusicRecord("aaaa", "", 1888, "Blues");
            MusicRecord artistGood = new MusicRecord("The One That Works", "AAAAA", 1989, "Prog Rock");

            Assert.ThrowsException<ArgumentNullException>(() => artistNull.ValidateArtist());
            Assert.ThrowsException<ArgumentException>(() => artistEmpty.ValidateArtist());
            Assert.AreEqual("AAAAA", artistGood.Artist);
        }

        [TestMethod()]
        public void ValidateReleaseTest()
        {
            MusicRecord releaseNull = new MusicRecord("aaa", "test", null, "Your Favourite Genre");
            MusicRecord releaseThousand = new MusicRecord("aaaaa", "test", 1000, "Idk");
            MusicRecord releaseNineninenine = new MusicRecord("aaaaa", "test", 999, "Idk");
            MusicRecord releaseGood = new MusicRecord("The One That Works", "AAAAA", 1001, "Prog Rock");

            Assert.ThrowsException<ArgumentNullException>(() => releaseNull.ValidateRelease());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => releaseThousand.ValidateRelease());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => releaseNineninenine.ValidateRelease());
            Assert.AreEqual(1001, releaseGood.Release);
        }

        [TestMethod()]
        public void ValidateGenreTest()
        {
            MusicRecord genreNull = new MusicRecord("aaa", "test", 1892, null);
            MusicRecord genreEmpty = new MusicRecord("aaaa", "test", 1888, "");
            MusicRecord genreGood = new MusicRecord("The One That Works", "AAAAA", 1989, "Prog Rock");

            Assert.ThrowsException<ArgumentNullException>(() => genreNull.ValidateGenre());
            Assert.ThrowsException<ArgumentException>(() => genreEmpty.ValidateGenre());
            Assert.AreEqual("Prog Rock", genreGood.Genre);
        }
    }
}