namespace CW
{
    public partial class MainForm : Form
    {
        Emitter emitter = new Emitter();
        public MainForm()
        {

            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };
            //emitter.gravityPoints.Add(new GravityPoint(picDisplay.Width / 2, picDisplay.Height / 2));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.DimGray);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}