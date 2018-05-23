using System;

using DevExpress.ExpressApp;

namespace DXExample.Module.Web {
    public class WebReportsController : ViewController {
        public WebReportsController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(MyReportData);
        }
        protected override void OnActivated() {
            base.OnActivated();
            ((MyReportData)View.CurrentObject).ReportCreated += new EventHandler<ReportCreatedEventArgs>(WinReportsController_ReportCreated);
        }
        void WinReportsController_ReportCreated(object sender, ReportCreatedEventArgs e) {
            // Place your code here
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            ((MyReportData)View.CurrentObject).ReportCreated -= new EventHandler<ReportCreatedEventArgs>(WinReportsController_ReportCreated);
        }
    }
}
