namespace CW
{
    public partial class MainForm : Form
    {
        List<Particle> particles = new List<Particle>();
        public MainForm()
        {

            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            for (var i = 0; i < 500; ++i)
            {
                var particle = new Particle();

                particle.X = picDisplay.Image.Width / 2;
                particle.Y = picDisplay.Image.Height / 2;

                particles.Add(particle);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }
    }
}