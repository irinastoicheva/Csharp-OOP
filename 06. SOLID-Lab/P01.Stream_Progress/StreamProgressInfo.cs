namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IResult result;

        public StreamProgressInfo(IResult result)
        {
            this.result = result;
        }

        public int CalculateCurrentPercent()
        {
            return (this.result.BytesSent * 100) / this.result.Length;
        }
    }
}
