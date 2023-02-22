using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BasicPuzzle {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            int size = 80;

            Control.ControlCollection draggableControls = draggablePanel.Controls;
            Control.ControlCollection resultControls = resultPanel.Controls;

            for (int i = 0; i < 4; i++) {
                for (int a = 0; a < 4; a++) {
                    PictureBox pictureBox = new PictureBox() {
                        BackgroundImage = Image.FromFile(GetResourceFileByName($"mountains2-{i}-{a}.png")),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Bounds = new Rectangle(a * size, i * size, size, size),
                        Cursor = Cursors.Hand
                    };

                    PictureBox emptyBox = new PictureBox() {
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Bounds = pictureBox.Bounds,
                        BorderStyle = BorderStyle.FixedSingle,
                        AllowDrop = true,
                        Tag = pictureBox
                    };

                    pictureBox.MouseDown += MouseDownEvent;
                    emptyBox.DragDrop += DragDropEvent;
                    emptyBox.DragEnter += DragEnterEvent;

                    draggableControls.Add(pictureBox);
                    resultControls.Add(emptyBox);
                }
            }
        }

        private void MouseDownEvent(object sender, MouseEventArgs e) {
            if (sender is PictureBox pict) {
                pict.Hide();

                if (pict.DoDragDrop(pict.BackgroundImage, DragDropEffects.All) == DragDropEffects.None) {
                    pict.Show();
                }
            }
        }

        private void DragDropEvent(object sender, DragEventArgs e) {
            if (sender is PictureBox pict) {
                pict.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
                pict.BorderStyle = BorderStyle.None;

                if (pict.Tag is PictureBox sec) {
                    sec.Hide();
                    sec.Tag = null;
                    pict.Tag = sec;
                }
            }
        }

        private void DragEnterEvent(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }

        private string GetResourceFileByName(string name) {
            return string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), name);
        }
    }
}
