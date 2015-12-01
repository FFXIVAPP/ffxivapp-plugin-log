// FFXIVAPP.Plugin.Log
// FFXIVAPP & Related Plugins/Modules
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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
    public abstract class Russian
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "Добавить Вкладку");
            Dictionary.Add("log_AllTabHeader", "Все");
            Dictionary.Add("log_DebugTabHeader", "Отладка");
            Dictionary.Add("log_DebugOptionsHeader", "Опции Отладки");
            Dictionary.Add("log_EnableDebugHeader", "Включить Отладку");
            Dictionary.Add("log_EnableTranslateHeader", "Включить Перевод");
            Dictionary.Add("log_RegExLabel", "RegEx:");
            Dictionary.Add("log_UseRomanizationHeader", "Использовать Романизацию");
            Dictionary.Add("log_ShowASCIIDebugHeader", "Показать ASCII Отладку");
            Dictionary.Add("log_TabNameLabel", "Имя Вкладки:");
            Dictionary.Add("log_TranslateLSHeader", "LS");
            Dictionary.Add("log_TranslateFCHeader", "FC");
            Dictionary.Add("log_TranslatePartyHeader", "Party");
            Dictionary.Add("log_TranslateableChatTabHeader", "Чат с переводом");
            Dictionary.Add("log_TranslatedTabHeader", "Перевод");
            Dictionary.Add("log_TranslateJPOnlyHeader", "Переводить только Японский");
            Dictionary.Add("log_TranslateSettingsTabHeader", "Настройки Перевода");
            Dictionary.Add("log_TranslateToHeader", "Перевести на");
            Dictionary.Add("log_TranslateSayHeader", "Say");
            Dictionary.Add("log_TranslateShoutHeader", "Shout");
            Dictionary.Add("log_TranslateTellHeader", "Tell");
            Dictionary.Add("log_TranslateYellHeader", "Yell");
            Dictionary.Add("log_EnableAllHeader", "Включить все");
            Dictionary.Add("log_TranslateAllianceHeader", "Alliance");
            Dictionary.Add("log_GitHubButtonText", "Страница проекта (GitHub)");
            return Dictionary;
        }
    }
}
