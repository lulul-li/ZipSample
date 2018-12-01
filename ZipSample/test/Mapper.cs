namespace ZipSample.test
{
    public class Mapper : IMapper<Bet, BetDto>
    {
        public BetDto Map(Bet bet)
        {
            return new BetDto
            {
                BetId = bet.Id,
                Date = bet.CreatedDate.ToString("yyyyMMdd"),
                Amount = (int)bet.Stake
            };
        }

    }
}