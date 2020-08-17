using System;
using System.Collections.Generic;
using System.Text;

namespace OddsCalculator.Services
{
	public class CalculationsService
	{
		public double CalculateOddsByPayout(double oddsA, double payout)
		{
			return 1 / (100 / payout - 1 / oddsA);
		}

		public double CalculateOddsByPayout(double oddsA, double oddsB, double payout)
		{
			return 1 / (100 / payout - 1 / oddsA - 1 / oddsB);
		}

		public double CalculateMargin(double oddsA, double oddsB)
		{
			return (1 / oddsA + 1 / oddsB) * 100 - 100;
		}

		public double CalculateMargin(double oddsA, double oddsB, double oddsC)
		{
			return (1 / oddsA + 1 / oddsB + 1 / oddsC) * 100 - 100;
		}

		public double CalculatePayout(double oddsA, double oddsB)
		{
			return 100 / (1 / oddsA + 1 / oddsB);
		}

		public double CalculatePayout(double oddsA, double oddsB, double oddsC)
		{
			return 100 / (1 / oddsA + 1 / oddsB + 1 / oddsC);
		}
	}
}
