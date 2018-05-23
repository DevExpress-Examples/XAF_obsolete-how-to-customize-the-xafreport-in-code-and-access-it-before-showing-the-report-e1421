# OBSOLETE - How to customize the XafReport in code and access it before showing the Report Preview


<p><strong>================================</strong></p><p><strong>This example is now considered obsolete. Please refer to the following help topics to learn how to accomplish the headlined task:</strong><br />
<a href="http://documentation.devexpress.com/#Xaf/CustomDocument3243"><u>How to: Implement a Custom Report Class</u></a><u><br />
</u><a href="http://documentation.devexpress.com/#Xaf/DevExpressExpressAppReportsWinWinReportServiceController_CustomShowPreviewtopic"><u>WinReportServiceController.CustomShowPreview Event</u></a><br />
================================</p><p>This example demonstrates how to create a custom ReportData class to customize XAF Reports. The Header property will be added to the ReportData class, and the corresponding XRLabel control with the Header text will be created in the XafReport. Also, this example demonstrates how to access the XafReport via the ViewController before previewing it. This functionality may be useful, if you cannot access some information from the ReportData class.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E908">E908</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2108">E2108</a></p>


<h3>Description</h3>

<p>Since version 9.3, XAF supports the Report Wizard feature. Since the wizard creates report&#39;s controls from scratch based on the user&#39;s choice, it is necessary to customize XafReport after the wizard is finished. In this example, it is done via the WinReportServiceController.NewXafReportWizardShowing event.</p>

<br/>


