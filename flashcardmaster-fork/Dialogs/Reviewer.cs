/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2006 Nithin Philips
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation,Inc.,59 Temple Place - Suite 330,Boston,MA 02111-1307, USA.
 *
 *  Author            :  Nithin Philips <spikiermonkey@users.sourceforge.net>
 *  Original FileName :  Reviewer.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlashCardMaster.Painters;
using LibFlashcard.Model;
using FlashCardMaster.Utilities;
using FlashCardMaster.User;

namespace FlashCardMaster.Dialogs
{
    public partial class Reviewer : Form
    {
        public void Localize() {
            this.ckAnimate.Text = i18n.Language.Animate;
            this.lblAeroAnimate.Text = i18n.Language.Animate;
            this.Text = i18n.Language.Reviewer;
            this.ttProvider.SetToolTip(this.ckAnimate, i18n.Language.ReviewerAnimateTT);
            this.ttProvider.SetToolTip(this.ckTimed, i18n.Language.ReviewerToggleTT);
            this.ttProvider.SetToolTip(this.btFlip, i18n.Language.ReviewerFlipCardTT);
            this.ttProvider.SetToolTip(this.btNext, i18n.Language.ReviewerNextCardTT);
            this.ttProvider.SetToolTip(this.btPrev, i18n.Language.ReviewerPreviousCardTT);
            this.ttProvider.SetToolTip(this.rdbMaybe, i18n.Language.ReviewerNeedsReviewTT);
            this.ttProvider.SetToolTip(this.rdbYes, i18n.Language.ReviewerLearnedTT);
            this.ttProvider.SetToolTip(this.rdbNo, i18n.Language.ReviewerNotLearnedTT);

        }

        LibFlashcard.Utilities.BiDirectionalEnumerator<Card> cardEnumerator;

        public Reviewer(LibFlashcard.Utilities.BiDirectionalEnumerator<Card> enumerator) {
            InitializeComponent();
            Utilities.Utility.SetIcon(this);
            Localize();
            FlashCardMaster.Utilities.Utility.SetFormSize(this, .42f, .5f);
            this.CenterToParent();

            this.pnlCard.Font = User.Settings.AppInstance.PreferredFont.GetFont();

            SetSide(CardElementSides.Front);

            this.ckAnimate.Checked = Settings.AppInstance.ReviewAnimate;

            cardEnumerator = enumerator;
            cardEnumerator.MoveNext();

            pnlCard.NoCardMessage = i18n.Language.ReviewNoCardsMessage;
            UpdatePainters();
            pnlCard.Invalidate();
            ckTimed.Focus();

            if (VistaControls.OSSupport.IsVistaOrBetter && VistaControls.OSSupport.IsCompositionEnabled) {
                this.pnlCard.BorderStyle = BorderStyle.None;
                int bottomHeight = this.ClientSize.Height - this.pnlCard.Bottom;
                this.BackColor = Color.Black;
                VistaControls.DWM.DWMManager.EnableGlassFrame(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
                VistaControls.DWM.GlassHelper.HandleBackgroundPainting(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
                VistaControls.DWM.GlassHelper.HandleFormMovementOnGlass(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
                lblAeroAnimate.Visible = true;
                UpdateAeroLabel();
            }
        }

        public event EventHandler DataModified;

        protected void OnDataModified() {
            this.modified = true;
            if (DataModified != null) {
                DataModified(this, new EventArgs());
            }
        }

        CardElementSides currentSide = CardElementSides.Front;

        private void UpdatePainters() {
            if (!ckTimed.Checked) {
                btNext.Enabled = cardEnumerator.CanMoveNext();
                btPrev.Enabled = cardEnumerator.CanMovePrevious();
            }
            if (cardEnumerator.Count <= 0) {
                pnlCard.Card = null;
                this.Text = i18n.Language.ReviewerNoCards;
                ckTimed.Enabled = panel2.Enabled = btPrev.Enabled = btFlip.Enabled = btNext.Enabled = false;
            } else {
                this.Text = string.Format(i18n.Language.fReviewer, cardEnumerator.CurrentIndex + 1, cardEnumerator.Count, currentSide);
                pnlCard.Side = currentSide;
                pnlCard.Card = cardEnumerator.Current;
                if (cardEnumerator.Current.LearnStatus == CardLearningStaus.Learned) {
                    rdbYes.Checked = true;
                } else if (cardEnumerator.Current.LearnStatus == CardLearningStaus.MaybeLearned) {
                    rdbMaybe.Checked = true;
                } else if (cardEnumerator.Current.LearnStatus == CardLearningStaus.NotLearned) {
                    rdbNo.Checked = true;
                }
            }
        }

        private void btPrev_Click(object sender, EventArgs e) {
            Prev();
        }

        private void btNext_Click(object sender, EventArgs e) {
            Next();
        }

        private void Prev() {
            if (cardEnumerator.MovePrevious()) {
                SetSide(CardElementSides.Front);
                UpdatePainters();
                if (ckAnimate.Checked) { AnimateSwitch(); }
            }
        }

        private bool Next() {
            if (cardEnumerator.MoveNext()) {
                SetSide(CardElementSides.Front);
                UpdatePainters();
                if (ckAnimate.Checked) { AnimateSwitch(); }
                return true;
            } else {
                return false;
            }
        }

        private void btFlip_Click(object sender, EventArgs e) {
            DoFlip();
        }


        Image rotateLeft = Properties.Resources.rotate_left;
        Image rotateRight = Properties.Resources.rotate_right;

        private void SetSide(CardElementSides side) {
            this.currentSide = side;
            if (this.currentSide == CardElementSides.Front) {
                btFlip.Image = rotateRight;
            } else {
                btFlip.Image = rotateLeft;
            }
        }

        private void DoFlip() {
            if (this.currentSide == CardElementSides.Front) {
                SetSide(CardElementSides.Back);
            } else {
                SetSide(CardElementSides.Front);
            }
            UpdatePainters();
            if (ckAnimate.Checked) { AnimateFlip(); }
        }

        PanelAnimator animator;
        private void AnimateFlip() {
            if (this.animator != null) {
                this.animator.Stop();
            }
            this.animator = new PanelAnimator(PanelAnimator.AnimationStyle.Vertical, pnlCard);
            this.animator.AnimationEnded += new EventHandler(animator_AnimationEnded);
            this.animator.Animate();
        }

        private void AnimateSwitch() {
            if (this.animator != null) {
                this.animator.Stop();
            }
            ResetSize(); // Sometimes panels drift; So, making sure everything is in place!
            this.animator = new PanelAnimator(PanelAnimator.AnimationStyle.Horizontal, pnlCard);
            this.animator.AnimationEnded += new EventHandler(animator_AnimationEnded);
            this.animator.Animate();
        }

        void animator_AnimationEnded(object sender, EventArgs e) {
            this.animator = null;
            if ((this != null) && (!this.IsDisposed)) {
                ResetSize();
            }
        }

        private void ResetSize() {
            // Random(?) 'NullReferenceException' exceptions were thrown by this block
            // of code. The Null check should suffice in curtailing that.
            //  see http://sourceforge.net/support/tracker.php?aid=1611834 for details.
            if (Utility.IsNullorDisposed(this.pnlCard)) { return; }
            if (Utility.IsNullorDisposed(this.pnlCard.Parent)) { return; }

            this.pnlCard.Location = new Point(12, 12);
            this.pnlCard.Width = this.pnlCard.Parent.ClientSize.Width - (this.pnlCard.Left * 2);
            this.pnlCard.Height = this.pnlCard.Parent.ClientSize.Height - (this.pnlCard.Top + 43);
        }

        private class PanelAnimator : IDisposable
        {
            Timer timer;
            AnimationStyle style;
            CardPanel panel;
            Rectangle originalRect;
            AnimationState state;

            public AnimationState State {
                get { return state; }
                set { state = value; }
            }

            public event EventHandler AnimationEnded;

            public void OnAnimationEnded() {
                if (AnimationEnded != null) {
                    AnimationEnded(this, new EventArgs());
                }
            }

            public enum AnimationState { Shrinking, Growing, None };
            public enum AnimationStyle { Vertical, Horizontal };

            public PanelAnimator(AnimationStyle style, CardPanel panel) {
                timer = new Timer();
                timer.Tick += new EventHandler(timer_Tick);

                if (style == AnimationStyle.Horizontal) {
                    this.delta = panel.Width / 12;
                } else {
                    this.delta = panel.Height / 12;
                }
                this.state = AnimationState.Shrinking;
                this.style = style;
                this.panel = panel;
                this.timer.Interval = 2;
                this.originalRect = panel.ClientRectangle;
                this.originalRect.Offset(panel.Location);
            }

            public void Animate() {
                panel.SuspendPaint = true;
                this.timer.Start();
            }

            private void EndAnimation() {
                panel.SuspendPaint = false;
                this.state = AnimationState.None;
                this.timer.Stop();
                OnAnimationEnded();
            }

            public void Stop() {
                this.Dispose(); // Kill the timer
                EndAnimation(); // call reset etc.
            }

            int delta = 20;
            void timer_Tick(object sender, EventArgs e) {
                if (state == AnimationState.Shrinking) {
                    if (this.style == AnimationStyle.Horizontal) {
                        if (panel.Width >= delta) {
                            panel.Width -= delta;
                        } else {
                            panel.Width = 0;
                            state = AnimationState.Growing;
                        }
                    } else {
                        if (panel.Height >= delta) {
                            panel.Height -= delta;
                        } else {
                            panel.Height = 0;
                            state = AnimationState.Growing;
                        }
                    }
                } else {
                    if (this.style == AnimationStyle.Horizontal) {
                        if (panel.Width + delta < originalRect.Width) {
                            panel.Width += delta;
                        } else {
                            EndAnimation();
                        }
                    } else {
                        if (panel.Height + delta < originalRect.Height) {
                            panel.Height += delta;
                        } else {
                            EndAnimation();
                        }
                    }
                }
                if (this.style == AnimationStyle.Horizontal) {
                    panel.Left = originalRect.Left + ((originalRect.Width / 2) - (panel.Width / 2));
                } else {
                    panel.Top = originalRect.Top + ((originalRect.Height / 2) - (panel.Height / 2));
                }
            }

            #region IDisposable Members

            public void Dispose() {
                if (this.timer != null) {
                    this.timer.Dispose();
                }
            }

            #endregion
        }

        private void ckTimed_CheckedChanged(object sender, EventArgs e) {
            SetMode(ckTimed.Checked);
        }

        private Timer playTimer;
        private Timer flipTimer;

        private void SetMode(bool timed) {
            if (timed) {
                if (this.playTimer == null) {
                    // Shows the front Side
                    this.playTimer = new Timer();
                    this.playTimer.Interval = (int)(Settings.AppInstance.ReviewFrontDelay * 1000);
                    this.playTimer.Tick += new EventHandler(playTimer_Tick);
                }

                if (this.flipTimer == null) {
                    this.flipTimer = new Timer();
                    this.flipTimer.Interval = (int)(Settings.AppInstance.ReviewBackDelay * 1000);
                    this.flipTimer.Tick += new EventHandler(flipTimer_Tick);
                }

                if (this.currentSide == CardElementSides.Front) {
                    this.flipTimer.Start();
                } else {
                    this.playTimer.Start();
                }

                // Todo: Allow user to manually progress and then reset timers
                btNext.Enabled = btFlip.Enabled = btPrev.Enabled = false;
            } else {
                if (this.playTimer != null) { this.playTimer.Stop(); }
                if (this.flipTimer != null) { this.flipTimer.Stop(); }

                btNext.Enabled = btFlip.Enabled = btPrev.Enabled = true;
            }
        }

        void flipTimer_Tick(object sender, EventArgs e) {
            DoFlip();
            flipTimer.Stop();
            playTimer.Start();
        }

        void playTimer_Tick(object sender, EventArgs e) {
            if (!Next()) {
                cardEnumerator.Reset();
                Next();
            }
            playTimer.Stop();
            flipTimer.Start();
        }

        private void Reviewer_KeyUp(object sender, KeyEventArgs e) {
            if (cardEnumerator.Count <= 0) return;
            e.SuppressKeyPress = true;
            //		  Console.WriteLine(e.KeyCode);
            switch (e.KeyCode) {
                case Keys.ShiftKey:
                    if (this.currentSide == CardElementSides.Front) {
                        DoFlip();
                    } else {
                        Next();
                    }
                    break;
                case Keys.PageDown: // (Front-Back-Front-Back)
                    if (this.currentSide == CardElementSides.Front) {
                        DoFlip();
                    } else {
                        Next();
                    }
                    break;
                case Keys.PageUp: // (Back-Front-Back-Front)
                    if (this.currentSide == CardElementSides.Front) {
                        DoFlip();
                    } else {
                        Prev();
                    }
                    break;
                case Keys.Right:
                    Next();
                    break;
                case Keys.Left:
                    Prev();
                    break;
                case Keys.Up:
                    DoFlip();
                    break;
                case Keys.Down:
                    DoFlip();
                    break;
                case Keys.Home:
                    cardEnumerator.Reset();
                    Next();
                    break;
                case Keys.End:
                    cardEnumerator.ResetLast();
                    Prev();
                    break;
                case Keys.Y:
                    rdbYes.Checked = true;
                    this.OnDataModified();
                    break;
                case Keys.N:
                    rdbNo.Checked = true;
                    this.OnDataModified();
                    break;
                case Keys.M:
                    rdbMaybe.Checked = true;
                    this.OnDataModified();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    e.SuppressKeyPress = false;
                    break;
            }
        }

        private void rdbYes_CheckedChanged(object sender, EventArgs e) {
            if (rdbYes.Checked) {
                this.cardEnumerator.Current.LearnStatus = CardLearningStaus.Learned;
                rdbMaybe.Checked = rdbNo.Checked = false;
            }
        }

        private void rdbMaybe_CheckedChanged(object sender, EventArgs e) {
            if (rdbMaybe.Checked) {
                this.cardEnumerator.Current.LearnStatus = CardLearningStaus.MaybeLearned;
                rdbYes.Checked = rdbNo.Checked = false;
            }
        }

        private void rdbNo_CheckedChanged(object sender, EventArgs e) {
            if (rdbNo.Checked) {
                this.cardEnumerator.Current.LearnStatus = CardLearningStaus.NotLearned;
                rdbMaybe.Checked = rdbYes.Checked = false;
            }
        }

        bool modified = false;

        public bool Modified {
            get { return modified; }
        }

        private void rdbYesNoMaybe_Click(object sender, EventArgs e) {
            this.OnDataModified();
        }

        private void ckAnimate_CheckedChanged(object sender, EventArgs e) {
            Settings.AppInstance.ReviewAnimate = ckAnimate.Checked;
        }

        private void UpdateAeroLabel() {
            int offset = 12;
            lblAeroAnimate.Location = new Point(tableLayoutPanel1.Left + ckAnimate.Left + offset, tableLayoutPanel1.Top + ckAnimate.Top);
            lblAeroAnimate.Size = new Size(ckAnimate.Width - offset, ckAnimate.Height);
        }

        private void Reviewer_SizeChanged(object sender, EventArgs e) {
            UpdateAeroLabel();
            if (this.animator == null) {
                ResetSize();
            }
            //		  Console.WriteLine(this.Size);
        }

        private void Reviewer_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.WindowState == FormWindowState.Normal) {
                Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
            }
            if (this.animator != null) {
                this.animator.Dispose();
            }
        }

        private void lblAeroAnimate_Click(object sender, EventArgs e) {
            ckAnimate.Checked = !ckAnimate.Checked;
        }

        private void lblAeroAnimate_MouseClick(object sender, MouseEventArgs e) {
            ckAnimate.Checked = !ckAnimate.Checked;
        }

    }
}