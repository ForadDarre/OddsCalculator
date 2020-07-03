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
		private double roi;

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
				OnPropertyChanged("ROI");
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
					oddsB = 1 / (2 - 1 / oddsA - roi / 100);
				}

				return oddsB;
			}

			set
			{
				oddsB = value;
				OnPropertyChanged("ROI");
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
				OnPropertyChanged("ROI");
				OnPropertyChanged("Margin");
				OnPropertyChanged("OddsA");
				OnPropertyChanged("OddsB");
			}
		}

		public double ROI
		{
			get
			{
				if (mode == MainVM.marginMode)
				{
					roi = 200 - (1 / oddsA + 1 / oddsB) * 100;
				}

				return roi;
			}

			set
			{
				roi = value;
				OnPropertyChanged("ROI");
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
				roi = 100.0;
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