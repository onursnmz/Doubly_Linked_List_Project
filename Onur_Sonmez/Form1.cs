using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onur_Sonmez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class dugum
        {
            public string ad;
            public int numara;
            public int fiyat;
            public dugum onceki;
            public dugum sonraki;
            
        }
        dugum ilk = null;
        dugum temp = null;
        dugum yeni = new dugum();
        

        public void print()
        {
            listBox1.Items.Clear();
            dugum abc = new dugum();
            abc = ilk;

            while (abc != null)
            {
                listBox1.Items.Add(abc.numara + "---"+" "+ abc.ad+"---"+" "+ abc.fiyat.ToString()+" "+"TL");

                abc = abc.sonraki;
            }

        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            dugum yeni = new dugum();
            yeni.ad = textBox2.Text;
            yeni.numara = Convert.ToInt32(textBox1.Text);
            yeni.fiyat = Convert.ToInt32(textBox3.Text);
            if (ilk == null)
            {

                yeni.ad = textBox2.Text;
                yeni.numara = Convert.ToInt32(textBox1.Text);
                ilk = yeni;
                ilk.sonraki = null;

            }
            else
            {
                dugum iter, temp;
                iter = ilk;
                if (yeni.numara < ilk.numara)
                {
                    temp = ilk;
                    ilk = yeni;
                    ilk.sonraki = temp;
                }
                else
                {
                    while (iter.sonraki != null && iter.sonraki.numara < yeni.numara)
                    {
                        iter = iter.sonraki;
                    }
                    yeni.sonraki = iter.sonraki;
                    iter.sonraki = yeni;
                }
            }
            print();
            

        }

        public void button2_Click(object sender, EventArgs e)
        {
            dugum iter;
            iter = ilk;
            dugum temp;
            if (ilk == null)
            {
                label10.ForeColor = Color.Red;
                label10.Text = "LİSTEDE HERHANGİ BİR ELEMAN YOK!";
            }
            else
            {
                //Eğer sileceğimiz düğüm baştaysa, başlangıç düğümünü kaybetmemek adına temp adlı değişken
                //oluşturup sileceğimiz düğümü o temp haline getirip öyle sildik. Daha sonrasında başlangıç düğümünü
                //eski başlangıç'ın bir sonrasına attık(çünkü eski başlangıç silinmesi istendi)
                if (ilk.numara == Convert.ToInt32(textBox6.Text))
                {
                    temp = ilk;
                    ilk = ilk.sonraki;
                    temp = null;
                }
                else
                {
                    while (iter.sonraki != null && iter.sonraki.numara != Convert.ToInt32(textBox6.Text))
                    {
                        iter = iter.sonraki;
                    }
                    if (iter.sonraki == null)
                    {
                        label10.ForeColor = Color.Red;
                        label10.Text = "Girdiğiniz numara bulunamadı.";
                    }
                    else
                    {
                        temp = iter.sonraki;
                        iter.sonraki = iter.sonraki.sonraki;
                        temp = null;
                    }
                }
            }
            print();

        }

        public void button5_Click(object sender, EventArgs e)
        {
            temp = ilk;
            dugum onceki;
            dugum bul = new dugum();
            bul.numara = Convert.ToInt32(textBox6.Text);
            if (ilk.numara == bul.numara)
            {
                textBox5.Text = temp.ad;
                textBox4.Text = Convert.ToString(temp.fiyat);
            }else{

                onceki = ilk;
                temp = ilk.sonraki;




                if (temp.numara == bul.numara)
                {
                    onceki.sonraki = temp.sonraki;
                    textBox5.Text = temp.ad;
                    textBox4.Text = Convert.ToString(temp.fiyat);
                }


                else
                {
                    label10.ForeColor = Color.Red;
                    label10.Text = "Ürün bulunamadı.";
                }

            }

        }
            

       public void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            temp = ilk;
            dugum onceki;
            dugum bul = new dugum();
            bul.numara = Convert.ToInt32(textBox9.Text);
            if (ilk.numara == bul.numara)
            {
                textBox8.Text = temp.ad;
                textBox7.Text = Convert.ToString(temp.fiyat);
            }
            else
            {

                onceki = ilk;
                temp = ilk.sonraki;




                if (temp.numara == bul.numara)
                {
                    onceki.sonraki = temp.sonraki;
                    textBox8.Text = temp.ad;
                    textBox7.Text = Convert.ToString(temp.fiyat);
                }


                else
                {
                    label10.ForeColor = Color.Red;
                    label10.Text = "Ürün bulunamadı.";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dugum iter;
            iter = ilk;
            dugum temp;
            if (ilk == null)
            {
                label10.ForeColor = Color.Red;
                label10.Text = "LİSTEDE HERHANGİ BİR ELEMAN YOK!";
            }
            else
            {
                
                while(iter.numara != Convert.ToInt32(textBox9.Text))
                {
                    iter = iter.sonraki;
                }
                    iter.ad = textBox8.Text;
                    iter.fiyat = Convert.ToInt32(textBox7.Text);
                
                
            }
            print();
        }
    }
    }

