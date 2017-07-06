// FFXIVAPP.Plugin.Log ~ French.cs
// 
// Copyright © 2007 - 2017 Ryan Wilson - All Rights Reserved
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

using System.Windows;

namespace FFXIVAPP.Plugin.Log.Localization
{
    public abstract class French
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
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
