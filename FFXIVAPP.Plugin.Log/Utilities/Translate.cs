// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Translate.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Translate.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Utilities {
    using System;

    using FFXIVAPP.Common.Translation;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Views;
    using FFXIVAPP.Plugin.Log.Windows;

    using NLog;

    using Constants = FFXIVAPP.Common.Constants;

    internal static class Translate {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static GoogleTranslateProvider _googleTranslateProvider;

        private static CognitiveTranslateProvider _cognitiveTranslateProvider;

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <param name="resultOnly"></param>
        public static TranslationResult GetAutomaticResult(string line, bool isJP, bool resultOnly = false, string color = "#EAFF00") {
            Logging.Log(Logger, "Begin Translation");
            var timeStampColor = Settings.Default.TimeStampColor.ToString();
            var player = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal)) + ": ";
            var message = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1);

            Logging.Log(Logger, $"Player [{player}] said [{message}]");

            TranslationResult result = TranslateText(message, isJP);

            Logging.Log(Logger, $"Translation Result: {result?.Translated}");
            Logging.Log(Logger, $"Translation Result: {result?.Romanization}");

            if (result != null) {
                if (result.Translated.Length <= 0 || string.Equals(line, result.Translated, StringComparison.InvariantCultureIgnoreCase)) {
                    return new TranslationResult {
                        Original = line,
                    };
                }
            }

            if (!resultOnly && result != null) {
                Constants.FD.AppendFlow(
                    player, string.Empty, result.Translated, new[] {
                        timeStampColor,
                        color,
                    }, MainView.View.TranslatedFD._FDR);
                if (TranslationWidget.View.IsVisible) {
                    Constants.FD.AppendFlow(
                        player, string.Empty, result.Translated, new[] {
                            timeStampColor,
                            color,
                        }, TranslationWidget.View.TranslatedFD._FDR);
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
        public static TranslationResult GetManualResult(string line, string outLang, bool isJP) {
            return GetTranslationProvider().TranslateText(line, "en", outLang, isJP);
        }

        private static ITranslationProvider GetTranslationProvider() {
            switch (Settings.Default.TranslationProvider) {
                case "Google":
                    return _googleTranslateProvider ??= new GoogleTranslateProvider(Settings.Default.GoogleServiceKey);
                case "Cognitive":
                    return _cognitiveTranslateProvider ??= new CognitiveTranslateProvider(Settings.Default.CognitiveServiceKey, Settings.Default.CognitiveServiceRegion);
            }
            throw new NotImplementedException($"{Settings.Default.TranslationProvider} is not a valid translation provider");
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <returns></returns>
        private static TranslationResult TranslateText(string line, bool isJP) {
            TranslationResult result = null;
            var toLanguage = Common.Translation.Constants.LanguageMap[Settings.Default.TranslateTo].ToString();
            if (Settings.Default.TranslateJPOnly) {
                if (isJP) {
                    result = GetTranslationProvider().TranslateText(line, "ja", toLanguage, true);
                }
            }
            else {
                result = GetTranslationProvider().TranslateText(
                    line, isJP
                              ? "ja"
                              : "en", toLanguage, true);
            }

            return result;
        }
    }
}