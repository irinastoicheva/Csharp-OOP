namespace P01.Stream_Progress
{
    public interface IResult
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
