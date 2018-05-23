Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp

Namespace DXExample.Module.Web
	Public Class WebReportsController
		Inherits ViewController
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(MyReportData)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler (CType(View.CurrentObject, MyReportData)).ReportCreated, AddressOf WinReportsController_ReportCreated
		End Sub
		Private Sub WinReportsController_ReportCreated(ByVal sender As Object, ByVal e As ReportCreatedEventArgs)
			' Place your code here
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler (CType(View.CurrentObject, MyReportData)).ReportCreated, AddressOf WinReportsController_ReportCreated
		End Sub
	End Class
End Namespace
