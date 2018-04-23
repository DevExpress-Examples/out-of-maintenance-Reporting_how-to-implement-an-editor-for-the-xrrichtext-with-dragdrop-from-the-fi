Imports System
Imports System.Collections
Imports System.Text
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.Serialization
Imports DevExpress.XtraReports.Native
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.Drawing
Imports RepCustomXRRichText.Design

Namespace RepCustomXRRichText.ControlsFamily
    ''' <summary>
    ''' Summary description for CustomXRControl.
    ''' </summary>
    ''' 
    <ToolboxItem(True), ToolboxBitmap(GetType(CustomRichText)), XRDesigner("RepCustomXRRichText.Design.CustomControlDesigner," & "RepCustomXRRichText")> _
    Public Class CustomRichText
        Inherits XRRichText

        Public Sub New()
            Rtf = String.Empty
        End Sub

        <Editor(GetType(CustomRichTextEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Property CustomTextEditor() As String
            Get
                Return Rtf
            End Get
            Set(ByVal value As String)
                Rtf = value
            End Set
        End Property
    End Class

    Friend Class CustomRichTextEditor
        Inherits UITypeEditor

        Public Sub New()

        End Sub

        Public Overrides Function GetEditStyle(ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.Modal
        End Function

        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
            Dim edSvc As IWindowsFormsEditorService = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

            If edSvc IsNot Nothing Then
                Dim frm As New RepCustomXRRichText.RichTextEditorForm()

                frm.richTextBox1.Rtf = (TryCast(context.Instance, XRRichText)).Rtf
                edSvc.ShowDialog(frm)
                Return frm.richTextBox1.Rtf
            End If

            Return value
        End Function

    End Class

End Namespace
