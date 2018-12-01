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

        [Test]
        public void test()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m

            };
            var betDto = _luluMapper.Mapper(bet,
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

        [Test]
        public void map_class_with_mapper()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m

            };

            var betDto = _luluMapper.Mapper(bet, new Mapper());

            var expected = new BetDto()
            {
                BetId = 1,
                Date = "20181201",
                Amount = 10
            };

            expected.ToExpectedObject().ShouldEqual(betDto);
        }

        [Test]
        public void mapper_with_properties()
        {
            var bet = new Bet()
            {
                Id = 1,
                CreatedDate = new DateTime(2018, 12, 1),
                Stake = 10m,
                Status="success"
            };

            var betDto = _luluMapper.Mapper<Bet, BetDto>(bet);

            var expected = new BetDto()
            {
               Status="success"
            };

            expected.ToExpectedObject().ShouldEqual(betDto);
        }
    }
}