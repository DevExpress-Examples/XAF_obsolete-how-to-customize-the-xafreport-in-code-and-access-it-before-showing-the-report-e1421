using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Reports;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DXExample.Module {
    public class MyReportData : ReportData {
        private const string HeaderLabelName = "HeaderLabel";
        public MyReportData(Session session) : base(session) { }
        public override XafReport LoadXtraReport(ObjectSpace objectSpace) {
            XafReport report = base.LoadXtraReport(objectSpace);
            XRLabel label = report.FindControl(HeaderLabelName, false) as XRLabel;
            if (label != null) {
                label.Text = Header;
            }
            if (ReportCreated != null) {
                ReportCreated(this, new ReportCreatedEventArgs(report));
            }
            return report;
        }
        protected override XafReport CreateReport() {
            XafReport report = base.CreateReport();
            XRLabel label = new XRLabel();
            label.Name = HeaderLabelName;
            report.Bands[BandKind.PageHeader].Controls.Add(label);
            int pageWidth = report.PageWidth - report.Margins.Left - report.Margins.Right;
            label.Location = new System.Drawing.Point((pageWidth - label.Width) / 2, 10);
            return report;
        }
        private string _Header;
        public string Header {
            get { return _Header; }
            set { SetPropertyValue("Header", ref _Header, value); }
        }
        [Browsable(false)]
        public event EventHandler<ReportCreatedEventArgs> ReportCreated;
    }
    public class ReportCreatedEventArgs : EventArgs {
        XafReport report;
        public ReportCreatedEventArgs(XafReport report) {
            this.report = report;
        }
        public XafReport Report {
            get { return report; }
        }
    }
}
