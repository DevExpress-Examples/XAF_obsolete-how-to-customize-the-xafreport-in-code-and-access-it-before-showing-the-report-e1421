Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Reports.Win

Namespace DXExample.Module.Win
	Public Class WinReportsController
		Inherits ReportsController
		Public Sub New()
		End Sub
		Protected Overrides Sub ExecuteReport(ByVal showViewParameters As ShowViewParameters, ByVal reportDataKey As Object)
			Dim reportData As MyReportData = ObjectSpace.GetObjectByKey(Of MyReportData)(reportDataKey)
			If reportData IsNot Nothing Then
				AddHandler reportData.ReportCreated, AddressOf reportData_ReportCreated
			End If
			MyBase.ExecuteReport(showViewParameters, reportDataKey)
		End Sub
		Private Sub reportData_ReportCreated(ByVal sender As Object, ByVal e As ReportCreatedEventArgs)
			' Place your code here
		End Sub
	End Class
End Namespace
