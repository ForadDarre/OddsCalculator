#region namespaces
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using OddsCalculator.Models;
#endregion

namespace OddsCalculator
{
	public class MainVM : INotifyPropertyChanged
	{
		#region constants
		// constants to switch the calculation mode properly
		public const string OddsMode = "OddsCalculataion";
		public const string MarginMode = "MarginCalculataion";

		// themes names
		public const string DarkTheme = "DarkTheme";
		public const string LightTheme = "LightTheme";
		#endregion

		#region variables
		private TwoLegsModel twoLegsOdds;
		private ThreeLegsModel threeLegsOdds;

		private TwoLegsModel twoLegsMargin;
		private ThreeLegsModel threeLegsMargin;

		private string currentTheme;

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
		#endregion

		public MainVM()
		{
			twoLegsOdds = new TwoLegsModel(OddsMode);
			twoLegsMargin = new TwoLegsModel(MarginMode);

			threeLegsOdds = new ThreeLegsModel(OddsMode);
			threeLegsMargin = new ThreeLegsModel(MarginMode);

			currentTheme = DarkTheme;
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
					if (currentTheme == DarkTheme)
					{
						currentTheme = LightTheme;
					}

					else
					{
						currentTheme = DarkTheme;
					}

					Uri uri = new Uri("Themes/" + currentTheme + ".xaml", UriKind.Relative);
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
