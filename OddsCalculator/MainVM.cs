using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
		private ThreeLegsModel threeLegsMargin;



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

		public ThreeLegsModel ThreeLegsMargin
		{
			get
			{
				return threeLegsMargin;
			}

			set
			{
				threeLegsMargin = value;
				OnPropertyChanged("ThreeLegsMargin");
			}
		}



		public MainVM()
		{
			twoLegsOdds = new TwoLegsModel(oddsMode);
			twoLegsMargin = new TwoLegsModel(marginMode);

			threeLegsOdds = new ThreeLegsModel(oddsMode);
			threeLegsMargin = new ThreeLegsModel(marginMode);
		}

		#region Commands
		private RelayCommand closeCommand;
		public RelayCommand CloseCommand
		{
			get
			{
				return closeCommand ??
					(closeCommand = new RelayCommand(param => Close()));
			}
		}

		public Action CloseAction { get; set; }

		private void Close()
		{
			CloseAction();
		}


		private RelayCommand mazimizeCommand;
		public RelayCommand MaximizeCommand
		{
			get
			{
				return mazimizeCommand ??
					(mazimizeCommand = new RelayCommand(param => Maximize()));
			}
		}

		public Action MaximizeAction { get; set; }

		private void Maximize()
		{
			MaximizeAction();
		}

		private RelayCommand minimizeCommand;
		public RelayCommand MinimizeCommand
		{
			get
			{
				return minimizeCommand ??
					(minimizeCommand = new RelayCommand(param => Minimize()));
			}
		}

		public Action MinimizeAction { get; set; }

		private void Minimize()
		{
			MinimizeAction();
		}

		private RelayCommand dragCommand;
		public RelayCommand DragCommand
		{
			get
			{
				return dragCommand ??
					(dragCommand = new RelayCommand(param => Drag()));
			}
		}

		public Action DragAction { get; set; }

		private void Drag()
		{
			DragAction();
		}

		private RelayCommand switchThemeCommand;
		public RelayCommand SwitchThemeCommand
		{
			get
			{
				return switchThemeCommand ?? (switchThemeCommand = new RelayCommand(obj =>
				{
					string style = "Styles2";
					Uri uri = new Uri("Themes/" + style + ".xaml", UriKind.Relative);
					ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;

					Application.Current.Resources.MergedDictionaries.Clear();
					Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
				}));
			}
		}
		#endregion

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
