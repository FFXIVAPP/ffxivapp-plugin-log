// FFXIVAPP.Plugin.Log ~ TabItemHelper.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
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

using System.Text.RegularExpressions;
using System.Windows.Controls;
using FFXIVAPP.Common.Controls;
using FFXIVAPP.Common.Helpers;
using FFXIVAPP.Plugin.Log.Properties;

namespace FFXIVAPP.Plugin.Log.Helpers
{
    public static class TabItemHelper
    {
        /// <summary>
        /// </summary>
        public static void AddTabByName(string xKey, string xValue, string xRegularExpression)
        {
            xKey = Regex.Replace(xKey, "[^a-zA-Z]", "");
            var tabItem = new TabItem
            {
                Header = xKey
            };
            var flowDoc = new xFlowDocument();
            foreach (var code in xValue.Split(','))
            {
                flowDoc.Codes.Items.Add(code);
            }
            flowDoc.RegEx.Text = xRegularExpression;
            var binding = BindingHelper.ZoomBinding(Settings.Default, "Zoom");
            flowDoc._FDR.SetBinding(FlowDocumentReader.ZoomProperty, binding);
            tabItem.Content = flowDoc;
            PluginViewModel.Instance.Tabs.Add(tabItem);
            ThemeHelper.SetupFont(ref flowDoc);
            ThemeHelper.SetupColor(ref flowDoc);
        }
    }
}
