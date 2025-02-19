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

namespace WindowsFormsApp5 {
    public partial class Form1 : Form {
        struct krater {
            public double x;
            public double y;
            public double r;
            public string nev;
        }
        List<krater> lista = new List<krater>();
        public Form1() {
            InitializeComponent();
            // 1. feladat - beolvasás
            var sr = new StreamReader("felszin.txt");
            while (!sr.EndOfStream) {
                var sor = sr.ReadLine().Split('\t');
                var rekord = new krater();
                rekord.x = double.Parse(sor[0]);
                rekord.y = double.Parse(sor[1]);
                rekord.r = double.Parse(sor[2]);
                rekord.nev = sor[3];
                lista.Add(rekord);
            }
            sr.Close();
            // 2. sorok száma
            label2.Text = lista.Count.ToString();
            // 4. feladat - maximum keresés
            var maxSugar = lista[0].r;
            foreach (var item in lista) {
                if (item.r > maxSugar) {
                    maxSugar = item.r;
                    label4.Text = $"A legnagyobb kráter neve és sugara: {item.nev}, {item.r}";
                }
            }
            // 5. feladat
            double tav = tavolsag(100.5,50.0,200.0,80.0);
            MessageBox.Show(tav.ToString());
        }

        private double tavolsag(double x1, double y1, double x2, double y2) {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        private void button1_Click(object sender, EventArgs e) {
            // 3. 
            var keresettAdat = textBox1.Text;
            var index = -1;
            foreach (var item in lista) {
                if (item.nev == keresettAdat) {
                    index = lista.IndexOf(item);
                }
            }
            if (index == -1) {
                label3.Text = "Nincs ilyen nevű kráter";
            }
            else {
                //megvan
                label3.Text = $"A {lista[index].nev} középpontja: {lista[index].x}, {lista[index].y}";
            }
        }
    }
}
