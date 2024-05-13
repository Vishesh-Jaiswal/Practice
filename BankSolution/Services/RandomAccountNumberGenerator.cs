using BankSolution.Interfaces;
using System;

namespace BankSolution.Services
{
    public class RandomAccountNumberGenerator : IAccountNumberGenerator
    {
        private readonly Random _random;

        public RandomAccountNumberGenerator()
        {
            _random = new Random();
        }

        public int? GenerateAccountNumber()
        {
            return _random.Next(1000000, 9999999);
        }
    }
}
