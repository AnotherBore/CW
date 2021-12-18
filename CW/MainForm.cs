namespace CW
{
    public partial class MainForm : Form
    {
        List<Particle> particles = new List<Particle>();
        private int MousePositionX = 0;
        private int MousePositionY = 0;
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

        int counter = 0;

        private void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1; 

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rand.Next(100);

                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }

            }
        }

        private void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                Render(g);
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
    }
}