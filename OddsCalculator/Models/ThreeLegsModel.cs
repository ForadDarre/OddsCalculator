using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace OddsCalculator.Models
{
	public class ThreeLegsModel : INotifyPropertyChanged
	{
		private double coefA;
		private double coefB;
		private double coefC;
		private double margin;

		public double CoefA
		{
			get
			{
				return coefA;
			}

			set
			{
				coefA = value;
				OnPropertyChanged("CoefA");
			}
		}

		public double CoefB
		{
			get
			{
				return coefB;
			}

			set
			{
				coefB = value;
				OnPropertyChanged("CoefB");
			}
		}


		public double CoefC
		{
			get
			{
				return coefC;
			}

			set
			{
				coefC = value;
				OnPropertyChanged("CoefC");
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

		public ThreeLegsModel()
		{
			coefA = 3.0;
			coefB = 3.0;
			coefB = 3.0;
			margin = 0.0;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
