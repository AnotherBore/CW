using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        protected IImpactPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public abstract void ImpactParticle(Particle particle);
        public abstract void Render(Graphics g);
    }

    public class CounterCircle : IImpactPoint
    {
        private int Killed;
        public int Radius = 40;
        public CounterCircle(float x, float y) : base(x, y)
        {
        }
        public override void Render(Graphics g)
        {
            float c = Killed + 1000;
            float k = Math.Min(1f, Math.Abs(Killed / c));
            var mixedColor = ParticleColorful.MixColor(Color.LightGoldenrodYellow, Color.Red, k);
            var b = new Pen(Color.Black, 3); 
            g.DrawEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            g.FillEllipse(new SolidBrush(mixedColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("" + Killed, new Font("Arial", 10), Brushes.Black, X, Y, stringFormat);
            b.Dispose();
        }

        public override void ImpactParticle(Particle particle)
        {
            var x = Math.Abs(particle.X - X);
            var y = Math.Abs(particle.Y - Y);
            var r = Math.Sqrt(x * x + y * y);
            if (r < Radius)
            {
                Killed++;
            }

        }

    }

}
