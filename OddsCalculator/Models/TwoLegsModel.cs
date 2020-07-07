using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using OddsCalculator;

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
				if (mode == MainVM.oddsMode)
				{
					//oddsB = 1 / (2 - payout / 100 - 1 / oddsA);
					oddsB = 1 / (100 / payout - 1 / oddsA);
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
				margin = (1 / oddsA + 1 / oddsB) * 100 - 100;

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
				if (mode == MainVM.marginMode)
				{
					//payout = 200 - 100 / oddsA - 100 / oddsB;
					payout = 100 / (1 / oddsA + 1 / oddsB);
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

			if (mode == MainVM.marginMode)
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
