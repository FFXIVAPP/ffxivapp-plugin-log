// FFXIVAPP.Plugin.Log ~ LogPublisher.cs
// 
// Copyright © 2007 - 2017 Ryan Wilson - All Rights Reserved
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using FFXIVAPP.Common.Controls;
using FFXIVAPP.Common.Helpers;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.RegularExpressions;
using FFXIVAPP.Common.Utilities;
using FFXIVAPP.Memory.Core;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Views;
using NLog;

namespace FFXIVAPP.Plugin.Log.Utilities
{
    public static class LogPublisher
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        public static void Process(ChatLogEntry chatLogEntry)
        {
            try
            {
                // setup variables
                var timeStampColor = Settings.Default.TimeStampColor.ToString();
                var timeStamp = chatLogEntry.TimeStamp.ToString("[HH:mm:ss] ");
                var line = chatLogEntry.Line.Replace("  ", " ");
                var rawLine = line;
                var color = Constants.Colors.ContainsKey(chatLogEntry.Code) ? Constants.Colors[chatLogEntry.Code][0] : "FFFFFF";
                var isLS = Constants.Linkshells.ContainsKey(chatLogEntry.Code);
                line = isLS ? Constants.Linkshells[chatLogEntry.Code] + line : line;
                var playerName = string.Empty;

                // handle tabs
                if (CheckMode(chatLogEntry.Code, Constants.ChatPublic))
                {
                    playerName = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal));
                    line = line.Replace(playerName + ":", string.Empty);
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
                    var asciiString = string.Empty;
                    for (var j = 0; j < chatLogEntry.Bytes.Length; j++)
                    {
                        asciiString += chatLogEntry.Bytes[j]
                                                   .ToString(CultureInfo.CurrentUICulture) + " ";
                    }
                    asciiString = asciiString.Trim();
                    Common.Constants.FD.AppendFlow("", "", asciiString, new[]
                    {
                        "", "#FFFFFFFF"
                    }, MainView.View.DebugFD._FDR);
                }
                if (Settings.Default.EnableDebug)
                {
                    var raw = $"{chatLogEntry.Raw.Substring(0, 8)}[{chatLogEntry.Code}]{chatLogEntry.Raw.Substring(12)}";
                    Common.Constants.FD.AppendFlow("", "", raw, new[]
                    {
                        "", "#FFFFFFFF"
                    }, MainView.View.DebugFD._FDR);
                }
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, new LogItem(ex, true));
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
