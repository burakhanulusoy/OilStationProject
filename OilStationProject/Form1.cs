using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OilStationProject
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] depo_info;  // Depo Miktarları yapma nedenim ListViewe atmak  //url için
        string[] price_info; // fiyat miktaralrı nedeni aynı  //url için

        double depo_ben95, depo_97, depo_nor_diesel, depo_eoru_dis, depo_lpg;  // dosyadan alınan degerler
        
        double max_ben95=1000, max_97=1000, max_nor_diesel=1000, max_eoru_dis=1000, max_lpg=1000; // progress bar max ayarlamak için


        double ekle_ben95, ekle_97, ekle_nor_diesel, ekle_eoru_dis, ekle_lpg;// eklenecek olan depo degrleri

        // globalde tanımlama sebebim metotlar ile çalıştım kolay erişebilmek için


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void depo_txt_oku()  // DOSYADAN DEPO DEGERLERİ OKUMA METOTUM GENELDE İLK HATA VERDİ AMA HEM TXT HEM NORMAL AD YAZINCA DÜZELDİ SEBEBİNİ BULAMADIM
        {
            depo_info = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");  // KURAL
            depo_ben95 = Convert.ToDouble(depo_info[0]);      // İLK DEGERLERİ ATADIM
            depo_97 = Convert.ToDouble(depo_info[1]);
            depo_nor_diesel = Convert.ToDouble(depo_info[2]);
            depo_eoru_dis = Convert.ToDouble(depo_info[3]);
            depo_lpg = Convert.ToDouble(depo_info[4]);
        }

        private void depo_txt_labelWrite()
        {
            label_gASOLİNE95.Text = depo_ben95.ToString();   // LABEL A DEGRLERİ YAZDIRMA METODU
            label_gas97.Text = depo_97.ToString();
            label_di.Text = depo_nor_diesel.ToString();
            label_euroDi.Text = depo_eoru_dis.ToString();
            label_lpg.Text = depo_lpg.ToString();
        }

       
        private void depo_ekle_oil()  // ADD BASINCA BU METOT CALISSSIN DEDİM 
        {

            if (textBox_gas95.Text.Length > 0)  // BİR SEYLER YAZIP YAZMADIGINI KONTROL ETTIM YAZMADIYSA İŞLEME GEREK YOK ELSE DE GEREK YOK BUNU İÇİN
            {
                ekle_ben95 = Convert.ToDouble(textBox_gas95.Text);// EKLENECEK OLANI ATAMA GLOBALDE TANIMLI BUNLAR!!!!

                if ((ekle_ben95 + depo_ben95) < max_ben95)  // MAX DEGERİ GECEMEZ
                {
                    depo_ben95 += ekle_ben95;
                    textBox_gas95.Text = "";

                }
                else
                {
                    MessageBox.Show(" 95 benzin Depoda yeterli alan yok");
                }

            }

            //********************************************

            if(textBox_gas97.Text.Length > 0)
            {
                ekle_97 = Convert.ToDouble(textBox_gas97.Text);

                if ((ekle_97 + depo_97) < max_97)
                {
                    depo_97 += ekle_97;
                    textBox_gas97.Text = "";
                }
                else
                {
                    MessageBox.Show(" 97 benzin Depoda yeterli alan yok");
                }

            }

            if(textBox_di.Text.Length > 0)
            {
                ekle_nor_diesel = Convert.ToDouble(textBox_di.Text);

                if ((ekle_nor_diesel + depo_nor_diesel) < max_nor_diesel)
                {
                    depo_nor_diesel += ekle_nor_diesel;
                    textBox_di.Text = "";
                }
                else
                {
                    MessageBox.Show(" Normal Dizel Depoda yeterli alan yok");
                }
            }

            if(textBox_diwuro.Text.Length > 0)
            {
                ekle_eoru_dis = Convert.ToDouble(textBox_diwuro.Text);
                if ((ekle_eoru_dis + depo_eoru_dis) < max_eoru_dis)
                {
                    depo_eoru_dis += ekle_eoru_dis;
                    textBox_diwuro.Text = "";
                }
                else
                {
                    MessageBox.Show(" Euro Dizel Depoda yeterli alan yok");
                }
            }

            if(textBox_lpg.Text.Length > 0)
            {
                ekle_lpg = Convert.ToDouble(textBox_lpg.Text);

                if ((ekle_lpg + depo_lpg) < max_lpg)
                {
                    depo_lpg += ekle_lpg;
                    textBox_lpg.Text = "";
                }
                else
                {
                    MessageBox.Show(" LPG Depoda yeterli alan yok");
                }

            }

            satıs_yap_fiyat_yazlabele();

        }

        

        private void depo_progressBar()   // PROGRESS BAR MAX ATAMAM LAIM İLK CUNKU DEPO MKTARINI DEGİSTİREBİLŞİRİM
        {
            progressBar1.Maximum = (int)max_ben95;//maxları yukarda 1000 olarak tanımladım ilk bakabiirsin
            progressBar5.Maximum = (int)max_97;
            progressBar2.Maximum = (int)max_nor_diesel;
            progressBar3.Maximum = (int)max_eoru_dis;
            progressBar4.Maximum = (int)max_lpg;

            // DEGERİNİ DEPODA O ANDA BULUNAN MİKTAR YAPTIM

            progressBar1.Value= (int)depo_ben95;
            progressBar5.Value = (int)depo_97;
            progressBar2.Value = (int)depo_nor_diesel;
            progressBar3.Value = (int)depo_eoru_dis;
            progressBar4.Value = (int)depo_lpg;

            label14.Text=max_ben95.ToString();//maxların labelleri
            label15.Text = max_97.ToString();
            label16.Text = max_nor_diesel.ToString();
            label17.Text = max_eoru_dis.ToString();
            label18.Text = max_lpg.ToString();


        }           

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////
        /// </summary>
        

        /*

        yukarisi depo ayarlari dikkat 
        aşagısı fiyat ayaralri

        */

      

        private void tabPage2_Click(object sender, EventArgs e)
        {

      
        }


        // GLOBAL FİYAT DEGERLERİ BENZİNLERİN
        double fiyat_ben95, fiyat_97, fiyat_nor_diesel, fiyat_eoru_dis, fiyat_lpg;

        // FİYAT DEGİSİNCE BUNLARA ATADIM    
        double change_ben95, change_97, change_nor_diesel, change_eoru_dis, change_lpg;

      
        // DEGİSMEDEN ONCEKİ DEGRLERİ BUNLARA ATADIM
        double before_change_ben95, before_change_97, before_change_nor_diesel, before_change_eoru_dis, before_change_lpg;

        
        // ZAM VEYA İNDİDİRİM YAPMA ADı OLAY
        string olay = null; 


        // BURDA LİSTVİEWE EKLEME İŞLMİ YAPLDİ
        private void numapupIslemleri(ListView list, double beforePrice, double nowPrice)
        {
            string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string[] infos = { time, olay, beforePrice.ToString(), nowPrice.ToString(), olay };
            ListViewItem listViewItem = new ListViewItem(infos);
            list.Items.Add(listViewItem);

        }


        // DOSYADAN OKUMA İŞLEMİ VE ATAMA YAPTIK
        private void fiyat_oku()
        {
            price_info = System.IO.File.ReadAllLines(Application.StartupPath + "\\deger.txt");

            fiyat_ben95 = Convert.ToDouble(price_info[0]);
            fiyat_97 = Convert.ToDouble(price_info[1]);
            fiyat_nor_diesel = Convert.ToDouble(price_info[2]);
            fiyat_eoru_dis = Convert.ToDouble(price_info[3]);
            fiyat_lpg = Convert.ToDouble(price_info[4]);
        }



        /// ZAM OLAYI BURDA YAPILDI MANTIK COK BASİT ANLATIYORUM
        private void fiyat_art()
        {
            
            olay = "zam";
            if (numericUpDown1.Value != 0)  // MURİCTEKİ DEGER 0 DA FARKLİ OLMAK ZORUNDA CUNKU 0 ZAM VEYA İNDİİRİM OLMAZ YANİ DEGER İSTİYORUZ
            { 
                                            // DEGİSİM OLCAGI ICIN BENZİN FİYATINDA
                                            
                                            //İL ONCE BEFORE FİYATA ATADIM 
                                           
                                            //CHANGE İLE NUMERİCTEKİ DEGRİ ALİP FİYATA EKLEDIM VE HEMEN LİSTVİEW ATAYIP DEGERİ EKLEDİM
                                                
                before_change_ben95 = fiyat_ben95;
                change_ben95 = Convert.ToDouble(numericUpDown1.Value);
                fiyat_ben95 += change_ben95;
                numapupIslemleri(listView1, before_change_ben95, fiyat_ben95);
                numericUpDown1.Value = 0;
            }
            if (numericUpDown2.Value != 0)
            {
                before_change_97 = (int)fiyat_97;
                change_97 = Convert.ToDouble(numericUpDown2.Value);
                fiyat_97 += change_97;
                numapupIslemleri(listView2,before_change_97, fiyat_97);
                numericUpDown2.Value = 0;
            }
            if(numericUpDown3.Value != 0)
            {
                before_change_nor_diesel = (int)fiyat_nor_diesel;
                change_nor_diesel = Convert.ToDouble(numericUpDown3.Value);
                fiyat_nor_diesel += change_nor_diesel;
                numapupIslemleri(listView3,before_change_nor_diesel, fiyat_nor_diesel);  
                numericUpDown3.Value = 0;
            }
            if (numericUpDown4.Value != 0)
            {
                before_change_eoru_dis = (int)fiyat_eoru_dis;
                change_eoru_dis = Convert.ToDouble(numericUpDown4.Value);
                fiyat_eoru_dis += change_eoru_dis;
                numapupIslemleri(listView4,before_change_eoru_dis, fiyat_eoru_dis);
                numericUpDown4.Value = 0;
            }
            if (numericUpDown5.Value != 0)
            {
                before_change_lpg = (int)fiyat_lpg;
                change_lpg = Convert.ToDouble(numericUpDown5.Value);
                fiyat_lpg += change_lpg;
                numapupIslemleri(listView5,before_change_lpg, fiyat_lpg);
                numericUpDown5.Value = 0;
            }

            satıs_yap_fiyat_yazlabele();

        }  


        // AZALTMA OLAYI ARRTTIRMA ILE TAMAMMEN AYNI MANTIK
        private void fiyat_azalt()
        {
            olay = "indirim";
            if (numericUpDown1.Value != 0)
            {
                before_change_ben95 = (double)fiyat_ben95;
                change_ben95 = Convert.ToDouble(numericUpDown1.Value);
                fiyat_ben95 -= change_ben95;
                numapupIslemleri(listView1, before_change_ben95, fiyat_ben95);
                numericUpDown1.Value = 0;
            }
            if (numericUpDown2.Value != 0)
            {
                before_change_97 = (int)fiyat_97;
                change_97 = Convert.ToDouble(numericUpDown2.Value);
                fiyat_97 -= change_97;
                numapupIslemleri(listView2,before_change_97, fiyat_97);
                numericUpDown2.Value = 0;
            }
            if (numericUpDown3.Value != 0)
            {
                before_change_nor_diesel = (int)fiyat_nor_diesel;
                change_nor_diesel = Convert.ToDouble(numericUpDown3.Value);
                fiyat_nor_diesel -= change_nor_diesel;
                numapupIslemleri(listView3,before_change_nor_diesel, fiyat_nor_diesel);
                numericUpDown3.Value = 0;
            }
            if (numericUpDown4.Value != 0)
            {
                before_change_eoru_dis = (int)fiyat_eoru_dis;
                change_eoru_dis = Convert.ToDouble(numericUpDown4.Value);
                fiyat_eoru_dis -=change_eoru_dis;
                numapupIslemleri(listView4,before_change_eoru_dis, fiyat_eoru_dis);
                numericUpDown4.Value = 0;

            }
            if (numericUpDown5.Value != 0)
            {
                before_change_lpg = (int)fiyat_lpg;
                change_lpg = Convert.ToDouble(numericUpDown5.Value);
                fiyat_lpg -= change_lpg;
                numapupIslemleri(listView5,before_change_lpg, fiyat_lpg);
                numericUpDown5.Value = 0;
            }

            satıs_yap_fiyat_yazlabele();
        }
        // YENİ FİYATI LABELE YAZDIDIM
        private void fiyat_yaz_labele()
        {

            label23.Text = fiyat_ben95.ToString();
            label19.Text = fiyat_97.ToString();
            label20.Text = fiyat_nor_diesel.ToString();
            label21.Text = fiyat_eoru_dis.ToString();
            label22.Text = fiyat_lpg.ToString();



        }
      

        // satıs isşlemleri baslıyorum

        /*



        *****************************************************************



        */


        // SATIS YAPINCA DEPO MIKTARI AZALIR BUNUN ICIN DEPO SAYFASI VE BU SAYFADAKI LABELLERE İSLEM YAPTIRDIM

       private void satıs_yap_fiyat_yazlabele()
        {
            label39.Text = depo_ben95.ToString();
            label30.Text = depo_97.ToString();
            label31.Text = depo_nor_diesel.ToString();
            label32.Text = depo_eoru_dis.ToString();
            label33.Text = depo_lpg.ToString();

            ////////////////////////////



            label44.Text = fiyat_ben95.ToString();
            label40.Text = fiyat_97.ToString();
            label41.Text = fiyat_nor_diesel.ToString();
            label42.Text = fiyat_eoru_dis.ToString();
            label43.Text = fiyat_lpg.ToString();
        }


        // SATIS METOTU ACIKLIYORUM
        private void Sat()
        {
            long tc = Convert.ToInt64(textBox11.Text);

            // ONCELİKLE CHECKBOX KONTROLU TC KONTROLU DİREK BUUTON CLIKTE
            //ONCE YAZILI BIR SEY VAR MI KONTROLU
            //SONRA DEPO KONTROLIU
            //SONRA SATIS

            if (checkBox1.Checked)
            {
                if (textBox6.Text.Length > 0)
                {
                    if (depo_ben95 > Convert.ToInt32(textBox6.Text))
                    {
                        ListViweIslemiSatıs(tc, fiyat_ben95, Convert.ToInt32(textBox6.Text), "gasoline 95");
                        textBox16.Text = (fiyat_ben95 * Convert.ToInt32(textBox6.Text)).ToString();
                        //16 .TEXTBOC ENABLED FALSE SADECE FİYAT GORUNUR SATINCA GELEN TOPLAM PARA
                        depo_ben95 -= Convert.ToDouble(textBox6.Text);
                        textBox6.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Depoda yeterli benzin(95) yok");
                        textBox6.Text = "";
                    }



                }

                //
                if (textBox7.Text.Length > 0)
                {

                    if (depo_97 > Convert.ToInt32(textBox7.Text))
                    {
                        ListViweIslemiSatıs(tc, fiyat_97, Convert.ToInt32(textBox7.Text), "gasoline 97");
                        textBox15.Text = (fiyat_97 * Convert.ToInt32(textBox7.Text)).ToString();

                        depo_97 -= Convert.ToDouble(textBox7.Text);
                        textBox7.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Depoda yeterli benzin(97) yok");
                        textBox7.Text = "";
                    }

                }

                if (textBox8.Text.Length > 0)
                {
                    if (depo_nor_diesel > Convert.ToInt32(textBox8.Text))
                    {
                        ListViweIslemiSatıs(tc, fiyat_nor_diesel, Convert.ToInt32(textBox8.Text), "Normal diesel");
                        textBox14.Text = (fiyat_nor_diesel * Convert.ToInt32(textBox8.Text)).ToString();

                        depo_nor_diesel -= Convert.ToDouble(textBox8.Text);
                        textBox8.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Depoda yeterli dizel yok");
                        textBox8.Text = "";
                    }
                }

                if (textBox9.Text.Length > 0)
                {
                    if (depo_eoru_dis > Convert.ToInt32(textBox9.Text))
                    {
                        ListViweIslemiSatıs(tc, fiyat_eoru_dis, Convert.ToInt32(textBox9.Text), "euro diesel");
                        textBox13.Text = (fiyat_eoru_dis * Convert.ToInt32(textBox9.Text)).ToString();




                        depo_eoru_dis -= Convert.ToDouble(textBox9.Text);
                        textBox9.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Depoda yeterli dizel yok");
                        textBox9.Text = "";
                    }


                }

                if (textBox10.Text.Length > 0)
                {
                    if (depo_lpg > Convert.ToInt32(textBox10.Text))
                    {
                        ListViweIslemiSatıs(tc, fiyat_lpg, Convert.ToInt32(textBox10.Text), "lpg");
                        textBox12.Text = (fiyat_lpg * Convert.ToInt32(textBox10.Text)).ToString();

                        depo_lpg -= Convert.ToDouble(textBox10.Text);
                        textBox10.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Depoda yeterli dizel yok");
                        textBox10.Text = "";
                    }


                }

                depo_txt_labelWrite();
                depo_progressBar();
                satıs_yap_fiyat_yazlabele();


            }
            else
            {
                MessageBox.Show("Eğer değerler dogru ise onalyain ", "hata!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        // LİSTVİEW İSLEMİ SATIS AİT
        private void ListViweIslemiSatıs(long tc,double fiyat,int litre,string cesit)
        {
            string[] eklenen = { Convert.ToString(DateTime.Now),tc.ToString(),fiyat.ToString(),litre.ToString(),cesit,(fiyat*litre).ToString()};
            ListViewItem abi = new ListViewItem(eklenen);
            listView6.Items.Add(abi);
        }


        //3.SAYFA SATIS BUTTONU
        private void button5_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox11, "11 karekterli olmak zorunda");
            if (textBox11.Text.Length == 11)
            {
                errorProvider1.Clear();
                Sat();
            }
        }


        // CLASSİCAL
        private void Form1_Load(object sender, EventArgs e)
        {
            depo_txt_oku();
            depo_txt_labelWrite();
            depo_progressBar();

            fiyat_oku();
            fiyat_yaz_labele();

            satıs_yap_fiyat_yazlabele();


        }

        // DEPO ADD BUTONU
        private void button1_Click(object sender, EventArgs e)
        {

            depo_ekle_oil();
            depo_txt_labelWrite();
            depo_progressBar();
        }


       //DEPO MİKTARI ARRRTIRMA BUTONU
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                max_ben95 += Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
            }
            if(textBox2.Text.Length > 0)
            {
                max_97 += Convert.ToDouble(textBox2.Text);
                textBox2.Text = "";
            }
            if (textBox3.Text.Length > 0)
            {
                max_nor_diesel += Convert.ToDouble(textBox3.Text);
                textBox3.Text = "";
            }
            if (textBox4.Text.Length > 0)
            {
                max_eoru_dis += Convert.ToDouble(textBox4.Text);
                textBox4.Text = "";
            }
            if (textBox5.Text.Length > 0)
            {
                max_lpg += Convert.ToDouble(textBox5.Text);
                textBox5.Text = "";
            }

            depo_progressBar();


        }

        // FİYAR ARRTTIR
        private void button3_Click(object sender, EventArgs e)
        {
            fiyat_art();
            fiyat_yaz_labele();
        }

        //// FİYAT AZALT BUTONU 
        private void button4_Click(object sender, EventArgs e)
        {

            fiyat_azalt();
            fiyat_yaz_labele();

        }




    }
}









