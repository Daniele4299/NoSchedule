namespace NoSchedule
{
    public partial class Form1 : Form
    {

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;      

            t1.Interval = 15; 
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();
        }

        void fadeIn(object? sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                t1.Stop();
                MainForm main = new MainForm();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
                Opacity += 0.01;
        }
    }
}
