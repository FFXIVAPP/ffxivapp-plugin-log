// FFXIVAPP.Plugin.Log
// LogPublisher.cs
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using FFXIVAPP.Common.Controls;
using FFXIVAPP.Common.Core.Memory;
using FFXIVAPP.Common.Helpers;
using FFXIVAPP.Common.RegularExpressions;
using FFXIVAPP.Common.Utilities;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Views;
using NLog;

namespace FFXIVAPP.Plugin.Log.Utilities
{
    public static class LogPublisher
    {
        public static void Process(ChatLogEntry chatLogEntry)
        {
            try
            {
                // setup variables
                var timeStampColor = Settings.Default.TimeStampColor.ToString();
                var timeStamp = chatLogEntry.TimeStamp.ToString("[HH:mm:ss] ");
                var line = chatLogEntry.Line.Replace("  ", " ");
                var rawLine = line;
                var color = (Constants.Colors.ContainsKey(chatLogEntry.Code)) ? Constants.Colors[chatLogEntry.Code][0] : "FFFFFF";
                var isLS = Constants.Linkshells.ContainsKey(chatLogEntry.Code);
                line = isLS ? Constants.Linkshells[chatLogEntry.Code] + line : line;
                var playerName = "";

                // handle tabs
                if (CheckMode(chatLogEntry.Code, Constants.ChatPublic))
                {
                    playerName = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal));
                    line = line.Replace(playerName + ":", "");
                }
                if (Settings.Default.EnableAll)
                {
                    Common.Constants.FD.AppendFlow(timeStamp, playerName, line, new[]
                    {
                        timeStampColor, "#" + color
                    }, MainView.View.AllFD._FDR);
                }
                DispatcherHelper.Invoke(delegate
                {
                    foreach (var flowDoc in PluginViewModel.Instance.Tabs.Select(ti => (xFlowDocument) ((TabItem) ti).Content))
                    {
                        var resuccess = false;
                        var xRegularExpression = flowDoc.RegEx.Text;
                        switch (xRegularExpression)
                        {
                            case "*":
                                resuccess = true;
                                break;
                            default:
                                try
                                {
                                    var check = new Regex(xRegularExpression);
                                    if (SharedRegEx.IsValidRegex(xRegularExpression))
                                    {
                                        var reg = check.Match(line);
                                        if (reg.Success)
                                        {
                                            resuccess = true;
                                        }
                                    }
                                }
                                catch
                                {
                                    resuccess = true;
                                }
                                break;
                        }
                        if (resuccess && flowDoc.Codes.Items.Contains(chatLogEntry.Code))
                        {
                            Common.Constants.FD.AppendFlow(timeStamp, playerName, line, new[]
                            {
                                timeStampColor, "#" + color
                            }, flowDoc._FDR);
                        }
                    }
                });
                // handle translation
                if (Settings.Default.EnableTranslate)
                {
                    if (CheckMode(chatLogEntry.Code, Constants.ChatSay) && Settings.Default.TranslateSay)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatTell) && Settings.Default.TranslateTell)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatParty) && Settings.Default.TranslateParty)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatShout) && Settings.Default.TranslateShout)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatYell) && Settings.Default.TranslateYell)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatLS) && Settings.Default.TranslateLS)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatFC) && Settings.Default.TranslateFC)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                    if (CheckMode(chatLogEntry.Code, Constants.ChatAlliance) && Settings.Default.TranslateAlliance)
                    {
                        Translate.GetAutomaticResult(rawLine, chatLogEntry.JP);
                    }
                }
                // handle debug tab
                if (Settings.Default.ShowASCIIDebug)
                {
                    var asciiString = "";
                    for (var j = 0; j < chatLogEntry.Bytes.Length; j++)
                    {
                        asciiString += chatLogEntry.Bytes[j].ToString(CultureInfo.CurrentUICulture) + " ";
                    }
                    asciiString = asciiString.Trim();
                    Common.Constants.FD.AppendFlow("", "", asciiString, new[]
                    {
                        "", "#FFFFFFFF"
                    }, MainView.View.DebugFD._FDR);
                }
                if (Settings.Default.EnableDebug)
                {
                    var raw = String.Format("{0}[{1}]{2}", chatLogEntry.Raw.Substring(0, 8), chatLogEntry.Code, chatLogEntry.Raw.Substring(12));
                    Common.Constants.FD.AppendFlow("", "", raw, new[]
                    {
                        "", "#FFFFFFFF"
                    }, MainView.View.DebugFD._FDR);
                }
            }
            catch (Exception ex)
            {
                Logging.Log(LogManager.GetCurrentClassLogger(), "", ex);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="chatMode"> </param>
        /// <param name="log"> </param>
        /// <returns> </returns>
        private static bool CheckMode(string chatMode, IEnumerable<string> log)
        {
            return log.Any(t => t == chatMode);
        }
    }
}
