using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Reports.Win;

namespace DXExample.Module.Win {
    public class WinReportsController : ReportsController {
        public WinReportsController() { }
        protected override void ExecuteReport(ShowViewParameters showViewParameters, object reportDataKey) {
            MyReportData reportData = ObjectSpace.GetObjectByKey<MyReportData>(reportDataKey);
            if (reportData != null) {
                reportData.ReportCreated += new EventHandler<ReportCreatedEventArgs>(reportData_ReportCreated);
            }
            base.ExecuteReport(showViewParameters, reportDataKey);
        }
        void reportData_ReportCreated(object sender, ReportCreatedEventArgs e) {
            // Place your code here
        }
    }
}
