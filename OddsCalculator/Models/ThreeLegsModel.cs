using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace OddsCalculator.Models
{
	public class ThreeLegsModel : INotifyPropertyChanged
	{
		private double oddsA;
		private double oddsB;
		private double oddsC;
		private double margin;

		private string mode;

		public double CoefA
		{
			get
			{
				return oddsA;
			}

			set
			{
				oddsA = value;
				OnPropertyChanged("OddsA");
			}
		}

		public double CoefB
		{
			get
			{
				return oddsB;
			}

			set
			{
				oddsB = value;
				OnPropertyChanged("OddsB");
			}
		}


		public double CoefC
		{
			get
			{
				return oddsC;
			}

			set
			{
				oddsC = value;
				OnPropertyChanged("OddsC");
			}
		}

		public double Margin
		{
			get
			{
				return margin;
			}

			set
			{
				margin = value;
				OnPropertyChanged("Margin");
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
			oddsA = 3.0;
			oddsB = 3.0;
			oddsB = 3.0;
			margin = 0.0;
			mode = _mode;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
