using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    public abstract class IImpactPoint //создаеим абстрактный класс под все особые частицы
    {
        public float X;
        public float Y;

        protected IImpactPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public abstract void ImpactParticle(Particle particle); //абстрактные метод под касание с частицей
        public abstract void Render(Graphics g);//и под рендер
    }

    public class CounterCircle : IImpactPoint
    {
        private int Killed;//количество съеденных частиц
        public int Radius = 40;//радиус частицы 
        public CounterCircle(float x, float y) : base(x, y)
        {
        }
        public override void Render(Graphics g)
        {
            float c = Killed + 1000;//под максимальное значение цвета
            float k = Math.Min(1f, Math.Abs(Killed / c));
            var mixedColor = ParticleColorful.MixColor(Color.LightGoldenrodYellow, Color.Red, k);//смешиваем цвет, в зависимости от убитых
            var b = new Pen(Color.Black, 3);//создаем линию под контур частицы
            g.DrawEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);//рисуем прозрачный круг
            g.FillEllipse(new SolidBrush(mixedColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);// и красим смешанным цветом


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("" + Killed, new Font("Arial", 10), Brushes.Black, X, Y, stringFormat);//рисуем количество убитых в центре круга
            b.Dispose();
        }

        public override void ImpactParticle(Particle particle)
        {
            var x = Math.Abs(particle.X - X);
            var y = Math.Abs(particle.Y - Y);
            var r = Math.Sqrt(x * x + y * y);
            if (r < Radius)//если коснулась грани счетчика
            {
                Killed++;
                particle.Life = 0;
            }
        }       
    }

    public class RadarPoint : IImpactPoint
    {
        List<Particle> PI = new List<Particle>();//создаем список входящих внутрь радара частиц
        public int particlesInside = 0;//под количество чатиц, которое надо написать внутри радара
        public int Radius = 40;//под радиус радара
        public RadarPoint(float x, float y) : base(x, y)
        {
        }
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black, 3), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            if(particlesInside > 0)
            {
                g.DrawString("" + particlesInside, new Font("Arial", 10), Brushes.Black, X, Y, stringFormat);//выводим количество в центре радара
            }
        }

        public override void ImpactParticle(Particle particle)
        {
            var colorful = particle as ParticleColorful;// точка должна быть цветной

                float gX = X - particle.X;
                float gY = Y - particle.Y;

                double r = Math.Sqrt(gX * gX + gY * gY);
                if (r + particle.Radius < Radius)//если внутри радиуса
                {
                    if(PI.Contains(particle) == false)// если этой точки еще нет в списке
                    {
                        PI.Add(particle);//добавим
                    }
                    colorful.setColor(true);//поменяем цвет
                }
                else
                {
                    if (PI.Contains(particle))//если такая частица есть в списке
                    {
                        PI.Remove(particle);//убираем
                    }
                    colorful.setColor(false);//меняем цвет назад
                }
                particlesInside = PI.Count;//смотрим, сколько в списке сейчас
                
           }
    }
}
