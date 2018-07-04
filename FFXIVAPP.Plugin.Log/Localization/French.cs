// --------------------------------------------------------------------------------------------------------------------
// <copyright file="French.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   French.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Localization {
    using System.Windows;

    public abstract class French {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "Ajouter onglet");
            Dictionary.Add("log_AllTabHeader", "Tout");
            Dictionary.Add("log_DebugTabHeader", "Debug");
            Dictionary.Add("log_DebugOptionsHeader", "Options de Debug");
            Dictionary.Add("log_EnableDebugHeader", "Activer Debug");
            Dictionary.Add("log_EnableTranslateHeader", "Activer Traduction");
            Dictionary.Add("log_RegExLabel", "RegEx:");
            Dictionary.Add("log_UseRomanizationHeader", "Envoyer Romanisation");
            Dictionary.Add("log_ShowASCIIDebugHeader", "Afficher Debug ASCII");
            Dictionary.Add("log_TabNameLabel", "Nom de l'onglet:");
            Dictionary.Add("log_TranslateLSHeader", "LS");
            Dictionary.Add("log_TranslateFCHeader", "CL");
            Dictionary.Add("log_TranslatePartyHeader", "Equipe");
            Dictionary.Add("log_TranslateableChatTabHeader", "Chat traduisible");
            Dictionary.Add("log_TranslatedTabHeader", "Traduit");
            Dictionary.Add("log_TranslateJPOnlyHeader", "Traduire exclusivement le JP");
            Dictionary.Add("log_TranslateSettingsTabHeader", "Paramètres de traduction");
            Dictionary.Add("log_TranslateToHeader", "Traduire en");
            Dictionary.Add("log_TranslateSayHeader", "Dire");
            Dictionary.Add("log_TranslateShoutHeader", "Crier");
            Dictionary.Add("log_TranslateTellHeader", "Murmurer");
            Dictionary.Add("log_TranslateYellHeader", "Hurler");
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