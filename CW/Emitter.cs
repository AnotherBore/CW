using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    public class Emitter
    {
        public List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int X; // координата X центра эмиттера
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 0; // разброс частиц относительно Direction
        public int SpeedMain = 1; // начальная скорость движения частицы
        public int SpeedOfFlow = 10; // скорость сноса
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 10; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public Color ColorFrom = Color.Gold; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.DeepPink); // конечный цвет частиц

        public float GravitationX = 0;
        public float GravitationY = 1;
        public int ParticlesCount = 1000;

        public int ParticlesPerTick = 10;
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * SpeedOfFlow);
            particle.SpeedY = SpeedMain;

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
            ResetColor(particle);
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public virtual void ResetColor(Particle particle)
        {
            var color = particle as ParticleColorful;
            if (particle.Life > 0)
            {
                color.ToColor = ColorTo;
                color.FromColor = ColorFrom;
            }
        }

        public void UpdateState()
        {

            for (var i = 0; i < ParticlesPerTick; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = CreateParticle();

                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {
                particle.Life -= 1;

                if (particle.Life <= 0)
                {
                    particle.Life += 2;
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }

    public class TopEmitter : Emitter
    {
        public int Width;
        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); 

          
            particle.X = Particle.rand.Next(Width);
            particle.Y = 0;  
/*
            particle.SpeedY = 1; 
            particle.SpeedX = Particle.rand.Next(-2, 2); */
        }
    }
}
