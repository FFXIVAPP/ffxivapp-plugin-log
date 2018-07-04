// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogPublisher.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   LogPublisher.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Utilities {
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
    using FFXIVAPP.Plugin.Log.Properties;
    using FFXIVAPP.Plugin.Log.Views;

    using NLog;

    using Sharlayan.Core;

    public static class LogPublisher {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Process(ChatLogItem chatLogItem) {
            try {
                // setup variables
                var timeStampColor = Settings.Default.TimeStampColor.ToString();
                var timeStamp = chatLogItem.TimeStamp.ToString("[HH:mm:ss] ");
                var line = chatLogItem.Line.Replace("  ", " ");
                var rawLine = line;
                var color = Constants.Colors.ContainsKey(chatLogItem.Code)
                                ? Constants.Colors[chatLogItem.Code][0]
                                : "FFFFFF";
                var isLS = Constants.Linkshells.ContainsKey(chatLogItem.Code);
                line = isLS
                           ? Constants.Linkshells[chatLogItem.Code] + line
                           : line;
                var playerName = string.Empty;

                // handle tabs
                if (CheckMode(chatLogItem.Code, Constants.ChatPublic)) {
                    playerName = line.Substring(0, line.IndexOf(":", StringComparison.Ordinal));
                    line = line.Replace(playerName + ":", string.Empty);
                }

                if (Settings.Default.EnableAll) {
                    Common.Constants.FD.AppendFlow(
                        timeStamp,
                        playerName,
                        line,
                        new[] {
                            timeStampColor,
                            "#" + color
                        },
                        MainView.View.AllFD._FDR);
                }

                DispatcherHelper.Invoke(
                    delegate {
                        foreach (xFlowDocument flowDoc in PluginViewModel.Instance.Tabs.Select(ti => (xFlowDocument) ((TabItem) ti).Content)) {
                            var resuccess = false;
                            var xRegularExpression = flowDoc.RegEx.Text;
                            switch (xRegularExpression) {
                                case "*":
                                    resuccess = true;
                                    break;
                                default:
                                    try {
                                        var check = new Regex(xRegularExpression);
                                        if (SharedRegEx.IsValidRegex(xRegularExpression)) {
                                            Match reg = check.Match(line);
                                            if (reg.Success) {
                                                resuccess = true;
                                            }
                                        }
                                    }
                                    catch {
                                        resuccess = true;
                                    }

                                    break;
                            }

                            if (resuccess && flowDoc.Codes.Items.Contains(chatLogItem.Code)) {
                                Common.Constants.FD.AppendFlow(
                                    timeStamp,
                                    playerName,
                                    line,
                                    new[] {
                                        timeStampColor,
                                        "#" + color
                                    },
                                    flowDoc._FDR);
                            }
                        }
                    });

                // handle translation
                if (Settings.Default.EnableTranslate) {
                    if (CheckMode(chatLogItem.Code, Constants.ChatSay) && Settings.Default.TranslateSay) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatTell) && Settings.Default.TranslateTell) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatParty) && Settings.Default.TranslateParty) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatShout) && Settings.Default.TranslateShout) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatYell) && Settings.Default.TranslateYell) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatLS) && Settings.Default.TranslateLS) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatFC) && Settings.Default.TranslateFC) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }

                    if (CheckMode(chatLogItem.Code, Constants.ChatAlliance) && Settings.Default.TranslateAlliance) {
                        Translate.GetAutomaticResult(rawLine, chatLogItem.JP);
                    }
                }

                // handle debug tab
                if (Settings.Default.ShowASCIIDebug) {
                    var asciiString = string.Empty;
                    for (var j = 0; j < chatLogItem.Bytes.Length; j++) {
                        asciiString += chatLogItem.Bytes[j].ToString(CultureInfo.CurrentUICulture) + " ";
                    }

                    asciiString = asciiString.Trim();
                    Common.Constants.FD.AppendFlow(
                        string.Empty,
                        string.Empty,
                        asciiString,
                        new[] {
                            string.Empty,
                            "#FFFFFFFF"
                        },
                        MainView.View.DebugFD._FDR);
                }

                if (Settings.Default.EnableDebug) {
                    var raw = $"{chatLogItem.Raw.Substring(0, 8)}[{chatLogItem.Code}]{chatLogItem.Raw.Substring(12)}";
                    Common.Constants.FD.AppendFlow(
                        string.Empty,
                        string.Empty,
                        raw,
                        new[] {
                            string.Empty,
                            "#FFFFFFFF"
                        },
                        MainView.View.DebugFD._FDR);
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="chatMode"> </param>
        /// <param name="log"> </param>
        /// <returns> </returns>
        private static bool CheckMode(string chatMode, IEnumerable<string> log) {
            return log.Any(t => t == chatMode);
        }
    }
}