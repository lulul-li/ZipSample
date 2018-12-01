namespace ZipSample.test
{
    public interface IMapper<in TSource, out TResult>
    {
        TResult Map(TSource bet);
    }
}