using mnForm = EllieMae.Encompass.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using winForm = System.Windows.Forms;

namespace jsonConversionLibrary
{
    public class codebase : EllieMae.Encompass.Forms.Form
    {
        private mnForm.TextBox _tbox = new mnForm.TextBox();
        private mnForm.Button _tbutt = new mnForm.Button();
        private mnForm.Panel _mnPanel;
        
        protected override void OnLoad(EventArgs e)
        {

            try
            {
                _mnPanel = FindControl("pnlForm") as mnForm.Panel;
                _tbutt.ControlID = "test";
                // _tbox.ControlID = "test1";
                _mnPanel.Controls.Insert(_tbutt);
                _tbutt.Click += new EventHandler(SelectButton_Click);
 
                // JsonSerializer.Deserialize()

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        public class OpenFileDialogForm : winForm.Form
            {
                [STAThread]
                public static void Main()
                {
                    winForm.Application.SetCompatibleTextRenderingDefault(false);
                    winForm.Application.EnableVisualStyles();
                    winForm.Application.Run(new OpenFileDialogForm());
                }

                private winForm.OpenFileDialog openFileDialog1;
                private winForm.TextBox textBox1;
                private winForm.Button selectButton;

                public OpenFileDialogForm()
                {
                    openFileDialog1 = new winForm.OpenFileDialog();
                    selectButton = new winForm.Button
                    {
                        Size = new Size(100, 20),
                        Location = new Point(15, 15),
                        Text = "Select file"
                    };
                    selectButton.Click += new EventHandler(SelectButton_Click);
                    textBox1 = new winForm.TextBox
                    {
                        Size = new Size(300, 300),
                        Location = new Point(15, 40),
                        Multiline = true,
                        ScrollBars = winForm.ScrollBars.Vertical
                    };
                    ClientSize = new Size(330, 360);
                    Controls.Add(selectButton);
                    Controls.Add(textBox1);
                }

                public void SelectButton_Click(object sender, EventArgs e)
                {
                    if (openFileDialog1.ShowDialog() == winForm.DialogResult.OK)
                    {
                        try
                        {
                            var sr = new StreamReader(openFileDialog1.FileName);
                            SetText(sr.ReadToEnd());
                        }
                        catch (Exception exi)
                        {
                            winForm.MessageBox.Show($"Security error.\n\nError message: {exi.Message}\n\n" +
                            $"Details:\n\n{exi.StackTrace}");
                        }
                    }
                }

                private void SetText(string text)
                {
                    textBox1.Text = text;
                }
            }


    }
    

    }
