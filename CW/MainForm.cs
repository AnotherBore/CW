namespace CW
{
    public partial class MainForm : Form
    {
        List<Emitter> emitters = new List<Emitter>();//создаем список под эмиттеры
        List<CounterCircle> counterCircles = new List<CounterCircle>();//список счетчиков
        Emitter emitter;
        CounterCircle counterCircle;
        int ModeForClick;
        RadarPoint radarPoint;
        public MainForm()
        {
            
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.emitter = new TopEmitter//создаем снежный эмиттер
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


            emitters.Add(emitter);//добавляем этот эмиттер в список
        }

        private void timer_Tick(object sender, EventArgs e)//при тике таймера
        {
            emitter.UpdateState();//обновляем все данные в эмиттере

            using (var g = Graphics.FromImage(picDisplay.Image))//выводим все что насчитал эмиттер на экран
            {
                g.Clear(Color.Gainsboro);
                emitter.Render(g);

            }
            picDisplay.Invalidate();//обновляем экран
        }
        
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (ModeForClick == 2)//если выбрано задание на радар 
            {
                if(radarPoint == null)//если радара это первый раз, то создаем радар
                {
                    radarPoint = new RadarPoint(e.X, e.Y);
                    emitter.impactPoints.Add(radarPoint);
                }
                else
                {
                    if(radarPoint.Radius == 0)//если второй раз начинаем с нуля, то делаем стандартного радиуса
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
                if (radarPoint != null)//делаем радар невидимым
                {
                    radarPoint.Radius = 0;
                    radarPoint.particlesInside = 0;
                }
            }
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {

            if (ModeForClick == 2)//если работаем с радаром
            {
                int preRadius;//запоминаем текущий радиус
                if (radarPoint != null)//если радар существует уже
                {
                    if(emitter.impactPoints.Count > 1)//если наплодили лишний радар
                    {
                        emitter.impactPoints.Remove(radarPoint);
                    }
                        if (e.Delta > 0)//если колесико крутим вниз
                        {
                            preRadius = radarPoint.Radius - e.Delta/3;
                            if(preRadius > 5)//если накрутили не больше, чем надо
                            {
                                radarPoint.Radius = preRadius;
                            }                          
                        }
                        else//если колесико крутим наверх
                        {
                            preRadius = radarPoint.Radius + Math.Abs(e.Delta)/3;
                            if (preRadius < 400)
                            {
                                radarPoint.Radius = preRadius;
                            }
                        }
                    
                    emitter.impactPoints.Add(radarPoint);//добавляем радар в список активных точек
                }
            }
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

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (ModeForClick != 0)
            {
                if (ModeForClick == 1)//если выбрано соответсвующее задание в комбобоксе
                {
                    int count = emitter.impactPoints.Count;
                    if (e.Button == MouseButtons.Left)//по нажатию левой кнопки добавляем новый счетчик
                    {
                        IImpactPoint counterCircle = new CounterCircle(e.X, e.Y);
                        emitter.impactPoints.Add(counterCircle);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        for (int i = 0; i < count; i++)
                        {

                            var counterCircle = emitter.impactPoints[i];
                            if(counterCircle is CounterCircle)//если из списка вытащили именно счетчик
                            {
                                CounterCircle counter = (CounterCircle)counterCircle;
                                var x = Math.Abs(e.X - counterCircle.X);
                                var y = Math.Abs(e.Y - counterCircle.Y);
                                var lenght = Math.Sqrt(x * x + y * y);
                                if (lenght < counter.Radius)//если указатель на одной из точек
                                {
                                    emitter.impactPoints.Remove(counterCircle);//удаляем
                                    i--;
                                }
                                count = emitter.impactPoints.Count;//обновляем количество итераций
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