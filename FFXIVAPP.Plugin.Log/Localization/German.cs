// FFXIVAPP.Plugin.Log
// German.cs
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
