// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Settings.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Properties {
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
    using System.Windows;
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

    internal class Settings : ApplicationSettingsBase, INotifyPropertyChanged {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static Settings _default;

        public new event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static Settings Default {
            get {
                return _default ?? (_default = (Settings) Synchronized(new Settings()));
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF000000")]
        public Color ChatBackgroundColor {
            get {
                return (Color) this["ChatBackgroundColor"];
            }

            set {
                this["ChatBackgroundColor"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Microsoft Sans Serif, 12pt")]
        public Font ChatFont {
            get {
                return (Font) this["ChatFont"];
            }

            set {
                this["ChatFont"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool EnableAll {
            get {
                return (bool) this["EnableAll"];
            }

            set {
                this["EnableAll"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool EnableDebug {
            get {
                return (bool) this["EnableDebug"];
            }

            set {
                this["EnableDebug"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool EnableTranslate {
            get {
                return (bool) this["EnableTranslate"];
            }

            set {
                this["EnableTranslate"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Japanese")]
        public string ManualTranslate {
            get {
                return (string) this["ManualTranslate"];
            }

            set {
                this["ManualTranslate"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool ShowASCIIDebug {
            get {
                return (bool) this["ShowASCIIDebug"];
            }

            set {
                this["ShowASCIIDebug"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTitlesOnWidgets {
            get {
                return (bool) this["ShowTitlesOnWidgets"];
            }

            set {
                this["ShowTitlesOnWidgets"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool ShowTranslationWidgetOnLoad {
            get {
                return (bool) this["ShowTranslationWidgetOnLoad"];
            }

            set {
                this["ShowTranslationWidgetOnLoad"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("#FF800080")]
        public Color TimeStampColor {
            get {
                return (Color) this["TimeStampColor"];
            }

            set {
                this["TimeStampColor"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateAlliance {
            get {
                return (bool) this["TranslateAlliance"];
            }

            set {
                this["TranslateAlliance"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateFC {
            get {
                return (bool) this["TranslateFC"];
            }

            set {
                this["TranslateFC"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateJPOnly {
            get {
                return (bool) this["TranslateJPOnly"];
            }

            set {
                this["TranslateJPOnly"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
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
        public StringCollection TranslateLanguages {
            get {
                return (StringCollection) this["TranslateLanguages"];
            }

            set {
                this["TranslateLanguages"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateLS {
            get {
                return (bool) this["TranslateLS"];
            }

            set {
                this["TranslateLS"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateParty {
            get {
                return (bool) this["TranslateParty"];
            }

            set {
                this["TranslateParty"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateSay {
            get {
                return (bool) this["TranslateSay"];
            }

            set {
                this["TranslateSay"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateShout {
            get {
                return (bool) this["TranslateShout"];
            }

            set {
                this["TranslateShout"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateTell {
            get {
                return (bool) this["TranslateTell"];
            }

            set {
                this["TranslateTell"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("English")]
        public string TranslateTo {
            get {
                return (string) this["TranslateTo"];
            }

            set {
                this["TranslateTo"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("True")]
        public bool TranslateYell {
            get {
                return (bool) this["TranslateYell"];
            }

            set {
                this["TranslateYell"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int TranslationWidgetHeight {
            get {
                return (int) this["TranslationWidgetHeight"];
            }

            set {
                this["TranslationWidgetHeight"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("400")]
        public int TranslationWidgetLeft {
            get {
                return (int) this["TranslationWidgetLeft"];
            }

            set {
                this["TranslationWidgetLeft"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public int TranslationWidgetTop {
            get {
                return (int) this["TranslationWidgetTop"];
            }

            set {
                this["TranslationWidgetTop"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("1.0")]
        public string TranslationWidgetUIScale {
            get {
                return (string) this["TranslationWidgetUIScale"];
            }

            set {
                this["TranslationWidgetUIScale"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
  <string>1.1</string>
  <string>1.2</string>
  <string>1.3</string>
  <string>1.4</string>
  <string>1.5</string>
</ArrayOfString>")]
        public StringCollection TranslationWidgetUIScaleList {
            get {
                return (StringCollection) this["TranslationWidgetUIScaleList"];
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("600")]
        public int TranslationWidgetWidth {
            get {
                return (int) this["TranslationWidgetWidth"];
            }

            set {
                this["TranslationWidgetWidth"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool UseRomanization {
            get {
                return (bool) this["UseRomanization"];
            }

            set {
                this["UseRomanization"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("False")]
        public bool WidgetClickThroughEnabled {
            get {
                return (bool) this["WidgetClickThroughEnabled"];
            }

            set {
                this["WidgetClickThroughEnabled"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0.7")]
        public string WidgetOpacity {
            get {
                return (string) this["WidgetOpacity"];
            }

            set {
                this["WidgetOpacity"] = value;
                this.RaisePropertyChanged();
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue(
            @"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>0.5</string>
  <string>0.6</string>
  <string>0.7</string>
  <string>0.8</string>
  <string>0.9</string>
  <string>1.0</string>
</ArrayOfString>")]
        public StringCollection WidgetOpacityList {
            get {
                return (StringCollection) this["WidgetOpacityList"];
            }

            set {
                this["WidgetOpacityList"] = value;
                this.RaisePropertyChanged();
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("100")]
        public double Zoom {
            get {
                return (double) this["Zoom"];
            }

            set {
                this["Zoom"] = value;
                this.RaisePropertyChanged();
            }
        }

        public new void Reset() {
            this.DefaultSettings();
            foreach (var key in Constants.Settings) {
                SettingsProperty settingsProperty = Default.Properties[key];
                if (settingsProperty == null) {
                    continue;
                }

                var value = settingsProperty.DefaultValue.ToString();
                this.SetValue(key, value, CultureInfo.InvariantCulture);
            }
        }

        public override void Save() {
            // this call to default settings only ensures we keep the settings we want and delete the ones we don't (old)
            this.DefaultSettings();
            this.SaveSettingsNode();
            this.SaveTabsNode();
            Constants.XSettings.Save(Path.Combine(Common.Constants.PluginsSettingsPath, "FFXIVAPP.Plugin.Log.xml"));
        }

        public void SetValue(string key, string value, CultureInfo cultureInfo) {
            try {
                var type = Default[key].GetType().Name;
                switch (type) {
                    case "Boolean":
                        Default[key] = bool.Parse(value);
                        break;
                    case "Color":
                        var cc = new ColorConverter();
                        object color = cc.ConvertFrom(value);
                        Default[key] = color ?? Colors.Black;
                        break;
                    case "Double":
                        Default[key] = double.Parse(value, cultureInfo);
                        break;
                    case "Font":
                        var fc = new FontConverter();
                        object font = fc.ConvertFromString(value);
                        Default[key] = font ?? new Font(new FontFamily("Microsoft Sans Serif"), 12);
                        break;
                    case "Int32":
                        Default[key] = int.Parse(value, cultureInfo);
                        break;
                    default:
                        Default[key] = value;
                        break;
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            this.RaisePropertyChanged(key);
        }

        private void DefaultSettings() {
            Constants.Settings.Clear();

            

            Constants.Settings.Add("TranslationWidgetWidth");
            Constants.Settings.Add("TranslationWidgetHeight");
            Constants.Settings.Add("TranslationWidgetUIScale");
            Constants.Settings.Add("ShowTranslationWidgetOnLoad");
            Constants.Settings.Add("TranslationWidgetTop");
            Constants.Settings.Add("TranslationWidgetLeft");

            

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

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        private void SaveSettingsNode() {
            if (Constants.XSettings == null) {
                return;
            }

            IEnumerable<XElement> xElements = Constants.XSettings.Descendants().Elements("Setting");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (var setting in Constants.Settings) {
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key").Value == setting);
                var xKey = setting;
                if (Default[xKey] == null) {
                    continue;
                }

                if (element == null) {
                    var xValue = Default[xKey].ToString();
                    List<XValuePair> keyPairList = new List<XValuePair> {
                        new XValuePair {
                            Key = "Value",
                            Value = xValue
                        }
                    };
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Setting", xKey, keyPairList);
                }
                else {
                    XElement xElement = element.Element("Value");
                    if (xElement != null) {
                        xElement.Value = Default[setting].ToString();
                    }
                }
            }
        }

        private void SaveTabsNode() {
            if (Constants.XSettings == null) {
                return;
            }

            Constants.XSettings.Descendants("Tab").Where(node => PluginViewModel.Instance.Tabs.All(t => ((TabItem) t).Header.ToString() != node.Attribute("Key").Value)).Remove();
            IEnumerable<XElement> xElements = Constants.XSettings.Descendants().Elements("Tab");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();
            foreach (UIElement tab in PluginViewModel.Instance.Tabs) {
                var tabItem = (TabItem) tab;
                var flowDoc = (xFlowDocument) tabItem.Content;
                var xKey = tabItem.Header.ToString();
                var xValue = flowDoc.Codes.Items.Cast<object>().Aggregate(string.Empty, (c, code) => c + "," + code).Substring(1);
                var xRegularExpression = flowDoc.RegEx.Text;
                List<XValuePair> keyPairList = new List<XValuePair>();
                keyPairList.Add(
                    new XValuePair {
                        Key = "Value",
                        Value = xValue
                    });
                keyPairList.Add(
                    new XValuePair {
                        Key = "RegularExpression",
                        Value = xRegularExpression
                    });
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key").Value == xKey);
                if (element == null) {
                    XmlHelper.SaveXmlNode(Constants.XSettings, "Settings", "Tab", xKey, keyPairList);
                }
                else {
                    XElement xValueElement = element.Element("Value");
                    if (xValueElement != null) {
                        xValueElement.Value = xValue;
                    }

                    XElement xRegularExpressionElement = element.Element("RegularExpression");
                    if (xRegularExpressionElement != null) {
                        xRegularExpressionElement.Value = xRegularExpression;
                    }
                }
            }
        }
    }
}