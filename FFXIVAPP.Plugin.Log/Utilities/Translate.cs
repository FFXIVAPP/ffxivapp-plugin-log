// FFXIVAPP.Plugin.Log
// Translate.cs
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

using System;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.Utilities;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Views;

namespace FFXIVAPP.Plugin.Log.Utilities
{
    internal static class Translate
    {
        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <param name="resultOnly"></param>
        public static GoogleTranslateResult GetAutomaticResult(string line, bool isJP, bool resultOnly = false)
        {
            var timeStampColor = Settings.Default.TimeStampColor.ToString();
            var player = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal)) + ": ";
            var tmpMessage = line.Substring(line.IndexOf(":", StringComparison.Ordinal) + 1);
            var result = ResolveGoogleTranslateResult(tmpMessage, isJP);
            if (result != null)
            {
                if (result.Translated.Length <= 0 || String.Equals(line, result.Translated, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new GoogleTranslateResult
                    {
                        Original = line
                    };
                }
            }
            if (!resultOnly && result != null)
            {
                Common.Constants.FD.AppendFlow(player, "", result.Translated, new[]
                {
                    timeStampColor, "#EAFF00"
                }, MainView.View.TranslatedFD._FDR);
            }
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="outLang"></param>
        /// <param name="isJP"></param>
        /// <returns></returns>
        public static GoogleTranslateResult GetManualResult(string line, string outLang, bool isJP)
        {
            return GoogleTranslate.Translate(line, "en", outLang, isJP);
        }

        /// <summary>
        /// </summary>
        /// <param name="line"></param>
        /// <param name="isJP"></param>
        /// <returns></returns>
        private static GoogleTranslateResult ResolveGoogleTranslateResult(string line, bool isJP)
        {
            GoogleTranslateResult result = null;
            var outLang = GoogleTranslate.Offsets[Settings.Default.TranslateTo].ToString();
            if (Settings.Default.TranslateJPOnly)
            {
                if (isJP)
                {
                    result = GoogleTranslate.Translate(line, "ja", outLang, true);
                }
            }
            else
            {
                result = GoogleTranslate.Translate(line, isJP ? "ja" : "en", outLang, true);
            }
            return result;
        }
    }
}
