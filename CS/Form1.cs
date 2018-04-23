using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using RepCustomXRRichText.ControlsFamily;
using System.Drawing.Design;

namespace RepCustomXRRichText {

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            XtraReport report = new XtraReport();

            report.Bands.Add(new DetailBand());
            report.Bands[0].Controls.Add(new CustomRichText());

            report.DesignerLoaded += new DesignerLoadedEventHandler(report_DesignerLoaded);

            xrDesignPanel1.OpenReport(report);
            xrDesignPanel1.Report.DataSource = OwnerUtility.GetAllOwners();

            report.Tag = this;
        }

        void report_DesignerLoaded(object sender, DesignerLoadedEventArgs e) {
            IToolboxService tbs = (IToolboxService)xrDesignPanel1.GetService(typeof(IToolboxService));
            ToolboxItem tbi = new ToolboxItem(typeof(CustomRichText));

            tbi.DisplayName = "Custom Rich Text";
            tbs.AddToolboxItem(tbi, "Custom Controls");

            //Form form = new Form();
            //PictureBox p = new PictureBox();
            //p.Image = tbi.Bitmap;
            //form.Controls.Add(p);
            //p.Dock = DockStyle.Fill;
            //p.SizeMode = PictureBoxSizeMode.StretchImage;
            //form.ShowDialog();
        }
    }

    
    #region Owners and Pets DataSet creator
    public sealed class OwnerUtility
    {

        private OwnerUtility() { }

        public static OwnersDataSet GetAllOwners()
        {
            return new OwnersDataSet();
        }
    }
    #endregion Owners and Pets DataSet creator

    #region Owners and Pets DataSet
    public class OwnersDataSet : DataSet
    {
        public OwnersDataSet()
            : base()
        {
            DataTable owners = new DataTable("Owners");
            DataTable pets = new DataTable("Pets");

            DataSetName = "OwnersAndPets";

            owners.Columns.Add("ownerId", typeof(Int32));
            owners.Columns.Add("yearOfBirth", typeof(Int32));
            owners.Columns.Add("firstName", typeof(string));
            owners.Columns.Add("lastName", typeof(string));

            pets.Columns.Add("ownerId", typeof(Int32));
            pets.Columns.Add("petId", typeof(Int32));
            pets.Columns.Add("name", typeof(string));
            pets.Columns.Add("isNeutured", typeof(bool));
            pets.Columns.Add("type", typeof(PetType));

            Tables.AddRange(new DataTable[] { owners, pets });
            Relations.Add("OwnersPets", owners.Columns["ownerId"], pets.Columns["ownerId"]);

            owners.Rows.Add(new object[] { 1, 1950, "John", "Smith" });
            owners.Rows.Add(new object[] { 2, 1980, "Cathy", "Williams" });
            owners.Rows.Add(new object[] { 3, 1974, "Simon", "Iverson" });
            owners.Rows.Add(new object[] { 4, 1969, "Angie", "Young" });
            owners.Rows.Add(new object[] { 5, 1988, "Charles", "Adam" });
            owners.Rows.Add(new object[] { 6, 1920, "Michelle", "Jonson" });

            pets.Rows.Add(new object[] { 1, 2, "Smyth", true, PetType.Bird });
            pets.Rows.Add(new object[] { 1, 7, "Smyth2", true, PetType.Bird });
            pets.Rows.Add(new object[] { 1, 8, "Jaidan", false, PetType.Cat });

            pets.Rows.Add(new object[] { 2, 1, "Goldie", false, PetType.Fish });
            pets.Rows.Add(new object[] { 2, 3, "Willow", true, PetType.Rodent });

            pets.Rows.Add(new object[] { 3, 4, "Surge", true, PetType.Dog });

            pets.Rows.Add(new object[] { 4, 5, "Jumbo", true, PetType.Cat });
            pets.Rows.Add(new object[] { 4, 10, "Pat", true, PetType.Cat });
            pets.Rows.Add(new object[] { 4, 11, "Mike", false, PetType.Fish });
            pets.Rows.Add(new object[] { 4, 113, "Bill", false, PetType.Fish });

            pets.Rows.Add(new object[] { 5, 12, "Pete", false, PetType.Bird });
            pets.Rows.Add(new object[] { 5, 17, "Rufus", true, PetType.Dog });
        }

        #region Disable Serialization for Tables and Relations
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables
        {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations
        {
            get { return base.Relations; }
        }
        #endregion Disable Serialization for Tables and Relations
    }

    public enum PetType
    {
        Dog = 1,
        Cat = 2,
        Fish = 3,
        Bird = 4,
        Rodent = 5,
        Other = 6
    }
    #endregion Owners and Pets DataSet
        
}