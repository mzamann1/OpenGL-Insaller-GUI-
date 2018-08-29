using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace InstallOpenGLFiles
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue500, Primary.Blue400,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            materialLabel1.Text = "Note," +Environment.NewLine + "glut.h should be in Visual Studio's C++ Include Folder,"+Environment.NewLine+ "glut.dll should be in C:>Windows>System>" + Environment.NewLine+"glut32.lib should be in Visual Studio's C++ Lib Folder";
            
            b2.Enabled = false;
            b3.Enabled = false;
        }
        string[] file = new string[] {@"../../Files\glut.h",@"../../Files\glut.dll",@"../../Files\glut32.lib"};
        FileWrite fw = new FileWrite();
        string p;
        
        public void close()
        {
            if (!(b1.Enabled&b2.Enabled&b3.Enabled))
            {
                this.Dispose();
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f1 = new FolderBrowserDialog();
            f1.ShowDialog();
            textBox1.Text = f1.SelectedPath.ToString();
            p = Path.GetFullPath(file[0]);
            string opt = fw.Write(p, textBox1.Text, "glut.h");
            if (opt=="FAE")
            {
                b1.Enabled = false;
                textBox1.Enabled = false;
                throw new Exception("File Already Existed");
                
            }
            else
            MessageBox.Show(opt, "Success", MessageBoxButtons.OK);

            b1.Enabled = false;
            textBox1.Enabled = false;
            b2.Enabled = true;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f2 = new FolderBrowserDialog();
            f2.ShowDialog();
            textBox2.Text = f2.SelectedPath.ToString();
            p = Path.GetFullPath(file[1]);
            if (textBox2.Text == @"C:\Windows\System32")
            {
                string opt1 = fw.Write(p, textBox2.Text, "glut32.dll");

                if (opt1 == "FAE")
                {
                    b2.Enabled = false;
                    textBox1.Enabled = false;
                    throw new Exception("File Already Existed");
                }
                else
                {
                    MessageBox.Show(opt1,"Success", MessageBoxButtons.OK);
                    
                }
                b2.Enabled = false;
                textBox2.Enabled = false;
                b3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Directory Must Be C:>Windows>System32>", "Error", MessageBoxButtons.OK);
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f3 = new FolderBrowserDialog();
            f3.ShowDialog();
            textBox3.Text = f3.SelectedPath.ToString();
            p = Path.GetFullPath(file[2]);

            string opt2 = fw.Write(p, textBox3.Text, "glut32.lib");
            
            if (opt2 == "FAE")
            {
                b3.Enabled = false;
                textBox3.Enabled = false;
                throw new Exception("File Already Existed");
            }
            else
            MessageBox.Show(opt2,"Success", MessageBoxButtons.OK);

            textBox3.Enabled = false;
            b3.Enabled = false;
            close();
        }
    }
        
}
