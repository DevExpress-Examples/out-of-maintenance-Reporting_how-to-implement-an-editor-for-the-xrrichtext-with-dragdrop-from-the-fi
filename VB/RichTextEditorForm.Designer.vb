Imports Microsoft.VisualBasic
Imports System
Namespace RepCustomXRRichText
	Partial Public Class RichTextEditorForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.SuspendLayout()
			' 
			' richTextBox1
			' 
			Me.richTextBox1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.richTextBox1.Location = New System.Drawing.Point(12, 12)
			Me.richTextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.Size = New System.Drawing.Size(268, 235)
			Me.richTextBox1.TabIndex = 0
			Me.richTextBox1.Text = ""
			' 
			' RichTextEditorForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(292, 260)
			Me.Controls.Add(Me.richTextBox1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "RichTextEditorForm"
			Me.Text = "RichTextEditorForm"
'			Me.Load += New System.EventHandler(Me.RichTextEditorForm_Load);
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public richTextBox1 As System.Windows.Forms.RichTextBox


	End Class
End Namespace