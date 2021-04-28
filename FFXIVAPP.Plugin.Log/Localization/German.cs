// --------------------------------------------------------------------------------------------------------------------
// <copyright file="German.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   German.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Localization {
    using System.Windows;

    public abstract class German {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "Tab hinzufügen");
            Dictionary.Add("log_AllTabHeader", "Alle");
            Dictionary.Add("log_DebugTabHeader", "Debug");
            Dictionary.Add("log_DebugOptionsHeader", "Debug Einstellungen");
            Dictionary.Add("log_EnableDebugHeader", "Debug Aktivieren");
            Dictionary.Add("log_EnableTranslateHeader", "Übersetzen Aktivieren");
            Dictionary.Add("log_RegExLabel", "RegEx:");
            Dictionary.Add("log_UseRomanizationHeader", "Romanisierung benutzen");
            Dictionary.Add("log_ShowASCIIDebugHeader", "Ascii Debug zeigen");
            Dictionary.Add("log_TabNameLabel", "Tab Name");
            Dictionary.Add("log_TranslateLSHeader", "LS übersetzen");
            Dictionary.Add("log_TranslateFCHeader", "FC übersetzen");
            Dictionary.Add("log_TranslatePartyHeader", "Party übersetzen");
            Dictionary.Add("log_TranslateableChatTabHeader", "Chat übersetzen");
            Dictionary.Add("log_TranslatedTabHeader", "übersetzen");
            Dictionary.Add("log_TranslateJPOnlyHeader", "Nur JP übersetzen");
            Dictionary.Add("log_TranslateSettingsTabHeader", "übersetzen einstellungen");
            Dictionary.Add("log_TranslateToHeader", "übersetzen");
            Dictionary.Add("log_TranslationProviderHeader", "Translation Provider");
            Dictionary.Add("log_CognitiveServiceKeyHeader", "Cognitive Service Key");
            Dictionary.Add("log_CognitiveServiceRegionHeader", "Cognitive Service Region");
            Dictionary.Add("log_TranslateNoviceHeader", "Novice");
            Dictionary.Add("log_TranslateSayHeader", "Say übersetzen");
            Dictionary.Add("log_TranslateShoutHeader", "Shout übersetzen");
            Dictionary.Add("log_TranslateTellHeader", "Tell übersetzen");
            Dictionary.Add("log_TranslateYellHeader", "Yell übersetzen");
            Dictionary.Add("log_EnableAllHeader", "Enable All");
            Dictionary.Add("log_TranslateAllianceHeader", "Alliance");
            Dictionary.Add("log_GitHubButtonText", "Open Project Source (GitHub)");

            Dictionary.Add("log_OpenNowButtonText", "Open Now");
            Dictionary.Add("log_ResetPositionButtonText", "Reset Settings");
            Dictionary.Add("log_TranslationTitleBar", "[TRANSLATION]");
            Dictionary.Add("log_TranslationWidgetHeader", "Translation Widget");
            Dictionary.Add("log_EnableClickThroughHeader", "Enable Click-Through On Widgets");
            Dictionary.Add("log_WidgetOpacityHeader", "Widget Opacity");
            Dictionary.Add("log_ShowTitlesOnWidgetsHeader", "Show Titles On Widgets");
            Dictionary.Add("log_UIScaleHeader", "UI Scale");
            Dictionary.Add("log_WidgetSettingsTabHeader", "Widget Settings");
            Dictionary.Add("log_TranslationWidgetSettingsTabLabel", "SETTINGS:TRANSLATION");
            return Dictionary;
        }
    }
}