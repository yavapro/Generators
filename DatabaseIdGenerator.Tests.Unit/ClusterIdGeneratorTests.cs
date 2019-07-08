namespace DatabaseIdGenerator.Tests.Unit
{
    using System;
    using System.Threading;
    using Xunit;
    
    public class ClusterIdGeneratorTests
    {
        private readonly ClusterIdGenerator target;

        public ClusterIdGeneratorTests()
        {
            target = new ClusterIdGenerator(DateTime.UnixEpoch);
        }

        [Fact]
        public void GenerateTwoComponentNotNullTest()
        {
            var dataId = 1;
            
            var id = target.GenerateTwoComponent(dataId);
            
            Assert.NotEqual(0L, id);
        }
        
        [Fact]
        public void GenerateTwoComponentUniqTest()
        {
            var dataId = 1;
            
            var id1 = target.GenerateTwoComponent(dataId);
            
            Thread.Sleep(1);
            
            var id2 = target.GenerateTwoComponent(dataId);
            
            Assert.NotEqual(id1, id2);
        }
        
        [Fact]
        public void GenerateThreeComponentNotNullTest()
        {
            ushort dataId = 1;
            
            var id = target.GenerateThreeComponent(dataId);
            
            Assert.NotEqual(0L, id);
        }
        
        [Fact]
        public void GenerateThreeComponentUniqTest()
        {
            ushort dataId = 1;
            
            var id1 = target.GenerateThreeComponent(dataId);
            
            Thread.Sleep(1);
            
            var id2 = target.GenerateThreeComponent(dataId);
            
            Assert.NotEqual(id1, id2);
        }
    }
}