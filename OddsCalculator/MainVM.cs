using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using OddsCalculator.Models;

namespace OddsCalculator
{
	public class MainVM : INotifyPropertyChanged
	{
		public const string oddsMode = "OddsCalculataion";
		public const string marginMode = "MarginCalculataion";

		private TwoLegsModel twoLegsOdds;
		private ThreeLegsModel threeLegsOdds;

		private TwoLegsModel twoLegsMargin;

		public TwoLegsModel TwoLegsOdds
		{
			get
			{
				return twoLegsOdds;
			}

			set
			{
				twoLegsOdds = value;
				OnPropertyChanged("TwoLegsOdds");
			}
		}

		public ThreeLegsModel ThreeLegsOdds
		{
			get
			{
				return threeLegsOdds;
			}

			set
			{
				threeLegsOdds = value;
				OnPropertyChanged("ThreeLegsOdds");
			}
		}

		public TwoLegsModel TwoLegsMargin
		{
			get
			{
				return twoLegsMargin;
			}

			set
			{
				twoLegsMargin = value;
				OnPropertyChanged("TwoLegsMargin");
			}
		}

		public MainVM()
		{
			twoLegsOdds = new TwoLegsModel(oddsMode);
			twoLegsMargin = new TwoLegsModel(marginMode);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
