// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PluginViewModel.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   PluginViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;

    using FFXIVAPP.Common.Events;
    using FFXIVAPP.Common.Helpers;

    internal sealed class PluginViewModel : INotifyPropertyChanged {
        private static Lazy<PluginViewModel> _instance = new Lazy<PluginViewModel>(() => new PluginViewModel());

        private Dictionary<string, string> _chatCodes;

        private bool _enableHelpLabels;

        private Dictionary<string, string> _locale;

        private ObservableCollection<UIElement> _tabs;

        // used for global static properties
        public event EventHandler<PopupResultEvent> PopupResultChanged = delegate { };

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static PluginViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        public static Dictionary<string, string> PluginInfo {
            get {
                Dictionary<string, string> pluginInfo = new Dictionary<string, string>();
                pluginInfo.Add("Icon", "Logo.png");
                pluginInfo.Add("Name", AssemblyHelper.Name);
                pluginInfo.Add("Description", AssemblyHelper.Description);
                pluginInfo.Add("Copyright", AssemblyHelper.Copyright);
                pluginInfo.Add("Version", AssemblyHelper.Version.ToString());
                return pluginInfo;
            }
        }

        public Dictionary<string, string> ChatCodes {
            get {
                return this._chatCodes ?? (this._chatCodes = new Dictionary<string, string>());
            }

            set {
                this._chatCodes = value;
                this.RaisePropertyChanged();
            }
        }

        public bool EnableHelpLabels {
            get {
                return this._enableHelpLabels;
            }

            set {
                this._enableHelpLabels = value;
                this.RaisePropertyChanged();
            }
        }

        public Dictionary<string, string> Locale {
            get {
                return this._locale ?? (this._locale = new Dictionary<string, string>());
            }

            set {
                this._locale = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<UIElement> Tabs {
            get {
                return this._tabs ?? (this._tabs = new ObservableCollection<UIElement>());
            }

            set {
                this._tabs = value;
                this.RaisePropertyChanged();
            }
        }

        public void OnPopupResultChanged(PopupResultEvent e) {
            this.PopupResultChanged(this, e);
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}