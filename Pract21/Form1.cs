namespace Pract21
{
    public partial class Form1 : Form
    {
        int width = 767, height = 446;
        int centerX, centerY;

        public Form1()
        {
            InitializeComponent();

            centerX = width / (2 * 30);
            centerY = height / (2 * 30);
        }

        float xn = -15, xk = 10, xh = 0.5f;

        private void button1_Click(object sender, EventArgs e)
        {
            xn = (float)double.Parse(textBox1.Text);
            xk = (float)double.Parse(textBox3.Text);
            xh = (float)double.Parse(textBox2.Text);

            panel1.Invalidate();
        }

        void Draw()
        {
            Graphics g = panel1.CreateGraphics();
            float x_last = xn + centerX;

            g.ScaleTransform(30, 30);

            for (float x = xn; x <= xk; x += 0.01f)
            {
                float y_last = (3 * (float)Math.Sin(2 * x_last)) * xh + centerY;
                float y = (3 * (float)Math.Sin(2 * x + centerX)) * xh + centerY;

                PointF[] points = { new PointF(x_last, y_last), new PointF(x + centerX, y) };

                g.DrawCurve(new Pen(Color.OrangeRed, 0.15f), points, 0f);

                y = (4 * (float)Math.Cos(2 * (x + centerX))) * xh + centerY;
                y_last = (4 * (float)Math.Cos(2 * x_last)) * xh + centerY;

                points = new PointF[] { new PointF(x_last, y_last), new PointF(x + centerX, y) };

                g.DrawCurve(new Pen(Color.Blue, 0.15f), points, 0f);

                x_last = x + centerX;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
    }
}