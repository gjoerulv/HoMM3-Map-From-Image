#define DUMPBMP
using Heroes_3_Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heroes_3_Map_From_Image
{
    public partial class Form1 : Form
    {

        int[] storedTerrainsArray = new int[] { 7, 7, 6, 6, 5, 1, 1, 3, 3 };
        bool startingUp = true;

        H3Map _heroes3Map;
        public Form1()
        {
            InitializeComponent();
            RestoreFDSetting(openFileDialogImage, tbTextFile, Properties.Settings.Default.LatestImg);
            RestoreFDSetting(openFileDialogMap, tbMapFile, Properties.Settings.Default.LatestMap);
            RestoreFDSetting(saveMapFileDialog, null, 
                string.IsNullOrEmpty(Properties.Settings.Default.LatestMapSaved) ?
                Properties.Settings.Default.LatestMap :
                Properties.Settings.Default.LatestMapSaved);

            try
            {
                string storedTerrains = Properties.Settings.Default.SavedTerrains;
                if(string.IsNullOrWhiteSpace(storedTerrains))
                    SaveTerrains();
                else
                    storedTerrainsArray = storedTerrains
                        .Split(',')
                        .Select(s => int.Parse(s))
                        .ToArray();

                int i = 0;
                cb1.SelectedIndex = storedTerrainsArray[i++];
                cb2.SelectedIndex = storedTerrainsArray[i++];
                cb3.SelectedIndex = storedTerrainsArray[i++];
                cb4.SelectedIndex = storedTerrainsArray[i++];
                cb5.SelectedIndex = storedTerrainsArray[i++];
                cb6.SelectedIndex = storedTerrainsArray[i++];
                cb7.SelectedIndex = storedTerrainsArray[i++];
                cb8.SelectedIndex = storedTerrainsArray[i++];
                cb9.SelectedIndex = storedTerrainsArray[i];

                rbGrayscale.Checked = Properties.Settings.Default.UseGrayscale;
                if (!rbGrayscale.Checked) rbRGB.Checked = true;

                nudMapNumber.Value = Properties.Settings.Default.MapNumber;
                cbConversionMethod.SelectedIndex = Properties.Settings.Default.ConversionMethod;

                SetMap(tbMapFile.Text);

            }
            catch (Exception ex)
            {
                /*silent*/
            }
            finally
            {
                startingUp = false;
            }
        }

        private void SaveTerrains()
        {
            Properties.Settings.Default.SavedTerrains =
                    string.Join(",",
                            storedTerrainsArray
                            .Select(i => i.ToString())
                            .ToArray()
                        );
            Properties.Settings.Default.Save();
        }

        private void BtnMapFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogMap.ShowDialog() == DialogResult.OK)
            {
                tbMapFile.Text = openFileDialogMap.FileName;
                openFileDialogMap.InitialDirectory = System.IO.Path.GetDirectoryName(openFileDialogMap.FileName);
                Properties.Settings.Default.LatestMap = openFileDialogMap.FileName;
                Properties.Settings.Default.Save();

                if (string.IsNullOrEmpty(Properties.Settings.Default.LatestMapSaved))
                    StoreSavedFileToSettings(openFileDialogMap.FileName);

                try
                {
                    SetMap(openFileDialogMap.FileName);
                }
                catch (Exception ex)
                {
                    _heroes3Map = null;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StoreSavedFileToSettings(string file)
        {
            if (string.IsNullOrEmpty(file)) return;
            saveMapFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(file);
            Properties.Settings.Default.LatestMapSaved = file;
            Properties.Settings.Default.Save();
        }

        private void SetMap(string file)
        {
            lblVersion.Text = "Version detected: ";
            cbDims.SelectedIndex = -1;

            if (string.IsNullOrEmpty(file))
                return;
            if (!System.IO.File.Exists(file))
                return;
            _heroes3Map = new H3Map(file);

            switch (_heroes3Map.Dimension)
            {
                case 36: cbDims.SelectedIndex = 0; break;
                case 72: cbDims.SelectedIndex = 1; break;
                case 108: cbDims.SelectedIndex = 2; break;
                case 144: cbDims.SelectedIndex = 3; break;
                case 180: cbDims.SelectedIndex = 4; break;
                case 216: cbDims.SelectedIndex = 5; break;
                case 252: cbDims.SelectedIndex = 6; break;
                default: throw new ArgumentException("Could not find map dimensions.", nameof(file));
            }
            lblVersion.Text = "Version detected: " + _heroes3Map.Version.ToString();
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                tbTextFile.Text = openFileDialogImage.FileName;
                openFileDialogImage.InitialDirectory = System.IO.Path.GetDirectoryName(openFileDialogImage.FileName);
                Properties.Settings.Default.LatestImg = openFileDialogImage.FileName;
                Properties.Settings.Default.Save();
            }
        }

        string[] splt = new string[] { Environment.NewLine };

        Bitmap bmp;
        Image imgFromFile;
        private readonly ushort[] validDims = { 36, 72, 108, 144, 180, 216, 252 };

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rbRGB.Checked && !rbGrayscale.Checked)
                    throw new Exception("Must use Grayscale or Closest Color.");


                if (saveMapFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StoreSavedFileToSettings(saveMapFileDialog.FileName);
                    Import(saveMapFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bmp != null) bmp.Dispose();
                if (imgFromFile != null) imgFromFile.Dispose();
            }
        }

        private void Import(string file)
        {
            if (_heroes3Map == null)
                SetMap(tbMapFile.Text);

            if (_heroes3Map == null)
                throw new ArgumentNullException("Could not load map.");

            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentNullException("Can't save to empty location");

            string[] lines;

            //TODO: Must also have option to read lines dirctly from txt file.
            imgFromFile = ASCIIConverter.FromFile(tbTextFile.Text);


            int dim = _heroes3Map.Dimension;

            //TODO:
            bmp = ASCIIConverter.ScaleImage(imgFromFile, dim, dim);

            imgFromFile.Dispose();

            lines = GetLinesFromImage(dim);

            MapHandlerParams _params = MapHandlerParams.Generate(
                GetMehod(),
                FormTiles,
                lines);

            MapHandler _handler = new MapHandler(_params, _heroes3Map);


            _handler.Import((int)nudMapNumber.Value, file);
            MessageBox.Show(
                "Saved map: " + file,
                "Success!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private string[] GetLinesFromImage(int dim)
        {
#if DEBUG && DUMPBMP
            SaveBmp(1);
#endif
            bmp = ASCIIConverter.ResizeImageAbsolute(bmp, dim, dim / 2);
#if DEBUG && DUMPBMP
            SaveBmp(2);
#endif
            if (rbGrayscale.Checked)
            {
                bmp = ASCIIConverter.Grayscale(bmp);
#if DEBUG && DUMPBMP
                SaveBmp(3);
#endif
                return ASCIIConverter.GrayscaleImageToASCII(bmp).
                    Split(splt, StringSplitOptions.RemoveEmptyEntries);
            }
            return ImageIndexList(bmp, TileColors, GetMehod()).
                Split(splt, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        /// <param name="colorRange"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string ImageIndexList(Image img, List<Color> colorRange, ConversionMethod method)
        {
            //Bitmap bmp = null;
            StringBuilder output = new StringBuilder();
            try
            {
                using (Bitmap bmp = new Bitmap(img))
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color col = bmp.GetPixel(x, y);
                            int colorIndex = 0;
                            switch(method)
                            {
                                case ConversionMethod.MatchRGB:
                                    colorIndex = ASCIIConverter.ClosestColor1(colorRange, col);
                                    break;
                                case ConversionMethod.HuesOnly:
                                    colorIndex = ASCIIConverter.ClosestColor2(colorRange, col);
                                    break;
                                case ConversionMethod.HueSaturationAndBrightness:
                                    colorIndex = ASCIIConverter.ClosestColor3(colorRange, col);
                                    break;
                                case ConversionMethod.DistanceRGB:
                                    colorIndex = ASCIIConverter.ClosestColor(colorRange, col);
                                    break;
                                default: throw new NotImplementedException("Method not implemented.");
                            }
                            output.Append(colorIndex.ToString("X"));

                            if (x == bmp.Width - 1)
                            {
                                output.Append(Environment.NewLine); break;
                            }
                        }
                    }
                }

                return output.ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private ConversionMethod GetMehod()
        {
            
            if (rbGrayscale.Checked)
                return ConversionMethod.GrayScale;
            ConversionMethod method;
            switch (cbConversionMethod.SelectedIndex)
            {
                case 0: method = ConversionMethod.HuesOnly; break;
                case 1: method = ConversionMethod.MatchRGB; break;
                case 2: method = ConversionMethod.HueSaturationAndBrightness; break;
                case 3: method = ConversionMethod.DistanceRGB; break;
                default: throw new NotImplementedException("Conversion method not implemented.");
            }
            return method;
        }

        private void RestoreFDSetting(FileDialog d, TextBox tb, string file)
        {
            try
            {
                if (file == null) return;
                if (System.IO.File.Exists(file))
                {
                    d.InitialDirectory = System.IO.Path.GetDirectoryName(file);
                    d.FileName = file;
                    if (tb == null)
                        return;
                    tb.Text = file;
                }
            } catch(Exception) { /*silent*/ }
        }

        private TileType[] FormTiles
        {
            get
            {
                return new TileType[]
                {
                    (TileType)cb1.SelectedIndex,
                    (TileType)cb2.SelectedIndex,
                    (TileType)cb3.SelectedIndex,
                    (TileType)cb4.SelectedIndex,
                    (TileType)cb5.SelectedIndex,
                    (TileType)cb6.SelectedIndex,
                    (TileType)cb7.SelectedIndex,
                    (TileType)cb8.SelectedIndex,
                    (TileType)cb9.SelectedIndex,
                };
            }
        }

        public readonly List<Color> TileColors = new List<Color>(new Color[]
        {
            Color.FromArgb(82, 57, 8), //26 197 42 Dirt
            Color.FromArgb(222, 206, 140), //32 133 170 Sand
            Color.FromArgb(0, 66, 0), //26 197 42 Grass
            Color.FromArgb(181, 198, 198), //120 31 178 Snow
            Color.FromArgb(74, 132, 107), //103 68 97 Swamp
            Color.FromArgb(132, 115, 49), //32 110 85 Rough
            Color.FromArgb(132, 49, 0), //15 240 62 Sub
            Color.FromArgb(74, 74, 74), //160 0 70 Lava
            Color.FromArgb(8, 82, 148), //139 215 73 Water
            Color.FromArgb(0, 0, 0), //160 0 0 Rock
            Color.FromArgb(41, 115, 24), //73 157 65 Highl
            Color.FromArgb(189, 90, 8), //18 221 93 Waste
        });
        /*
         public enum TileType : byte
    {
        Dirt = 0
        , Sand
        , Grass
        , Snow
        , Swamp,
        , Rough,
        , Subterranean,
        , Lava,     
        , Water
        , Rock
        , Highland
        , Wasteland
    }

         
         */

#if DEBUG && DUMPBMP
        private void SaveBmp(int nr)
        {
            if (bmp != null)
            {
                string path = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(tbTextFile.Text), "debug");
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                bmp.Save(path + "/d" + nr + ".bmp");
            }
        }
#endif

        private void cbTerrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int storedSettingsIndex = int.Parse((sender as ComboBox).Tag.ToString());
                int selectedIndexOfSender = (sender as ComboBox).SelectedIndex;

                storedTerrainsArray[storedSettingsIndex] = selectedIndexOfSender;
                if(!startingUp) SaveTerrains();
            }
            catch (Exception)
            {
                /*silent*/
            }
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cb1.Enabled =
                cb2.Enabled =
                cb3.Enabled =
                cb4.Enabled =
                cb5.Enabled =
                cb6.Enabled =
                cb7.Enabled =
                cb8.Enabled =
                cb9.Enabled = rbGrayscale.Checked;

                cbConversionMethod.Enabled = !rbGrayscale.Checked;
                
                if(!startingUp)
                {
                    Properties.Settings.Default.UseGrayscale = rbGrayscale.Checked;
                    Properties.Settings.Default.Save();
                }
            } catch (Exception) { /*silent*/ }
        }

        private void nudMapNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!startingUp)
                {
                    Properties.Settings.Default.MapNumber = nudMapNumber.Value;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception) { /*silent*/ }
        }

        private void cbDims_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbConversionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!startingUp)
                {
                    Properties.Settings.Default.ConversionMethod = cbConversionMethod.SelectedIndex;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception) { /*silent*/ }
        }
    }
}
