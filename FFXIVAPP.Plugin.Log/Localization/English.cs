// FFXIVAPP.Plugin.Log ~ English.cs
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

using System.Windows;

namespace FFXIVAPP.Plugin.Log.Localization
{
    public abstract class English
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "Add Tab");
            Dictionary.Add("log_AllTabHeader", "All");
            Dictionary.Add("log_DebugTabHeader", "Debug");
            Dictionary.Add("log_DebugOptionsHeader", "Debug Options");
            Dictionary.Add("log_EnableDebugHeader", "Enable Debug");
            Dictionary.Add("log_EnableTranslateHeader", "Enable Translate");
            Dictionary.Add("log_RegExLabel", "RegEx:");
            Dictionary.Add("log_UseRomanizationHeader", "Use Romanization");
            Dictionary.Add("log_ShowASCIIDebugHeader", "Show ASCII Debug");
            Dictionary.Add("log_TabNameLabel", "Tab Name:");
            Dictionary.Add("log_TranslateLSHeader", "LS");
            Dictionary.Add("log_TranslateFCHeader", "FC");
            Dictionary.Add("log_TranslatePartyHeader", "Party");
            Dictionary.Add("log_TranslateableChatTabHeader", "Translateable Chat");
            Dictionary.Add("log_TranslatedTabHeader", "Translated");
            Dictionary.Add("log_TranslateJPOnlyHeader", "Translate JP Only");
            Dictionary.Add("log_TranslateSettingsTabHeader", "Translate Settings");
            Dictionary.Add("log_TranslateToHeader", "Translate To");
            Dictionary.Add("log_TranslateSayHeader", "Say");
            Dictionary.Add("log_TranslateShoutHeader", "Shout");
            Dictionary.Add("log_TranslateTellHeader", "Tell");
            Dictionary.Add("log_TranslateYellHeader", "Yell");
            Dictionary.Add("log_EnableAllHeader", "Enable All");
            Dictionary.Add("log_TranslateAllianceHeader", "Alliance");
            Dictionary.Add("log_GitHubButtonText", "Open Project Source (GitHub)");
            return Dictionary;
        }
    }
}
