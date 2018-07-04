// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   MainViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.ViewModels {
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows.Input;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.RegularExpressions;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.Common.ViewModelBase;
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Utilities;
    using FFXIVAPP.Plugin.Log.Views;

    internal sealed class MainViewModel : INotifyPropertyChanged {
        public static readonly Regex TranalateIsValid = new Regex(@"^/\w( \w+ \w+)?$", SharedRegEx.DefaultOptions);

        private static Lazy<MainViewModel> _instance = new Lazy<MainViewModel>(() => new MainViewModel());

        public MainViewModel() {
            this.DeleteTabCommand = new DelegateCommand(DeleteTab);
            this.ManualTranslateCommand = new DelegateCommand<string>(ManualTranslate);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static MainViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public ICommand DeleteTabCommand { get; private set; }

        public ICommand ManualTranslateCommand { get; private set; }

        /// <summary>
        /// </summary>
        private static void DeleteTab() {
            if (MainView.View.MainViewTC.SelectedIndex < 3) {
                return;
            }

            var selection = Settings.Default.EnableDebug
                                ? 2
                                : 1;
            PluginViewModel.Instance.Tabs.RemoveAt(MainView.View.MainViewTC.SelectedIndex - 3);
            if (PluginViewModel.Instance.Tabs.Any()) {
                return;
            }

            MainView.View.MainViewTC.SelectedIndex = selection;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        private static void ManualTranslate(string value) {
            value = value.Trim();
            var outLang = GoogleTranslate.Offsets[Settings.Default.ManualTranslate].ToString();
            if (value.Length <= 0) {
                return;
            }

            GoogleTranslateResult tmpTranString = Translate.GetManualResult(value, outLang, false);
            MainView.View.Chatter.Text = Settings.Default.UseRomanization
                                             ? tmpTranString.Romanization
                                             : tmpTranString.Translated;
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}