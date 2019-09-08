using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace LettertypeChaos
{
    public partial class MainWindow : Window
    {
        private Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Button_ScrambleFonts_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox_Output.Document.Blocks.Clear();

            foreach (var inblock in RichTextBox_Input.Document.Blocks)
            {
                var start = inblock.ContentStart;
                var end = inblock.ContentEnd;
                var text = new TextRange(start, end).Text;

                var outblock = new Paragraph();
                outblock.Margin = new Thickness(0);

                foreach (var c in text)
                {
                    var run = new Run(c.ToString());

                    // Choose a size for the font between 24 and 32
                    run.FontSize = random.NextDouble() * 8 + 24;

                    // Make one third of the characters italic
                    run.FontStyle = random.NextDouble() > 0.333 ? FontStyles.Normal : FontStyles.Italic;

                    // Choose one of the four font weights
                    run.FontWeight = weights[(int)(random.NextDouble() * weights.Length)];

                    // Choose one of the eight colors
                    run.Foreground = colors[(int)(random.NextDouble() * colors.Length)];

                    // Choose one of the ten fonts
                    var font = fonts[(int)(random.NextDouble() * fonts.Length)];
                    run.FontFamily = new FontFamily(font);

                    outblock.Inlines.Add(run);
                }

                RichTextBox_Output.Document.Blocks.Add(outblock);
            }
        }

        private static FontWeight[] weights =
        {
            FontWeights.Normal,
            FontWeights.SemiBold,
            FontWeights.Bold,
            FontWeights.UltraBold,
        };

        private static Brush[] colors =
        {
            Brushes.Black,
            Brushes.Red,
            Brushes.Green,
            Brushes.Blue,
            Brushes.DarkGray,
            Brushes.Crimson,
            Brushes.Gold,
            Brushes.Aquamarine,
        };

        // Array of some random fonts
        private static string[] fonts =
        {
            "Arial Black",
            "Comic Sans MS",
            "Courier New",
            "Franklin Gothic",
            "Georgia",
            "Impact",
            "MS Gothic",
            "Times New Roman",
            "Trebuchet MS",
            "Verdana",
        };
    }
}
