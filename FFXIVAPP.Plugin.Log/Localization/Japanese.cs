// FFXIVAPP.Plugin.Log
// Japanese.cs
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
    public abstract class Japanese
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("log_", "*PH*");
            Dictionary.Add("log_AddTabButtonText", "タブを追加する");
            Dictionary.Add("log_AllTabHeader", "全て");
            Dictionary.Add("log_DebugTabHeader", "デバッグ");
            Dictionary.Add("log_DebugOptionsHeader", "デバッグオプション");
            Dictionary.Add("log_EnableDebugHeader", "デバッグ情報を表示する");
            Dictionary.Add("log_EnableTranslateHeader", "チャットを翻訳する");
            Dictionary.Add("log_RegExLabel", "正規表現:");
            Dictionary.Add("log_UseRomanizationHeader", "ローマ字を利用する");
            Dictionary.Add("log_ShowASCIIDebugHeader", "ASCIIコードを表示する (デバッグ用)");
            Dictionary.Add("log_TabNameLabel", "タブ名:");
            Dictionary.Add("log_TranslateLSHeader", "LSチャットを翻訳する");
            Dictionary.Add("log_TranslateFCHeader", "FCチャットを翻訳する");
            Dictionary.Add("log_TranslatePartyHeader", "Partyチャットを翻訳する");
            Dictionary.Add("log_TranslateableChatTabHeader", "チャット翻訳対象");
            Dictionary.Add("log_TranslatedTabHeader", "翻訳");
            Dictionary.Add("log_TranslateJPOnlyHeader", "日本語のみ翻訳する");
            Dictionary.Add("log_TranslateSettingsTabHeader", "翻訳オプション");
            Dictionary.Add("log_TranslateToHeader", "翻訳先言語");
            Dictionary.Add("log_TranslateSayHeader", "Sayを翻訳する");
            Dictionary.Add("log_TranslateShoutHeader", "Shoutを翻訳する");
            Dictionary.Add("log_TranslateTellHeader", "Tellを翻訳する");
            Dictionary.Add("log_TranslateYellHeader", "Yellを翻訳する");
            Dictionary.Add("log_EnableAllHeader", "すべて有効にする");
            Dictionary.Add("log_TranslateAllianceHeader", "Allianceチャットを翻訳する");
            Dictionary.Add("log_GitHubButtonText", "Open Project Source (GitHub)");
            return Dictionary;
        }
    }
}
