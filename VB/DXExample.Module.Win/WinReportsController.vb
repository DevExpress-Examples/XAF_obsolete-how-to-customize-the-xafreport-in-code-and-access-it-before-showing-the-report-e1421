Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Reports.Win
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UserDesigner

Namespace DXExample.Module.Win
    Public Class WinReportsController
        Inherits ViewController
        Public Sub New()
        End Sub
        Private reportServiceController As WinReportServiceController
        Protected Overloads Overrides Sub OnActivated()
            MyBase.OnActivated()
            reportServiceController = Frame.GetController(Of WinReportServiceController)()
            AddHandler reportServiceController.NewXafReportWizardShowing, AddressOf WinReportsController_NewXafReportWizardShowing
            AddHandler reportServiceController.CustomShowPreview, AddressOf WinReportsController_CustomShowPreview
        End Sub
        Private wizardShowingEventArgs As NewXafReportWizardShowingEventArgs
        Private Sub WinReportsController_NewXafReportWizardShowing(ByVal sender As Object, ByVal args As NewXafReportWizardShowingEventArgs)
            args.Handled = True
            wizardShowingEventArgs = args
            Using form As New XRDesignFormEx()
                form.OpenReport(args.WizardParameters.Report)
                Dim wizard As New XtraReportWizardRunner(args.WizardParameters.Report)
                AddHandler wizard.BeforeRun, AddressOf wizard_BeforeRun
                args.WizardResult = wizard.Run()
                If args.WizardResult = System.Windows.Forms.DialogResult.OK Then
                    MyReportData.InsertHeaderBand(args.WizardParameters.Report)
                End If
            End Using
        End Sub
        Private Sub wizard_BeforeRun(ByVal sender As Object, ByVal e As XRWizardRunnerBeforeRunEventArgs)
            For i As Integer = 0 To e.WizardPages.Count - 1
                If TypeOf e.WizardPages(i) Is WizPageWelcome Then
                    e.WizardPages(i) = New WizPageXafWelcome(CType(sender, XtraReportWizardRunner), Application, wizardShowingEventArgs.WizardParameters)
                    Exit For
                End If
            Next i
        End Sub
        Private Sub WinReportsController_CustomShowPreview(ByVal sender As Object, ByVal e As CustomShowPreviewEventArgs)
            ' Place your code here
        End Sub
        Protected Overloads Overrides Sub OnDeactivating()
            MyBase.OnDeactivating()
            RemoveHandler reportServiceController.NewXafReportWizardShowing, AddressOf WinReportsController_NewXafReportWizardShowing
            RemoveHandler reportServiceController.CustomShowPreview, AddressOf WinReportsController_CustomShowPreview
        End Sub
    End Class
End Namespace
