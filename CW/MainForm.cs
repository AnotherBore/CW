namespace CW
{
    public partial class MainForm : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        List<CounterCircle> counterCircles = new List<CounterCircle>();
        Emitter emitter;
        CounterCircle counterCircle;
        int ModeForClick;
        RadarPoint radarPoint;
        public MainForm()
        {
            
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                Direction = 90,
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
        {
            if (ModeForClick == 2)
            {
                if(radarPoint == null)
                {
                    radarPoint = new RadarPoint(e.X, e.Y);
                    emitter.impactPoints.Add(radarPoint);
                }
                else
                {
                    if(radarPoint.Radius == 0)
                    {
                        radarPoint.Radius = 40;
                    }
                    radarPoint.X = e.X;
                    radarPoint.Y = e.Y;
                    emitter.impactPoints.Remove(radarPoint);
                    emitter.impactPoints.Add(radarPoint);
                }
            }
            else
            {
                if (radarPoint != null)
                {
                    radarPoint.Radius = 0;
                    radarPoint.particlesInside = 0;
                }
            }
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {

            if (ModeForClick == 2)
            {
                int preRadius;
                if (radarPoint != null)
                {
                    if(emitter.impactPoints.Count > 1)
                    {
                        emitter.impactPoints.Remove(radarPoint);
                    }
                        if (e.Delta > 0)
                        {
                            preRadius = radarPoint.Radius - e.Delta/3;
                            if(preRadius > 5)
                            {
                                radarPoint.Radius = preRadius;
                            }                          
                        }
                        else
                        {
                            preRadius = radarPoint.Radius + Math.Abs(e.Delta)/3;
                            if (preRadius < 400)
                            {
                                radarPoint.Radius = preRadius;
                            }
                        }
                    
                    emitter.impactPoints.Add(radarPoint);
                }
            }
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

        private int countOfType(int mode, List<IImpactPoint> particles)
        {
            int count = 0;
            switch (mode)
            {
                case 1:
                    foreach (var point in emitter.impactPoints)
                    {
                        if (point is CounterCircle) count++;
                    }
                    break;
                case 2:
                    foreach (var point in emitter.impactPoints)
                    {
                        if (point is RadarPoint) count++;
                    }
                    break;
            }
            return count;
        }
        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (ModeForClick != 0)
            {
                if (ModeForClick == 1)
                {
                    int count = emitter.impactPoints.Count;
                    if (e.Button == MouseButtons.Left)
                    {
                        IImpactPoint counterCircle = new CounterCircle(e.X, e.Y);
                        emitter.impactPoints.Add(counterCircle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        for (int i = 0; i < count; i++)
                        {

                            var counterCircle = emitter.impactPoints[i];
                            if(counterCircle is CounterCircle)
                            {
                                CounterCircle counter = (CounterCircle)counterCircle;
                                var x = Math.Abs(e.X - counterCircle.X);
                                var y = Math.Abs(e.Y - counterCircle.Y);
                                var lenght = Math.Sqrt(x * x + y * y);
                                if (lenght < counter.Radius)
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
        }

        private void tbParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbParticlesPerTick.Value;
            lblParticlesPerTick.Text = $"{tbParticlesPerTick.Value} частиц/ тик";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Задания") ModeForClick = 0;
            else if (comboBox1.SelectedItem.ToString() == "Точка-пожиратель") ModeForClick = 1;
            else if (comboBox1.SelectedItem.ToString() == "Точка-радар") ModeForClick = 2;
        }
    }
}