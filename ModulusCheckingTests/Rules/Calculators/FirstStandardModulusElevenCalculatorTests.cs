﻿using ModulusChecking.Loaders;
using ModulusChecking.Models;
using ModulusChecking.Steps.Calculators;
using NUnit.Framework;

namespace ModulusCheckingTests.Rules.Calculators
{
    public class FirstStandardModulusElevenCalculatorTests
    {
        private FirstStandardModulusElevenCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new FirstStandardModulusElevenCalculator();
        }

        [Test]
        public void ExceptionThreeWhereCisNeitherSixNorNine()
        {
            var accountDetails = new BankAccountDetails("827101", "28748352");
            accountDetails.WeightMappings = ModulusWeightTable.GetInstance.GetRuleMappings(accountDetails.SortCode);
            var result = _calculator.Process(accountDetails);
            Assert.IsTrue(result);
        }

        [Test]
        public void CanPassBasicModulus11Test()
        {
            var accountDetails = new BankAccountDetails("202959", "63748472");
            accountDetails.WeightMappings = ModulusWeightTable.GetInstance.GetRuleMappings(accountDetails.SortCode);
            var result = _calculator.Process(accountDetails);
            Assert.IsTrue(result);
        }
    }
}
