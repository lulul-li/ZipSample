using System;

namespace ZipSample.test
{
    public class LuluMapper
    {
        public TResult Mapper<TSource, TResult>(TSource bet, Func<TSource, TResult> selector)
        {
            return selector(bet);
        }

        public TResult Mapper<TSource, TResult>(TSource bet, IMapper<TSource, TResult> mapper)
        {
            return mapper.Map(bet);
        }

        public TResult Mapper<TSource, TResult>(TSource bet)
        {
            var resultProperties = typeof(TResult).GetProperties();
            var result = Activator.CreateInstance(typeof(TResult));
            foreach (var property in resultProperties)
            {
                var value = bet.GetType().GetProperty(property.Name)?.GetValue(bet);
                result.GetType().GetProperty(property.Name).SetValue(result,value);
            }
            return (TResult) result;
        }
    }
}