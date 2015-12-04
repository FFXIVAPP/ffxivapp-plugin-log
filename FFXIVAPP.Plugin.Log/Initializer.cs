// FFXIVAPP.Plugin.Log ~ Initializer.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Xml.Linq;
using FFXIVAPP.Common.Controls;
using FFXIVAPP.Plugin.Log.Helpers;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Views;

namespace FFXIVAPP.Plugin.Log
{
    internal static class Initializer
    {
        /// <summary>
        /// </summary>
        public static void LoadSettings()
        {
            if (Constants.XSettings != null)
            {
                Settings.Default.Reset();
                foreach (var xElement in Constants.XSettings.Descendants()
                                                  .Elements("Setting"))
                {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    if (String.IsNullOrWhiteSpace(xKey) || String.IsNullOrWhiteSpace(xValue))
                    {
                        return;
                    }
                    if (Constants.Settings.Contains(xKey))
                    {
                        Settings.Default.SetValue(xKey, xValue, CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        Constants.Settings.Add(xKey);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public static void LoadTabs()
        {
            if (Constants.XSettings != null)
            {
                foreach (var xElement in Constants.XSettings.Descendants()
                                                  .Elements("Tab"))
                {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    var xRegularExpression = (string) xElement.Element("RegularExpression");
                    if (String.IsNullOrWhiteSpace(xKey) || String.IsNullOrWhiteSpace(xValue))
                    {
                        continue;
                    }
                    xRegularExpression = String.IsNullOrWhiteSpace(xRegularExpression) ? "*" : xRegularExpression;
                    TabItemHelper.AddTabByName(xKey, xValue, xRegularExpression);
                }
            }
        }

        /// <summary>
        /// </summary>
        public static void ApplyTheming()
        {
            ThemeHelper.SetupFont(ref MainView.View.AllFD);
            ThemeHelper.SetupFont(ref MainView.View.TranslatedFD);
            ThemeHelper.SetupFont(ref MainView.View.DebugFD);
            ThemeHelper.SetupColor(ref MainView.View.AllFD);
            ThemeHelper.SetupColor(ref MainView.View.TranslatedFD);
            ThemeHelper.SetupColor(ref MainView.View.DebugFD);
            foreach (TabItem s in PluginViewModel.Instance.Tabs)
            {
                var flowDocument = (xFlowDocument) s.Content;
                ThemeHelper.SetupFont(ref flowDocument);
                ThemeHelper.SetupColor(ref flowDocument);
            }
        }

        #region Declarations

        #endregion
    }
}
