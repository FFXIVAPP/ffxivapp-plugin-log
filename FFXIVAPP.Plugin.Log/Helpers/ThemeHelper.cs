// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ThemeHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Helpers {
    using System.Drawing;
    using System.Windows;
    using System.Windows.Media;

    using FFXIVAPP.Common.Controls;
    using FFXIVAPP.Plugin.Log.Properties;

    using FontFamily = System.Windows.Media.FontFamily;

    internal static class ThemeHelper {
        public static void SetupColor(ref xFlowDocument flowDoc) {
            flowDoc._FD.Background = new SolidColorBrush(Settings.Default.ChatBackgroundColor);
        }

        public static void SetupFont(ref xFlowDocument flowDoc) {
            Font font = Settings.Default.ChatFont;
            flowDoc._FD.FontFamily = new FontFamily(font.Name);
            flowDoc._FD.FontWeight = font.Bold
                                         ? FontWeights.Bold
                                         : FontWeights.Regular;
            flowDoc._FD.FontStyle = font.Italic
                                        ? FontStyles.Italic
                                        : FontStyles.Normal;
            flowDoc._FD.FontSize = font.Size;
        }
    }
}