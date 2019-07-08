namespace DatabaseIdGenerator
{
    using System;
    
    public class ClusterIdGenerator
    {
        private readonly DateTime epochStartPoint;
        private Random random;

        private Random Random
        {
            get
            {
                if (random == null)
                {
                    random = new Random();
                }

                return random;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="epochStartPoint">start date to get milliseconds</param>
        public ClusterIdGenerator(DateTime epochStartPoint)
        {
            this.epochStartPoint = epochStartPoint;
        }

        /// <summary>
        /// Generate new Id from timestamp (38 bit) + shardId (26 bit)
        /// </summary>
        /// <param name="shardId">26 bit value</param>
        public long GenerateTwoComponent(int shardId)
        {
            DateTime now = DateTime.UtcNow;
            long milliseconds = (long)(now - epochStartPoint).TotalMilliseconds;
            
            long keyPart1_38bit = milliseconds << (64 - 38);
            long keyPart2_26bit = shardId % (2 ^ 26);

            long id = keyPart1_38bit | keyPart2_26bit;

            return id;
        }
        
        /// <summary>
        /// Generate new Id from timestamp (38 bit) + shardId (16 bit) + random (10 bit)
        /// </summary>
        /// <param name="shardId">16 bit value</param>
        public long GenerateThreeComponent(ushort shardId)
        {
            DateTime now = DateTime.UtcNow;
            long milliseconds = (long)(now - epochStartPoint).TotalMilliseconds;
            int randId = (int) Math.Floor((float) Random.Next(1024));
            
            long keyPart1_38bit = milliseconds << (64 - 38);
            long keyPart2_16bit = shardId << (64 - 38 - 10);
            long keyPart3_10bit = randId;

            long id = keyPart1_38bit | keyPart2_16bit | keyPart3_10bit;

            return id;
        }
    }
}