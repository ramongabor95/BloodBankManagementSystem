using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using BBMS.BBWS;

namespace BBMS
{
    public partial class MainForm
    {
        private bool _isValidSSN2;
        private bool _isValidRBC;
        private bool _isValidHGB;
        private bool _isValidHCT;
        private bool _isValidMCV;
        private bool _isValidMCHC;
        private bool _isValidWBC;
        private bool _isValidPLT;
        private bool _isValidVSH;
        private bool _isValidTGP;
        private bool _isValidGroup2;
        private bool _isValidRh2;
        private bool _isValidBloodBagId;

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == @"Search by first name...")
            {
                textBox10.Text = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == @"")
            {
                textBox10.Text = @"Search by first name...";
                textBox10.ForeColor = Color.Silver;
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Text == @"Search by last name...")
            {
                textBox11.Text = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == @"")
            {
                textBox11.Text = @"Search by last name...";
                textBox11.ForeColor = Color.Silver;
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Text == @"Search by SSN...")
            {
                textBox12.Text = "";
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == @"")
            {
                textBox12.Text = @"Search by SSN...";
                textBox12.ForeColor = Color.Silver;
            }
        }
        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Text == @"First name...")
            {
                textBox13.Text = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == @"")
            {
                textBox13.Text = @"First name...";
                textBox13.ForeColor = Color.Silver;
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == @"Last name...")
            {
                textBox14.Text = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == @"")
            {
                textBox14.Text = @"Last name...";
                textBox14.ForeColor = Color.Silver;
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Text == @"SSN...")
            {
                textBox15.Text = "";
                textBox15.ForeColor = Color.Black;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == @"")
            {
                textBox15.Text = @"SSN...";
                textBox15.ForeColor = Color.Silver;
            }
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            if (textBox17.Text == @"Phone...")
            {
                textBox17.Text = "";
                textBox17.ForeColor = Color.Black;
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text == @"")
            {
                textBox17.Text = @"Phone...";
                textBox17.ForeColor = Color.Silver;
            }
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            if (textBox16.Text == @"City...")
            {
                textBox16.Text = "";
                textBox16.ForeColor = Color.Black;
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text == @"")
            {
                textBox16.Text = @"City...";
                textBox16.ForeColor = Color.Silver;
            }
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (textBox18.Text == @"Country...")
            {
                textBox18.Text = "";
                textBox18.ForeColor = Color.Black;
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text == @"")
            {
                textBox18.Text = @"Country...";
                textBox18.ForeColor = Color.Silver;
            }
        }

        private void SSNTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SSNTextbox_An.Text))
            {
                BloodBagId_An.Enabled = true;
            }
            else
            {
                BloodBagId_An.Enabled = false;
                panel24.Visible = false;
                if (!ValidateSocialSecurityNumber(SSNTextbox_An.Text))
                {
                    panel12.Visible = true;
                    label53.Text = @"Invalid SSN";
                    label53.Visible = true;
                    _isValidSSN2 = false;
                }
                else
                {
                    panel12.Visible = false;
                    _isValidSSN2 = true;
                }
            }
        }

        private void RBCTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RBCTextbox_An.Text))
            {
                panel22.Visible = true;
                label54.Text = @"Please enter a value";
                label54.Visible = true;
                _isValidRBC = false;
            }
            else
            {
                if (RBCTextbox_An.Text.Any(char.IsLetter))
                {
                    panel22.Visible = true;
                    label54.Text = @"Please enter a valid value";
                    label54.Visible = true;
                    _isValidRBC = false;
                }
                else
                {
                    panel22.Visible = false;
                    _isValidRBC = true;
                }
            }
        }

        private void HGBTextBox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HGBTextBox_An.Text))
            {
                panel21.Visible = true;
                label55.Text = @"Please enter a value";
                label55.Visible = true;
                _isValidHGB = false;
            }
            else
            {
                if (HGBTextBox_An.Text.Any(char.IsLetter))
                {
                    panel21.Visible = true;
                    label55.Text = @"Please enter a valid value";
                    label55.Visible = true;
                    _isValidHGB = false;
                }
                else
                {
                    panel21.Visible = false;
                    _isValidHGB = true;
                }
            }
        }

        private void HCTTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HCTTextbox_An.Text))
            {
                panel18.Visible = true;
                label56.Text = @"Please enter a value";
                label56.Visible = true;
                _isValidHCT = false;
            }
            else
            {
                if (HCTTextbox_An.Text.Any(char.IsLetter))
                {
                    panel18.Visible = true;
                    label56.Text = @"Please enter a valid value";
                    label56.Visible = true;
                    _isValidHCT = false;
                }
                else
                {
                    panel18.Visible = false;
                    _isValidHCT = true;
                }
            }
        }

        private void MCVTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MCVTextbox_An.Text))
            {
                panel19.Visible = true;
                label57.Text = @"Please enter a value";
                label57.Visible = true;
                _isValidMCV = false;
            }
            else
            {
                if (MCVTextbox_An.Text.Any(char.IsLetter))
                {
                    panel19.Visible = true;
                    label57.Text = @"Please enter a valid value";
                    label57.Visible = true;
                    _isValidMCV = false;
                }
                else
                {
                    panel19.Visible = false;
                    _isValidMCV = true;
                }
            }
        }

        private void MCHCTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MCHCTextbox_An.Text))
            {
                panel20.Visible = true;
                label58.Text = @"Please enter a value";
                label58.Visible = true;
                _isValidMCHC = false;
            }
            else
            {
                if (MCHCTextbox_An.Text.Any(char.IsLetter))
                {
                    panel20.Visible = true;
                    label58.Text = @"Please enter a valid value";
                    label58.Visible = true;
                    _isValidMCHC = false;
                }
                else
                {
                    panel20.Visible = false;
                    _isValidMCHC = true;
                }
            }
        }

        private void WBCTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WBCTextbox_An.Text))
            {
                panel13.Visible = true;
                label59.Text = @"Please enter a value";
                label59.Visible = true;
                _isValidWBC = false;
            }
            else
            {
                if (WBCTextbox_An.Text.Any(char.IsLetter))
                {
                    panel13.Visible = true;
                    label59.Text = @"Please enter a valid value";
                    label59.Visible = true;
                    _isValidWBC = false;
                }
                else
                {
                    panel13.Visible = false;
                    _isValidWBC = true;
                }
            }
        }

        private void PLTTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PLTTextbox_An.Text))
            {
                panel14.Visible = true;
                label60.Text = @"Please enter a value";
                label60.Visible = true;
                _isValidPLT = false;
            }
            else
            {
                if (PLTTextbox_An.Text.Any(char.IsLetter))
                {
                    panel14.Visible = true;
                    label60.Text = @"Please enter a valid value";
                    label60.Visible = true;
                    _isValidPLT = false;
                }
                else
                {
                    panel14.Visible = false;
                    _isValidPLT = true;
                }
            }
        }

        private void VSHTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VSHTextbox_An.Text))
            {
                panel23.Visible = true;
                label61.Text = @"Please enter a value";
                label61.Visible = true;
                _isValidVSH = false;
            }
            else
            {
                if (VSHTextbox_An.Text.Any(char.IsLetter))
                {
                    panel23.Visible = true;
                    label61.Text = @"Please enter a valid value";
                    label61.Visible = true;
                    _isValidVSH = false;
                }
                else
                {
                    panel23.Visible = false;
                    _isValidVSH = true;
                }
            }
        }

        private void TGPTextbox_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TGPTextbox_An.Text))
            {
                panel16.Visible = true;
                label62.Text = @"Please enter a value";
                label62.Visible = true;
                _isValidTGP = false;
            }
            else
            {
                if (TGPTextbox_An.Text.Any(char.IsLetter))
                {
                    panel16.Visible = true;
                    label62.Text = @"Please enter a valid value";
                    label62.Visible = true;
                    _isValidTGP = false;
                }
                else
                {
                    panel16.Visible = false;
                    _isValidTGP = true;
                }
            }
        }

        private void BloodBagId_An_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BloodBagId_An.Text))
            {
                SSNTextbox_An.Enabled = true;
            }
            else
            {
                SSNTextbox_An.Enabled = false;
                panel12.Visible = false;
                if (BloodBagId_An.Text.Any(char.IsLetter))
                {
                    panel24.Visible = true;
                    label70.Text = @"Please enter valid value";
                    label70.Visible = true;
                    _isValidBloodBagId = false;
                }
                else
                {
                    panel24.Visible = false;
                    _isValidBloodBagId = true;
                }
            }
        }

        private void GroupCombobox_An_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GroupCombobox_An.SelectedItem.ToString() == "")
            {
                panel15.Visible = true;
                label63.Text = @"Invalid";
                label63.Visible = true;
                _isValidGroup2 = false;
            }
            else
            {
                panel15.Visible = false;
                _isValidGroup2 = true;
            }
        }

        private void RHComboBox_An_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RHComboBox_An.SelectedItem.ToString() == "")
            {
                panel17.Visible = true;
                label64.Text = @"Invalid";
                label64.Visible = true;
                _isValidRh2 = false;
            }
            else
            {
                panel17.Visible = false;
                _isValidRh2 = true;
            }
        }

        public bool IsAllAnalysisDataValid()
        {
            if (!_isValidBloodBagId && !_isValidSSN2) return false;
            if (!_isValidRBC) return false;
            if (!_isValidHGB) return false;
            if (!_isValidHCT) return false;
            if (!_isValidMCV) return false;
            if (!_isValidMCHC) return false;
            if (!_isValidWBC) return false;
            if (!_isValidPLT) return false;
            if (!_isValidVSH) return false;
            if (!_isValidTGP) return false;
            if (!_isValidGroup2) return false;
            if (!_isValidRh2) return false;
            
            return true;
        }

        public void RestoreAnalysisDataPanelsAndLabels()
        {
            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;
        }

        public void ResetAnalysisDetails()
        {
            RestoreAnalysisDataPanelsAndLabels();

            SSNTextbox_An.Text = string.Empty;
            HCTTextbox_An.Text = string.Empty;
            RBCTextbox_An.Text = string.Empty;
            HGBTextBox_An.Text = string.Empty;
            MCVTextbox_An.Text = string.Empty;
            MCHCTextbox_An.Text = string.Empty;
            WBCTextbox_An.Text = string.Empty;
            PLTTextbox_An.Text = string.Empty;
            VSHTextbox_An.Text = string.Empty;
            TGPTextbox_An.Text = string.Empty;
            BloodBagId_An.Text = string.Empty;
            GroupCombobox_An.SelectedItem = string.Empty;
            RHComboBox_An.SelectedItem = string.Empty;
            checkBox1.Checked = false;
            radioButton10.Checked = true;
            radioButton12.Checked = true;
            radioButton14.Checked = true;
            radioButton16.Checked = true;
            radioButton18.Checked = true;
        }

        public BloodBag CreateBloodBagAnalysisObject()
        {
            var toReturn = new BloodBag
            {
                SocialSecurityNumber = SSNTextbox_An.Text,
                Rbc = Convert.ToDecimal(RBCTextbox_An.Text),
                Hgb = Convert.ToDecimal(HGBTextBox_An.Text),
                Hct = Convert.ToDecimal(HCTTextbox_An.Text),
                Mcv = Convert.ToDecimal(MCVTextbox_An.Text),
                Mchc = Convert.ToDecimal(MCHCTextbox_An.Text),
                Wbc = Convert.ToDecimal(WBCTextbox_An.Text),
                Plt = Convert.ToDecimal(PLTTextbox_An.Text),
                Vsh = Convert.ToDecimal(VSHTextbox_An.Text),
                Tgp = Convert.ToDecimal(TGPTextbox_An.Text),
                Group = GroupCombobox_An.SelectedItem.ToString(),
                Rh = RHComboBox_An.SelectedItem.ToString(),
                AnticorpsHiv = !radioButton10.Checked,
                AnticoprsHeB = !radioButton12.Checked,
                AnticorpsHeC = !radioButton14.Checked,
                AnticorpsLec = !radioButton16.Checked,
                AnticorpsSif = !radioButton18.Checked,
                IsGoodForUse = checkBox1.Checked
            };

            return toReturn;
        }
    }
}
