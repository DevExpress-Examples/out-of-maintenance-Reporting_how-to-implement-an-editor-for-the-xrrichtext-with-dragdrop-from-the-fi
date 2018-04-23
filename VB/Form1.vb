Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner
Imports RepCustomXRRichText.ControlsFamily
Imports System.Drawing.Design

Namespace RepCustomXRRichText

	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim report As New XtraReport()

			report.Bands.Add(New DetailBand())
			report.Bands(0).Controls.Add(New CustomRichText())

			AddHandler report.DesignerLoaded, AddressOf report_DesignerLoaded

			xrDesignPanel1.OpenReport(report)
			xrDesignPanel1.Report.DataSource = OwnerUtility.GetAllOwners()

			report.Tag = Me
		End Sub

		Private Sub report_DesignerLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
			Dim tbs As IToolboxService = CType(xrDesignPanel1.GetService(GetType(IToolboxService)), IToolboxService)
			Dim tbi As New ToolboxItem(GetType(CustomRichText))

			tbi.DisplayName = "Custom Rich Text"
			tbs.AddToolboxItem(tbi, "Custom Controls")

			'Form form = new Form();
			'PictureBox p = new PictureBox();
			'p.Image = tbi.Bitmap;
			'form.Controls.Add(p);
			'p.Dock = DockStyle.Fill;
			'p.SizeMode = PictureBoxSizeMode.StretchImage;
			'form.ShowDialog();
		End Sub
	End Class


	#Region "Owners and Pets DataSet creator"
	Public NotInheritable Class OwnerUtility

		Private Sub New()
		End Sub

		Public Shared Function GetAllOwners() As OwnersDataSet
			Return New OwnersDataSet()
		End Function
	End Class
	#End Region ' Owners and Pets DataSet creator

	#Region "Owners and Pets DataSet"
	Public Class OwnersDataSet
		Inherits DataSet
		Public Sub New()
			MyBase.New()
			Dim owners As New DataTable("Owners")
			Dim pets As New DataTable("Pets")

			DataSetName = "OwnersAndPets"

			owners.Columns.Add("ownerId", GetType(Int32))
			owners.Columns.Add("yearOfBirth", GetType(Int32))
			owners.Columns.Add("firstName", GetType(String))
			owners.Columns.Add("lastName", GetType(String))

			pets.Columns.Add("ownerId", GetType(Int32))
			pets.Columns.Add("petId", GetType(Int32))
			pets.Columns.Add("name", GetType(String))
			pets.Columns.Add("isNeutured", GetType(Boolean))
			pets.Columns.Add("type", GetType(PetType))

			Tables.AddRange(New DataTable() { owners, pets })
			Relations.Add("OwnersPets", owners.Columns("ownerId"), pets.Columns("ownerId"))

			owners.Rows.Add(New Object() { 1, 1950, "John", "Smith" })
			owners.Rows.Add(New Object() { 2, 1980, "Cathy", "Williams" })
			owners.Rows.Add(New Object() { 3, 1974, "Simon", "Iverson" })
			owners.Rows.Add(New Object() { 4, 1969, "Angie", "Young" })
			owners.Rows.Add(New Object() { 5, 1988, "Charles", "Adam" })
			owners.Rows.Add(New Object() { 6, 1920, "Michelle", "Jonson" })

			pets.Rows.Add(New Object() { 1, 2, "Smyth", True, PetType.Bird })
			pets.Rows.Add(New Object() { 1, 7, "Smyth2", True, PetType.Bird })
			pets.Rows.Add(New Object() { 1, 8, "Jaidan", False, PetType.Cat })

			pets.Rows.Add(New Object() { 2, 1, "Goldie", False, PetType.Fish })
			pets.Rows.Add(New Object() { 2, 3, "Willow", True, PetType.Rodent })

			pets.Rows.Add(New Object() { 3, 4, "Surge", True, PetType.Dog })

			pets.Rows.Add(New Object() { 4, 5, "Jumbo", True, PetType.Cat })
			pets.Rows.Add(New Object() { 4, 10, "Pat", True, PetType.Cat })
			pets.Rows.Add(New Object() { 4, 11, "Mike", False, PetType.Fish })
			pets.Rows.Add(New Object() { 4, 113, "Bill", False, PetType.Fish })

			pets.Rows.Add(New Object() { 5, 12, "Pete", False, PetType.Bird })
			pets.Rows.Add(New Object() { 5, 17, "Rufus", True, PetType.Dog })
		End Sub

		#Region "Disable Serialization for Tables and Relations"
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Tables() As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Relations() As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property
		#End Region ' Disable Serialization for Tables and Relations
	End Class

	Public Enum PetType
		Dog = 1
		Cat = 2
		Fish = 3
		Bird = 4
		Rodent = 5
		Other = 6
	End Enum
	#End Region ' Owners and Pets DataSet

End Namespace