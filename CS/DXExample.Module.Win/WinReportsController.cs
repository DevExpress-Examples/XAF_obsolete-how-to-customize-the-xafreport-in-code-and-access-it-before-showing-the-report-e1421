using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Reports.Win;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.UserDesigner;

namespace DXExample.Module.Win {
    public class WinReportsController : ViewController {
        public WinReportsController() { }
        WinReportServiceController reportServiceController;
        protected override void OnActivated() {
            base.OnActivated();
            reportServiceController = Frame.GetController<WinReportServiceController>();
            reportServiceController.NewXafReportWizardShowing += new EventHandler<NewXafReportWizardShowingEventArgs>(WinReportsController_NewXafReportWizardShowing);
            reportServiceController.CustomShowPreview += new EventHandler<CustomShowPreviewEventArgs>(WinReportsController_CustomShowPreview);
        }

        void WinReportsController_NewXafReportWizardShowing(object sender, NewXafReportWizardShowingEventArgs args) {
            args.Handled = true;
            using (XRDesignFormEx form = new XRDesignFormEx()) {
                form.OpenReport(args.WizardParameters.Report);
                XtraReportWizardRunner wizard = new XtraReportWizardRunner(args.WizardParameters.Report);
                wizard.BeforeRun += delegate(object s, XRWizardRunnerBeforeRunEventArgs e) {
                    for (int i = 0; i < e.WizardPages.Count; i++) {
                        if (e.WizardPages[i] is WizPageWelcome) {
                            e.WizardPages[i] = new WizPageXafWelcome(wizard, Application, args.WizardParameters);
                            break;
                        }
                    }
                };
                args.WizardResult = wizard.Run();
                if (args.WizardResult == System.Windows.Forms.DialogResult.OK) {
                    MyReportData.InsertHeaderBand(args.WizardParameters.Report);
                }
            }
        }
        void WinReportsController_CustomShowPreview(object sender, CustomShowPreviewEventArgs e) {
            // Place your code here
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            reportServiceController.NewXafReportWizardShowing -= new EventHandler<NewXafReportWizardShowingEventArgs>(WinReportsController_NewXafReportWizardShowing);
            reportServiceController.CustomShowPreview -= new EventHandler<CustomShowPreviewEventArgs>(WinReportsController_CustomShowPreview);
        }
    }
}
