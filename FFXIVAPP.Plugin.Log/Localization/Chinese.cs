// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Chinese.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Chinese.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Localization {
    using System.Windows;

    public abstract class Chinese {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context() {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "添加Tab");
            Dictionary.Add("log_AllTabHeader", "所有");
            Dictionary.Add("log_DebugTabHeader", "调试");
            Dictionary.Add("log_DebugOptionsHeader", "调试选项");
            Dictionary.Add("log_EnableDebugHeader", "开启调试");
            Dictionary.Add("log_EnableTranslateHeader", "开启翻译");
            Dictionary.Add("log_RegExLabel", "RegEx:");
            Dictionary.Add("log_UseRomanizationHeader", "使用罗马");
            Dictionary.Add("log_ShowASCIIDebugHeader", "显示 ASCII 调试");
            Dictionary.Add("log_TabNameLabel", "Tab 名称:");
            Dictionary.Add("log_TranslateLSHeader", "LS");
            Dictionary.Add("log_TranslateFCHeader", "FC");
            Dictionary.Add("log_TranslatePartyHeader", "聚会");
            Dictionary.Add("log_TranslateableChatTabHeader", "可翻译聊天");
            Dictionary.Add("log_TranslatedTabHeader", "已被翻译");
            Dictionary.Add("log_TranslateJPOnlyHeader", "只翻译 JP");
            Dictionary.Add("log_TranslateSettingsTabHeader", "翻译设置");
            Dictionary.Add("log_TranslateToHeader", "翻译为");
            Dictionary.Add("log_TranslationProviderHeader", "Translation Provider");
            Dictionary.Add("log_CognitiveServiceKeyHeader", "Cognitive Service Key");
            Dictionary.Add("log_CognitiveServiceRegionHeader", "Cognitive Service Region");
            Dictionary.Add("log_TranslateNoviceHeader", "Novice");
            Dictionary.Add("log_TranslateSayHeader", "说");
            Dictionary.Add("log_TranslateShoutHeader", "喊");
            Dictionary.Add("log_TranslateTellHeader", "告诉");
            Dictionary.Add("log_TranslateYellHeader", "训斥");
            Dictionary.Add("log_EnableAllHeader", "开启所有");
            Dictionary.Add("log_TranslateAllianceHeader", "联盟");
            Dictionary.Add("log_GitHubButtonText", "打开项目源代码(GitHub)");

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