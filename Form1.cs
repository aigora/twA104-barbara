using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace electro2
{
    public partial class Form1 : Form
    {
        Pen lapiz_G = new Pen(Color.Blue);    //Con el comando pen, le digo el color del lapiz con el que quiero dibujar
        Pen lapiz_Basico = new Pen(Color.Magenta, width: 2); //En este caso es igual al anterior, pero con la particularidad del comando wigth:2 que me indica el doble del grosor asignado
        Graphics G = null;
        static int Ix,Fx,Iy,Fy;
        string Fichero = "";

        private void Pintar_Click(object sender, EventArgs e)
        {
            Reinicia();  //Llamamos a la funcion que declaramos detras del codigo
            string linea;
            int incremento;
            System.IO.StreamReader fich_bin = new System.IO.StreamReader(Fichero);  //En este caso que lea los carcteres del fichero
            while ((linea = fich_bin.ReadLine()) != null)  //Los caracteres leidos se asignan a la string linea siempre y cuando no este vacio
            {
                incremento = Int32.Parse(linea);  //En esta linea te convierte los caracteres leidos en numeros enteros
                dibuja_Linea(Ix,Fx, Iy, Fy,lapiz_G );  //Llama la funcion dibuja_linea
                Ix = Fx;
                Iy = Fy;
                Fx = Fx + 20; //El 20 podria ser cualquier numero en este caso yo digo que este 20 corresponde a 1 seg
                Fy = panel2.Height - 40 -incremento;  //En este caso se resta el incremento porque la y sube nunca es negativa
                
            }
        }

        private void Reinicia()
        {
            Ix = 40; //Inicia el punto incial y el final de x como el mismo
            Fx = 40;
            Iy = panel2.Height - 40;
            Fy = panel2.Height - 40;
            panel2.Refresh();
            G = panel2.CreateGraphics();
            G.Clear(Color.LightYellow);
            dibuja_Linea(40, 40, 40, panel2.Height-40,lapiz_Basico); //Dibuja una linea vertical
            dibuja_Linea(40,panel2.Width-40, panel2.Height - 40, panel2.Height - 40,lapiz_Basico); //Dibuja una linea horizontal
        }

        private void dibuja_Linea(int pIx, int pFx, int pIy, int pFy, Pen t_lapiz)
        {
            Point[] puntos =                 //array
            {
                new Point (pIx,pIy),
                new Point (pFx,pFy)
            };
            
            G.DrawLines(t_lapiz, puntos);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fich_dialogo = new OpenFileDialog();
            if (fich_dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fichero = fich_dialogo.FileName;
                ruta_fichero.Text = Fichero;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ruta_fichero_TextChanged(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
