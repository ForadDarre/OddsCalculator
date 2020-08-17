using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using OddsCalculator;
using OddsCalculator.Services;

namespace OddsCalculator.Models
{
	public class TwoLegsModel : INotifyPropertyChanged
	{
		private double oddsA;
		private double oddsB;
		private double margin;
		private double payout;

		private string mode;

		public double OddsA
		{
			get
			{
				return oddsA;
			}

			set
			{
				oddsA = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
			}
		}

		public double OddsB
		{
			get
			{
				if (mode == MainVM.OddsMode)
				{
					CalculationsService calculationsService = new CalculationsService();
					oddsB = calculationsService.CalculateOddsByPayout(oddsA, payout);
				}

				return oddsB;
			}

			set
			{
				oddsB = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
			}
		}

		public double Margin
		{
			get
			{
				CalculationsService calculationsService = new CalculationsService();
				margin = calculationsService.CalculateMargin(oddsA, oddsB);

				return margin;
			}

			set
			{
				margin = value;
				OnPropertyChanged("Margin");
			}
		}

		public double Payout
		{
			get
			{
				if (mode == MainVM.MarginMode)
				{
					CalculationsService calculationsService = new CalculationsService();
					payout = calculationsService.CalculatePayout(oddsA, oddsB);
				}

				return payout;
			}

			set
			{
				payout = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
			}
		}

		public string Mode
		{
			get
			{
				return mode;
			}

			set
			{
				mode = value;
				OnPropertyChanged("Mode");
			}
		}

		public TwoLegsModel(string _mode)
		{
			mode = _mode;

			if (mode == MainVM.MarginMode)
			{
				oddsA = 2.0;
				oddsB = 2.0;
			}

			else
			{
				payout = 100.0;
				oddsA = 2.0;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
