using System;

namespace ZipSample.test
{
    public class LuluMapper
    {
        public TResult CreatedBetDto<TSource, TResult>(TSource bet, Func<TSource, TResult> selector)
        {
            return selector(bet);
        }

        public TResult CreatedBetDto<TSource, TResult>(TSource bet, IMapper<TSource, TResult> mapper)
        {
            return mapper.Map(bet);
        }

        public BetDto CreatedBetDto<TSource>(TSource bet)
        {
            return new BetDto
            {
                BetId =  (int) bet.GetType().GetProperty("BetId").GetValue(bet),
                Date = (string) bet.GetType().GetProperty("Date").GetValue(bet),
                Amount = (int) bet.GetType().GetProperty("Amount").GetValue(bet),
                Status = (string) bet.GetType().GetProperty("Status").GetValue(bet),
            };
           
        }
    }
}