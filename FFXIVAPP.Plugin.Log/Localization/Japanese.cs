// FFXIVAPP.Plugin.Log ~ Japanese.cs
// 
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
