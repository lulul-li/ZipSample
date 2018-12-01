using System;
using System.Collections.Generic;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ZipSample.test
{
    [TestFixture]
    public class BetTest
    {
        private readonly LuluMapper _luluMapper = new LuluMapper();

        [TestMethod]
        public void test()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m

            };
            var betDto = _luluMapper.CreatedBetDto(bet,
                b => new BetDto
                {
                    BetId = b.Id,
                    Date = b.CreatedDate.ToString("yyyyMMdd"),
                    Amount = (int)b.Stake
                });

            var expected = new BetDto()
            {
                BetId = 1,
                Date = "20181201",
                Amount = 10
            };

            expected.ToExpectedObject().ShouldEqual(betDto);
        }

        [TestMethod]
        public void test2()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m

            };

            var betDto = _luluMapper.CreatedBetDto(bet, new Mapper());

            var expected = new BetDto()
            {
                BetId = 1,
                Date = "20181201",
                Amount = 10
            };

            expected.ToExpectedObject().ShouldEqual(betDto);
        }

        [TestMethod]
        public void test3()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m,
                Status="success"
            };

            var betDto = _luluMapper.CreatedBetDto(bet);

            var expected = new BetDto()
            {
               Status="success"
            };

            expected.ToExpectedObject().ShouldEqual(betDto);
        }
    }

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

    public interface IMapper<in TSource, out TResult>
    {
        TResult Map(TSource bet);
    }

    public class Bet
    {
        public int Id { get; set; }
        public decimal Stake { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }

    public class BetDto
    {
        public int BetId { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
    }
}