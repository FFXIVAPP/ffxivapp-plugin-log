﻿// FFXIVAPP.Plugin.Log ~ Settings.cs
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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using FFXIVAPP.Common.Controls;
using FFXIVAPP.Common.Helpers;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.Utilities;
using NLog;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using FontFamily = System.Drawing.FontFamily;

namespace FFXIVAPP.Plugin.Log.Properties
{
    internal class Settings : ApplicationSettingsBase, INotifyPropertyChanged
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        private static Settings _default;

        public static Settings Default
        {
            get { return _default ?? (_default = (Settings) Synchronized(new Settings())); }
        }

        public override void Save()
        {
            // this call to default settings only ensures we keep the settings we want and delete the ones we don't (old)
            DefaultSettings();
            SaveSettingsNode();
            SaveTabsNode();
            Constants.XSettings.Save(Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Log.xml"));
        }

        private void DefaultSettings()
        {
            Constants.Settings.Clear();

            #region Widgets

            Constants.Settings.Add("TranslationWidgetWidth");
            Constants.Settings.Add("TranslationWidgetHeight");
            Constants.Settings.Add("TranslationWidgetUIScale");
            Constants.Settings.Add("ShowTranslationWidgetOnLoad");
            Constants.Settings.Add("TranslationWidgetTop");
            Constants.Settings.Add("TranslationWidgetLeft");

            #endregion

            Constants.Settings.Add("WidgetClickThroughEnabled");
            Constants.Settings.Add("ShowTitlesOnWidgets");
            Constants.Settings.Add("WidgetOpacity");

            Constants.Settings.Add("EnableAll");
            Constants.Settings.Add("EnableDebug");
            Constants.Settings.Add("ShowASCIIDebug");
            Constants.Settings.Add("EnableTranslate");
            Constants.Settings.Add("UseRomanization");
            Constants.Settings.Add("TranslateTo");
            Constants.Settings.Add("ManualTranslate");
            Constants.Settings.Add("TranslateJPOnly");
            Constants.Settings.Add("TranslateSay");
            Constants.Settings.Add("TranslateTell");
            Constants.Settings.Add("TranslateParty");
            Constants.Settings.Add("TranslateLS");
            Constants.Settings.Add("TranslateShout");
            Constants.Settings.Add("TranslateFC");
            Constants.Settings.Add("TranslateAlliance");
            Constants.Settings.Add("Zoom");
        }

        public new void Reset()
        {
            DefaultSettings();
            foreach (var key in Constants.Settings)
            {
                var settingsProperty = Default.Properties[key];
                if (settingsProperty == null)
                {
                    continue;
                }
                var value = settingsProperty.DefaultValue.ToString();
                SetValue(key, value, CultureInfo.InvariantCulture);
            }
        }

        public void SetValue(string key, string value, CultureInfo cultureInfo)
        {
            try
            {
                var type = Default[key]
                    .GetType()
                    .Name;
                switch (type)
                {
                    case "Boolean":
                        Default[key] = Boolean.Parse(value);
                        break;
                    case "Color":
                        var cc = new ColorConverter();
                        var color = cc.ConvertFrom(value);
                        Default[key] = color ?? Colors.Black;
                        break;
                    case "Double":
                        Default[key] = Double.Parse(value, cultureInfo);
                        break;
                    case "Font":
                        var fc = new FontConverter();
                        var font = fc.ConvertFromString(value);
                        Default[key] = font ?? new Font(new FontFamily("Microsoft Sans Serif"), 12);
                        break;
                    case "Int32":
                        Default[key] = Int32.Parse(value, cultureInfo);
                        break;
                    default:
                        Default[key] = value;
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, new LogItem(ex, true));
            }
            RaisePropertyChanged(key);
        }

        #region Property Bindings (Settings)

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF000000")]
        public Color ChatBackgroundColor
        {
            get { return (Color) this["ChatBackgroundColor"]; }
            set
            {
                this["ChatBackgroundColor"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF800080")]
        public Color TimeStampColor
        {
            get { return (Color) this["TimeStampColor"]; }
            set
            {
                this["TimeStampColor"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Microsoft Sans Serif, 12pt")]
        public Font ChatFont
        {
            get { return (Font) this["ChatFont"]; }
            set
            {
                this["ChatFont"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public Double Zoom
        {
            get { return (Double) this["Zoom"]; }
            set
            {
                this["Zoom"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.7")]
        public string WidgetOpacity
        {
            get { return (string) this["WidgetOpacity"]; }
            set
            {
                this["WidgetOpacity"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=string.Empty1.0string.Empty encoding=string.Emptyutf-16string.Empty?>
<ArrayOfString xmlns:xsi=string.Emptyhttp://www.w3.org/2001/XMLSchema-instancestring.Empty xmlns:xsd=string.Emptyhttp://www.w3.org/2001/XMLSchemastring.Empty>
  <string>0.5</string>
  <string>0.6</string>
  <string>0.7</string>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
</ArrayOfString>")]
        public StringCollection WidgetOpacityList
        {
            get { return (StringCollection) this["WidgetOpacityList"]; }
            set
            {
                this["WidgetOpacityList"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool WidgetClickThroughEnabled
        {
            get { return (bool) this["WidgetClickThroughEnabled"]; }
            set
            {
                this["WidgetClickThroughEnabled"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTitlesOnWidgets
        {
            get { return (bool) this["ShowTitlesOnWidgets"]; }
            set
            {
                this["ShowTitlesOnWidgets"] = value;
                RaisePropertyChanged();
            }
        }

        #region Translation Widget

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("600")]
        public int TranslationWidgetWidth
        {
            get { return (int) this["TranslationWidgetWidth"]; }
            set
            {
                this["TranslationWidgetWidth"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int TranslationWidgetHeight
        {
            get { return (int) this["TranslationWidgetHeight"]; }
            set
            {
                this["TranslationWidgetHeight"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string TranslationWidgetUIScale
        {
            get { return (string) this["TranslationWidgetUIScale"]; }
            set
            {
                this["TranslationWidgetUIScale"] = value;
                RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=string.Empty1.0string.Empty encoding=string.Emptyutf-16string.Empty?>
<ArrayOfString xmlns:xsi=string.Emptyhttp://www.w3.org/2001/XMLSchema-instancestring.Empty xmlns:xsd=string.Emptyhttp://www.w3.org/2001/XMLSchemastring.Empty>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection TranslationWidgetUIScaleList
        {
            get { return (StringCollection) this["TranslationWidgetUIScaleList"]; }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTranslationWidgetOnLoad
        {
            get { return (bool) this["ShowTranslationWidgetOnLoad"]; }
            set
            {
                this["ShowTranslationWidgetOnLoad"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int TranslationWidgetTop
        {
            get { return (int) this["TranslationWidgetTop"]; }
            set
            {
                this["TranslationWidgetTop"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int TranslationWidgetLeft
        {
            get { return (int) this["TranslationWidgetLeft"]; }
            set
            {
                this["TranslationWidgetLeft"] = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool EnableAll
        {
            get { return (bool) this["EnableAll"]; }
            set
            {
                this["EnableAll"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool EnableDebug
        {
            get { return (bool) this["EnableDebug"]; }
            set
            {
                this["EnableDebug"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowASCIIDebug
        {
            get { return (bool) this["ShowASCIIDebug"]; }
            set
            {
                this["ShowASCIIDebug"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool EnableTranslate
        {
            get { return (bool) this["EnableTranslate"]; }
            set
            {
                this["EnableTranslate"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool UseRomanization
        {
            get { return (bool) this["UseRomanization"]; }
            set
            {
                this["UseRomanization"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("English")]
        public string TranslateTo
        {
            get { return (string) this["TranslateTo"]; }
            set
            {
                this["TranslateTo"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Japanese")]
        public string ManualTranslate
        {
            get { return (string) this["ManualTranslate"]; }
            set
            {
                this["ManualTranslate"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateJPOnly
        {
            get { return (bool) this["TranslateJPOnly"]; }
            set
            {
                this["TranslateJPOnly"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateSay
        {
            get { return (bool) this["TranslateSay"]; }
            set
            {
                this["TranslateSay"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateTell
        {
            get { return (bool) this["TranslateTell"]; }
            set
            {
                this["TranslateTell"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateParty
        {
            get { return (bool) this["TranslateParty"]; }
            set
            {
                this["TranslateParty"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateLS
        {
            get { return (bool) this["TranslateLS"]; }
            set
            {
                this["TranslateLS"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateFC
        {
            get { return (bool) this["TranslateFC"]; }
            set
            {
                this["TranslateFC"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateAlliance
        {
            get { return (bool) this["TranslateAlliance"]; }
            set
            {
                this["TranslateAlliance"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateShout
        {
            get { return (bool) this["TranslateShout"]; }
            set
            {
                this["TranslateShout"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateYell
        {
            get { return (bool) this["TranslateYell"]; }
            set
            {
                this["TranslateYell"] = value;
                RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(@"<?xml version=string.Empty1.0string.Empty encoding=string.Emptyutf-16string.Empty?>
<ArrayOfString xmlns:xsi=string.Emptyhttp://www.w3.org/2001/XMLSchema-instancestring.Empty xmlns:xsd=string.Emptyhttp://www.w3.org/2001/XMLSchemastring.Empty>
  <string>Albanian</string>
  <string>Arabic</string>
  <string>Bulgarian</string>
  <string>Catalan</string>
  <string>Chinese (Simplified)</string>
  <string>Chinese (Traditional)</string>
  <string>Croatian</string>
  <string>Czech</string>
  <string>Danish</string>
  <string>Dutch</string>
  <string>English</string>
  <string>Estonian</string>
  <string>Filipino</string>
  <string>Finnish</string>
  <string>French</string>
  <string>Galician</string>
  <string>German</string>
  <string>Greek</string>
  <string>Hebrew</string>
  <string>Hindi</string>
  <string>Hungarian</string>
  <string>Indonesian</string>
  <string>Italian</string>
  <string>Japanese</string>
  <string>Korean</string>
  <string>Latvian</string>
  <string>Lithuanian</string>
  <string>Maltese</string>
  <string>Norwegian</string>
  <string>Polish</string>
  <string>Portuguese</string>
  <string>Romanian</string>
  <string>Russian</string>
  <string>Serbian</string>
  <string>Slovak</string>
  <string>Slovenian</string>
  <string>Spanish</string>
  <string>Swedish</string>
  <string>Thai</string>
  <string>Turkish</string>
  <string>Ukrainian</string>
  <string>Vietnamese</string>
</ArrayOfString>")]
        public StringCollection TranslateLanguages
        {
            get { return (StringCollection) this["TranslateLanguages"]; }
            set { this["TranslateLanguages"] = value; }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion

        #region Iterative Settings Saving

        private void SaveSettingsNode()
        {
            if (Constants.XSettings == null)
            {
                return;
            }
            var xElements = Constants.XSettings.Descendants()
                                     .Elements("Setting");
            var enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var setting in Constants.Settings)
            {
                var element = enumerable.FirstOrDefault(e => e.Attribute("Key")
                                                              .Value == setting);
                var xKey = setting;
                if (Default[xKey] == null)
                {
                    continue;
                }
                if (element == null)
                {
                    var xValue = Default[xKey]
                        .ToString();
                    var keyPairList = new List<XValuePair>
                    {
                        new XValuePair
                        {
                            Key = "Value",
                            Value = xValue
                        }
                    };
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Setting", xKey, keyPairList);
                }
                else
                {
                    var xElement = element.Element("Value");
                    if (xElement != null)
                    {
                        xElement.Value = Default[setting]
                            .ToString();
                    }
                }
            }
        }

        private void SaveTabsNode()
        {
            if (Constants.XSettings == null)
            {
                return;
            }
            Constants.XSettings.Descendants("Tab")
                     .Where(node => PluginViewModel.Instance.Tabs.All(t => ((TabItem) t).Header.ToString() != node.Attribute("Key")
                                                                                                                  .Value))
                     .Remove();
            var xElements = Constants.XSettings.Descendants()
                                     .Elements("Tab");
            var enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var tab in PluginViewModel.Instance.Tabs)
            {
                var tabItem = (TabItem) tab;
                var flowDoc = (xFlowDocument) tabItem.Content;
                var xKey = tabItem.Header.ToString();
                var xValue = flowDoc.Codes.Items.Cast<object>()
                                    .Aggregate("", (c, code) => c + "," + code)
                                    .Substring(1);
                var xRegularExpression = flowDoc.RegEx.Text;
                var keyPairList = new List<XValuePair>();
                keyPairList.Add(new XValuePair
                {
                    Key = "Value",
                    Value = xValue
                });
                keyPairList.Add(new XValuePair
                {
                    Key = "RegularExpression",
                    Value = xRegularExpression
                });
                var element = enumerable.FirstOrDefault(e => e.Attribute("Key")
                                                              .Value == xKey);
                if (element == null)
                {
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Tab", xKey, keyPairList);
                }
                else
                {
                    var xValueElement = element.Element("Value");
                    if (xValueElement != null)
                    {
                        xValueElement.Value = xValue;
                    }
                    var xRegularExpressionElement = element.Element("RegularExpression");
                    if (xRegularExpressionElement != null)
                    {
                        xRegularExpressionElement.Value = xRegularExpression;
                    }
                }
            }
        }

        #endregion
    }
}
