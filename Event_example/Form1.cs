using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]
namespace Event_example
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        public Form1()
        {
            InitializeComponent();
            log.Debug("This is a Debug Message");
            log.Info("This is a Info Message");
            log.Warn("This is a Warn Message");
            log.Error("This is a Error Message");
            log.Fatal("This is a Fatal Message");
            fun();
        }
        public delegate void del();
        public void fun()
        {
            log.Debug("This is a Debug Message");
            log.Info("This is a Info Message");
            log.Warn("This is a Warn Message");
            log.Error("This is a Error Message");
            log.Fatal("This is a Fatal Message");
            try
            {
                throw new Exception("!this is a test message!");
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fun();
            Araba araba = new Araba();
            araba.HizAsimi += Araba_HizAsimi;
            araba.Hiz = 50;
            for (int i = 0; i < 10; i++)
            {
                araba.Hiz += 10;
                listBox1.Items.Add(araba.Hiz);
            }
            del de = new del(Araba_HizAsimi);
            de.Invoke();
            List<string> lst = new List<string>() { "asd", "asdf" };
            IEnumerable<string> ienum = lst;
            foreach (var item in ienum)
            {
                listBox1.Items.Add(item);
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "Excel|*.xlsx";
            ofd.ShowDialog();
        }

        private void Araba_HizAsimi()
        {
            listBox1.Items.Add("Hızı aştığından Hız Sabitlendi!!!");
        }
    }
}
