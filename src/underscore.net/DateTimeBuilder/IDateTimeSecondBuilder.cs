namespace underscore.net
{
    public interface IDateTimeSecondBuilder : IDateTimeBuilder
    {
        IDateTimeMilisecondBuilder Second(int second);
    }
}