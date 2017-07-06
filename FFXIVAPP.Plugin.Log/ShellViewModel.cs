// FFXIVAPP.Plugin.Log ~ ShellViewModel.cs
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.Utilities;
using FFXIVAPP.Plugin.Log.Interop;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Views;
using NLog;

namespace FFXIVAPP.Plugin.Log
{
    public sealed class ShellViewModel : INotifyPropertyChanged
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        public ShellViewModel()
        {
            Initializer.LoadSettings();
            Initializer.LoadTabs();
            Initializer.SetupWidgetTopMost();
            Settings.Default.PropertyChanged += DefaultOnPropertyChanged;
        }

        internal static void Loaded(object sender, RoutedEventArgs e)
        {
            ShellView.View.Loaded -= Loaded;
            Initializer.ApplyTheming();
            MainView.View.MainViewTC.SelectedIndex = Settings.Default.EnableAll ? 0 : 1;
        }

        private static void DefaultOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "EnableAll":
                    try
                    {
                        if (MainView.View.MainViewTC.SelectedIndex == 0 && !Settings.Default.EnableAll)
                        {
                            MainView.View.MainViewTC.SelectedIndex = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Log(Logger, new LogItem(ex, true));
                    }
                    break;
                case "EnableDebug":
                    try
                    {
                        if (MainView.View.MainViewTC.SelectedIndex == 2 && !Settings.Default.EnableDebug)
                        {
                            MainView.View.MainViewTC.SelectedIndex = 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.Log(Logger, new LogItem(ex, true));
                    }
                    break;
                case "WidgetClickThroughEnabled":
                    WinAPI.ToggleClickThrough(Widgets.Instance.TranslationWidget);
                    break;
                case "TranslationWidgetUIScale":
                    try
                    {
                        Settings.Default.TranslationWidgetWidth = (int) (600 * Double.Parse(Settings.Default.TranslationWidgetUIScale));
                        Settings.Default.TranslationWidgetHeight = (int) (400 * Double.Parse(Settings.Default.TranslationWidgetUIScale));
                    }
                    catch (Exception)
                    {
                        Settings.Default.TranslationWidgetWidth = 600;
                        Settings.Default.TranslationWidgetHeight = 400;
                    }
                    break;
            }
        }

        #region Property Bindings

        private static ShellViewModel _instance;

        public static ShellViewModel Instance
        {
            get { return _instance ?? (_instance = new ShellViewModel()); }
        }

        #endregion

        #region Declarations

        #endregion

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
