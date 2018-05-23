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
        public override XafReport LoadXtraReport(IObjectSpace objectSpace) {
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
            InsertHeaderBand(report);
            return report;
        }
        public static void InsertHeaderBand(XafReport report) {
            XRLabel label = new XRLabel();
            label.Name = HeaderLabelName;
            PageHeaderBand band = report.Bands[BandKind.PageHeader] as PageHeaderBand;
            if (band == null) {
                band = new PageHeaderBand();
                report.Bands.Add(band);
            } else {
                foreach (XRControl control in band.Controls) {
                    control.LocationF = new System.Drawing.PointF(control.LocationF.X, control.LocationF.Y + label.HeightF + 10);
                }
            }
            band.Controls.Add(label);
            int pageWidth = report.PageWidth - report.Margins.Left - report.Margins.Right;
            label.Location = new System.Drawing.Point((pageWidth - label.Width) / 2, 0);
            band.HeightF = label.BottomF;
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
