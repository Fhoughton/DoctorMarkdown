using FSharp.Markdown;
using FSharp.Markdown.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace DocuMd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string previewPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"preview.pdf");

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                PdfPreview.OpenFile(previewPath);

                System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                TextEntry.TextChanged += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 120);
                dispatcherTimer.Start();
            }
            catch 
            {
            
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // formatting to PDF and save result to file
            MarkdownPdf.Transform(TextEntry.Text, previewPath);
            PdfPreview.OpenFile(previewPath);
        }
    }
}
