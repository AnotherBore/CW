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

        public float GravitationX = 0; //гравитация по оси X
        public float GravitationY = 1;//гравитация по оси Y
        public int ParticlesCount = 1000;//максимальное количество частиц

        public int ParticlesPerTick = 10;//количество частиц за такт
        public virtual void ResetParticle(Particle particle)//обновляем частицу, рандомно генерируя начальное положение и характеристики
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
            var particle = new ParticleColorful();//создаем цветную частицу
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public virtual void ResetColor(Particle particle)//сброс цвета частицы
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

            for (var i = 0; i < ParticlesPerTick; ++i) //генерируем частицы в количество, заданном пользователем
            {
                if (particles.Count < ParticlesCount)//пока не заполним список полностью
                {
                    var particle = CreateParticle();

                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else//если список заполнен, пропускаем
                {
                    break;
                }
            }
            int particlesToCreate = ParticlesPerTick;//буферизируем количество чатиц на такт, чтобы можно было отнимать

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

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);                       
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

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

    public class TopEmitter : Emitter//эмиттер со сбросом чатиц сверху (снежный тип)
    {
        public int Width; // ширина, на которую генерируем частицы
        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);//сбрасываем частицу как обычно

          
            particle.X = Particle.rand.Next(Width);
            particle.Y = 0;  
        }
    }
}
