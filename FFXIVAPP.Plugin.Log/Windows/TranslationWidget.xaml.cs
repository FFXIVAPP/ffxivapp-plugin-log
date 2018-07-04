// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TranslationWidget.xaml.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   TranslationWidget.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Windows {
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using FFXIVAPP.Plugin.Log.Interop;
    using FFXIVAPP.Plugin.Log.Properties;

    /// <summary>
    ///     Interaction logic for TranslationWidget.xaml
    /// </summary>
    public partial class TranslationWidget {
        public static TranslationWidget View;

        public TranslationWidget() {
            View = this;
            this.InitializeComponent();
            View.SourceInitialized += delegate {
                WinAPI.ToggleClickThrough(this);
            };
        }

        private void TitleBar_OnPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }

        private void TranslationWidget_OnClosing(object sender, CancelEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

        private void TranslationWidgetClose_OnClick(object sender, RoutedEventArgs e) {
            Settings.Default.ShowTranslationWidgetOnLoad = false;
            this.Close();
        }
    }
}