// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Russian.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Russian.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Localization {
    using System.Windows;

    public abstract class Russian {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
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