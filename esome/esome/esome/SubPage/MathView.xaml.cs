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
    public partial class MathView : ContentView
    {
        public MathView()
        {
            InitializeComponent();
        }

        private void CvtHex2Dec_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] org = new byte[4];
                string strHex = txtHexOrg.Text.Replace(" ", "").PadLeft(8, '0');
                for (int i = 0; i < strHex.Length / 2; i++)
                {
                    org[i] = byte.Parse(strHex.Substring(i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                }
                txtDecRst.Text = BitConverter.ToSingle(org, 0).ToString();
            }
            catch (Exception)
            {
                txtHexOrg.Text = string.Empty;
                txtDecRst.Text = string.Empty;
            }
        }

        private void CvtDec2Hex_Click(object sender, EventArgs e)
        {
            float.TryParse(txtDecOrg.Text.Trim(), out float org);
            txtHexRst.Text = BitConverter.ToString(BitConverter.GetBytes(org)).Replace("-", "");
        }

        private void CvtHex2Dec2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] org = new byte[8];
                string strHex = txtHexOrg2.Text.Replace(" ", "").PadLeft(16, '0');
                for (int i = 0; i < strHex.Length / 2; i++)
                {
                    org[i] = byte.Parse(strHex.Substring(i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                }
                txtDecRst2.Text = BitConverter.ToDouble(org, 0).ToString();
            }
            catch (Exception)
            {
                txtHexOrg2.Text = string.Empty;
                txtDecRst2.Text = string.Empty;
            }
        }

        private void CvtDec2Hex2_Click(object sender, EventArgs e)
        {
            double.TryParse(txtDecOrg2.Text.Trim(), out double org);
            txtHexRst2.Text = BitConverter.ToString(BitConverter.GetBytes(org)).Replace("-", "");
        }

        private void CvtHex2Dec3_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] org = new byte[8];
                string strHex = txtHexOrg3.Text.Replace(" ", "").PadLeft(16, '0');
                for (int i = 0; i < strHex.Length / 2; i++)
                {
                    org[i] = byte.Parse(strHex.Substring(i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                }
                txtDecRst3.Text = BitConverter.ToInt64(org.Reverse().ToArray(), 0).ToString();
            }
            catch (Exception)
            {
                txtHexOrg3.Text = string.Empty;
                txtDecRst3.Text = string.Empty;
            }
        }

        private void CvtDec2Hex3_Click(object sender, EventArgs e)
        {
            long.TryParse(txtDecOrg3.Text.Trim(), out long org);
            txtHexRst3.Text = BitConverter.ToString(BitConverter.GetBytes(org).Reverse().ToArray()).Replace("-", "");
        }
    }
}