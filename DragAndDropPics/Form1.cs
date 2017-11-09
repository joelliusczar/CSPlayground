using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ComTypes = System.Runtime.InteropServices.ComTypes;
using System.IO;

namespace DragAndDropPics
{
    public partial class Form1 : Form
    {

        [DllImport("ole32.dll")]
        public static extern void ReleaseStgMedium([In, MarshalAs(UnmanagedType.Struct)] ref ComTypes.STGMEDIUM pmedium);

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("hi");
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                DLUsingURL(sender, e);
                
            }
            catch (Exception ex)
            {
                if (ex != null) { }
                MessageBox.Show("Arrrrrgggg!");
            }
        }

        private void DLUsingURL(object sender, DragEventArgs e)
        {
            string dragType = "UniformResourceLocator";
            if(e.Data.GetDataPresent(dragType))
            {
                MemoryStream dataStream = (MemoryStream)e.Data.GetData(dragType, true);
                StreamReader reader = new StreamReader(dataStream);
                string output = reader.ReadToEnd();
            }

        }

        private void PInvokeWay(object sender, DragEventArgs e)
        {
            int cfFormat = DataFormats.GetFormat(DataFormats.Text).Id;
            ComTypes.FORMATETC formatEtc;
            ComTypes.STGMEDIUM stgMedium;

            formatEtc = new ComTypes.FORMATETC
            {
                cfFormat = (short)cfFormat,
                dwAspect = ComTypes.DVASPECT.DVASPECT_CONTENT,
                lindex = -1,
                tymed = ComTypes.TYMED.TYMED_GDI
            };

            ((ComTypes.IDataObject)e.Data).GetData(ref formatEtc, out stgMedium);
            Bitmap remotingImage = Bitmap.FromHbitmap(stgMedium.unionmember);

            pictureBox1.Image = remotingImage;

            ReleaseStgMedium(ref stgMedium);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
