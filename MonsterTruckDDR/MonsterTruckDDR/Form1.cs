using WMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Media;

namespace MonsterTruckDDR
{

    public partial class Form1 : Form
    {
        int currentTime = 0;

        int currentHits = 0;
        int currentHits2 = 0;

        int currentMisses = 0;
        int currentMisses2 = 0;

        static SerialPort port;

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            for (int i = 0; i < (10000 * port.BytesToRead) / port.BaudRate; i++)
                ;       //Delay a bit for the serial to catch up
            Console.Write(port.ReadExisting());
        }

        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;

            WMPLib.WindowsMediaPlayer axWindowsMediaPlayer1 = new WMPLib.WindowsMediaPlayer();

            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.URL = "monstertruckddrsong.mp3";
            axWindowsMediaPlayer1.controls.play();

            player1HitsLabel.Visible = false;
            player2HitsLabel.Visible = false;

            player1MissesLabel.Visible = false;
            player2MissesLabel.Visible = false;

            player1AccuracyLabel.Visible = false;
            player2AccuracyLabel.Visible = false;

            exitButton.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void showInstructions()
        {
            startButton.Visible = false;
            helpButton.Visible = false;
            backToScreenButton.Visible = true;
            instructionsBox.Visible = true;
        }

        private void removeInstructions()
        {
            startButton.Visible = true;
            helpButton.Visible = true;
            backToScreenButton.Visible = false;
            instructionsBox.Visible = false;
        }

        private void startInput()
        {
            startButton.Visible = false;
            helpButton.Visible = false;
            backgroundImage1.Visible = false;
            timeInputTextBox.Visible = true;
            timeInputBox.Visible = true;
            continueButton.Visible = true;
            background2.Visible = true;
        }

        private async void runGame()
        {
            timeInputTextBox.Visible = false;
            timeInputBox.Visible = false;
            continueButton.Visible = false;
            timer.Text = timeInputTextBox.Text;

            readyBox.Visible = true;
            await Task.Delay(1000);

            readyBox.Visible = false;
            setBox.Visible = true;
            await Task.Delay(1000);

            setBox.Visible = false;
            goBox.Visible = true;

            await Task.Delay(1000);
            goBox.Visible = false;

            gameBackground.Visible = true;
            gameBackground2.Visible = true;

            timer.Visible = true;
            timerLabel.Visible = true;

            player1Label.Visible = true;
            player2Label.Visible = true;

            hitCounter.Visible = true;
            hitCounter2.Visible = true;

            hitCounterLabel.Visible = true;
            hitCounterLabel2.Visible = true;

            Random currentArrow = new Random();
            int arrow = 0;
            int secondArrow = 0;
            int timerCount = 0;

            if (Int32.TryParse(timer.Text, out currentTime) == false)
            {
                //Make the user try again
            }


            // else continue as normal, current time has our new value

            leftArrow.Visible = false;
            upArrow.Visible = false;
            downArrow.Visible = false;
            rightArrow.Visible = false;

            aArrow.Visible = false;
            wArrow.Visible = false;
            sArrow.Visible = false;
            dArrow.Visible = false;

            while (currentTime != 0)
            {
                if (leftArrow.Visible == true || upArrow.Visible == true || downArrow.Visible == true || rightArrow.Visible == true)
                {

                }
                else
                {
                    arrow = currentArrow.Next(4);

                    if (arrow == 0)
                    {
                        leftArrow.Visible = true;
                        upArrow.Visible = false;
                        downArrow.Visible = false;
                        rightArrow.Visible = false;
                    }
                    else if (arrow == 1)
                    {
                        leftArrow.Visible = false;
                        upArrow.Visible = true;
                        downArrow.Visible = false;
                        rightArrow.Visible = false;
                    }
                    else if (arrow == 2)
                    {
                        leftArrow.Visible = false;
                        upArrow.Visible = false;
                        downArrow.Visible = true;
                        rightArrow.Visible = false;
                    }
                    else if (arrow == 3)
                    {
                        leftArrow.Visible = false;
                        upArrow.Visible = false;
                        downArrow.Visible = false;
                        rightArrow.Visible = true;
                    }
                }

                if (aArrow.Visible == true || wArrow.Visible == true || sArrow.Visible == true || dArrow.Visible == true)
                {

                }
                else
                {
                    secondArrow = currentArrow.Next(4);

                    if (secondArrow == 0)
                    {
                        aArrow.Visible = true;
                        wArrow.Visible = false;
                        sArrow.Visible = false;
                        dArrow.Visible = false;
                    }
                    else if (secondArrow == 1)
                    {
                        aArrow.Visible = false;
                        wArrow.Visible = true;
                        sArrow.Visible = false;
                        dArrow.Visible = false;
                    }
                    else if (secondArrow == 2)
                    {
                        aArrow.Visible = false;
                        wArrow.Visible = false;
                        sArrow.Visible = true;
                        dArrow.Visible = false;
                    }
                    else if (secondArrow == 3)
                    {
                        aArrow.Visible = false;
                        wArrow.Visible = false;
                        sArrow.Visible = false;
                        dArrow.Visible = true;
                    }
                }

                await Task.Delay(100);
                timerCount++;

                if (timerCount == 10)
                {
                    currentTime--;
                    timer.Text = currentTime.ToString();
                    timerCount = 0;
                }
            }

            leftArrow.Visible = false;
            upArrow.Visible = false;
            downArrow.Visible = false;
            rightArrow.Visible = false;

            aArrow.Visible = false;
            wArrow.Visible = false;
            sArrow.Visible = false;
            dArrow.Visible = false;

            gameBackground.Visible = false;
            gameBackground2.Visible = false;

            timer.Visible = false;
            timerLabel.Visible = false;

            hitCounter.Visible = false;
            hitCounter2.Visible = false;

            hitCounterLabel.Visible = false;
            hitCounterLabel2.Visible = false;

            player1Label.Visible = false;
            player2Label.Visible = false;

            endScreen.Visible = true;

            player1HitsLabel.Visible = true;
            player2HitsLabel.Visible = true;

            player1MissesLabel.Visible = true;
            player2MissesLabel.Visible = true;

            player1AccuracyLabel.Visible = true;
            player2AccuracyLabel.Visible = true;

            exitButton.Visible = true;

            string portName = "COM3";
            int baudRate = 9600;
            port = new SerialPort(portName, baudRate);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();

            byte[] hitBytes;

            if (currentHits > currentHits2)
            {
                winnerLabel.Text = "Player 1";
                hitBytes = BitConverter.GetBytes(currentHits);
            }
            else
            {
                winnerLabel.Text = "Player 2";
                hitBytes = BitConverter.GetBytes(currentHits2);
            }

            port.Write(hitBytes, 0, 4);

            player1HitsLabel.Text = currentHits.ToString();
            player2HitsLabel.Text = currentHits2.ToString();

            player1MissesLabel.Text = currentMisses.ToString();
            player2MissesLabel.Text = currentMisses2.ToString();

            double player1Acc = (((double)currentHits / ((double)currentHits + (double)currentMisses)) * 100);
            double player2Acc = (((double)currentHits2 / ((double)currentHits2 + (double)currentMisses2)) * 100);

            if (((currentHits + currentMisses) == 0) && ((currentHits2 + currentMisses2) == 0))
            {
                player1AccuracyLabel.Text = "% 0.00";
                player2AccuracyLabel.Text = "% 0.00";
            }
            else if ((currentHits + currentMisses) == 0)
            {
                player1AccuracyLabel.Text = "% 0.00";
                player2AccuracyLabel.Text = "% " + player2Acc.ToString("0.00");
            }
            else if ((currentHits2 + currentMisses2) == 0)
            {
                player1AccuracyLabel.Text = "% " + player1Acc.ToString("0.00");
                player2AccuracyLabel.Text = "% 0.00";
            }
            else
            {
                player1AccuracyLabel.Text = "% " + player1Acc.ToString("0.00");
                player2AccuracyLabel.Text = "% " + player2Acc.ToString("0.00");
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            showInstructions();
        }

        private void backToScreenButton_Click(object sender, EventArgs e)
        {
            removeInstructions();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startInput();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            runGame();
        }

        protected override bool IsInputKey(Keys keyData)
        {
            bool leftArrowPress = false;
            bool downArrowPress = false;
            bool upArrowPress = false;
            bool rightArrowPress = false;

            bool aPress = false;
            bool sPress = false;
            bool wPress = false;
            bool dPress = false;

            switch (keyData)
            {
                case Keys.Left:
                    leftArrowPress = true;
                    return leftArrowPress;
                case Keys.Up:
                    upArrowPress = true;
                    return upArrowPress;
                case Keys.Down:
                    downArrowPress = true;
                    return downArrowPress;
                case Keys.Right:
                    rightArrowPress = true;
                    return rightArrowPress;
                case Keys.A:
                    aPress = true;
                    return aPress;
                case Keys.S:
                    sPress = true;
                    return sPress;
                case Keys.W:
                    wPress = true;
                    return wPress;
                case Keys.D:
                    dPress = true;
                    return dPress;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        protected async override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        if (leftArrow.Visible == true)
                        {
                            leftArrow.Visible = false;
                            leftArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            leftArrowCorrect.Visible = false;
                            currentHits = currentHits + 1;
                            hitCounter.Text = currentHits.ToString();
                        }
                        else if (upArrow.Visible == true)
                        {
                            upArrow.Visible = false;
                            upArrowWrong.Visible = true;
                            await Task.Delay(100);
                            upArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (downArrow.Visible == true)
                        {
                            downArrow.Visible = false;
                            downArrowWrong.Visible = true;
                            await Task.Delay(100);
                            downArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (rightArrow.Visible == true)
                        {
                            rightArrow.Visible = false;
                            rightArrowWrong.Visible = true;
                            await Task.Delay(100);
                            rightArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }

                        break;
                    }
                case Keys.Up:
                    {
                        if (leftArrow.Visible == true)
                        {
                            leftArrow.Visible = false;
                            leftArrowWrong.Visible = true;
                            await Task.Delay(100);
                            leftArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (upArrow.Visible == true)
                        {
                            upArrow.Visible = false;
                            upArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            upArrowCorrect.Visible = false;
                            currentHits = currentHits + 1;
                            hitCounter.Text = currentHits.ToString();
                        }
                        else if (downArrow.Visible == true)
                        {
                            downArrow.Visible = false;
                            downArrowWrong.Visible = true;
                            await Task.Delay(100);
                            downArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (rightArrow.Visible == true)
                        {
                            rightArrow.Visible = false;
                            rightArrowWrong.Visible = true;
                            await Task.Delay(100);
                            rightArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }

                        break;
                    }
                case Keys.Down:
                    {
                        if (leftArrow.Visible == true)
                        {
                            leftArrow.Visible = false;
                            leftArrowWrong.Visible = true;
                            await Task.Delay(100);
                            leftArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (upArrow.Visible == true)
                        {
                            upArrow.Visible = false;
                            upArrowWrong.Visible = true;
                            await Task.Delay(100);
                            upArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (downArrow.Visible == true)
                        {
                            downArrow.Visible = false;
                            downArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            downArrowCorrect.Visible = false;
                            currentHits = currentHits + 1;
                            hitCounter.Text = currentHits.ToString();
                        }
                        else if (rightArrow.Visible == true)
                        {
                            rightArrow.Visible = false;
                            rightArrowWrong.Visible = true;
                            await Task.Delay(100);
                            rightArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }

                        break;
                    }
                case Keys.Right:
                    {
                        if (leftArrow.Visible == true)
                        {
                            leftArrow.Visible = false;
                            leftArrowWrong.Visible = true;
                            await Task.Delay(100);
                            leftArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (upArrow.Visible == true)
                        {
                            upArrow.Visible = false;
                            upArrowWrong.Visible = true;
                            await Task.Delay(100);
                            upArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (downArrow.Visible == true)
                        {
                            downArrow.Visible = false;
                            downArrowWrong.Visible = true;
                            await Task.Delay(100);
                            downArrowWrong.Visible = false;
                            currentMisses = currentMisses + 1;
                        }
                        else if (rightArrow.Visible == true)
                        {
                            rightArrow.Visible = false;
                            rightArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            rightArrowCorrect.Visible = false;
                            currentHits = currentHits + 1;
                            hitCounter.Text = currentHits.ToString();
                        }

                        break;
                    }
                case Keys.A:
                    {
                        if (aArrow.Visible == true)
                        {
                            aArrow.Visible = false;
                            aArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            aArrowCorrect.Visible = false;
                            currentHits2 = currentHits2 + 1;
                            hitCounter2.Text = currentHits2.ToString();
                        }
                        else if (wArrow.Visible == true)
                        {
                            wArrow.Visible = false;
                            wArrowWrong.Visible = true;
                            await Task.Delay(100);
                            wArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (sArrow.Visible == true)
                        {
                            sArrow.Visible = false;
                            sArrowWrong.Visible = true;
                            await Task.Delay(100);
                            sArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (dArrow.Visible == true)
                        {
                            dArrow.Visible = false;
                            dArrowWrong.Visible = true;
                            await Task.Delay(100);
                            dArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }

                        break;
                    }
                case Keys.W:
                    {
                        if (aArrow.Visible == true)
                        {
                            aArrow.Visible = false;
                            aArrowWrong.Visible = true;
                            await Task.Delay(100);
                            aArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (wArrow.Visible == true)
                        {
                            wArrow.Visible = false;
                            wArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            wArrowCorrect.Visible = false;
                            currentHits2 = currentHits2 + 1;
                            hitCounter2.Text = currentHits2.ToString();
                        }
                        else if (sArrow.Visible == true)
                        {
                            sArrow.Visible = false;
                            sArrowWrong.Visible = true;
                            await Task.Delay(100);
                            sArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (dArrow.Visible == true)
                        {
                            dArrow.Visible = false;
                            dArrowWrong.Visible = true;
                            await Task.Delay(100);
                            dArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }

                        break;
                    }
                case Keys.S:
                    {
                        if (aArrow.Visible == true)
                        {
                            aArrow.Visible = false;
                            aArrowWrong.Visible = true;
                            await Task.Delay(100);
                            aArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (wArrow.Visible == true)
                        {
                            wArrow.Visible = false;
                            wArrowWrong.Visible = true;
                            await Task.Delay(100);
                            wArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (sArrow.Visible == true)
                        {
                            sArrow.Visible = false;
                            sArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            sArrowCorrect.Visible = false;
                            currentHits2 = currentHits2 + 1;
                            hitCounter2.Text = currentHits2.ToString();
                        }
                        else if (dArrow.Visible == true)
                        {
                            dArrow.Visible = false;
                            dArrowWrong.Visible = true;
                            await Task.Delay(100);
                            dArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }

                        break;
                    }
                case Keys.D:
                    {
                        if (aArrow.Visible == true)
                        {
                            aArrow.Visible = false;
                            aArrowWrong.Visible = true;
                            await Task.Delay(100);
                            aArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (wArrow.Visible == true)
                        {
                            wArrow.Visible = false;
                            wArrowWrong.Visible = true;
                            await Task.Delay(100);
                            wArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (sArrow.Visible == true)
                        {
                            sArrow.Visible = false;
                            sArrowWrong.Visible = true;
                            await Task.Delay(100);
                            sArrowWrong.Visible = false;
                            currentMisses2 = currentMisses2 + 1;
                        }
                        else if (dArrow.Visible == true)
                        {
                            dArrow.Visible = false;
                            dArrowCorrect.Visible = true;
                            await Task.Delay(100);
                            dArrowCorrect.Visible = false;
                            currentHits2 = currentHits2 + 1;
                            hitCounter2.Text = currentHits2.ToString();
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}