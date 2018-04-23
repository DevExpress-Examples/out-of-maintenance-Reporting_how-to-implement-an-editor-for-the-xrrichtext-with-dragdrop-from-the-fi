Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Data.Browsing

Namespace RepCustomXRRichText
    Partial Public Class RichTextEditorForm
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub RichTextEditorForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            richTextBox1.AllowDrop = True
            AddHandler richTextBox1.DragEnter, AddressOf richTextBox1_DragEnter
            AddHandler richTextBox1.DragOver, AddressOf richTextBox1_DragOver
            AddHandler richTextBox1.DragDrop, AddressOf richTextBox1_DragDrop
        End Sub

        Private Sub richTextBox1_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data.GetData(GetType(DataInfo())) IsNot Nothing Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End Sub

        Private Sub richTextBox1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data.GetData(GetType(DataInfo())) IsNot Nothing Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End Sub

        Private Sub richTextBox1_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
            Dim droppedData As DataInfo = DirectCast(e.Data.GetData(GetType(DataInfo())), DataInfo())(0)

            richTextBox1.SelectedText = "[" & droppedData.Member & "]"
        End Sub

    End Class
End Namespace