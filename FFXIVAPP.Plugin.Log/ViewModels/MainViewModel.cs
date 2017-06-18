// FFXIVAPP.Plugin.Log ~ MainViewModel.cs
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

using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FFXIVAPP.Common.RegularExpressions;
using FFXIVAPP.Common.Utilities;
using FFXIVAPP.Common.ViewModelBase;
using FFXIVAPP.Plugin.Log.Properties;
using FFXIVAPP.Plugin.Log.Utilities;
using FFXIVAPP.Plugin.Log.Views;

namespace FFXIVAPP.Plugin.Log.ViewModels
{
    internal sealed class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            DeleteTabCommand = new DelegateCommand(DeleteTab);
            ManualTranslateCommand = new DelegateCommand<string>(ManualTranslate);
        }

        #region Property Bindings

        private static MainViewModel _instance;

        public static MainViewModel Instance
        {
            get { return _instance ?? (_instance = new MainViewModel()); }
        }

        #endregion

        #region Declarations

        public static readonly Regex TranalateIsValid = new Regex(@"^/\w( \w+ \w+)?$", SharedRegEx.DefaultOptions);
        public ICommand DeleteTabCommand { get; private set; }
        public ICommand ManualTranslateCommand { get; private set; }

        #endregion

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        /// <summary>
        /// </summary>
        private static void DeleteTab()
        {
            if (MainView.View.MainViewTC.SelectedIndex < 3)
            {
                return;
            }
            var selection = Settings.Default.EnableDebug ? 2 : 1;
            PluginViewModel.Instance.Tabs.RemoveAt(MainView.View.MainViewTC.SelectedIndex - 3);
            if (PluginViewModel.Instance.Tabs.Any())
            {
                return;
            }
            MainView.View.MainViewTC.SelectedIndex = selection;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        private static void ManualTranslate(string value)
        {
            value = value.Trim();
            var outLang = GoogleTranslate.Offsets[Settings.Default.ManualTranslate]
                                         .ToString();
            if (value.Length <= 0)
            {
                return;
            }
            var tmpTranString = Translate.GetManualResult(value, outLang, false);
            MainView.View.Chatter.Text = Settings.Default.UseRomanization ? tmpTranString.Romanization : tmpTranString.Translated;
        }

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
