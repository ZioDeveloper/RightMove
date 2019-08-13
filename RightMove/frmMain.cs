using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace RightMove
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            lblFileName.Text = "...";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"T:\Fiat\Derr\";
                openFileDialog.Filter = "Txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    lblFileName.Text = filePath;
                    //lblFileName.Text = @"M:\@\@Transito\Movimentato_2019.08.07 - Copia.TXT";
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        //fileContent = reader.ReadToEnd();
                    }

                    //txtFileContent.Text = fileContent;
                }
            }
        }

        public class FileData
        {
            public string C01 { get; set; }
            public string C02 { get; set; }
            public string C04 { get; set; }
            public string C03 { get; set; }
            public string C05 { get; set; }
            public string C06 { get; set; }
            public string C07 { get; set; }
            public string C08 { get; set; }
            public string C09 { get; set; }
            public string C10 { get; set; }
            public string C11 { get; set; }
            public string C12 { get; set; }
            public string C13 { get; set; }
            public string C14 { get; set; }
            public string C15 { get; set; }
            public string C16 { get; set; }
            public string C17 { get; set; }
            public string C18 { get; set; }
            public string C19 { get; set; }
            public string C20 { get; set; }
            public string C21 { get; set; }
        }

       

        private void cmdParse2_Click(object sender, EventArgs e)
        {
            if (chkCopyFile.Checked)
            {
                try
                {
                    string aName = Path.GetFileName(lblFileName.Text);
                    File.Copy(lblFileName.Text, @"T:\FIAT\DERR\MovimentatoFatto\" + aName, true);
                    txtFileContent.Text += Environment.NewLine + "Copiato file : " + lblFileName.Text + @" in " + Environment.NewLine + @" T:\FIAT\DERR\MovimentatoFatto" + Environment.NewLine;

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            File.Delete(@"T:\FIAT\DERR\Movimentato_dwh.TXT");
            txtFileContent.Text += Environment.NewLine + @"Cancellato file file : T:\FIAT\DERR\Movimentato_dwh.TXT ";

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int cnt = 0;
            int corr = 0;
            int i = File.ReadAllLines(lblFileName.Text).Count();

            string myFile = string.Empty;

            string myDir = Path.GetDirectoryName(lblFileName.Text);
            string myDestFile = myDir + @"\" + "Movimentato_dwh_new.txt";

            using (StreamWriter outputFile = new StreamWriter(@"T:\Fiat\Derr\Movimentato_dwh.txt"))
            {
               
                foreach (var line in File.ReadLines(lblFileName.Text))
                {
                    FileData myLine = new FileData();
                    cnt++;

                    int count = line.Split('\t').Count();

                    if (count == 20)
                    {
                        if (cnt < i)
                        {
                            myFile = line + "\n";
                        }
                        else
                        {
                            var tempLine = line.Split('\t');
                            myLine.C01 = tempLine[0];
                            myLine.C02 = tempLine[1];
                            myLine.C03 = tempLine[2];
                            myLine.C04 = tempLine[3];
                            myLine.C05 = tempLine[4];
                            myLine.C06 = tempLine[5];
                            myLine.C07 = tempLine[6];
                            myLine.C08 = tempLine[7];
                            myLine.C09 = tempLine[8];
                            myLine.C10 = tempLine[9];
                            myLine.C11 = tempLine[10];
                            myLine.C12 = tempLine[11];
                            myLine.C13 = tempLine[12];
                            myLine.C14 = tempLine[13];
                            myLine.C15 = tempLine[14];
                            myLine.C16 = tempLine[15];
                            myLine.C17 = tempLine[16];
                            myLine.C18 = tempLine[17];
                            myLine.C19 = tempLine[18];
                            myLine.C20 = tempLine[19];
                            myFile = myLine.C01 + "\t" + myLine.C02 + "\t" + myLine.C03 + "\t" + myLine.C04 + "\t" + myLine.C05 + "\t" +
                                 myLine.C06 + "\t" + myLine.C07 + "\t" + myLine.C08 + "\t" + myLine.C09 + "\t" + myLine.C10 + "\t" +
                                 myLine.C11 + "\t" + myLine.C12 + "\t" + myLine.C13 + "\t" + myLine.C14 + "\t" + myLine.C15 + "\t" +
                                 myLine.C16 + "\t" + myLine.C17 + "\t" + myLine.C18 + "\t" + myLine.C19 + "\t" + myLine.C20;
                            corr++;
                           
                        }
                       

                    }

                    else
                    {
                        corr++;
                        var tempLine = line.Split('\t');
                        myLine.C01 = tempLine[0];
                        myLine.C02 = tempLine[1];
                        myLine.C03 = tempLine[2];
                        myLine.C04 = tempLine[3];
                        myLine.C05 = tempLine[4];
                        myLine.C06 = tempLine[5];
                        myLine.C07 = tempLine[6];
                        myLine.C08 = tempLine[7];
                        myLine.C09 = tempLine[8];
                        myLine.C10 = tempLine[9];
                        myLine.C11 = tempLine[10];
                        myLine.C12 = tempLine[11];
                        myLine.C13 = tempLine[12];
                        myLine.C14 = tempLine[13];
                        myLine.C15 = tempLine[14];
                        myLine.C16 = tempLine[15];
                        myLine.C17 = tempLine[16];
                        myLine.C18 = tempLine[17];
                        myLine.C19 = tempLine[18];
                        myLine.C20 = tempLine[19];

                        myLine.C21 = tempLine[20];

                        if (cnt < i)
                        {
                            myFile = myLine.C01 + "\t" + myLine.C02 + "\t" + myLine.C03 + "\t" + myLine.C04 + "\t" + myLine.C05 + "\t" +
                                        myLine.C06 + "\t" + myLine.C07 + "\t" + myLine.C08 + "\t" + myLine.C09 + "\t" + myLine.C10 + "\t" +
                                        myLine.C11 + "\t" + myLine.C13 + "\t" + myLine.C14 + "\t" + myLine.C15 + "\t" +
                                        myLine.C16 + "\t" + myLine.C17 + "\t" + myLine.C18 + "\t" + myLine.C19 + "\t" + myLine.C20 + "\n";
                        }
                        else
                        {
                            myFile = myLine.C01 + "\t" + myLine.C02 + "\t" + myLine.C03 + "\t" + myLine.C04 + "\t" + myLine.C05 + "\t" +
                                        myLine.C06 + "\t" + myLine.C07 + "\t" + myLine.C08 + "\t" + myLine.C09 + "\t" + myLine.C10 + "\t" +
                                        myLine.C11 + "\t" + myLine.C13 + "\t" + myLine.C14 + "\t" + myLine.C15 + "\t" +
                                        myLine.C16 + "\t" + myLine.C17 + "\t" + myLine.C18 + "\t" + myLine.C19 + "\t" + myLine.C20;
                        }
                        

                    }

                    outputFile.Write(myFile);
                }
                
                
            }

            File.Delete(lblFileName.Text);
            txtFileContent.Text += Environment.NewLine + @"Cancellato file file : " + lblFileName.Text;

            txtFileContent.Text += Environment.NewLine + "N° " + corr.ToString() + " correzzioni apportate " + Environment.NewLine;
            txtFileContent.Text += Environment.NewLine + "Finito alle " + DateTime.Now.ToString();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCopyFile_CheckedChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
