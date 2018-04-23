using System;
using System.Collections;
using System.Text;
using System.Drawing;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraReports.Native;
using DevExpress.Utils.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using RepCustomXRRichText.ControlsFamily;
using DevExpress.XtraReports.UserDesigner;

namespace RepCustomXRRichText.Design {
	/// <summary>
	/// Summary description for CustomControlDesigner.
	/// </summary>
	public class CustomControlDesigner : XRRichTextDesigner {
        public static int MyCustomEditor = 0x77;
              
        public CustomControlDesigner() {
			
		}

        public override void Initialize(IComponent component) {
            base.Initialize(component);
            this.Verbs.Add(new DesignerVerb("MyCustomEditor", new EventHandler(OnMyCustomEditor), new CommandID(new Guid(), MyCustomEditor)));

            for (int i = 0; i < this.Verbs.Count; i++) {
                XRDesignerVerb verb = (this.Verbs[i] as XRDesignerVerb);

                if (verb != null && verb.ReportCommand == ReportCommand.VerbEditText) {
                    this.Verbs.Remove(verb);
                    break;
                }
            }

        }

        public void OnMyCustomEditor(Object sender, EventArgs e) {
            RepCustomXRRichText.RichTextEditorForm frm = new RepCustomXRRichText.RichTextEditorForm();

            frm.richTextBox1.Rtf = (this.Component as XRRichText).Rtf;
            frm.Owner = (this.ReportDesigner.RootReport.Tag as System.Windows.Forms.Form);
            frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frm_FormClosed);
            frm.Show();
        }

        void frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e) {
            (this.Component as XRRichText).Rtf = (sender as RepCustomXRRichText.RichTextEditorForm).richTextBox1.Rtf;
            (this.GetService(typeof(IBandViewInfoService)) as IBandViewInfoService).UpdateView();
        }

		protected override void RegisterActionLists(DesignerActionListCollection list) {
            base.RegisterActionLists(list);		
		}
	}

	
}
