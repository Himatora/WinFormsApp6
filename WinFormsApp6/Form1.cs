using System.Diagnostics.Eventing.Reader;
using System.Runtime.ExceptionServices;
using WinFormsApp6.Objects;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new List<BaseObject>();
        Player player;
        Marker marker;
        MyCircle first;
        MyCircle second;
        MyCircle newMyCircle1;
        MyCircle newMyCircle2;
        int score = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            first = new MyCircle(rnd.Next(0, pbMain.Width - 100), rnd.Next(0, pbMain.Height - 100), 0, 30);
            second = new MyCircle(rnd.Next(0, pbMain.Width - 100), rnd.Next(0, pbMain.Height - 100), 0, 40);
            objects.Add(first);
            objects.Add(second);

            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnCircleOverlap += (c) =>
            {
                if (c == first || c == newMyCircle1)
                {
                    CreateNewObjectOverlap(c, 1);
                }
                else
                {
                    CreateNewObjectOverlap(c, 2);
                }
                score++;
                label2.Text = score.ToString();
                timer1.Start();
            };
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);

            objects.Add(player);

        }
        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            updatePlayer();
            updateSize(first);
            updateSize(second);
            if (newMyCircle1 != null)
            {
                updateSize(newMyCircle1);
                if (newMyCircle1.Size == 0)
                {
                    CreateNewObjectOverlap(newMyCircle1, 1);
                    timer1.Stop();
                }
            }
            timer1.Start();
            if (newMyCircle2 != null)
            {
                updateSize(newMyCircle2);
                if (newMyCircle2.Size == 0)
                {
                    CreateNewObjectOverlap(newMyCircle2, 2);
                    timer1.Stop();
                }
            }
            timer1.Start();
            if (first.Size == 0)
            {
                CreateNewObjectOverlap(first, 1);
                timer1.Stop();
            }
            timer1.Start();
            if (second.Size == 0)
            {
                CreateNewObjectOverlap(second, 2);
                timer1.Stop();
            }
            timer1.Start();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }
        private void updateSize(MyCircle myCircle)
        {
            myCircle.DescreaseSize(1);

        }
        private void updatePlayer()
        {
            if (marker != null)
            {
                //расчитываем вектор между игроком и маркером
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                //находим длину вектора
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;//нормализуем координаты
                dy /= length;
                //скорость движения
                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;
                //угол поворота игрока
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            //постпенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;
            //пересчитываем координаты игрока
            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)//движение на точку
        {
            //Обновление pbMain
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)//создание координаты по клику мыши
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }
            marker.X = e.X;
            marker.Y = e.Y;
        }
        private void CreateNewObjectOverlap(MyCircle curMyCircle, int num)
        {
            objects.Remove(curMyCircle);
            switch (num)
            {
                case 1:
                    newMyCircle1 = new MyCircle(rnd.Next(0, pbMain.Width), rnd.Next(0, pbMain.Height), 0, rnd.Next(30, 100));
                    objects.Add(newMyCircle1);
                    timer1.Stop();
                    break;
                case 2:
                    newMyCircle2 = new MyCircle(rnd.Next(0, pbMain.Width), rnd.Next(0, pbMain.Height), 0, rnd.Next(30, 100));
                    objects.Add(newMyCircle2);
                    timer1.Stop();
                    break;
            }
        }
    }
}