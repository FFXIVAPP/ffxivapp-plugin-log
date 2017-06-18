// FFXIVAPP.Plugin.Log ~ German.cs
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
    public abstract class German
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
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
            Dictionary.Add("log_TranslateSayHeader", "Say übersetzen");
            Dictionary.Add("log_TranslateShoutHeader", "Shout übersetzen");
            Dictionary.Add("log_TranslateTellHeader", "Tell übersetzen");
            Dictionary.Add("log_TranslateYellHeader", "Yell übersetzen");
            Dictionary.Add("log_EnableAllHeader", "Enable All");
            Dictionary.Add("log_TranslateAllianceHeader", "Alliance");
            Dictionary.Add("log_GitHubButtonText", "Open Project Source (GitHub)");
            return Dictionary;
        }
    }
}
