using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OddsCalculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			MainVM vm = new MainVM();
			DataContext = vm;

			SetWindowCommands(vm);
		}

		private void SetWindowCommands(MainVM vm)
		{
			if (vm.CloseAction == null)
				vm.CloseAction = new Action(() => this.Close());

			if (vm.MaximizeAction == null)
				vm.MaximizeAction = new Action(() =>
				{
					if (this.WindowState == WindowState.Maximized)
						this.WindowState = WindowState.Normal;
					else if (this.WindowState == WindowState.Normal)
						this.WindowState = WindowState.Maximized;
				});

			if (vm.MinimizeAction == null)
				vm.MinimizeAction = new Action(() => this.WindowState = WindowState.Minimized);

			if (vm.DragAction == null)
				vm.DragAction = new Action(() => this.DragMove());
		}
	}
}
