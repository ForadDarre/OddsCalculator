using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using OddsCalculator;
using OddsCalculator.Services;

namespace OddsCalculator.Models
{
	public class ThreeLegsModel : INotifyPropertyChanged
	{
		private double oddsA;
		private double oddsB;
		private double oddsC;
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
				OnPropertyChanged("OddsC");
			}
		}

		public double OddsB
		{
			get
			{
				return oddsB;
			}

			set
			{
				oddsB = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
				OnPropertyChanged("OddsC");
			}
		}


		public double OddsC
		{
			get
			{
				if (mode == MainVM.OddsMode)
				{
					CalculationsService calculationsService = new CalculationsService();
					oddsC = calculationsService.CalculateOddsByPayout(oddsA, oddsB, payout);
				}

				return oddsC;
			}

			set
			{
				oddsC = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
				OnPropertyChanged("OddsC");
			}
		}

		public double Margin
		{
			get
			{
				CalculationsService calculationsService = new CalculationsService();
				margin = calculationsService.CalculateMargin(oddsA, oddsB, oddsC);

				return margin;
			}

			set
			{
				margin = value;
				OnPropertyChanged("Payout");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
				OnPropertyChanged("OddsC");
			}
		}

		public double Payout
		{
			get
			{
				if (mode == MainVM.MarginMode)
				{
					CalculationsService calculationsService = new CalculationsService();
					payout = calculationsService.CalculatePayout(oddsA, oddsB, oddsC);
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
				OnPropertyChanged("OddsC");
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

		public ThreeLegsModel(string _mode)
		{
			mode = _mode;

			if (mode == MainVM.MarginMode)
			{
				oddsA = 3.0;
				oddsB = 3.0;
				oddsC = 3.0;
			}

			else
			{
				payout = 100.0;
				oddsA = 3.0;
				oddsB = 3.0;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
