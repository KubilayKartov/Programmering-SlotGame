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

        // Deklarera vinst, totalbet och pengar
        public static long pengar = 25000;
        public static long vinst = 0;
        public static int totalbet = 30;

        // Deklarerar varje bild så att de alla får ett varsitt nummer
        public static int p1;
        public static int p2;
        public static int p3;
        public static int p4;
        public static int p5;

        // Gör så att t.ex pictureBoxen som har labeln "pictureBox3" får bilden "3.png" från filen där allting ligger...
        // ...Det här märker man när man startar programmet och man ser layouten/designen för första gången, det finns totalt 5 bilder och alla är olika.
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

            private static void Init()
            {
                if (random == null) random = new Random();
            }
            public static int Random(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (pengar >= totalbet)
            {
                pengar = pengar - totalbet;
                label1.Text = "Pengar: " + pengar.ToString();

                // Använder for sats för att göra det slumpmässigt

                for (var i = 0; i < 10; i++)
                {
                    p1 = IntUtil.Random(1, 4);
                    p2 = IntUtil.Random(1, 4);
                    p3 = IntUtil.Random(1, 4);
                    p4 = IntUtil.Random(1, 4);
                    p5 = IntUtil.Random(1, 4);
                }

                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");

                if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
                pictureBox4.Image = Image.FromFile(p4.ToString() + ".png");

                if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
                pictureBox5.Image = Image.FromFile(p5.ToString() + ".png");

                vinst = 0;

                // Hanterar med hjälp av if-satser hur vinsten ska betalas ut till användaren om hen vinner...
                // ...T.ex om man får den 1:a av de 5 bilderna i den första pictureBoxen får man 5 pengar...
                // ...i detta fall blir det då vinst = vinst + 5 vilket blir den totala vinsten...
                // ...Medans t.ex i ett annat fall går det till så att om du får i den ordern så att 1:a pictureBoxen blir den 2:a bilden...
                // ...och den 2:a pictureBoxen får samma bild dvs den 2:a bilden. Då får man 20 pengar i vinst istället för 5 osv osv.
                
                if (p1 == 3) vinst = vinst + 5;
                if (p1 == 4) vinst = vinst + 5;
                if (p1 == 5) vinst = vinst + 5;

                if (p1 == 2 & p2 == 2) vinst = vinst + 20;
                if (p1 == 3 & p2 == 3) vinst = vinst + 20;
                if (p1 == 4 & p2 == 4) vinst = vinst + 20;
                if (p1 == 5 & p2 == 5) vinst = vinst + 20;

                if (p1 == 1 & p2 == 1 & p3 == 1) vinst = vinst + 40;
                if (p1 == 2 & p2 == 2 & p3 == 2) vinst = vinst + 50;
                if (p1 == 3 & p2 == 3 & p3 == 3) vinst = vinst + 60;
                if (p1 == 4 & p2 == 4 & p3 == 4) vinst = vinst + 70;
                if (p1 == 5 & p2 == 5 & p3 == 5) vinst = vinst + 80;

                // Din totala summa av pengar är dina pengar + din vinst.

                pengar = pengar + vinst;

                // Gör så att texten "Vinst: " i designen håller koll på hur mycket du vinner varje gång du spelar.

                label3.Text = "Vinst: " + vinst.ToString();

                // Gör så att texten "Pengar: " i designen håller koll åt dig hur mycket du har totalt kvar att spela för.

                label1.Text = "Pengar: " + pengar.ToString();

            }
        }

        // Jag la bara dom här här för jag vet inte hur man tar bort dom.

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
