Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Reports.Win

Namespace DXExample.Module.Win
	Public Class WinReportsController
		Inherits ViewController
		Public Sub New()
		End Sub
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			AddHandler Frame.GetController(Of WinReportServiceController)().CustomShowPreview, AddressOf WinReportsController_CustomShowPreview
		End Sub
		Private Sub WinReportsController_CustomShowPreview(ByVal sender As Object, ByVal e As CustomShowPreviewEventArgs)
			' Place your code here
		End Sub
		Protected Overrides Overloads Sub OnDeactivating()
			MyBase.OnDeactivating()
			RemoveHandler Frame.GetController(Of WinReportServiceController)().CustomShowPreview, AddressOf WinReportsController_CustomShowPreview
		End Sub
	End Class
End Namespace
