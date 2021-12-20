using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    public class CounterCircle
    {
        public int X, Y, Killed;
        public int Radius = 40;
        List<CounterCircle> counterCircles = new List<CounterCircle>();

        public CounterCircle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics g)
        {
            float c = Killed + 1000;
            float k = Math.Min(1f, Math.Abs(Killed / c));
            var mixedColor = ParticleColorful.MixColor(Color.LightGoldenrodYellow, Color.Red, k);
            var b = new Pen(Color.Black, 3); // создали кисть для рисования
            g.DrawEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            g.FillEllipse(new SolidBrush(mixedColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose(); // почистили объект из памяти, чтобы сборщику мусора было попроще
        }
        public void Eat(Particle p)
        {
            Killed++;
        }
        public bool IsTouching(Particle particle)
        {
            var x = Math.Abs(particle.X - X);
            var y = Math.Abs(particle.Y - Y);
            var lenght = Math.Sqrt(x * x + y * y);

            return lenght < Radius;
        }
    }
}
