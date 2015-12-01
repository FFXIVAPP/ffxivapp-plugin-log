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
    public abstract class Chinese
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
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
            Dictionary.Add("log_TranslateSayHeader", "说");
            Dictionary.Add("log_TranslateShoutHeader", "喊");
            Dictionary.Add("log_TranslateTellHeader", "告诉");
            Dictionary.Add("log_TranslateYellHeader", "训斥");
            Dictionary.Add("log_EnableAllHeader", "开启所有");
            Dictionary.Add("log_TranslateAllianceHeader", "联盟");
            Dictionary.Add("log_GitHubButtonText", "打开项目源代码(GitHub)");
            return Dictionary;
        }
    }
}
