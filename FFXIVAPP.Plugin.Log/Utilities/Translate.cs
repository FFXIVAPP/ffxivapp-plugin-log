// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Translate.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Translate.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Utilities {
    using System;

    using FFXIVAPP.Common;
    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Views;
    using FFXIVAPP.Plugin.Log.Windows;

    using NLog;

    internal static class Translate {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <param name="resultOnly"></param>
        public static GoogleTranslateResult GetAutomaticResult(string line, bool isJP, bool resultOnly = false) {
            Logging.Log(Logger, "Begin Translation");
            var timeStampColor = Settings.Default.TimeStampColor.ToString();
            var player = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal)) + ": ";
            var message = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1);

            Logging.Log(Logger, $"Player [{player}] said [{message}]");

            GoogleTranslateResult result = ResolveGoogleTranslateResult(message, isJP);

            Logging.Log(Logger, $"Translation Result: {result?.Translated}");
            Logging.Log(Logger, $"Translation Result: {result?.Romanization}");

            if (result != null) {
                if (result.Translated.Length <= 0 || string.Equals(line, result.Translated, StringComparison.InvariantCultureIgnoreCase)) {
                    return new GoogleTranslateResult {
                        Original = line
                    };
                }
            }

            if (!resultOnly && result != null) {
                Constants.FD.AppendFlow(
                    player,
                    string.Empty,
                    result.Translated,
                    new[] {
                        timeStampColor,
                        "#EAFF00"
                    },
                    MainView.View.TranslatedFD._FDR);
                if (TranslationWidget.View.IsVisible) {
                    Constants.FD.AppendFlow(
                        player,
                        string.Empty,
                        result.Translated,
                        new[] {
                            timeStampColor,
                            "#EAFF00"
                        },
                        TranslationWidget.View.TranslatedFD._FDR);
                }
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="outLang"></param>
        /// <param name="isJP"></param>
        /// <returns></returns>
        public static GoogleTranslateResult GetManualResult(string line, string outLang, bool isJP) {
            return GoogleTranslate.Translate(line, "en", outLang, isJP);
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <returns></returns>
        private static GoogleTranslateResult ResolveGoogleTranslateResult(string line, bool isJP) {
            GoogleTranslateResult result = null;
            var outLang = GoogleTranslate.Offsets[Settings.Default.TranslateTo].ToString();
            if (Settings.Default.TranslateJPOnly) {
                if (isJP) {
                    result = GoogleTranslate.Translate(line, "ja", outLang, true);
                }
            }
            else {
                result = GoogleTranslate.Translate(
                    line,
                    isJP
                        ? "ja"
                        : "en",
                    outLang,
                    true);
            }

            return result;
        }
    }
}