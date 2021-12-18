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
        public void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), X - 5, Y - 5, 10, 10);
        }
    }
    public class GravityPoint : IImpactPoint
    {
        public int Power = 500;

        public GravityPoint(float x, float y) : base(x, y)
        {
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }
    }
    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;

        public AntiGravityPoint(float x, float y) : base(x, y)
        {
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; 
            particle.SpeedY -= gY * Power / r2;
        }
    }

}
