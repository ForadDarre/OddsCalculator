using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace OddsCalculator.Models
{
	public class TwoLegsModel : INotifyPropertyChanged
	{
		private double coefA;
		private double coefB;
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

		public TwoLegsModel()
		{
			coefA = 2.0;
			coefB = 2.0;
			margin = 0.0;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
