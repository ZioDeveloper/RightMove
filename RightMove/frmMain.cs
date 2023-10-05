using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleControl;

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
            string myYear = "";
            string myMonth = "";
            string myDay = "";

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
                            if (cnt == 1)
                            {
                                //myFile = line + "\n";
                                myFile = "cod_modello	cod_telaio	pro_movimento	cod_piazzale_origine	cod_piazzale_transito	cod_piazzale_destinazione	data_assegnazione	data_pic	data_uscita	data_pod	cod_trasportatore	codice_treno	codice_mezzo	cod_edv	cod_cliente_logistico	cod_stabilimento	Stamp_di_Aggiornamento	data_arrivo_edv	data_pod_fi	data_pod_log" + "\n";
                               // myFile = myFile.Replace("\r\n", "\r");
                            }
                            else
                            {   // vecchio formato
                                //myFile = line + "\n";
                                // nuovo
                                var tempLine = line.Split('\t');
                                myLine.C01 = tempLine[0];
                                myLine.C02 = tempLine[1];
                                myLine.C03 = tempLine[2];
                                myLine.C04 = tempLine[3]; 

                                myLine.C05 = tempLine[4]; // Colonna E 
                                if (myLine.C05.ToUpper() == "N.D.")
                                    myLine.C05 = "X";

                                myLine.C06 = tempLine[5]; // Colonna F 
                                if (myLine.C06.ToUpper() == "N.D.")
                                    myLine.C06 = "X";

                                myLine.C07 = tempLine[6]; // Colonna G data ssegnazione deve diventare dd/MM/YYYY ed è yyyy-MM-dd
                                if (myLine.C07 == "-")
                                    myLine.C07 = "";
                                // Trasformazione data...
                                //2018-03-16
                                //try
                                //{
                                //    myYear = myLine.C07.Left(4);
                                //    myMonth = myLine.C07.Substring(5, 2);
                                //    myDay = myLine.C07.Right(2);
                                //    myLine.C07 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch { myLine.C07 = ""; }

                                myLine.C08 = tempLine[7];
                                if (myLine.C08 == "-")
                                    myLine.C08 = "";
                                //try
                                //{
                                //    myYear = myLine.C08.Left(4);
                                //    myMonth = myLine.C08.Substring(5, 2);
                                //    myDay = myLine.C08.Right(2);
                                //    myLine.C08 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch { myLine.C08 = ""; }

                                myLine.C09 = tempLine[8];
                                if (myLine.C09 == "-")
                                    myLine.C09 = "";
                                //try
                                //{
                                //    myYear = myLine.C09.Left(4);
                                //    myMonth = myLine.C09.Substring(5, 2);
                                //    myDay = myLine.C09.Right(2);
                                //    myLine.C09 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch { myLine.C09 = ""; }

                                myLine.C10 = tempLine[9];
                                if (myLine.C10 == "-")
                                    myLine.C10 = "";

                                myLine.C11 = tempLine[10];
                                myLine.C12 = tempLine[11];

                                myLine.C13 = tempLine[12]; 
                                myLine.C14 = tempLine[13]; //Colonna N 
                                if (myLine.C14 == "-")
                                    myLine.C14 = "X";
                                if (myLine.C14 == "N.D.")
                                    myLine.C14 = "X";

                                myLine.C15 = tempLine[14]; //Colonna O
                                if (myLine.C15 == "-")
                                    myLine.C15 = "X";
                                if (myLine.C15 == "N.D.")
                                    myLine.C15 = "X";

                                myLine.C16 = tempLine[15]; //Colonna P
                                if (myLine.C16 == "D.")
                                    myLine.C16 = "X";
                                if (myLine.C16 == "-")
                                    myLine.C16 = "X";

                                myLine.C17 = tempLine[16].Left(10); // Colonna Q Job ID
                                try
                                {
                                    myLine.C17 = myLine.C17.Substring(0,10);
                                    myYear = myLine.C17.Right(4);
                                    myMonth = myLine.C17.Substring(3, 2);
                                    myDay = myLine.C17.Right(2);
                                    myLine.C17 = myYear + "-" + myMonth + "-" + myDay;
                                }
                                catch
                                { myLine.C17 = ""; }

                                myLine.C18 = tempLine[17];
                                if (myLine.C18 == "-")
                                    myLine.C18 = "";
                                //try
                                //{
                                //    myYear = myLine.C18.Left(4);
                                //    myMonth = myLine.C18.Substring(5, 2);
                                //    myDay = myLine.C18.Right(2);
                                //    myLine.C18 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch
                                //{ myLine.C18 = ""; }

                                myLine.C19 = tempLine[18];
                                if (myLine.C19 == "-")
                                    myLine.C19 = "";
                                //try
                                //{
                                //    myYear = myLine.C19.Left(4);
                                //    myMonth = myLine.C19.Substring(5, 2);
                                //    myDay = myLine.C19.Right(2);
                                //    myLine.C19 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch
                                //{ myLine.C19 = ""; }


                                myLine.C20 = tempLine[19];
                                if (myLine.C20 == "-")
                                    myLine.C20 = "";
                                //try
                                //{
                                //    myYear = myLine.C20.Left(4);
                                //    myMonth = myLine.C20.Substring(5, 2);
                                //    myDay = myLine.C20.Right(2);
                                //    myLine.C20 = myDay + "/" + myMonth + "/" + myYear;
                                //}
                                //catch
                                //{ myLine.C20 = ""; }


                                myFile = myLine.C01 + "\t" + myLine.C02 + "\t" + myLine.C03 + "\t" + myLine.C04 + "\t" + myLine.C05 + "\t" +
                                     myLine.C06 + "\t" + myLine.C07 + "\t" + myLine.C08 + "\t" + myLine.C09 + "\t" + myLine.C10 + "\t" +
                                     myLine.C11 + "\t" + myLine.C12 + "\t" + myLine.C13 + "\t" + myLine.C14 + "\t" + myLine.C15 + "\t" +
                                     myLine.C16 + "\t" + myLine.C17 + "\t" + myLine.C18 + "\t" + myLine.C19 + "\t" + myLine.C20 + "\n"; ;
                                //corr++;
                                //myFile = myFile.Replace("\r\n", "\r");
                            }

                        }
                        else
                        {
                            var tempLine = line.Split('\t');
                            myLine.C01 = tempLine[0];
                            myLine.C02 = tempLine[1];
                            myLine.C03 = tempLine[2];
                            myLine.C04 = tempLine[3];

                            myLine.C05 = tempLine[4]; // Colonna E 
                            if (myLine.C05.ToUpper() == "N.D.")
                                myLine.C05 = "X";

                            myLine.C06 = tempLine[5]; // Colonna F 
                            if (myLine.C06.ToUpper() == "N.D.")
                                myLine.C06 = "X";

                            myLine.C07 = tempLine[6]; // Colonna G data ssegnazione deve diventare dd/MM/YYYY ed è yyyy-MM-dd
                            if (myLine.C07 == "-")
                                myLine.C07 = "";
                            // Trasformazione data...
                            //2018-03-16
                            //try
                            //{
                            //    myYear = myLine.C07.Left(4);
                            //    myMonth = myLine.C07.Substring(5, 2);
                            //    myDay = myLine.C07.Right(2);
                            //    myLine.C07 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch { myLine.C07 = ""; }

                            myLine.C08 = tempLine[7];
                            if (myLine.C08 == "-")
                                myLine.C08 = "";
                            //try
                            //{
                            //    myYear = myLine.C08.Left(4);
                            //    myMonth = myLine.C08.Substring(5, 2);
                            //    myDay = myLine.C08.Right(2);
                            //    myLine.C08 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch { myLine.C08 = ""; }

                            myLine.C09 = tempLine[8];
                            if (myLine.C09 == "-")
                                myLine.C09 = "";
                            //try
                            //{
                            //    myYear = myLine.C09.Left(4);
                            //    myMonth = myLine.C09.Substring(5, 2);
                            //    myDay = myLine.C09.Right(2);
                            //    myLine.C09 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch { myLine.C09 = ""; }

                            myLine.C10 = tempLine[9];
                            if (myLine.C10 == "-")
                                myLine.C10 = "";

                            myLine.C11 = tempLine[10];
                            myLine.C12 = tempLine[11];

                            myLine.C13 = tempLine[12];
                            myLine.C14 = tempLine[13]; //Colonna N 
                            if (myLine.C14 == "-")
                                myLine.C14 = "X";
                            if (myLine.C14 == "N.D.")
                                myLine.C14 = "X";

                            myLine.C15 = tempLine[14]; //Colonna O
                            if (myLine.C15 == "-")
                                myLine.C15 = "X";
                            if (myLine.C15 == "N.D.")
                                myLine.C15 = "X";

                            myLine.C16 = tempLine[15]; //Colonna P
                            if (myLine.C16 == "D.")
                                myLine.C16 = "X";
                            if (myLine.C16 == "-")
                                myLine.C16 = "X";

                            myLine.C17 = tempLine[16].Left(10); // Colonna Q Job ID
                            try
                            {
                                myLine.C17 = myLine.C17.Substring(0, 10);
                                myYear = myLine.C17.Right(4);
                                myMonth = myLine.C17.Substring(3, 2);
                                myDay = myLine.C17.Right(2);
                                myLine.C17 = myYear + "-" + myMonth + "-" + myDay;
                            }
                            catch
                            { myLine.C17 = ""; }

                            myLine.C18 = tempLine[17];
                            if (myLine.C18 == "-")
                                myLine.C18 = "";
                            //try
                            //{
                            //    myYear = myLine.C18.Left(4);
                            //    myMonth = myLine.C18.Substring(5, 2);
                            //    myDay = myLine.C18.Right(2);
                            //    myLine.C18 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch
                            //{ myLine.C18 = ""; }

                            myLine.C19 = tempLine[18];
                            if (myLine.C19 == "-")
                                myLine.C19 = "";
                            //try
                            //{
                            //    myYear = myLine.C19.Left(4);
                            //    myMonth = myLine.C19.Substring(5, 2);
                            //    myDay = myLine.C19.Right(2);
                            //    myLine.C19 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch
                            //{ myLine.C19 = ""; }


                            myLine.C20 = tempLine[19];
                            if (myLine.C20 == "-")
                                myLine.C20 = "";
                            //try
                            //{
                            //    myYear = myLine.C20.Left(4);
                            //    myMonth = myLine.C20.Substring(5, 2);
                            //    myDay = myLine.C20.Right(2);
                            //    myLine.C20 = myDay + "/" + myMonth + "/" + myYear;
                            //}
                            //catch
                            //{ myLine.C20 = ""; }


                            myFile = myLine.C01 + "\t" + myLine.C02 + "\t" + myLine.C03 + "\t" + myLine.C04 + "\t" + myLine.C05 + "\t" +
                                 myLine.C06 + "\t" + myLine.C07 + "\t" + myLine.C08 + "\t" + myLine.C09 + "\t" + myLine.C10 + "\t" +
                                 myLine.C11 + "\t" + myLine.C12 + "\t" + myLine.C13 + "\t" + myLine.C14 + "\t" + myLine.C15 + "\t" +
                                 myLine.C16 + "\t" + myLine.C17 + "\t" + myLine.C18 + "\t" + myLine.C19 + "\t" + myLine.C20 ;
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

                        //myFile = myFile.Replace("\r\n", "\r");
                    }

                    outputFile.Write(myFile);
                    label2.Text = cnt.ToString();
                    Application.DoEvents();
                }
                
                
            }

            File.Delete(lblFileName.Text);
            txtFileContent.Text += Environment.NewLine + @"Cancellato file file : " + lblFileName.Text;

            txtFileContent.Text += Environment.NewLine + "N° " + corr.ToString() + " correzioni apportate " + Environment.NewLine;
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

        private void cmdDTS_Click(object sender, EventArgs e)
        {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                
                myProcess.StartInfo.FileName = @"C:\Users\Administrator\Desktop\PODFI.cmd";
                myProcess.StartInfo.CreateNoWindow = false; // Fa apparire la finestra CMD
                myProcess.Start();
                
            }
        }
    }
}
