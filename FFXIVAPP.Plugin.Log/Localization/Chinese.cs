// FFXIVAPP.Plugin.Log
// Chinese.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

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
