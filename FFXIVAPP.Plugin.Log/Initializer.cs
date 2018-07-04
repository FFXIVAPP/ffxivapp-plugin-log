// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Initializer.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Initializer.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log {
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Xml.Linq;

    using FFXIVAPP.Common.Controls;
    using FFXIVAPP.Plugin.Log.Helpers;
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Views;
    using FFXIVAPP.Plugin.Log.Windows;

    internal static class Initializer {
        /// <summary>
        /// </summary>
        public static void ApplyTheming() {
            ThemeHelper.SetupFont(ref MainView.View.AllFD);
            ThemeHelper.SetupFont(ref MainView.View.TranslatedFD);
            ThemeHelper.SetupFont(ref MainView.View.DebugFD);
            ThemeHelper.SetupColor(ref MainView.View.AllFD);
            ThemeHelper.SetupColor(ref MainView.View.TranslatedFD);
            ThemeHelper.SetupColor(ref MainView.View.DebugFD);
            ThemeHelper.SetupFont(ref TranslationWidget.View.TranslatedFD);
            ThemeHelper.SetupFont(ref TranslationWidget.View.TranslatedFD);
            foreach (UIElement item in PluginViewModel.Instance.Tabs) {
                var tab = (TabItem) item;
                var flowDocument = (xFlowDocument) tab.Content;
                ThemeHelper.SetupFont(ref flowDocument);
                ThemeHelper.SetupColor(ref flowDocument);
            }
        }

        /// <summary>
        /// </summary>
        public static void LoadSettings() {
            if (Constants.XSettings != null) {
                Settings.Default.Reset();
                foreach (XElement xElement in Constants.XSettings.Descendants().Elements("Setting")) {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    if (string.IsNullOrWhiteSpace(xKey) || string.IsNullOrWhiteSpace(xValue)) {
                        return;
                    }

                    if (Constants.Settings.Contains(xKey)) {
                        Settings.Default.SetValue(xKey, xValue, CultureInfo.InvariantCulture);
                    }
                    else {
                        Constants.Settings.Add(xKey);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public static void LoadTabs() {
            if (Constants.XSettings != null) {
                foreach (XElement xElement in Constants.XSettings.Descendants().Elements("Tab")) {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    var xRegularExpression = (string) xElement.Element("RegularExpression");
                    if (string.IsNullOrWhiteSpace(xKey) || string.IsNullOrWhiteSpace(xValue)) {
                        continue;
                    }

                    xRegularExpression = string.IsNullOrWhiteSpace(xRegularExpression)
                                             ? "*"
                                             : xRegularExpression;
                    TabItemHelper.AddTabByName(xKey, xValue, xRegularExpression);
                }
            }
        }

        public static void SetupWidgetTopMost() {
            WidgetTopMostHelper.HookWidgetTopMost();
        }
    }
}