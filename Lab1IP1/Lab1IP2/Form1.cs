using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Lab1IP1
{
    public partial class Form1 : Form
    {

        public static int currentGeoShape = 0;

        #region Class constructor

        /// <summary>
        /// Constructor for the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion


        #region Buttons 
        /// <summary>
        /// Add a form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Geometric shape file|*.gsf";
            openFileDialog.Title = "Geometric shape File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFileDialog.FileName);
                GeoShape shape = new GeoShape(file.ReadToEnd());

                file.Close();
            }
            DrawGraphic();
        }

        /// <summary>
        /// Delete a form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete(object sender, EventArgs e)
        {
            if (GeoShape.GeoShapes == null)
                GeoShape.GeoShapes = new List<GeoShape>();
            if (GeoShape.GeoShapes.Count > 0)
            {
                GeoShape.GeoShapes.RemoveAt(currentGeoShape);
                if (GeoShape.GeoShapes.Count - 1 < currentGeoShape)
                    currentGeoShape = 0;
            }
            else
            {
                MessageBox.Show("Please add an element to your colection before!");
            }
        }

        /// <summary>
        /// Next form draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNext(object sender, EventArgs e)
        {
            if (GeoShape.GeoShapes == null)
                GeoShape.GeoShapes = new List<GeoShape>();
            if (GeoShape.GeoShapes.Count > 0)
            {
                currentGeoShape += 1;
                if (GeoShape.GeoShapes.Count - 1 < currentGeoShape)
                    currentGeoShape = 0;
                DrawGraphic();
            }
            else
            {
                MessageBox.Show("Please add an element to your colection before!");
            }
        }

        /// <summary>
        /// Previous form draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrevious(object sender, EventArgs e)
        {
            if (GeoShape.GeoShapes == null)
                GeoShape.GeoShapes = new List<GeoShape>();
            if (GeoShape.GeoShapes.Count > 0)
            {
                currentGeoShape -= 1;
                if (0 > currentGeoShape)
                    currentGeoShape = GeoShape.GeoShapes.Count - 1;
                DrawGraphic();
            }
            else
            {
                MessageBox.Show("Please add an element to your colection before!");
            }
        }

        /// <summary>
        /// Save as a .gsfar file all the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCollection(object sender, EventArgs e)
        {
            if (GeoShape.GeoShapes == null)
                GeoShape.GeoShapes = new List<GeoShape>();
            if (GeoShape.GeoShapes.Count > 0)
            {
                string toSave = "";

                foreach (var obj in GeoShape.GeoShapes)
                {
                    toSave += obj.SaveObject();
                }

                System.Text.ASCIIEncoding uniEncoding = new System.Text.ASCIIEncoding();
                Stream streamToSaveText = new MemoryStream();
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "gsfar files (*.gsfar)|*.gsfar|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.RestoreDirectory = true;

                byte[] messageBytes = uniEncoding.GetBytes(toSave);
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((streamToSaveText = saveDialog.OpenFile()) != null)
                    {
                        streamToSaveText.Write(messageBytes, 0, messageBytes.Length);
                        streamToSaveText.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please add an element to your colection before!");
            }
        }

        /// <summary>
        /// Load collection from .gsf file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadColection(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Geometric shape files archive|*.gsfar";
            openFileDialog.Title = "Geometric shape file archive";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                GeoShape.GeoShapes.Clear();
                currentGeoShape = 0;

                StreamReader file = new StreamReader(openFileDialog.FileName);
                GeoShape.PopulateGeoShapes(file.ReadToEnd().ToString());

                file.Close();
            }
        }


        #endregion

        /// <summary>
        /// Draw function for objects .gsf
        /// </summary>
        private void DrawGraphic()
        {
            int width = pictureGraph.ClientSize.Width;
            int hight = pictureGraph.ClientSize.Height;
            Bitmap bitMap = new Bitmap(width, hight);
            using (Graphics graph = Graphics.FromImage(bitMap))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                //graph.ScaleTransform(1, -1);

                // Transform to map the graph bounds to the Bitmap.
                PointF[] fPoints =
                {
                    new PointF(0, hight),
                    new PointF(width, hight),
                    new PointF(0, 0),
                };

                Pen graphPen = new Pen(Color.Black, 3);

                labelObjectName.Text = GeoShape.GeoShapes[currentGeoShape].name;

                foreach (var i in GeoShape.GeoShapes[currentGeoShape].objectDefinition)
                {
                    try
                    {
                        if (i.Item1.Equals("DrawArc"))
                            graph.DrawArc(graphPen, i.Item2[0], i.Item2[1], i.Item2[2], i.Item2[3], i.Item2[4], i.Item2[5]);
                        else if (i.Item1.Equals("DrawBezier"))
                            graph.DrawBezier(graphPen, i.Item2[0], i.Item2[1], i.Item2[2], i.Item2[3], i.Item2[4], i.Item2[5], i.Item2[6], i.Item2[7]);
                        else if (i.Item1.Equals("DrawClosedCurve"))
                            graph.DrawClosedCurve(graphPen, FromListOfFloatToPointF(i.Item2).ToArray());
                        else if (i.Item1.Equals("DrawCurve"))
                            graph.DrawCurve(graphPen, FromListOfFloatToPointF(i.Item2).ToArray());
                        else if (i.Item1.Equals("DrawEllipse"))
                            graph.DrawEllipse(graphPen, i.Item2[0], i.Item2[1], i.Item2[2], i.Item2[3]);
                        else if (i.Item1.Equals("DrawLine"))
                            graph.DrawLine(graphPen, i.Item2[0], i.Item2[1], i.Item2[2], i.Item2[3]);
                        else if (i.Item1.Equals("DrawPie"))
                            graph.DrawPie(graphPen, i.Item2[0], i.Item2[1], i.Item2[2], i.Item2[3], i.Item2[4], i.Item2[5]);
                        else if (i.Item1.Equals("DrawPolygon"))
                            graph.DrawPolygon(graphPen, FromListOfFloatToPointF(i.Item2).ToArray());
                    }
                    catch
                    {
                    }
                }


                
            }

            pictureGraph.Image = bitMap;
        }

        /// <summary>
        /// Transforms a list of floats into an PointF list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns>List of PointF</returns>
        private List<PointF> FromListOfFloatToPointF(List<float> list)
        {
            List<PointF> toReturn = new List<PointF>();

            for (int i = 0; i < list.Count; i=i+2)
            {
                PointF create = new PointF(list[i], list[i + 1]);
                toReturn.Add(create);
            }

            return toReturn;
        }

        /// <summary>
        /// Set all buttons and views from first window to be visible with the value state.
        /// </summary>
        /// <param name="state">Value for visible.</param>
        private void SetVisibleAllControlsFromCollection(bool state)
        {
            buttonAdd.Visible = state;
            buttonDelete.Visible = state;

            pictureGraph.Visible = state;

            buttonSave.Visible = state;
            buttonLoadCollection.Visible = state;

            buttonNextForm.Visible = state;
            buttonPrevious.Visible = state;

            labelObjectName.Visible = state;
            labelStaticName.Visible = state;
        }
    }
}
