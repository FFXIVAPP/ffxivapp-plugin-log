// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabItemHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   TabItemHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Helpers {
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using System.Windows.Data;

    using FFXIVAPP.Common.Controls;
    using FFXIVAPP.Common.Helpers;
    using FFXIVAPP.Plugin.Log.Properties;

    public static class TabItemHelper {
        /// <summary>
        /// </summary>
        public static void AddTabByName(string xKey, string xValue, string xRegularExpression) {
            xKey = Regex.Replace(xKey, "[^a-zA-Z]", string.Empty);
            var tabItem = new TabItem {
                Header = xKey
            };
            var flowDoc = new xFlowDocument();
            foreach (var code in xValue.Split(',')) {
                flowDoc.Codes.Items.Add(code);
            }

            flowDoc.RegEx.Text = xRegularExpression;
            Binding binding = BindingHelper.ZoomBinding(Settings.Default, "Zoom");
            flowDoc._FDR.SetBinding(FlowDocumentReader.ZoomProperty, binding);
            tabItem.Content = flowDoc;
            PluginViewModel.Instance.Tabs.Add(tabItem);
            ThemeHelper.SetupFont(ref flowDoc);
            ThemeHelper.SetupColor(ref flowDoc);
        }
    }
}