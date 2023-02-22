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

                    pictureBox.MouseDown += (sender, e) => {
                        if (sender is PictureBox pict) {
                            Image backgroundImage = pict.BackgroundImage;

                            pict.BackgroundImage = null;

                            // Outside of panel
                            if (backgroundImage != null && pict.DoDragDrop(backgroundImage, DragDropEffects.All) == DragDropEffects.None) {
                                pict.BackgroundImage = backgroundImage;
                            }
                        }
                    };

                    emptyBox.DragDrop += (sender, e) => {
                        if (sender is PictureBox pict) {
                            Image img = pict.BackgroundImage;

                            // Replace image with the new one
                            if (img != null) {
                                if (pict.Tag is PictureBox pb) {
                                    pict.BackgroundImage = (Image) e.Data.GetData(DataFormats.Bitmap);
                                    pb.BackgroundImage = img;
                                }
                            } else {
                                pict.BackgroundImage = (Image) e.Data.GetData(DataFormats.Bitmap);
                                pict.BorderStyle = BorderStyle.None;
                            }
                        }
                    };

                    emptyBox.DragEnter += (sender, e) => e.Effect = DragDropEffects.All;

                    draggableControls.Add(pictureBox);
                    resultControls.Add(emptyBox);
                }
            }
        }

        private string GetResourceFileByName(string name) {
            return string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), name);
        }
    }
}
