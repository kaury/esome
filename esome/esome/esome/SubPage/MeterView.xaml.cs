using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace esome.SubPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeterView : ContentView
    {
        public MeterView()
        {
            InitializeComponent();
        }

        private void MeterCalc_Click(object sender, EventArgs e)
        {
            double.TryParse(txt_U.Text, out double Ub);
            double.TryParse(txt_I.Text, out double Ib);
            double.TryParse(txt_C.Text, out double C);
            double m = 1;
            switch (cmb_TestMode.SelectedItem.ToString())
            {
                case "1P2W": m = 1; break;
                case "3P3W": m = Math.Sqrt(3); break;
                case "3P4W": m = 3; break;
            }
            double factor = 1;
            bool IsMinus = false;
            if (!string.IsNullOrWhiteSpace(txt_PF.Text))
            {
                double.TryParse(txt_PF.Text, out factor);
                if (txt_PF.Text.IndexOf("-") >= 0) IsMinus = true;
                if (cmb_FR.SelectedItem.ToString() == "-") IsMinus = true;//Reverse
            }
            double s = Ub * Ib * m;
            double power = s * factor;
            double CFreq = Math.Abs(power * C / 3600 / 1000);
            double CTime = 0;
            if (CFreq != 0)
            {
                CTime = 1 / CFreq;
            }
            double seconds = CTime * C;

            double angle = Math.Acos(Math.Abs(factor)) / Math.PI * 180;
            if (IsMinus) angle = angle + 180;
            if ("Capacitive".Equals(cmb_LC.SelectedItem.ToString()))
            {
                angle = angle * -1;
                if (angle < 0) angle = angle + 360;
            }
            txt_P.Text = Math.Round(power, 5).ToString();
            txt_Q.Text = Math.Round(Math.Sqrt(s * s - power * power), 5).ToString();
            txt_S.Text = Math.Round(s, 5).ToString();
            txt_A.Text = Math.Round(angle, 5).ToString();
            txt_CHz.Text = Math.Round(CFreq, 5).ToString();
            txt_OnePulseTime.Text = Math.Round(CTime, 5).ToString("F");
            txt_TimePerkWh.Text = Math.Round(seconds, 5).ToString("F");
            txt_MinPerkWh.Text = Math.Round((seconds / 60F), 5).ToString("F");

            PowerHelper.CalculatePhaseDegree($"M{cmb_TestMode.SelectedItem.ToString()}", cmb_PQ.SelectedItem.ToString(), cmb_FR.SelectedItem.ToString() == "-" ? "Reverse" : "Forward", cmb_HABC.SelectedItem.ToString(), factor, cmb_LC.SelectedItem.ToString(), cmb_clockwise.SelectedItem.ToString().ToLower() == "anticlockwise", out PowerHelper.PhiParam phis);
            txt_PhiU1.Text = phis.PhiUa.ToString();
            txt_PhiU2.Text = phis.PhiUb.ToString();
            txt_PhiU3.Text = phis.PhiUc.ToString();
            txt_PhiI1.Text = phis.PhiIa.ToString();
            txt_PhiI2.Text = phis.PhiIb.ToString();
            txt_PhiI3.Text = phis.PhiIc.ToString();
            VectorHelper vector = new VectorHelper()
            {
                UL1Angle = (float)phis.PhiUa,
                UL2Angle = (float)phis.PhiUb,
                UL3Angle = (float)phis.PhiUc,
                IL1Angle = (float)phis.PhiIa,
                IL2Angle = (float)phis.PhiIb,
                IL3Angle = (float)phis.PhiIc,
            };
            switch (cmb_TestMode.SelectedItem.ToString())
            {
                case "1P2W":
                    vector.UL2Value = 0;
                    vector.UL3Value = 0;
                    vector.IL2Value = 0;
                    vector.IL3Value = 0;
                    break;
                case "3P3W":
                    vector.IL2Value = 0;
                    break;
                case "3P4W":
                    break;
            }
            //if (vector.DrawVector()) pic_phase.Source = PicHelper.GetBitmap(vector.VectorFullPath);
            //else pic_phase.Source = null;
        }
    }
}