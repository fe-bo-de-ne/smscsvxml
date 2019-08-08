using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO; 
using System.Xml.Serialization;
namespace smscsvxml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ofdScegli.ShowDialog() != DialogResult.OK)
            {

            }

            string fname = ofdScegli.FileName;

            string cartella = Path.GetDirectoryName(fname);
            string file = Path.GetFileName(fname);

            //characterset=65001; is for UTF8
            lblCSV.Text = file;
            var filename = fname;
            var connString = string.Format(
                @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;characterset=65001;HDR=YES;FMT=Delimited""",
                Path.GetDirectoryName(filename)
            );
            using (var conn = new OleDbConnection(connString))
            {
                conn.Open();
                var query = "SELECT * FROM [" + Path.GetFileName(filename) + "]";
                using (var adapter = new OleDbDataAdapter(query, conn))
                {
                    var dt = new DataTable("CSV File");
                    adapter.Fill(dt);
                    dgvSMS.DataSource = dt;

                    smses smsxml = new smses();
                    smsxml.count = (ushort)(dt.Rows.Count);
                    object[] lista = new object[dt.Rows.Count];

                    for (int i =0; i < dt.Rows.Count; i++)
                    {
                        smsesSms sms = new smsesSms();

                        //these defaults must be specified
                        sms.protocol = (byte)(0);
                        sms.protocolSpecified = true;
                        sms.toa = "null";
                        sms.sc_toa = "null";
                        sms.service_center = "null";
                        //epoch conversion
                        sms.address = dt.Rows[i].Field<double?>("Number").ToString();
                        if (sms.address == "" || sms.address == null) sms.address = "(Unknown)";
                         sms.date = (ulong)(1000 * (dt.Rows[i].Field<System.DateTime>("Created").ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
                        //net 4.6
                       // var dateTimeOffset = new DateTimeOffset(dt.Rows[i].Field<System.DateTime>("Created"));
                       // var unixDateTime = dateTimeOffset.ToUnixTimeSeconds();
                       // sms.date = (ulong)(unixDateTime * 1000);
                        switch (dt.Rows[i].Field<String>("Folder"))
                        {
                            case "INBOX":
                                    sms.type = 1;
                                break;

                            case "OUTBOX":
                                sms.type = 2;
                                break;

                            case "DRAFT":
                                sms.type = 3;
                                break;
                            default:
                                sms.type = 1;
                                break;
                        }
                        sms.subject = null;
                        sms.body = dt.Rows[i].Field<String>("Text");
                        sms.contact_name = dt.Rows[i].Field<String>("Sender Name");

                        if (sms.contact_name == "" || sms.contact_name == null) sms.contact_name = "(Unknown)";
                        sms.status = 0;
                        sms.read = 1;
                       // sms.readable_date = dt.Rows[i].Field<System.DateTime>("Created").ToString();
                        lista[i] = sms;
                    }
                    smsxml.Items = lista;
                    var x = new XmlSerializer(typeof(smses));
                   string pathbackup = @".\sms-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";

                    var fs = new FileStream((pathbackup), FileMode.OpenOrCreate);
                    x.Serialize(fs, smsxml);
                    fs.Close();
                    MessageBox.Show(pathbackup + " created!");
                }
            }
        }
    }
}
