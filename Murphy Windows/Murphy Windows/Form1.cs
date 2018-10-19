using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Net.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Murphy_Windows
{
    public partial class Form1 : Form
    {
       
        public  string constr = string.Format("Server=195.201.197.133; database=leskovac_marfiapp; UID=leskovac; password=TerTer55; SslMode = none");
        public int UpdateID;
        public bool ImageChanged = false;
        public string cmdstr = null;

        public string FTPURI = "ftp://195.201.197.133/";
        public string FTPUSER = "murphypub@marfipab.com";
        public string FTPPASS = "FTPMurphy1";
        public string FTPFILENAME = null;


        public Form1()
        {
            InitializeComponent();
        }

        public void ResetPictureBox()
        {
            Ppicture.Image = Properties.Resources.logo1;
            Dpicture.Image = Properties.Resources.logo1;
        }

        public string GetImageIDFromDogadjajID(int ID)
        { 
             MySqlConnection con = new MySqlConnection(constr);
        cmdstr = "SELECT `slikaURI` FROM `Dogadjaji` WHERE ID =  '" + ID.ToString()+"'";
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
        MySqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
               while(reader.Read())
                return reader[0].ToString();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return "NONE";
            }
            finally
            {
                reader.Close();
                con.Close();
                
            }
            return "NONE";
        }


        public string GetImageIDFromPromocijaID(int ID)
        {
            MySqlConnection con = new MySqlConnection(constr);
            cmdstr = "SELECT `SlikaURI` FROM `Promocije` WHERE ID =  '" + ID.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            MySqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    return reader[0].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return "NONE";
            }
            finally
            {
                reader.Close();
                con.Close();

            }
            return "NONE";
        }


        public void DeleteImageFromHost(string imgurl)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPURI+imgurl);
            request.Credentials = new NetworkCredential(FTPUSER, FTPPASS);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Delete status: {0}", response.StatusDescription);
            response.Close();

        }

            public void UploadImageToHost(Image img)
        {
            var image = imageToByte(img);
            Random rnd = new Random();
            FTPFILENAME = rnd.Next(1000000, 9999999).ToString();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FTPURI + FTPFILENAME);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(FTPUSER, FTPPASS);

            byte[] fileContents = image;

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
            response.Close();
        }
        
        
        public void UcitajPromocije()
        {
            Plist.Items.Clear();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("SELECT ID, naziv From Promocije", con);
            MySqlDataReader reader = null;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Plist.Items.Add(reader[0].ToString() + " |   " + reader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }


        }

        public void PopuniPRightPanel()
        {
            MySqlConnection con = new MySqlConnection(constr);
            cmdstr = "SELECT * From Promocije WHERE ID = " + UpdateID.ToString();
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            MySqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();

               PtbNaziv.Text = reader[1].ToString();
                Pnum.Value = (decimal)reader[2];
                if(reader[3].ToString().Equals("Priv"))
                {
                   rbPriv.Checked = true;
                   rbFix.Checked = false;
                }
                else
                {
                    rbPriv.Checked = false;
                    rbFix.Checked = true;
                }
                Pdatetime.Value = (DateTime)reader[4];
                PtbOpis.Text = reader[5].ToString();
                Byte[] ImageByte = (Byte[])(reader[6]);
                if (ImageByte != null)
                {
                    Ppicture.Image = ByteToImage(ImageByte);
                    Ppicture.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        public void UcitajDogadjaje()
        {
            Dlist.Items.Clear();
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("SELECT ID, naziv From Dogadjaji",con);
            MySqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Dlist.Items.Add(reader[0].ToString() + " |   " + reader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                reader.Close();
                con.Close();
            }


        }

        public void PopuniDRightPanel()
        { 
            MySqlConnection con = new MySqlConnection(constr);
            cmdstr = "SELECT * From Dogadjaji WHERE ID = " + UpdateID.ToString();
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            MySqlDataReader reader = null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();

                Ddatetime.Value = (DateTime)reader[3];
                DtbNaziv.Text = reader[4].ToString();
                DtbOpis.Text = reader[5].ToString();

                Byte[] ImageByte = (Byte[])(reader[1]);
                if (ImageByte != null)
                {
                    Dpicture.Image = ByteToImage(ImageByte);
                    Dpicture.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            DbtnIzbrisi.Enabled = false;
            DbtnIzmeni.Enabled = false;
            DRightPanel.Enabled = false;
            PbtnIzbrisi.Enabled = false;
            PbtnIzmeni.Enabled = false;
            PRightPanel.Enabled = false;
            ResetPictureBox();
            UcitajDogadjaje();
            UcitajPromocije();



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DtbNaziv.Text == string.Empty || DtbOpis.Text == string.Empty)
            {
                MessageBox.Show("Nisu sva polja popunjena!");
                return;
            }
            if (UpdateID == -1)
            {
        
                var image = imageToByte(Dpicture.Image);
                UploadImageToHost(Dpicture.Image);

                #region Notifikacija dogadjaji
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //serverKey - Key from Firebase cloud messaging server  
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAACCbCLTM:APA91bFmd6AKzomDEJjI7kqL75mSo4SBFLstcsvsLZmEckDFqLekz7YUxNqmAN2FrOI7cLF0mi8dNUegG3yyOL4weEp-UiNI1s75k5ZTWJHMjOvE0TgIFvUv8VD_B5LyVtW6l2sRzvW-"));
                //Sender Id - From firebase project setting  
                tRequest.Headers.Add(string.Format("Sender: id={0}", "35009998131"));
                tRequest.ContentType = "application/json";
                var payload = new
                {
                    to = "/topics/murphypub",
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = DtbNaziv.Text,
                        title = "Murphy's Pub",
                        badge = 1
                    },
                };

                string postbody = JsonConvert.SerializeObject(payload).ToString();
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    //result.Response = sResponseFromServer;
                                    //   MessageBox.Show(sResponseFromServer);
                                }
                        }
                    }
                }
#endregion


                #region MySql upisivanje 
                var paramimg = new MySqlParameter("@Dimg", MySqlDbType.Blob, image.Length);
                paramimg.Value = image;

                MySqlConnection con = new MySqlConnection(constr);
                cmdstr = "INSERT INTO Dogadjaji (`slika`, `slikaURI`, `datum`, `naziv`, `opis`)  VALUES(@Dimg,'" + FTPFILENAME+ "', '" + Ddatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "', '" + DtbNaziv.Text + "','" + DtbOpis.Text + "')";
                MySqlCommand cmd = new MySqlCommand("", con);
                cmd.CommandText = cmdstr;
                cmd.Parameters.Add(paramimg);
                try 
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "  " + ex.InnerException);
                }
                finally
                {
                    MessageBox.Show("Dogadjaj uspešno dodat!");
                    con.Close();
                    UcitajDogadjaje();

                    DRightPanel.Enabled = false;
                    Ddatetime.Value = DateTime.Now;
                    //slika default
                    DtbNaziv.Text = string.Empty;
                    DtbOpis.Text = string.Empty;
                    TabDisabled.Visible = false;
                    DLeftPanel.Enabled = true;
                    DbtnIzbrisi.Enabled = false;
                    DbtnIzmeni.Enabled = false;
                    ResetPictureBox();
                }
                #endregion



            }
            else
            {

               

                MySqlConnection con = new MySqlConnection(constr);
                MySqlCommand cmd = new MySqlCommand("", con);
                if (ImageChanged)
                {
                    DeleteImageFromHost(GetImageIDFromDogadjajID(UpdateID));
                    UploadImageToHost(Dpicture.Image);

                    var image = imageToByte(Dpicture.Image);
                    var paramimg = new MySqlParameter("@Dimg", MySqlDbType.Blob, image.Length);
                    paramimg.Value = image;
                    cmdstr = "UPDATE Dogadjaji SET slika = @Dimg, slikaURI='"+FTPFILENAME+"', datum= '" + Ddatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "', naziv=  '" + DtbNaziv.Text + "', opis =  '" + DtbOpis.Text + "' WHERE ID = " + UpdateID.ToString();
                    cmd.Parameters.Add(paramimg);
                }
                else
                {
                    cmdstr = "UPDATE Dogadjaji SET  datum= '" + Ddatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "', naziv=  '" + DtbNaziv.Text + "', opis =  '" + DtbOpis.Text + "' WHERE ID = " + UpdateID.ToString();
                }


                //  MessageBox.Show(cmdstr);
               
                cmd.CommandText = cmdstr;
               
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Dogadjaj uspešno izmenjen!");
                    con.Close();
                    UcitajDogadjaje();

                    DRightPanel.Enabled = false;
                    Ddatetime.Value = DateTime.Now;
                    //slika default
                    DtbNaziv.Text = string.Empty;
                    DtbOpis.Text = string.Empty;
                    TabDisabled.Visible = false;
                    DLeftPanel.Enabled = true;
                    DbtnIzbrisi.Enabled = false;
                    DbtnIzmeni.Enabled = false;
                    ResetPictureBox();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            PbtnIzbrisi.Enabled = false;
            PbtnIzmeni.Enabled = false;
            PRightPanel.Enabled = false;
            Dlist.SelectedIndex = -1;
            Plist.SelectedIndex = -1;
            UpdateID = -1;
            DbtnIzbrisi.Enabled = false;
            DbtnIzmeni.Enabled = false;
        }

        private void DbtnDodaj_Click(object sender, EventArgs e)
        {
         
            DRightPanel.Enabled = true;
            TabDisabled.Visible = true;
            DLeftPanel.Enabled = false;
            Dlist.SelectedIndex = -1;
            UpdateID = -1;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void DbtnIzadji_Click(object sender, EventArgs e)
        {
            DRightPanel.Enabled = false;
            Ddatetime.Value = DateTime.Now;
            //slika default
            DtbNaziv.Text = string.Empty;
            DtbOpis.Text = string.Empty;
            
            TabDisabled.Visible = false;
            DLeftPanel.Enabled = true;
            ResetPictureBox();
        }

        private void PbtnDodaj_Click(object sender, EventArgs e)
        {
            PRightPanel.Enabled = true;
            TabDisabled.Visible = true;
            PLeftPanel.Enabled = false;
            Plist.SelectedIndex = -1;
            UpdateID = -1;
        }

        private void rbPriv_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPriv.Checked)
            {
                PrivPanel.Visible = true;
                FixPanel.Visible = false;
            }
        }

        private void rbFix_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFix.Checked)
            {
                PrivPanel.Visible = false;
                FixPanel.Visible = true;
            }
        }

        private void PbtnIzadji_Click(object sender, EventArgs e)
        {
            PRightPanel.Enabled = false;
            TabDisabled.Visible = false;
            PLeftPanel.Enabled = true;
            //Slika default
            PtbNaziv.Text = string.Empty;
            Pnum.Value = 0;
            Pdatetime.Value = DateTime.Now;
            PtbOpis.Text = string.Empty;
            rbPriv.Checked = true;
            rbFix.Checked = false;
            PrivPanel.Visible = true;
            FixPanel.Visible = false;
            ResetPictureBox();
        }

        private void TabDisabled_Click(object sender, EventArgs e)
        {

        }

        private void Dlist_SelectedIndexChanged(object sender, EventArgs e)
        {
        

            if (Dlist.SelectedIndex != -1)
            {
                DbtnIzbrisi.Enabled = true;
                DbtnIzmeni.Enabled = true;
                string[] split = Dlist.Items[Dlist.SelectedIndex].ToString().Split('|');
                UpdateID = int.Parse(split[0]);
            }
          
        }

        private void DbtnIzbrisi_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj dogadjaj?",
                      "Brisanje dogadjaja", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;

            MySqlConnection con = new MySqlConnection(constr);
            cmdstr = "DELETE FROM Dogadjaji WHERE ID = " + UpdateID.ToString();
            MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            try
            {
                DeleteImageFromHost(GetImageIDFromDogadjajID(UpdateID));
                con.Open();
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Dogadjaj uspešno izbrisan!");
                con.Close();
                UcitajDogadjaje();
                DbtnIzbrisi.Enabled = false;
                DbtnIzmeni.Enabled = false;
            }
        }

        private void DbtnIzmeni_Click(object sender, EventArgs e)
        {
            DRightPanel.Enabled = true;
            TabDisabled.Visible = true;
            DLeftPanel.Enabled = false;
            ImageChanged = false;
            PopuniDRightPanel();

        }

        private void PtbOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void Plist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Plist.SelectedIndex != -1)
            {
                PbtnIzbrisi.Enabled = true;
                PbtnIzmeni.Enabled = true;
                string[] split = Plist.Items[Plist.SelectedIndex].ToString().Split('|');
                UpdateID = int.Parse(split[0]);
            }
        }

        private void PbtnIzbrisi_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li ste sigurni da želite da obrišete ovu promociju?",
                      "Brisanje promocije", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;


            MySqlConnection con = new MySqlConnection(constr);
            cmdstr = "DELETE FROM Promocije WHERE ID = " + UpdateID.ToString();
             MySqlCommand cmd = new MySqlCommand(cmdstr, con);
            try
            {
                DeleteImageFromHost(GetImageIDFromPromocijaID(UpdateID));
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Promocija uspešno izbrisana!");
                con.Close();
                UcitajPromocije();
                PbtnIzbrisi.Enabled = false;
                PbtnIzmeni.Enabled = false;
            }
        }

        private void PbtnSacuvaj_Click(object sender, EventArgs e)
        {
            if (PtbNaziv.Text == string.Empty|| (rbFix.Checked && PtbOpis.Text == string.Empty) )
            {
                MessageBox.Show("Nisu sva polja popunjena!");
                return;
            }
            string tip;
            if (rbPriv.Checked) { tip = "Priv"; }
            else { tip = "Fiks"; }
            if (UpdateID == -1)
            {

                #region Notifikacija promocije
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //serverKey - Key from Firebase cloud messaging server  
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAACCbCLTM:APA91bFmd6AKzomDEJjI7kqL75mSo4SBFLstcsvsLZmEckDFqLekz7YUxNqmAN2FrOI7cLF0mi8dNUegG3yyOL4weEp-UiNI1s75k5ZTWJHMjOvE0TgIFvUv8VD_B5LyVtW6l2sRzvW-"));
                //Sender Id - From firebase project setting  
                tRequest.Headers.Add(string.Format("Sender: id={0}", "35009998131"));
                tRequest.ContentType = "application/json";
                var payload = new
                {
                    to = "/topics/murphypub",
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = PtbNaziv.Text,
                        title = "Murphy's Pub",
                        badge = 1
                    },
                };

                string postbody = JsonConvert.SerializeObject(payload).ToString();
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    //result.Response = sResponseFromServer;
                                    //   MessageBox.Show(sResponseFromServer);
                                }
                        }
                    }
                }
                #endregion

                #region MySql upis
                var image = imageToByte(Ppicture.Image);
                UploadImageToHost(Ppicture.Image);
                var paramimg = new MySqlParameter("@Pimg", MySqlDbType.Blob, image.Length);
                paramimg.Value = image;

               

                MySqlConnection con = new MySqlConnection(constr);
                cmdstr = "INSERT INTO Promocije (`naziv`, `cena`, `tip`, `datum`, `opis`,`SlikaURI`, `slika`) VALUES('" + PtbNaziv.Text+ "', '" + (int)(Pnum.Value / 1) + "." + (int)((Pnum.Value % 1) * 100) + "', '" +tip+"' , '" + Pdatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "', '" + PtbOpis.Text + "', '"+ FTPFILENAME +"' ,@Pimg)";
                //  MessageBox.Show(cmdstr);
                MySqlCommand cmd = new MySqlCommand("", con);
                cmd.CommandText = cmdstr;
                cmd.Parameters.Add(paramimg);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//Skinuto zbog exception
                }
                finally
                {
                    MessageBox.Show("Promocija uspešno dodata!");
                    con.Close();
                    UcitajPromocije();

                    PRightPanel.Enabled = false;
                    TabDisabled.Visible = false;
                    PLeftPanel.Enabled = true;
                    //Slika default
                    PtbNaziv.Text = string.Empty;
                    Pnum.Value = 0;
                    Pdatetime.Value = DateTime.Now;
                    PtbOpis.Text = string.Empty;
                    rbPriv.Checked = true;
                    rbFix.Checked = false;
                    PrivPanel.Visible = true;
                    FixPanel.Visible = false;
                    ResetPictureBox();
                }
                #endregion

            }
            else
            {

                if (PtbOpis.Text == string.Empty)
                    PtbOpis.Text = "Nema";
                MySqlConnection con = new MySqlConnection(constr);

                MySqlCommand cmd = new MySqlCommand("", con);
                if (ImageChanged)
                {
                    DeleteImageFromHost(GetImageIDFromPromocijaID(UpdateID));
                    UploadImageToHost(Ppicture.Image);

                    var image = imageToByte(Ppicture.Image);
                    var paramimg = new MySqlParameter("@Pimg", MySqlDbType.Blob, image.Length);
                    paramimg.Value = image;
                    cmdstr = "UPDATE Promocije SET SlikaURI = '"+FTPFILENAME+"' ,naziv= '" + PtbNaziv.Text + "',cena =  " + (int)(Pnum.Value / 1) + "." + (int)((Pnum.Value % 1) * 100) + ",tip =  '" + tip + "' ,datum =  '" + Pdatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "',opis =  '" + PtbOpis.Text + "', slika = @Pimg WHERE ID = " + UpdateID.ToString();
                    cmd.Parameters.Add(paramimg);
                }
                else
                {
                    cmdstr = "UPDATE Promocije SET naziv= '" + PtbNaziv.Text + "',cena =  " + (int)(Pnum.Value / 1) + "." + (int)((Pnum.Value % 1) * 100) + ",tip =  '" + tip + "' ,datum =  '" + Pdatetime.Value.ToString("yyyy.MM.dd  H:mm:ss") + "',opis =  '" + PtbOpis.Text + "' WHERE ID = " + UpdateID.ToString();

                }



                //    MessageBox.Show(cmdstr);

                cmd.CommandText = cmdstr;
                

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MessageBox.Show("Promocija uspešno izmenjena!");
                    con.Close();
                    UcitajPromocije();

                    PRightPanel.Enabled = false;
                    TabDisabled.Visible = false;
                    PLeftPanel.Enabled = true;
                    //Slika default
                    PtbNaziv.Text = string.Empty;
                    Pnum.Value = 0;
                    Pdatetime.Value = DateTime.Now;
                    PtbOpis.Text = string.Empty;
                    rbPriv.Checked = true;
                    rbFix.Checked = false;
                    PrivPanel.Visible = true;
                    FixPanel.Visible = false;
                    ResetPictureBox();
                }
            }
        }

        private void PbtnIzmeni_Click(object sender, EventArgs e)
        {
            PRightPanel.Enabled = true;
            TabDisabled.Visible = true;
            PLeftPanel.Enabled = false;
            ImageChanged = false;
            PopuniPRightPanel();
        }

        public byte[] imageToByte(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void PbtnIzaberi_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpe; *.png";
            openFileDialog1.Title = "Izaberi sliku";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            ImageChanged = true;
            Ppicture.Image = Image.FromFile(openFileDialog1.FileName);
            Ppicture.Refresh();

        }

        private void DbtnIzaberi_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpe; *.png";
            openFileDialog2.Title = "Izaberi sliku";
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            ImageChanged = true;
            Dpicture.Image = Image.FromFile(openFileDialog2.FileName);
            Dpicture.Refresh();
        }
    }
}
