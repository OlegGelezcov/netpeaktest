using Autofac;
using HtmlWpfParser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HtmlWpfParser {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            RegisterServices();

            lstViewResults.ItemsSource = Results;
        }

        private int processedCount = 0;


        private static IContainer Container { get; set; }

        public ObservableCollection<UrlResultData> Results { get; private set; } = new ObservableCollection<UrlResultData>();

        private void RegisterServices() {
            var builder = new ContainerBuilder();
            builder.RegisterType<UrlContentReader>().As<IUrlContentReader>();
            builder.RegisterType<HtmlParser>().As<IHtmlParser>();
            Container = builder.Build();
        }

        private void btnParseUrl_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrEmpty(textBoxUrl.Text.Trim())) {
                string url = textBoxUrl.Text;

                ThreadPool.QueueUserWorkItem(ParseProc, url);
            } else {
                MessageBox.Show("Enter non empty url");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            UrlResultData resultData = (e.OriginalSource as Button).Tag as UrlResultData;
            DetailWindow detailWindow = new DetailWindow() {
                DataContext = resultData
            };
            detailWindow.Show();
        }

        private void ParseProc(object state) {
            IncrementProcess();
            using (var scope = Container.BeginLifetimeScope()) {
                var urlReader = scope.Resolve<IUrlContentReader>();
                var parser = scope.Resolve<IHtmlParser>();
                try {
                    var responseData = urlReader.Read((string)state);
                    var resultData = parser.Parse(responseData.Html);
                    resultData.ResponseData = responseData;
                    resultData.Url = (string)state;
                    Dispatcher.InvokeAsync(() => {
                        Results.Add(resultData);
                        DecrementProcess();
                    });
                } catch(System.Exception exception) {
                    DecrementProcess();
                    Dispatcher.InvokeAsync(() => {
                        MessageBox.Show(exception.Message);
                    });
                }
            }

        }

        private void IncrementProcess() {
            Interlocked.Increment(ref processedCount);
            UpdateProcessText();
        }

        private void DecrementProcess() {
            Interlocked.Decrement(ref processedCount);
            UpdateProcessText();
        }

        private void UpdateProcessText() {
            Dispatcher.Invoke(() => {
                Title = $"Processing {processedCount} urls";
            });
        }
    }
}
