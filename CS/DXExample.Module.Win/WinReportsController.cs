using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Reports.Win;

namespace DXExample.Module.Win {
    public class WinReportsController : ViewController {
        public WinReportsController() { }
        protected override void OnActivated() {
            base.OnActivated();
            Frame.GetController<WinReportServiceController>().CustomShowPreview += new EventHandler<CustomShowPreviewEventArgs>(WinReportsController_CustomShowPreview);
        }
        void WinReportsController_CustomShowPreview(object sender, CustomShowPreviewEventArgs e) {
            // Place your code here
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            Frame.GetController<WinReportServiceController>().CustomShowPreview -= new EventHandler<CustomShowPreviewEventArgs>(WinReportsController_CustomShowPreview);
        }
    }
}
