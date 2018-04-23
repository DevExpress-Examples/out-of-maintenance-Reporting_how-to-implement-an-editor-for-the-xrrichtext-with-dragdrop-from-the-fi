Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.Serialization
Imports DevExpress.XtraReports.Native
Imports DevExpress.Utils.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports RepCustomXRRichText.ControlsFamily
Imports DevExpress.XtraReports.UserDesigner

Namespace RepCustomXRRichText.Design
	''' <summary>
	''' Summary description for CustomControlDesigner.
	''' </summary>
	Public Class CustomControlDesigner
		Inherits XRRichTextDesigner
		Public Shared MyCustomEditor As Integer = &H77

		Public Sub New()

		End Sub

		Public Overrides Sub Initialize(ByVal component As IComponent)
			MyBase.Initialize(component)
			Me.Verbs.Add(New DesignerVerb("MyCustomEditor", New EventHandler(AddressOf OnMyCustomEditor), New CommandID(New Guid(), MyCustomEditor)))

			Dim i As Integer = 0
			Do While i < Me.Verbs.Count
				Dim verb As XRDesignerVerb = (TryCast(Me.Verbs(i), XRDesignerVerb))

				If verb IsNot Nothing AndAlso verb.ReportCommand = ReportCommand.VerbEditText Then
					Me.Verbs.Remove(verb)
					Exit Do
				End If
				i += 1
			Loop

		End Sub

		Public Sub OnMyCustomEditor(ByVal sender As Object, ByVal e As EventArgs)
			Dim frm As New RepCustomXRRichText.RichTextEditorForm()

			frm.richTextBox1.Rtf = (TryCast(Me.Component, XRRichText)).Rtf
			frm.Owner = (TryCast(Me.ReportDesigner.RootReport.Tag, System.Windows.Forms.Form))
			AddHandler frm.FormClosed, AddressOf frm_FormClosed
			frm.Show()
		End Sub

		Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
			TryCast(Me.Component, XRRichText).Rtf = TryCast(sender, RepCustomXRRichText.RichTextEditorForm).richTextBox1.Rtf
			TryCast(Me.GetService(GetType(IBandViewInfoService)), IBandViewInfoService).UpdateView()
		End Sub

		Protected Overrides Sub RegisterActionLists(ByVal list As DesignerActionListCollection)
			MyBase.RegisterActionLists(list)
		End Sub
	End Class


End Namespace
