namespace CW
{
    public partial class MainForm : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        List<CounterCircle> counterCircles = new List<CounterCircle>(); 
        Emitter emitter;
        CounterCircle counterCircle;
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
            counterCircle = new CounterCircle(e.X, e.Y);
            counterCircles.Add(counterCircle);
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

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left)
            {
                IImpactPoint counterCircle = new CounterCircle(e.X, e.Y);
                emitter.impactPoints.Add(counterCircle);
            }
            var count = emitter.impactPoints.Count;
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < count; i++)
                {
                    
                    var counterCircle = (CounterCircle)emitter.impactPoints[i];

                    var x = Math.Abs(e.X - counterCircle.X);
                    var y = Math.Abs(e.Y - counterCircle.Y);
                    var lenght = Math.Sqrt(x * x + y * y);
                    if (lenght < counterCircle.Radius)
                    {
                        emitter.impactPoints.Remove(counterCircle);
                        i--;
                    }
                    count = emitter.impactPoints.Count;
                }
            }

        }
    }
}