// FFXIVAPP.Plugin.Log ~ Translate.cs
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
