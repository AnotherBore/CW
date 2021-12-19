namespace CW
{
    public partial class MainForm : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;
        public MainForm()
        {

            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                Direction = 0,
                Spreading = 10,
                SpeedMain = 1,
                SpeedOfFlow = 0,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = 0,
                Y = 0,
            };


            emitters.Add(emitter);

            //emitter.gravityPoints.Add(new GravityPoint(picDisplay.Width / 2, picDisplay.Height / 2));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Gainsboro);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {/*
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;*/
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbSpeedMain_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMain = tbSpeedMain.Value;
            lblSpeedMain.Text = $"{tbSpeedMain.Value} пикс/ тик";
        }

        private void tbSpeedOfFlow_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedOfFlow = tbSpeedOfFlow.Value;
            lblSpeedOfFlow.Text = $"{tbSpeedOfFlow.Value} пикс/ тик";
        }

        private void tbMaxRadius_Scroll(object sender, EventArgs e)
        {
            emitter.RadiusMax = tbMaxRadius.Value;
            lblMaxRadius.Text = $"{tbMaxRadius.Value} пикселей";
        }
    }
}