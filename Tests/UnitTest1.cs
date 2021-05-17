using NUnit.Framework;
using System;
using System.Net.Http;
using OSRS.HiScores;
using System.Threading.Tasks;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task LynxTitanTest()
        {
            var lynxTitan = await PlayerScores.FindAsync("Lynx Titan", Mode.Classic);

            if (lynxTitan.Overall.Rank == 1)
                Assert.Pass();

            Assert.Fail();
        }
    }
}