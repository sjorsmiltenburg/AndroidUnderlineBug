using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnderlineAndroid.Views
{
    public partial class AboutPage : ContentPage
    {
        string sourceText = string.Empty;

        public AboutPage()
        {
            InitializeComponent();

            var sb = new StringBuilder();
            string x = "This is the first line which is quite long and it will break automatically showing that underlining a 'forced' linebreak works ok on android.";
            var y = x.Length;

            sb.AppendLine(x);
            sb.AppendLine("this is a short line.");
            sb.AppendLine("Another short line.");
            sb.AppendLine("This is the third line which is also quite long and it will break automatically showing that underlining a 'forced' linebreak works ok on android.");
            sourceText = sb.ToString();
        }

        private void Button_normal_Clicked(object sender, EventArgs e)
        {
            UnderlineSection(-1, -1);
        }

        private void Button_underlined_Clicked(object sender, EventArgs e)
        {
            UnderlineSection(10, 20); //no visual problem
        }

        private void Button_underlined_problem1_Clicked(object sender, EventArgs e)
        {
            UnderlineSection(142, 156);
        }

        private void Button_underlined_problem2_Clicked(object sender, EventArgs e)
        {
            UnderlineSection(142, 162);
        }

        private void Button_underlined_problem_Animated_Clicked(object sender, EventArgs e)
        {
            new Task(async () =>
            {
                var mySwitch = true;
                int startCharIndex = 0;
                int endCharIndex = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (mySwitch)
                    {
                        startCharIndex = 142;
                        endCharIndex = startCharIndex + 2;
                    }
                    else
                    {
                        startCharIndex = 142;
                        endCharIndex = startCharIndex + 20;
                    }
                    mySwitch = !mySwitch;

                    UnderlineSection(startCharIndex, endCharIndex);
                    await Task.Delay(500);
                }
            }).RunSynchronously();
        }


        private void UnderlineSection(int startCharIndex, int endCharIndex)
        {
            Debug.WriteLine($"Underlining characters from {startCharIndex} to {endCharIndex}");
            var fs = new FormattedString();
            if (startCharIndex < 0 || endCharIndex < 0)
            {
                fs.Spans.Add(new Span() { Text = sourceText });
            }
            else
            {
                var startSegment = sourceText.Substring(0, startCharIndex);
                fs.Spans.Add(new Span() { Text = startSegment });

                var activeSegment = sourceText.Substring(startCharIndex, endCharIndex - startCharIndex);
                fs.Spans.Add(new Span() { Text = activeSegment, TextDecorations = TextDecorations.Underline });

                var endSegment = sourceText.Substring(endCharIndex);
                fs.Spans.Add(new Span() { Text = endSegment });

            }
            MyTestLabel.FormattedText = fs;

        }
    }
}