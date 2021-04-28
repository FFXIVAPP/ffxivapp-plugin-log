// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SettingsViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.ViewModels {
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using FFXIVAPP.Common.ViewModelBase;
    using FFXIVAPP.Plugin.Log.Helpers;
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Views;

    internal sealed class SettingsViewModel : INotifyPropertyChanged {
        private static Lazy<SettingsViewModel> _instance = new Lazy<SettingsViewModel>(() => new SettingsViewModel());

        public SettingsViewModel() {
            this.AddTabCommand = new DelegateCommand(AddTab);
            this.ResetTranslationWidgetCommand = new DelegateCommand(this.ResetTranslationWidget);
            this.OpenTranslationWidgetCommand = new DelegateCommand(this.OpenTranslationWidget);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static SettingsViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public ICommand AddTabCommand { get; private set; }

        public ICommand OpenTranslationWidgetCommand { get; private set; }

        public ICommand ResetTranslationWidgetCommand { get; private set; }

        public void OpenTranslationWidget() {
            Settings.Default.ShowTranslationWidgetOnLoad = true;
            Widgets.Instance.ShowTranslationWidget();
        }

        public void ResetTranslationWidget() {
            Settings.Default.TranslationWidgetUIScale = Settings.Default.Properties["TranslationWidgetUIScale"].DefaultValue.ToString();
            Settings.Default.TranslationWidgetTop = int.Parse(Settings.Default.Properties["TranslationWidgetTop"].DefaultValue.ToString());
            Settings.Default.TranslationWidgetLeft = int.Parse(Settings.Default.Properties["TranslationWidgetLeft"].DefaultValue.ToString());
            Settings.Default.TranslationWidgetHeight = int.Parse(Settings.Default.Properties["TranslationWidgetHeight"].DefaultValue.ToString());
            Settings.Default.TranslationWidgetWidth = int.Parse(Settings.Default.Properties["TranslationWidgetWidth"].DefaultValue.ToString());
        }

        /// <summary>
        /// </summary>
        private static void AddTab() {
            var xKey = SettingsView.View.TName.Text;
            string xValue;
            var xRegularExpression = SettingsView.View.TRegEx.Text;
            if (SettingsView.View.Codes.SelectedItems.Count < 1) {
                xValue = string.Empty;
            }
            else {
                xValue = SettingsView.View.Codes.SelectedItems.Cast<object>().Aggregate(string.Empty, (current, item) => current + item.ToString().Split(',')[0] + ",").Replace("[", string.Empty);
                xValue = xValue.Substring(0, xValue.Length - 1);
            }

            if (xKey == string.Empty || xValue == string.Empty || xRegularExpression == string.Empty) { }
            else {
                TabItemHelper.AddTabByName(xKey, xValue, xRegularExpression);
                SettingsView.View.TName.Text = string.Empty;
                SettingsView.View.Codes.UnselectAll();
                MainView.View.MainViewTC.SelectedIndex = MainView.View.MainViewTC.Items.Count - 1;
                ShellView.View.ShellViewTC.SelectedIndex = 0;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}