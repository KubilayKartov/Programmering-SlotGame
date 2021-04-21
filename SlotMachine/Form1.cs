using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Deklarerar varje bild i spelet så att de alla får ett varsitt nummer.
        
        public static int b1;
        public static int b2;
        public static int b3;
        public static int b4;
        public static int b5;

        // Deklarerar pengar så att pengar får värdet 25000, deklarerar vinsten så att den blir 0 för vinsten börjar på 0..
        // ..och deklarerar totalbet dvs hur mycket som läggs in varje bet.
        
        public static long pengar = 25000;
        public static long vinst = 0;
        public static int totalbet = 30;

        // Gör så att t.ex pictureBoxen som har labeln "pictureBox3" t.ex får bilden "3.png" från filen där allting ligger..
        // ..Det här märker man när man startar programmet och man ser layouten/designen för första gången, det finns totalt 5 bilder och alla är olika.
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.png");
            pictureBox2.Image = Image.FromFile("2.png");
            pictureBox3.Image = Image.FromFile("3.png");
            pictureBox4.Image = Image.FromFile("4.png");
            pictureBox5.Image = Image.FromFile("5.png");
        }

        // Generar slumpmässiga nummer
        public static class IntUtil
        {
            private static Random random;

            public static int Random(int min, int max) 
            {
                Init();
                return random.Next(min, max);
            }
            private static void Init()
            {
                if (random == null) random = new Random();
            }
        }

        private void button1_Click(object sender, EventArgs e)

        {

            if (pengar >= totalbet)
            {
                pengar = pengar - totalbet;
                label1.Text = "Pengar: " + pengar.ToString();
                    
                vinst = 0;

                // Här använder vi for-looper för att göra det slumpmässigt. 
                // T.ex raden: "b1 = IntUtil.Random(1, 6);" gör så att b1 dvs första bilden får värdet antingen 1, 2, 3, 4 eller 5.
                // Om loopen körs och loopen hamnar på siffran 3 får b1 värdet 3 dvs tredje bilden.

                for (var i = 0; i < 10; i++)
                {
                    b1 = IntUtil.Random(1, 6);

                    b2 = IntUtil.Random(1, 6);

                    b3 = IntUtil.Random(1, 6);

                    b4 = IntUtil.Random(1, 6);

                    b5 = IntUtil.Random(1, 6);
                }

                // Kortfattat gör de här raderna detta: en slumpmässig siffra kommer från for-loopen ovan, den siffran tas och får till sig ".png" på slutet..
                // ..den siffran används sedan i t.ex pictureBox3, om pictureBox3 får av b3 siffran 5, kommer den femte bilden att användas.
                
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(b1.ToString() + ".png");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(b2.ToString() + ".png");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(b3.ToString() + ".png");

                if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
                pictureBox4.Image = Image.FromFile(b4.ToString() + ".png");

                if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
                pictureBox5.Image = Image.FromFile(b5.ToString() + ".png");

                // Hanterar med hjälp av if-satser hur vinsten ska betalas ut till användaren om hen vinner
                // T.ex om man får den 3:e av de 5 bilderna i den första pictureBoxen får man 5 pengar..
                // ..i detta fall blir det då vinst = vinst + 5 vilket blir den totala vinsten..
                // Medans t.ex i ett annat fall går det till så att om du får i den ordern så att 1:a pictureBoxen blir den 2:a bilden..
                // ..och den 2:a pictureBoxen får samma bild dvs den 2:a bilden, då får man 20 pengar i vinst istället för 5 osv osv.
                // Man får mer vinst desto mer krav man uppfyller. 
                // Om t.ex pictureBox1 blir 3 och pictureBox2 också blir 3 får man 25 i vinst eftersom båda kraven uppfylls.
                
                if (b1 == 3) vinst = vinst + 5;
                if (b1 == 4) vinst = vinst + 5;
                if (b1 == 5) vinst = vinst + 5;

                if (b1 == 2 & b2 == 2) vinst = vinst + 20;
                if (b1 == 3 & b2 == 3) vinst = vinst + 20;
                if (b1 == 4 & b2 == 4) vinst = vinst + 20;
                if (b1 == 5 & b2 == 5) vinst = vinst + 20;

                if (b1 == 1 & b2 == 1 & b3 == 1) vinst = vinst + 40;
                if (b1 == 2 & b2 == 2 & b3 == 2) vinst = vinst + 50;
                if (b1 == 3 & b2 == 3 & b3 == 3) vinst = vinst + 60;
                if (b1 == 4 & b2 == 4 & b3 == 4) vinst = vinst + 70;
                if (b1 == 5 & b2 == 5 & b3 == 5) vinst = vinst + 80;

                // Din totala summa av pengar är dina pengar + din vinst.

                pengar = pengar + vinst;

                // Gör så att texten "Vinst: " i designen håller koll på hur mycket du vinner varje gång du trycker på "spela" och spelar.

                label3.Text = "Vinst: " + vinst.ToString();

                // Gör så att texten "Pengar: " i designen håller koll åt dig hur mycket du totalt har kvar att spela för.

                label1.Text = "Pengar: " + pengar.ToString();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
