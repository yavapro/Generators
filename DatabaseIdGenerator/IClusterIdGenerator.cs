namespace DatabaseIdGenerator
{
    public interface IClusterIdGenerator
    {
        /// <summary>
        /// Generate new Id from timestamp (38 bit) + shardId (26 bit)
        /// </summary>
        /// <param name="shardId">26 bit value</param>
        long GenerateTwoComponent(int shardId);

        /// <summary>
        /// Generate new Id from timestamp (38 bit) + shardId (16 bit) + random (10 bit)
        /// </summary>
        /// <param name="shardId">16 bit value</param>
        long GenerateThreeComponent(ushort shardId);
    }
}