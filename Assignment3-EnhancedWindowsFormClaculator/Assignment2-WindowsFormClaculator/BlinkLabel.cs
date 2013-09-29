﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment2_WindowsFormClaculator
{
    /**
     * Custom Label that will blink
     **/
    class BlinkLabel : Label
    {
        private const int _maxNumberOfBlinks = 10;
        private int _blinkCount = 0;
        private Timer _timer;

        public BlinkLabel()
        {
            this._timer = new Timer();
            this._timer.Tick += new EventHandler(_timer_Tick);
            this._timer.Interval = 621;
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            if (!this._timer.Enabled && base.IsHandleCreated) StartBlink();
        }

        public void StartBlink()
        {
            this._blinkCount = 0;
            base.Visible = true;
            this._timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            base.Visible = !base.Visible;
            this._blinkCount++;
            if (this._blinkCount >= _maxNumberOfBlinks)
            {
                this._timer.Stop();
                base.Visible = true;
            }
        }
    }
}