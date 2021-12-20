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

            //emitter.gravityPoints.Add(new GravityPoint(picDisplay.Width / 2, picDisplay.Height / 2));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            UpdateCounterCircle();



            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Gainsboro);
                emitter.Render(g);
                foreach (var counterCircle in counterCircles)
                {
                    counterCircle.Draw(g);
                }
                foreach (var counterCircle in counterCircles)
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    g.DrawString("" + counterCircle.Killed, new Font("Arial", 10), Brushes.Black, counterCircle.X, counterCircle.Y, stringFormat);
                }
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

        public void UpdateCounterCircle()
        {
            foreach (var counterCircle in counterCircles)
            {
                foreach (var particle in emitter.particles)
                {
                    if (counterCircle.IsTouching(particle))
                        counterCircle.Eat(particle);
                }
            }
        }

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Left)
            {
                counterCircle = new CounterCircle(e.X, e.Y);
                counterCircles.Add(counterCircle);
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < counterCircles.Count; i++)
                {
                    var blackHole = counterCircles[i];

                    var x = Math.Abs(e.X - blackHole.X);
                    var y = Math.Abs(e.Y - blackHole.Y);
                    var lenght = Math.Sqrt(x * x + y * y);
                    if (lenght < blackHole.Radius)
                    {
                        counterCircles.Remove(blackHole);
                        i--;
                    }
                }
            }

        }
    }
}