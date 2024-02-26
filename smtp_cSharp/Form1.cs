using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smtp_cSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string connString = "Veri Tabanı Bağlantı Yolunuz";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.email_addressesTableAdapter.Fill(this.eMailDBDataSet.email_addresses);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Credentials = new System.Net.NetworkCredential("Mail Adresiniz", "Google Tarafından Aldığınız Şifre");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["e_mail"].Value != null && !string.IsNullOrEmpty(row.Cells["e_mail"].Value.ToString()))
                        {
                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress("Mail Adresiniz");
                            mail.To.Add(row.Cells["e_mail"].Value.ToString());
                            mail.Subject = textBox2.Text;
                            mail.Body = richTextBox1.Text;

                            try
                            {
                                smtp.Send(mail);
                                listBox2.Items.Add($"Mail Gönderimi Başarılı: {row.Cells["e_mail"].Value} {DateTime.Now}");
                            }
                            catch (SmtpException hata)
                            {
                                listBox1.Items.Add($"{hata.Message} Mail Gönderilemedi! HATA: {row.Cells["e_mail"].Value}");
                            }
                        }
                    }
                }
            }
        }
    }
}
