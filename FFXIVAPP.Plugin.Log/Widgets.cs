// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Widgets.cs" company="SyndicatedLife">
//   Copyright(c) 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Widgets.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Plugin.Log {
    using System;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;
    using FFXIVAPP.Plugin.Log.Windows;

    using NLog;

    public class Widgets {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static Lazy<Widgets> _instance = new Lazy<Widgets>(() => new Widgets());

        private TranslationWidget _translationWidget;

        public static Widgets Instance {
            get {
                return _instance.Value;
            }
        }

        public TranslationWidget TranslationWidget {
            get {
                return this._translationWidget ?? (this._translationWidget = new TranslationWidget());
            }
        }

        public void ShowTranslationWidget() {
            try {
                this.TranslationWidget.Show();
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }
        }
    }
}