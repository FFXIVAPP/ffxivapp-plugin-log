// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TranslationWidgetViewModel.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   TranslationWidgetViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log.Windows {
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    internal sealed class TranslationWidgetViewModel : INotifyPropertyChanged {
        private static Lazy<TranslationWidgetViewModel> _instance = new Lazy<TranslationWidgetViewModel>(() => new TranslationWidgetViewModel());

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static TranslationWidgetViewModel Instance {
            get {
                return _instance.Value;
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "") {
            this.PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
    }
}