﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.ValueObjects
{
    public sealed class Money: ValueObject
    {
        public decimal Amount { get; }

        private Money()
        {
        }

        private Money (decimal amount)
        {
            Amount = amount;
        }

        public static Money FromDecimal(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("amount should be positive");
            }
            return new Money(amount);
        }
    }
}
