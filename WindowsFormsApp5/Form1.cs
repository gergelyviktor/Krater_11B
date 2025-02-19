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
            // 3. 
        }
    }
}
