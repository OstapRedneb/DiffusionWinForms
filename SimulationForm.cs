using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using BallClassLibrary;

namespace DiffusionWinForms
{
    public partial class SimulationForm : Form
    {
        public static Random random;
        public static Graphics graphics;

        static int interval = 0;

        public SimulationForm()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            Ball.graphics = graphics;
        }
        public void SimulationForm_Load(object sender, EventArgs e) 
        {
            CreateBalls();
            timer.Tick += CheckColision;
        }
        public void hScrollBar1_Scroll(object sender, ScrollEventArgs e) 
        {
            if (e?.OldValue == 0 && e?.NewValue != 0)
            {
                timer.Start();
                foreach (Ball ball in BallsHandler.balls)
                {
                    ball.timer.Start();
                    ball.timer.Interval = e.NewValue == 100 ? 100 : 100 - e.NewValue;
                }
            }
            else if (e?.OldValue != 0 && e?.NewValue == 0)
            {
                timer.Stop();
                foreach (Ball ball in BallsHandler.balls)
                {
                    ball.timer.Stop(); 
                    ball.timer.Interval = e.NewValue == 100 ? 100 : 100 - e.NewValue;
                }
            }
            else 
            {
                foreach (Ball ball in BallsHandler.balls)
                {
                    ball.timer.Interval = e.NewValue == 100 ? 100 : 100 - e.NewValue;
                }
            }
            interval = e.NewValue == 0 ? 100 : 100 - e.NewValue;
        }
        public void resetButton_Click(object sender, EventArgs e) 
        {
            Application.Restart();
        }
        public void CreateBalls() 
        {
            for (int i = 0; i < 15; i++) 
            {
                Ball ball = new Ball(this, 30, 1, true);
                BallsHandler.balls.Add(ball);
                ball.Show();
            }
            for (int j = 0; j < 15; j++)
            {
                Ball ball = new Ball(this, 30, 1, false);
                BallsHandler.balls.Add(ball);
                ball.Show();
            }
        }
        public void CheckColision(object sender, EventArgs e) 
        {
            for (int i = 0; i < BallsHandler.balls.Count - 1; i++)
            {
                for (int j = i + 1; j < BallsHandler.balls.Count; j++)
                {
                    int distance = (int)MathF.Sqrt(MathF.Pow(BallsHandler.balls[i].CenterX - BallsHandler.balls[j].x - BallsHandler.balls[j].size, 2) + MathF.Pow(BallsHandler.balls[i].CenterY - BallsHandler.balls[j].y - BallsHandler.balls[j].size, 2));

                    if (distance <= BallsHandler.balls[j].Radius + BallsHandler.balls[i].Radius) HandleCollision(BallsHandler.balls[j], BallsHandler.balls[i]);
                }
            }

            foreach (Ball ball in BallsHandler.balls)
            {
                if (ball.CenterX <= 0 || ball.CenterX >= ClientSize.Width - ball.size) ball.vx = -ball.vx;
                if (ball.CenterY <= 0 || ball.CenterY >= ClientSize.Height - ball.size) ball.vy = -ball.vy;
            }
        }
        public static void HandleCollision(Ball ball1, Ball ball2)
        {
            // Вектор нормали столкновения
            float normalX = ball2.CenterX - ball1.CenterX;
            float normalY = ball2.CenterY - ball1.CenterY;
            float length = MathF.Sqrt(normalX * normalX + normalY * normalY);

            // Нормализация
            normalX /= length;
            normalY /= length;

            // Скалярные проекции скоростей
            float v1Proj = ball1.vx * normalX + ball1.vy * normalY;
            float v2Proj = ball2.vx * normalX + ball2.vy * normalY;

            // Обмен проекциями
            (v1Proj, v2Proj) = (v2Proj, v1Proj);

            // Пересчёт векторов скорости
            float dv1 = v1Proj - v2Proj;
            float dv2 = v2Proj - v1Proj;

            ball1.vx += (int)(dv1 * normalX);
            ball1.vy += (int)(dv1 * normalY);

            ball2.vx += (int)(dv2 * normalX);
            ball2.vy += (int)(dv2 * normalY);
        }
    }
}
