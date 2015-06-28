using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SRD.Utils;
using System.Drawing.Imaging;
using System.IO;

namespace SRD
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        string filename;
        Bitmap SRDBitmap;
        Bitmap SRDTresholdBitmap;

        int R1area;
        int R2area;

        int[,] originalSRDMatrix;
        int[,] SRDMatrix;
        int[,] SRDMatrixTreshold;

        Bitmap imageTMP = null;
        Bitmap SRDTmpBMP = null;
        Bitmap SRDThresholdTMP = null;

        string previousliClicked = "";

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string filename)
        {
            InitializeComponent();

            //MenuItem markAllBeneath = new MenuItem("Mark all pixels beneath");
            //markAllBeneath.Click += new EventHandler(markAllBeneath_Click);
            //ContextMenu SRDImageContextMenu = new ContextMenu();
            //SRDImageContextMenu.MenuItems.Add(markAllBeneath);
            //pictureBoxExtended2.ContextMenu = SRDImageContextMenu;


            try
            {
                imageTMP = null;
                SRDTmpBMP = null;
                SRDThresholdTMP = null;
                previousliClicked = "";

                bm = new Bitmap(filename);
                pictureBoxExtended1.Image = bm;

                SRD(bm, Int32.Parse(w1textBox.Text), Int32.Parse(w2textBox.Text), Int32.Parse(w3textBox.Text), Int32.Parse(qtextBox.Text));

                pictureBoxExtended2.Image = SRDBitmap;
                pictureBoxExtended3.Image = SRDTresholdBitmap;

                infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                clickedPointLabel.Text = "";
                SRDclickedPointLabel.Text = "";

                resizeImages();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
                MessageBox.Show(ex.StackTrace);
            }
        }

        //void markAllBeneath_Click(object sender, EventArgs e)
        //{
        //    int y = clicedPoint.Y;
        //}

        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageTMP = null;
                    SRDTmpBMP = null;
                    SRDThresholdTMP = null;
                    previousliClicked = "";

                    bm = new Bitmap(ofd.FileName);
                    filename = ofd.SafeFileName;

                    pictureBoxExtended1.Image = bm;

                    SRD(bm, Int32.Parse(w1textBox.Text), Int32.Parse(w2textBox.Text), Int32.Parse(w3textBox.Text), Int32.Parse(qtextBox.Text));

                    pictureBoxExtended2.Image = SRDBitmap;
                    pictureBoxExtended3.Image = SRDTresholdBitmap;

                    infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                    clickedPointLabel.Text = "";
                    SRDclickedPointLabel.Text = "";

                    resizeImages();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }

        }

        byte[,] imbyte;

        public void SRD(Bitmap image, int w1, int w2, int w3, int q)
        {

            R2area = w3 * w3 - w2 * w2 + 1;
            R1area = w2 * w2 - w1 * w1 + 1;

            int imwith = image.Width;
            int imheight = image.Height;

            //-------------
            imbyte = new byte[imwith, imheight];

            unsafe
            {
                BitmapData bd = image.LockBits(new Rectangle(0, 0, imwith, imheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                IntPtr ip = bd.Scan0;
                int* Pixels = (int*)ip;
                int stride = bd.Stride;

                int u;

                for (int i = 0; i < imwith; i++)
                {
                    for (int j = 0; j < imheight; j++)
                    {
                        u = Pixels[i + j * stride / 4];
                        imbyte[i, j] = Color.FromArgb(u).R;
                    }
                }

                image.UnlockBits(bd);
            }
            //-------------

            SRDMatrix = new int[R1area, R2area];

            int R1i = 0;
            int R2i = 0;
            byte centervalue = 0;

            for (int i = (w3 - 1) / 2; i < imwith - (w3 - 1) / 2; i++)
            {
                for (int j = (w3 - 1) / 2; j < imheight - (w3 - 1) / 2; j++)
                {

                    R1i = 0;
                    R2i = 0;

                    centervalue = imbyte[i, j];

                    for (int t = -((w3 - 1) / 2); t <= (w3 - 1) / 2; t++)
                    {
                        for (int z = -((w3 - 1) / 2); z <= (w3 - 1) / 2; z++)
                        {
                            if (centervalue - imbyte[i + t, j + z] > q)
                            {
                                if (Math.Abs(t) > (w2 - 1) / 2 || Math.Abs(z) > (w2 - 1) / 2)
                                {
                                    R2i++;
                                }
                                else if (Math.Abs(t) > (w1 - 1) / 2 || Math.Abs(z) > (w1 - 1) / 2)
                                {
                                    R1i++;
                                }
                            }
                        }
                    }

                    SRDMatrix[R1i, R2i]++;
                }
            }

            originalSRDMatrix = (int[,])SRDMatrix.Clone();

            int maskwidth = Int32.Parse(maskWidthTextBox.Text);
            int maskheight = Int32.Parse(maskHeightTextBox.Text);

            for (int i = 0; i < maskwidth; i++)
            {
                for (int j = 0; j < maskheight; j++)
                {
                    SRDMatrix[i, j] = 0;
                }
            }

            SRDMatrix.normalize(255);

            SRDBitmap = new Bitmap(R1area, R2area);
            SRDBitmap.fromArray(SRDMatrix);

            SRDTresholdBitmap = new Bitmap(R1area, R2area);
            SRDMatrixTreshold = SRDMatrix.UpperTreshold(Int32.Parse(thresholdTextBox.Text));

            SRDTresholdBitmap.fromArray(SRDMatrixTreshold);
        }

        public void SRD(Bitmap image, int w1, int w2, int w3, int q, int beneathY)
        {

            R2area = w3 * w3 - w2 * w2 + 1;
            R1area = w2 * w2 - w1 * w1 + 1;

            int imwith = image.Width;
            int imheight = image.Height;

            //-------------
            imbyte = new byte[imwith, imheight];

            unsafe
            {
                BitmapData bd = image.LockBits(new Rectangle(0, 0, imwith, imheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                IntPtr ip = bd.Scan0;
                int* Pixels = (int*)ip;
                int stride = bd.Stride;

                int u;

                for (int i = 0; i < imwith; i++)
                {
                    for (int j = 0; j < imheight; j++)
                    {
                        u = Pixels[i + j * stride / 4];
                        imbyte[i, j] = Color.FromArgb(u).R;
                    }
                }

                image.UnlockBits(bd);
            }
            //-------------

            imageTMP = (Bitmap)image.Clone();

            SRDMatrix = new int[R1area, R2area];

            int R1i = 0;
            int R2i = 0;
            byte centervalue = 0;

            for (int i = (w3 - 1) / 2; i < imwith - (w3 - 1) / 2; i++)
            {
                for (int j = (w3 - 1) / 2; j < imheight - (w3 - 1) / 2; j++)
                {

                    R1i = 0;
                    R2i = 0;

                    centervalue = imbyte[i, j];

                    for (int t = -((w3 - 1) / 2); t <= (w3 - 1) / 2; t++)
                    {
                        for (int z = -((w3 - 1) / 2); z <= (w3 - 1) / 2; z++)
                        {
                            if (centervalue - imbyte[i + t, j + z] > q)
                            {
                                if (Math.Abs(t) > (w2 - 1) / 2 || Math.Abs(z) > (w2 - 1) / 2)
                                {
                                    R2i++;
                                }
                                else if (Math.Abs(t) > (w1 - 1) / 2 || Math.Abs(z) > (w1 - 1) / 2)
                                {
                                    R1i++;
                                }
                            }
                        }
                    }

                    if (R2i >= beneathY)
                        imageTMP.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));

                    SRDMatrix[R1i, R2i]++;
                }
            }

            pictureBoxExtended1.Image = imageTMP;

            originalSRDMatrix = (int[,])SRDMatrix.Clone();

            int maskwidth = Int32.Parse(maskWidthTextBox.Text);
            int maskheight = Int32.Parse(maskHeightTextBox.Text);

            for (int i = 0; i < maskwidth; i++)
            {
                for (int j = 0; j < maskheight; j++)
                {
                    SRDMatrix[i, j] = 0;
                }
            }

            SRDMatrix.normalize(255);

            SRDBitmap = new Bitmap(R1area, R2area);
            SRDBitmap.fromArray(SRDMatrix, beneathY);

            SRDTresholdBitmap = new Bitmap(R1area, R2area);
            SRDMatrixTreshold = SRDMatrix.UpperTreshold(Int32.Parse(thresholdTextBox.Text));

            SRDTresholdBitmap.fromArray(SRDMatrixTreshold, beneathY);
        }

        public void SRD(Bitmap image, int w1, int w2, int w3, int q, Point mouseDownP, Point mouseUpP)
        {

            R2area = w3 * w3 - w2 * w2 + 1;
            R1area = w2 * w2 - w1 * w1 + 1;

            int imwith = image.Width;
            int imheight = image.Height;

            //-------------
            imbyte = new byte[imwith, imheight];

            unsafe
            {
                BitmapData bd = image.LockBits(new Rectangle(0, 0, imwith, imheight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                IntPtr ip = bd.Scan0;
                int* Pixels = (int*)ip;
                int stride = bd.Stride;

                int u;

                for (int i = 0; i < imwith; i++)
                {
                    for (int j = 0; j < imheight; j++)
                    {
                        u = Pixels[i + j * stride / 4];
                        imbyte[i, j] = Color.FromArgb(u).R;
                    }
                }

                image.UnlockBits(bd);
            }
            //-------------

            imageTMP = (Bitmap)image.Clone();

            SRDMatrix = new int[R1area, R2area];

            int R1i = 0;
            int R2i = 0;
            byte centervalue = 0;

            for (int i = (w3 - 1) / 2; i < imwith - (w3 - 1) / 2; i++)
            {
                for (int j = (w3 - 1) / 2; j < imheight - (w3 - 1) / 2; j++)
                {

                    R1i = 0;
                    R2i = 0;

                    centervalue = imbyte[i, j];

                    for (int t = -((w3 - 1) / 2); t <= (w3 - 1) / 2; t++)
                    {
                        for (int z = -((w3 - 1) / 2); z <= (w3 - 1) / 2; z++)
                        {
                            if (centervalue - imbyte[i + t, j + z] > q)
                            {
                                if (Math.Abs(t) > (w2 - 1) / 2 || Math.Abs(z) > (w2 - 1) / 2)
                                {
                                    R2i++;
                                }
                                else if (Math.Abs(t) > (w1 - 1) / 2 || Math.Abs(z) > (w1 - 1) / 2)
                                {
                                    R1i++;
                                }
                            }
                        }
                    }

                    if (mouseDownP.Y < R2i && R2i < mouseUpP.Y && mouseDownP.X < R1i && R1i < mouseUpP.X)
                    {
                        imageTMP.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));
                    }
                    //if (R2i >= beneathY)
                    //    imageTMP.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));

                    SRDMatrix[R1i, R2i]++;
                }
            }

            pictureBoxExtended1.Image = imageTMP;

            originalSRDMatrix = (int[,])SRDMatrix.Clone();

            int maskwidth = Int32.Parse(maskWidthTextBox.Text);
            int maskheight = Int32.Parse(maskHeightTextBox.Text);

            for (int i = 0; i < maskwidth; i++)
            {
                for (int j = 0; j < maskheight; j++)
                {
                    SRDMatrix[i, j] = 0;
                }
            }

            SRDMatrix.normalize(255);

            SRDBitmap = new Bitmap(R1area, R2area);
            SRDBitmap.fromArray(SRDMatrix, mouseDownP, mouseUpP);

            SRDTresholdBitmap = new Bitmap(R1area, R2area);
            SRDMatrixTreshold = SRDMatrix.UpperTreshold(Int32.Parse(thresholdTextBox.Text));

            SRDTresholdBitmap.fromArray(SRDMatrixTreshold, mouseDownP, mouseUpP);
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void pictureBoxExtended1_Click(object sender, EventArgs e)
        {
            try
            {
                Point p = pictureBoxExtended1.MousePositionOnImage;

                int w1 = Int32.Parse(w1textBox.Text);
                int w2 = Int32.Parse(w2textBox.Text);
                int w3 = Int32.Parse(w3textBox.Text);
                int q = Int32.Parse(qtextBox.Text);

                if (p.X > ((w3 - 1) / 2) && p.Y > ((w3 - 1) / 2) && p.X < bm.Width - ((w3 - 1) / 2) && p.Y < bm.Height - ((w3 - 1) / 2))
                {
                    clickedPointLabel.Text = string.Format("Clicked point: x={0}, y={1}", p.X, p.Y);
                    clickedPointLabel.Invalidate();

                    byte centervalue = 0;

                    int i = p.X;
                    int j = p.Y;

                    Bitmap image = bm;

                    int R1i = 0;
                    int R2i = 0;

                    centervalue = imbyte[i, j];

                    for (int t = -((w3 - 1) / 2); t <= (w3 - 1) / 2; t++)
                    {
                        for (int z = -((w3 - 1) / 2); z <= (w3 - 1) / 2; z++)
                        {
                            if (centervalue - imbyte[i + t, j + z] > q)
                            {
                                if (Math.Abs(t) > (w2 - 1) / 2 || Math.Abs(z) > (w2 - 1) / 2)
                                {
                                    R2i++;
                                }
                                else if (Math.Abs(t) > (w1 - 1) / 2 || Math.Abs(z) > (w1 - 1) / 2)
                                {
                                    R1i++;
                                }
                            }
                        }
                    }

                    if (previousliClicked != "original")
                    {
                        imageTMP = (Bitmap)image.Clone();
                        SRDTmpBMP = (Bitmap)SRDBitmap.Clone();
                        SRDThresholdTMP = (Bitmap)SRDTresholdBitmap.Clone();
                    }

                    if (Control.ModifierKeys == Keys.Control)
                    {
                        if (imageTMP == null)
                            imageTMP = (Bitmap)image.Clone();

                        imageTMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended1.Image = imageTMP;

                        if (SRDTmpBMP == null)
                            SRDTmpBMP = (Bitmap)SRDBitmap.Clone();

                        SRDTmpBMP.SetPixel(R1i, R2i, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended2.Image = SRDTmpBMP;

                        if (SRDThresholdTMP == null)
                            SRDThresholdTMP = (Bitmap)SRDTresholdBitmap.Clone();

                        SRDThresholdTMP.SetPixel(R1i, R2i, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended3.Image = SRDThresholdTMP;
                    }
                    else
                    {
                        imageTMP = (Bitmap)image.Clone();
                        SRDTmpBMP = (Bitmap)SRDBitmap.Clone();
                        SRDThresholdTMP = (Bitmap)SRDTresholdBitmap.Clone();

                        imageTMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended1.Image = imageTMP;

                        SRDTmpBMP.SetPixel(R1i, R2i, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended2.Image = SRDTmpBMP;

                        SRDThresholdTMP.SetPixel(R1i, R2i, Color.FromArgb(255, 255, 0, 0));
                        pictureBoxExtended3.Image = SRDThresholdTMP;
                    }

                    previousliClicked = "original";
                }
                else
                {
                    clickedPointLabel.Text = string.Format("Clicked point was out of range");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void recountButton_Click(object sender, EventArgs e)
        {
            try
            {
                SRD(bm, Int32.Parse(w1textBox.Text), Int32.Parse(w2textBox.Text), Int32.Parse(w3textBox.Text), Int32.Parse(qtextBox.Text));

                pictureBoxExtended2.Image = SRDBitmap;
                pictureBoxExtended3.Image = SRDTresholdBitmap;

                infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                clickedPointLabel.Text = "";
                SRDclickedPointLabel.Text = "";

                resizeImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void parameterDeterminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parameterDeterminationBackgroundWorker.RunWorkerAsync();
            parameterDeterminationBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(parameterDeterminationBackgroundWorker_RunWorkerCompleted);
        }

        void parameterDeterminationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            new ParamSettings(paramsettings).Show();
        }

        List<ParameterSettings> paramsettings = new List<ParameterSettings>();

        private void parameterDeterminationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int loopcounter = 0;
                for (int i = 3; i < 12; i += 2)
                {
                    for (int j = 7; j < 14; j += 2)
                    {
                        for (int k = 11; k < 18; k += 2)
                        {
                            if (i < j && j < k)
                            {
                                SRD(bm, i, j, k, Int32.Parse(qtextBox.Text));

                                pictureBoxExtended2.Image = SRDBitmap;
                                pictureBoxExtended3.Image = SRDTresholdBitmap;

                                //infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                                //clickedPointLabel.Text = "";
                                //SRDclickedPointLabel.Text = "";


                                int counter = 0;
                                for (int l = 0; l < SRDMatrix.GetLength(0); l++)
                                {
                                    for (int m = SRDMatrix.GetLength(1) / 2; m < SRDMatrix.GetLength(1); m++)
                                    {
                                        if (SRDMatrix[l, m] > 0)
                                            counter++;
                                    }
                                }

                                double overlap = Math.Round((double)counter / ((double)SRDMatrix.GetLength(0) * (double)SRDMatrix.GetLength(1) / 2d), 2);

                                paramsettings.Add(new ParameterSettings() { W1 = i, W2 = j, W3 = k, Overlap = overlap });

                                loopcounter++;
                                parameterDeterminationBackgroundWorker.ReportProgress(loopcounter);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Exception");
            }
        }

        private void parameterDeterminationBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            try
            {
                resizeImages();
            }
            catch (Exception)
            {

            }
        }

        private void pictureBoxExtended2_Click(object sender, EventArgs e)
        {
            try
            {
                Point p = pictureBoxExtended2.MousePositionOnImage;

                int pixelConter = srdClickProcessing(ref p);

                SRDclickedPointLabel.Text = string.Format("Clicked point: x={0}, y={1}\nMatching pixels on the original image: {2}", p.X, p.Y, pixelConter);
                previousliClicked = "SRD";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void pictureBoxExtended3_Click(object sender, EventArgs e)
        {
            try
            {
                Point p = pictureBoxExtended3.MousePositionOnImage;

                int pixelConter = srdClickProcessing(ref p);

                SRDclickedPointLabel.Text = string.Format("Clicked point: x={0}, y={1}\nMatching pixels on the original image: {2}", p.X, p.Y, pixelConter);
                previousliClicked = "thresholdedSRD";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private int srdClickProcessing(ref Point p)
        {
            if (imageTMP == null)
                imageTMP = (Bitmap)bm.Clone();

            if (Control.ModifierKeys != Keys.Control)
            {
                imageTMP = (Bitmap)bm.Clone();
            }

            int w1 = Int32.Parse(w1textBox.Text);
            int w2 = Int32.Parse(w2textBox.Text);
            int w3 = Int32.Parse(w3textBox.Text);
            int q = Int32.Parse(qtextBox.Text);

            int R1i = 0;
            int R2i = 0;
            byte centervalue = 0;


            int imwith = bm.Width;
            int imheight = bm.Height;

            int pixelConter = 0;
            for (int i = (w3 - 1) / 2; i < imwith - (w3 - 1) / 2; i++)
            {
                for (int j = (w3 - 1) / 2; j < imheight - (w3 - 1) / 2; j++)
                {

                    R1i = 0;
                    R2i = 0;

                    centervalue = imbyte[i, j];

                    for (int t = -((w3 - 1) / 2); t <= (w3 - 1) / 2; t++)
                    {
                        for (int z = -((w3 - 1) / 2); z <= (w3 - 1) / 2; z++)
                        {
                            if (centervalue - imbyte[i + t, j + z] > q)
                            {
                                if (Math.Abs(t) > (w2 - 1) / 2 || Math.Abs(z) > (w2 - 1) / 2)
                                {
                                    R2i++;
                                }
                                else if (Math.Abs(t) > (w1 - 1) / 2 || Math.Abs(z) > (w1 - 1) / 2)
                                {
                                    R1i++;
                                }
                            }
                        }
                    }

                    if (p.X == R1i && p.Y == R2i)
                    {
                        imageTMP.SetPixel(i, j, Color.FromArgb(255, 255, 0, 0));
                        pixelConter++;
                    }
                }
            }

            if (Control.ModifierKeys == Keys.Control)
            {
                if (SRDTmpBMP == null)
                    SRDTmpBMP = (Bitmap)SRDBitmap.Clone();

                if (SRDThresholdTMP == null)
                    SRDThresholdTMP = (Bitmap)SRDTresholdBitmap.Clone();

                pictureBoxExtended1.Image = imageTMP;

                SRDTmpBMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                pictureBoxExtended2.Image = SRDTmpBMP;

                SRDThresholdTMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                pictureBoxExtended3.Image = SRDThresholdTMP;
            }
            else
            {
                SRDTmpBMP = (Bitmap)SRDBitmap.Clone();
                SRDThresholdTMP = (Bitmap)SRDTresholdBitmap.Clone();

                pictureBoxExtended1.Image = imageTMP;

                SRDTmpBMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                pictureBoxExtended2.Image = SRDTmpBMP;

                SRDThresholdTMP.SetPixel(p.X, p.Y, Color.FromArgb(255, 255, 0, 0));
                pictureBoxExtended3.Image = SRDThresholdTMP;
            }

            return pixelConter;
        }

        private void originalImageSizetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                resizeImages();
            }
        }

        private void SRDImageSizetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                resizeImages();
            }
        }

        public void resizeImages()
        {
            pictureBoxExtended1.Width = (int)(bm.Width * (Double.Parse(originalImageSizetextBox.Text) / 100d));
            pictureBoxExtended1.Height = (int)(bm.Height * (Double.Parse(originalImageSizetextBox.Text) / 100d));

            pictureBoxExtended2.Width = (int)(SRDBitmap.Width * (Double.Parse(SRDImageSizetextBox.Text) / 100d));
            pictureBoxExtended2.Height = (int)(SRDBitmap.Height * (Double.Parse(SRDImageSizetextBox.Text) / 100d));

            pictureBoxExtended3.Width = (int)(SRDBitmap.Width * (Double.Parse(SRDImageSizetextBox.Text) / 100d));
            pictureBoxExtended3.Height = (int)(SRDBitmap.Height * (Double.Parse(SRDImageSizetextBox.Text) / 100d));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveSRDAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text file (*.txt)|*.txt";
                sfd.DefaultExt = "txt";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(sfd.FileName);

                    for (int i = 0; i < originalSRDMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < originalSRDMatrix.GetLength(1); j++)
                        {
                            tw.Write(originalSRDMatrix[i, j]);

                            if (j < originalSRDMatrix.GetLength(1) - 1)
                            {
                                tw.Write(",");
                            }
                        }

                        tw.WriteLine(";");
                    }

                    tw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void pictureBoxExtended2_DoubleClick(object sender, EventArgs e)
        {
            int y = pictureBoxExtended2.MousePositionOnImage.Y;

            try
            {
                SRD(bm, Int32.Parse(w1textBox.Text), Int32.Parse(w2textBox.Text), Int32.Parse(w3textBox.Text), Int32.Parse(qtextBox.Text), y);

                pictureBoxExtended2.Image = SRDBitmap;
                pictureBoxExtended3.Image = SRDTresholdBitmap;

                infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                clickedPointLabel.Text = "";
                SRDclickedPointLabel.Text = "";

                resizeImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        Point mouseDownPoint;
        private void pictureBoxExtended2_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
                mouseDownPoint = pictureBoxExtended2.MousePositionOnImage;
        }

        Point mouseUpPoint;
        private void pictureBoxExtended2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUpPoint = pictureBoxExtended2.MousePositionOnImage;

            if (Control.ModifierKeys == Keys.Shift)
            {
                if (mouseDownPoint != mouseUpPoint)
                {
                    try
                    {
                        SRD(bm, Int32.Parse(w1textBox.Text), Int32.Parse(w2textBox.Text), Int32.Parse(w3textBox.Text), Int32.Parse(qtextBox.Text), mouseDownPoint, mouseUpPoint);

                        pictureBoxExtended2.Image = SRDBitmap;
                        pictureBoxExtended3.Image = SRDTresholdBitmap;

                        infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                        clickedPointLabel.Text = "";
                        SRDclickedPointLabel.Text = "";

                        resizeImages();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception");
                    }
                }
            }
        }

        FileInfo[] imgpaths;

        private void batchRunningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);

                imgpaths = di.GetFiles("*.png");

                batchRunningBackgroundWorker.RunWorkerAsync();
            }
        }

        private void batchRunningBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (imgpaths.Length > 0)
            {
                TextWriter tw = new StreamWriter(imgpaths[0].DirectoryName + "/params.csv");

                for (int t = 0; t < imgpaths.Length; t++)
                {
                    imageTMP = null;
                    SRDTmpBMP = null;
                    SRDThresholdTMP = null;
                    previousliClicked = "";

                    bm = new Bitmap(imgpaths[t].FullName);
                    pictureBoxExtended1.Image = bm;

                    List<ParameterSettings> paramsettings = new List<ParameterSettings>();

                    try
                    {
                        int loopcounter = 0;
                        for (int i = 3; i < 12; i += 2)
                        {
                            for (int j = 7; j < 14; j += 2)
                            {
                                for (int k = 11; k < 18; k += 2)
                                {
                                    if (i < j && j < k)
                                    {
                                        SRD(bm, i, j, k, Int32.Parse(qtextBox.Text));

                                        pictureBoxExtended2.Image = SRDBitmap;
                                        pictureBoxExtended3.Image = SRDTresholdBitmap;

                                        //infoLabel.Text = string.Format("Original image size: {0} x {1}, SRD Matrix size: {2} x {3}", bm.Width, bm.Height, SRDBitmap.Width, SRDBitmap.Height);
                                        //clickedPointLabel.Text = "";
                                        //SRDclickedPointLabel.Text = "";


                                        int counter = 0;
                                        for (int l = 0; l < SRDMatrix.GetLength(0); l++)
                                        {
                                            for (int m = SRDMatrix.GetLength(1) / 2; m < SRDMatrix.GetLength(1); m++)
                                            {
                                                if (SRDMatrix[l, m] > 0)
                                                    counter++;
                                            }
                                        }

                                        double overlap = Math.Round((double)counter / ((double)SRDMatrix.GetLength(0) * (double)SRDMatrix.GetLength(1) / 2d), 2);

                                        paramsettings.Add(new ParameterSettings() { W1 = i, W2 = j, W3 = k, Overlap = overlap });

                                        loopcounter++;
                                    }
                                }
                            }
                        }

                        ParameterSettings best = paramsettings.OrderByDescending(p => p.Overlap).ToList().First();

                        tw.WriteLine(imgpaths[t].Name + ";" + best.W1 + ";" + best.W2 + ";" + best.W3 + ";" + best.Overlap);                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Exception");
                    }
                }

                tw.Close();
            }
        }

    }
}
