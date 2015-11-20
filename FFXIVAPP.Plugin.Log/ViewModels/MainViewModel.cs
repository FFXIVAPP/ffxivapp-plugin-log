// FFXIVAPP.Plugin.Log
// MainViewModel.cs
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
            var outLang = GoogleTranslate.Offsets[Settings.Default.ManualTranslate].ToString();
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
