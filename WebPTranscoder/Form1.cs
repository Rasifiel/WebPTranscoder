using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebPTranscoder {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void clipboard_ClipboardChanged(object sender, WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs e) {
      if (e.ContentType == WK.Libraries.SharpClipboardNS.SharpClipboard.ContentTypes.Files) {
        if (clipboard.ClipboardFiles.Count>1) {
          return;
        }
        string path = clipboard.ClipboardFile;
        if (!File.Exists(path)) {
          return;
        }
        FileStream fs = null;
        try {
          int retry = 0;
          while (fs == null) {
            try {
              fs = File.OpenRead(path);
              break;
            } catch (Exception) {
              // Do nothing
            }
            retry++;
            if (retry > 3) {
              return;
            }
            Task.Delay(100);
          }
          byte[] signature = new byte[12];
          int size = fs.Read(signature, 0, 12);
          if (size < 12) {
            return;
          }
          var expRIFF = new ArraySegment<byte>(signature, 0, 4).ToArray<byte>();
          var expWEBP = new ArraySegment<byte>(signature, 8, 4).ToArray<byte>();
          if (Encoding.ASCII.GetString(expRIFF) != "RIFF") {
            return;
          }
          if (Encoding.ASCII.GetString(expWEBP) != "WEBP") {
            return;
          }
          fs.Seek(0, SeekOrigin.Begin);
          byte[] content = new byte[fs.Length];
          fs.Read(content, 0, (int)fs.Length);
          ImageFactory imageFactory = new ImageFactory(false);
          string pngPath = Path.ChangeExtension(Path.GetTempFileName(), "png");
          try {
            imageFactory.Load(content).Format(new PngFormat()).Save(pngPath);
          } catch (Exception) {
            trayIcon.ShowBalloonTip(1000, "", "There was error while trying to open image.", ToolTipIcon.Error);
          }
          StringCollection resultCollection = new StringCollection {
            pngPath
          };
          Clipboard.SetFileDropList(resultCollection);
        } finally {
          if (fs != null) {
            fs.Close();
          }
        }
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      Application.Exit();
    }
  }
}
