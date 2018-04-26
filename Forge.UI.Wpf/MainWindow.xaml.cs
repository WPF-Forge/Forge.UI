using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Forge.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var useParser = Program.UseParser(new WpfParser(),
                "C:\\Users\\Marcos\\source\\repos\\Forge.UI\\Forge.UI\\ModelExample.json");
            if (useParser is IEnumerable enumerable)
            {
                foreach (var uiElement in enumerable.Cast<UIElement>())
                {
                    Testing.Children.Add(uiElement);
                }
            }
        }
    }
}