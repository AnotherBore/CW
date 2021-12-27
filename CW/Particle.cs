using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    public class Particle
    {
        public static Random rand = new Random();

        public int Radius;
        public float X;
        public float Y;
        public float SpeedX;
        public float SpeedY;
        public float Life;

        public Particle()//рандомно генерируем
        {
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }



        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            int alpha = (int)(k * 255);

            var color = Color.FromArgb(alpha, Color.Black);//создаем цвет, исходя из количества жизней
            var b = new SolidBrush(color);

          
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;
        Color CurrentColor;
        bool _isIsRadar;

        public static Color MixColor(Color color1, Color color2, float k)//мешаем цвета
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }
        public void setColor(bool isIsRadar)
        {
            _isIsRadar = isIsRadar;
        }
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Math.Abs(Life / 100));


            if (_isIsRadar)//если попала в радар
                CurrentColor = Color.Aqua;//цвет для радара
            else
                CurrentColor = MixColor(ToColor, FromColor, k);//мешаем цвета как обычно

            var b = new SolidBrush(CurrentColor);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();//чистим, чтоб сборщик не отрабатывал часто
        }
    }
}
