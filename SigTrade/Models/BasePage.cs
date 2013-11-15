using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SigTrade.Models {
    public class BasePage: ViewPage {

        protected override void InitializeCulture() {
            if (Session["locale"] != null) {
                String selectedLanguage = Session["locale"].ToString();
                UICulture = selectedLanguage;
                Culture = selectedLanguage;

                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(selectedLanguage);
            }
            base.InitializeCulture();
        }
    }
}
