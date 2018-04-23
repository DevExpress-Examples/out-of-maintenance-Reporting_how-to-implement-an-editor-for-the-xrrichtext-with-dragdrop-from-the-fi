using System;
using System.Collections;
using System.Text;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Serialization;
using DevExpress.XtraReports.Native;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Drawing;
using RepCustomXRRichText.Design;

namespace RepCustomXRRichText.ControlsFamily {
	/// <summary>
	/// Summary description for CustomXRControl.
	/// </summary>
	/// 
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(CustomRichText))]
    [XRDesigner("RepCustomXRRichText.Design.CustomControlDesigner," + "RepCustomXRRichText")]
    public class CustomRichText: XRRichText {
		public CustomRichText() {
            Rtf = string.Empty;
		}

        [Editor(typeof(CustomRichTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string CustomTextEditor {
            get { return Rtf; }
            set { Rtf = value; }
		}
	}

    class CustomRichTextEditor : UITypeEditor {
        public CustomRichTextEditor() {

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }
        
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value) {
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            
            if(edSvc != null) {
                RepCustomXRRichText.RichTextEditorForm frm = new RepCustomXRRichText.RichTextEditorForm();

                frm.richTextBox1.Rtf = (context.Instance as XRRichText).Rtf;
                edSvc.ShowDialog(frm);
                return frm.richTextBox1.Rtf;
            }

            return value;
        }

    }

}
