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
    public partial class PhaseSequenceView : ContentView
    {
        public PhaseSequenceView()
        {
            InitializeComponent();
        }

        private void PSCalc_Click(object sender, EventArgs e)
        {
            double.TryParse(txt_Ua.Text, out double Ua);
            double.TryParse(txt_UaPhi.Text, out double PhiUa);
            double.TryParse(txt_Ub.Text, out double Ub);
            double.TryParse(txt_UbPhi.Text, out double PhiUb);
            double.TryParse(txt_Uc.Text, out double Uc);
            double.TryParse(txt_UcPhi.Text, out double PhiUc);

            double.TryParse(txt_Ia.Text, out double Ia);
            double.TryParse(txt_IaPhi.Text, out double PhiIa);
            double.TryParse(txt_Ib.Text, out double Ib);
            double.TryParse(txt_IbPhi.Text, out double PhiIb);
            double.TryParse(txt_Ic.Text, out double Ic);
            double.TryParse(txt_IcPhi.Text, out double PhiIc);

            string format = "F3";

            PhaseSequence sequence = new PhaseSequence();

            {
                Polar vUa = new Polar(Ua, PhiUa);
                Polar vUb = new Polar(Ub, PhiUb);
                Polar vUc = new Polar(Uc, PhiUc);

                PSData vPositiveU = sequence.CalcPositive(vUa, vUb, vUc);

                txt_UPositive.Text = vPositiveU.Amplitude.ToString(format);
                txt_PhiUPositive.Text = vPositiveU.Phase.ToString(format);

                PSData vNegativeU = sequence.CalcNegative(vUa, vUb, vUc);

                txt_UNegative.Text = vNegativeU.Amplitude.ToString(format);
                txt_PhiUNegative.Text = vNegativeU.Phase.ToString(format);

                PSData vZeroU = sequence.CalcZero(vUa, vUb, vUc);

                txt_UZero.Text = vZeroU.Amplitude.ToString(format);
                txt_PhiUZero.Text = vZeroU.Phase.ToString(format);
            }

            {
                Polar vIa = new Polar(Ia, PhiIa);
                Polar vIb = new Polar(Ib, PhiIb);
                Polar vIc = new Polar(Ic, PhiIc);

                PSData vPositiveI = sequence.CalcPositive(vIa, vIb, vIc);

                txt_IPositive.Text = vPositiveI.Amplitude.ToString(format);
                txt_PhiIPositive.Text = vPositiveI.Phase.ToString(format);

                PSData vNegativeI = sequence.CalcNegative(vIa, vIb, vIc);

                txt_INegative.Text = vNegativeI.Amplitude.ToString(format);
                txt_PhiINegative.Text = vNegativeI.Phase.ToString(format);

                PSData vZeroI = sequence.CalcZero(vIa, vIb, vIc);

                txt_IZero.Text = vZeroI.Amplitude.ToString(format);
                txt_PhiIZero.Text = vZeroI.Phase.ToString(format);
            }

        }
    }
}