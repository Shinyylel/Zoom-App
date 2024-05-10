using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZoomApp
{
    public partial class MagnifierForm : Form
    {
        // INITIAL ZOOM LEVEL
        private double zoomLevel = 1;
        public bool mouseDown;
        private Point lastLocation;

        public int captureWidth;
        public int captureHeight;

        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 0x10;
        private const int HTRIGHT = 0x11;
        private const int HTTOP = 0x12;
        private const int HTTOPLEFT = 0x13;
        private const int HTTOPRIGHT = 0x14;
        private const int HTBOTTOM = 0x15;
        private const int HTBOTTOMLEFT = 0x16;
        private const int HTBOTTOMRIGHT = 0x17;

        private Timer refreshTimer;

        public MagnifierForm()
        {
            InitializeComponent();

            // CALLING FUNCTION
            cbmZoom_add();

            // SCREEN REFRESH TIMER
            this.refreshTimer = new Timer();
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += RefreshTimer_Tick;
            this.refreshTimer.Start();

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.ResizeRedraw = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;

                bool top = pt.Y <= 10;
                bool bottom = pt.Y >= clientSize.Height - 10;
                bool left = pt.X <= 10;
                bool right = pt.X >= clientSize.Width - 10;

                if (top && left)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (top && right)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (bottom && left)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (bottom && right)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (top)
                    m.Result = (IntPtr)HTTOP;
                else if (bottom)
                    m.Result = (IntPtr)HTBOTTOM;
                else if (left)
                    m.Result = (IntPtr)HTLEFT;
                else if (right)
                    m.Result = (IntPtr)HTRIGHT;
            }
        }

        private void MagnifierForm_MouseDown (object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MagnifierForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void MagnifierForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                MagnifierForm magnifier = new MagnifierForm();
                magnifier.Show();
            }
        }

        private void MagnifierForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void cbmZoom_add()
        {
            // ADDING ZOOM TEXT TO COMBO BOX

            cbmZoom.Items.Add("100%");
            cbmZoom.Items.Add("150%");
            cbmZoom.Items.Add("200%");
            cbmZoom.Items.Add("250%");
            cbmZoom.Items.Add("300%");
            cbmZoom.Items.Add("350%");
            cbmZoom.Items.Add("400%");
            cbmZoom.Items.Add("450%");
            cbmZoom.Items.Add("500%");
            cbmZoom.Items.Add("550%");
            cbmZoom.Items.Add("600%");
            cbmZoom.Items.Add("650%");
            cbmZoom.Items.Add("700%");
            cbmZoom.Items.Add("750%");
            cbmZoom.Items.Add("800%");
            cbmZoom.Items.Add("850%");
            cbmZoom.Items.Add("900%");
            cbmZoom.Items.Add("950%");
            cbmZoom.Items.Add("1000%");

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            captureHeight = (int)(this.Height / zoomLevel);
            captureWidth = (int)(this.Width / zoomLevel);

            try
            {
                Point formLocation = this.Location;
                Point screenCaptureStartPoint = new Point(
                    formLocation.X - (int)((captureWidth - this.Width) / 2),
                    formLocation.Y - (int)((captureHeight - this.Height) / 2)
                );

                using (Bitmap Buffer = new Bitmap(captureWidth, captureHeight, e.Graphics)) // CAPTURING SCREEN
                {
                    using (Graphics g = Graphics.FromImage(Buffer))
                    {
                        g.CopyFromScreen(screenCaptureStartPoint, Point.Empty, new Size(captureWidth, captureHeight));
                    }

                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    e.Graphics.DrawImage(Buffer, new Rectangle(0, 0, this.Width, this.Height));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during screen capture: " + ex.Message); // CALLS ERROR IF BREAKS ):
            }
        }

        private void MagnifierForm_Load(object sender, EventArgs e)
        {

        }

        private void cbmZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // CASE IF SELECTED ZOOM LEVEL AND SETTING ZOOMLEVEL
            switch (cbmZoom.SelectedIndex)
            {
                case 0:
                    zoomLevel = 1;
                    break;
                case 1:
                    zoomLevel = 2;
                    break;
                case 2:
                    zoomLevel = 2.5;
                    break;
                case 3:
                    zoomLevel = 3;
                    break;
                case 4:
                    zoomLevel = 3.5;
                    break;
                case 5:
                    zoomLevel = 4;
                    break;
                case 6:
                    zoomLevel = 4.5;
                    break;
                case 7:
                    zoomLevel = 5;
                    break;
                case 8:
                    zoomLevel = 5.5;
                    break;
                case 9:
                    zoomLevel = 6;
                    break;
                case 10:
                    zoomLevel = 6.5;
                    break;
                case 11:
                    zoomLevel = 7;
                    break;
                case 12:
                    zoomLevel = 7.5;
                    break;
                case 13:
                    zoomLevel = 8;
                    break;
                case 14:
                    zoomLevel = 8.5;
                    break;
                case 15:
                    zoomLevel = 9;
                    break;
                case 16:
                    zoomLevel = 10;
                    break;
                case 17:
                    zoomLevel = 12;
                    break;
                case 18:
                    zoomLevel = 14;
                    break;
            }
            this.Invalidate();
        }

        private void MagnifierForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
