Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Reports
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace DXExample.Module
	Public Class MyReportData
		Inherits ReportData
		Private Const HeaderLabelName As String = "HeaderLabel"
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Overrides Function LoadXtraReport(ByVal objectSpace As ObjectSpace) As XafReport
			Dim report As XafReport = MyBase.LoadXtraReport(objectSpace)
			Dim label As XRLabel = TryCast(report.FindControl(HeaderLabelName, False), XRLabel)
			If label IsNot Nothing Then
				label.Text = Header
			End If
			RaiseEvent ReportCreated(Me, New ReportCreatedEventArgs(report))
			Return report
		End Function
		Protected Overrides Function CreateReport() As XafReport
			Dim report As XafReport = MyBase.CreateReport()
			Dim label As New XRLabel()
			label.Name = HeaderLabelName
			report.Bands(BandKind.PageHeader).Controls.Add(label)
			Dim pageWidth As Integer = report.PageWidth - report.Margins.Left - report.Margins.Right
			label.Location = New System.Drawing.Point((pageWidth - label.Width) / 2, 10)
			Return report
		End Function
		Private _Header As String
		Public Property Header() As String
			Get
				Return _Header
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Header", _Header, value)
			End Set
		End Property
		<Browsable(False)> _
		Public Event ReportCreated As EventHandler(Of ReportCreatedEventArgs)
	End Class
	Public Class ReportCreatedEventArgs
		Inherits EventArgs
		Private report_Renamed As XafReport
		Public Sub New(ByVal report As XafReport)
			Me.report_Renamed = report
		End Sub
		Public ReadOnly Property Report() As XafReport
			Get
				Return report_Renamed
			End Get
		End Property
	End Class
End Namespace
