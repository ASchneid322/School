//***********************************************************************************
//Program:					Ballz
//Description:	            Game of ballz
//Date:						April 13th
//Authors:					Alexander Schneider
//Course:					CMPE1600
//Class:					CNTA02
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using System.Threading;
using System.IO;

namespace Lab2Ballz
{
    public enum Difficulty { easy = 3, medium, hard }

    public partial class Ballz : Form
    {
        private enum Bstate { alive, dead};
        private struct Ball{
            public Bstate state;
            public Color color;
            public Ball(Bstate _state, Color _color)
            {
                state = _state;
                color = _color;
            }
        }

        private Score DlgScore = new Score();
        private AniSpeed DlgAniSpeed = new AniSpeed();

        //Size of balls
        private const int BALLSIZE= 25;
        //height of drawer
        private const int height = 600;
        //width of drawer
        private const int width = 800;
        private const int ballWidth = width / BALLSIZE;
        private const int ballHeight = height / BALLSIZE;
        private const string filePath = "highscores.txt";

        //Players current score
        private int Score = 0;
        //Current delay
        private int Delay = 10;

        //Current held top scores and names
        //Read in at load, stored to stop rereading.
        private int scoreHard = 0;
        private int scoreMed = 0;
        private int scoreEasy = 0;
        private string nameHard;
        private string nameMed;
        private string nameEasy;

        private static Random rand = new Random(); //class level static

        private Difficulty diff;

        private CDrawer canvas;
        private Ball[,] balls = new Ball[ballWidth, ballHeight];

        public Ballz()
        {
            InitializeComponent();
        }

        private void UI_Bplay_Click(object sender, EventArgs e)
        {
            Select Ddialog = new Select();
            if (Ddialog.ShowDialog() == DialogResult.OK)
            {
                canvas = new CDrawer(width, height);
                diff = Ddialog.diff;
                Randomize(diff);
                Display();
                UI_timer.Enabled = true;
                UI_Bplay.Enabled = false;
            }
        }

        private void UI_timer_Tick(object sender, EventArgs e)
        {
            //HighScore newHigh = new HighScore();
            int ballsKilled = 0;
            ballsKilled = Pick();
            Score += Convert.ToInt32(Math.Pow(ballsKilled, 2) + 2 * ballsKilled);
            DlgScore.score = Score;
            Display();
            if (BallsAlive() == 0)
            {
                canvas.AddText("Game Over", 25, Color.Gray);
                UI_timer.Enabled = false;
                UI_Bplay.Enabled = true;
                if (diff == Difficulty.hard && Score > scoreHard)
                {
                    //scoreHard = Score;
                    newHighScore();
                }
                else if (diff == Difficulty.medium && Score > scoreMed)
                {
                    //scoreMed = Score;
                    newHighScore();
                }
                else if (diff == Difficulty.easy && Score > scoreEasy)
                {
                    //scoreEasy = Score;
                    newHighScore();
                }
            }
        }

        //If the player has a new high score, allow them to enter the board if they desire.
        private void newHighScore()
        {
            HighScore newHigh = new HighScore();
            if (newHigh.ShowDialog() == DialogResult.OK)
            {
                if (diff == Difficulty.hard)
                {
                    scoreHard = Score;
                    nameHard = newHigh.name;
                }
                else if (diff == Difficulty.medium)
                {
                    scoreMed = Score;
                    nameMed = newHigh.name;
                }
                else if (diff == Difficulty.easy)
                {
                    nameEasy = newHigh.name;
                    scoreEasy = Score;
                }
                using (StreamWriter highScores = new StreamWriter(filePath))
                {
                    highScores.WriteLine(String.Format("Easy {0} {1}", nameEasy, scoreEasy));
                    highScores.WriteLine(String.Format("Medium {0} {1}", nameMed, scoreMed));
                    highScores.WriteLine(String.Format("Hard {0} {1}", nameHard, scoreHard));
                }
            }
        }

        //Randomize the balls for play
        private void Randomize(Difficulty diff)
        {
            Random rand = new Random(); //class level static
            Color[] colors = new Color[5] { Color.Red, Color.Yellow, Color.Blue, Color.Green, Color.DarkOrange };
            for (int h=0; h<balls.GetLength(1); ++h)
            {
                for (int w = 0; w < balls.GetLength(0); ++w)
                {
                    balls[w, h] = new Ball(Bstate.alive, colors[rand.Next(0, (int)diff)]);
                }
            }
        }

        //Display the balls on GDI.
        private void Display()
        {
            canvas.Clear();
            for (int h = 0; h < balls.GetLength(1); ++h)
            {
                for (int w = 0; w < balls.GetLength(0); ++w)
                {
                    if (balls[w, h].state == Bstate.alive)
                        canvas.AddEllipse(w * BALLSIZE, h * BALLSIZE, BALLSIZE, BALLSIZE, balls[w, h].color);
                }
            }
        }

        //Get the users picked locatio.
        private int Pick()
        {
            Point cords;
            int xPos;
            int yPos;
            int score = 0;
            //Check if there is new coords from clicking.
            if (!canvas.GetLastMouseLeftClick(out cords))
                return 0;
            //Get the position of the cursor relative to the balls on screen by ballsize.
            xPos = cords.X / BALLSIZE;
            yPos = cords.Y / BALLSIZE;
            //Check balls to get score from balls killed.
            score = CheckBalls(xPos, yPos, balls[xPos, yPos].color);
            //Drop down all the remaining balls, so all dead is on top
            FallDown();
            return score;
        }

        //Check balls nearby to see if they beed to be killed.
        private int CheckBalls(int x, int y, Color ballC)
        {
            int ballsKilled=0;
            //Check the three cases where the ball doesnt count
            if ( x> balls.GetLength(0)-1 || x<0 || y<0 || y> balls.GetLength(1)-1)
                return 0;
            else if (balls[x, y].state == Bstate.dead)
                return 0;
            else if (balls[x, y].color != ballC)
                return 0;

            //If the ball counts, add 1 to the counting balls killed.
            //Recursively check around this ball for other balls.
            //And kill the ball
            ++ballsKilled;
            balls[x, y].state = Bstate.dead;
            ballsKilled += CheckBalls(x + 1, y , ballC);
            ballsKilled += CheckBalls(x - 1, y , ballC);
            ballsKilled += CheckBalls(x , y + 1, ballC);
            ballsKilled += CheckBalls(x , y - 1, ballC);

            return ballsKilled;
        }

        private int FallDown()
        {
            int drops;
            while ((drops = StepDown()) != 0) ;
            return drops;
        }

        //Moves the balls with dead space below them down.
        private int StepDown()
        {
            int drop = 0;
            for (int h = 0; h < balls.GetLength(1); ++h)
            {
                for (int w = 0; w < balls.GetLength(0); ++w)
                {
                    if (balls[w, h].state == Bstate.dead)
                    {
                        if ((h-1 > -1) && balls[w, h-1].state != Bstate.dead)
                        {
                            balls[w, h] = balls[w, h - 1];
                            balls[w, h - 1].state = Bstate.dead;
                            ++drop;
                            Thread.Sleep(Delay);
                            Display();
                        }
                    }
                }
            }
            return drop;
        }

        //Check if there are balls alive.
        private int BallsAlive()
        {
            int alive = 0;
            for (int h = 0; h < balls.GetLength(1); ++h)
            {
                for (int w = 0; w < balls.GetLength(0); ++w)
                {
                    if (balls[w, h].state != Bstate.dead)
                    {
                        ++alive;
                    }
                }
            }
            return alive;
        }

        private void UI_Sscore_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_Sscore.Checked)
            {
                DlgScore.DELformclosed = new Score.delVoidVoid(ScoreClosed);
                DlgScore.Show();
            }
        }

        private void ScoreClosed()
        {
            UI_Sscore.Checked = false;
        }

        private void UI_Sanispeed_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_Sanispeed.Checked)
            {
                DlgAniSpeed.DELformclosed = new AniSpeed.delVoidVoid(AniClosed);
                DlgAniSpeed.DELfreqchanged = new AniSpeed.delVoidInt(DelaySpeed);
                DlgAniSpeed.Show();
            }
        }

        private void AniClosed()
        {
            UI_Sanispeed.Checked = false;
        }

        private void DelaySpeed(int delay)
        {
            Delay = delay;
        }

        //Open file of scores.
        private void Ballz_Load(object sender, EventArgs e)
        {
            string[] scoreLine;
            try {
                using (StreamReader highScores = new StreamReader(filePath))
                {
                    scoreLine = highScores.ReadLine().Split();
                    nameEasy = scoreLine[1];
                    scoreEasy = Convert.ToInt32(scoreLine[2]);
                    scoreLine = highScores.ReadLine().Split();
                    nameMed = scoreLine[1];
                    scoreMed = Convert.ToInt32(scoreLine[2]);
                    scoreLine = highScores.ReadLine().Split();
                    nameHard = scoreLine[1];
                    scoreHard = Convert.ToInt32(scoreLine[2]);
                }
            }
            catch
            {
                nameEasy = "";
                scoreEasy = 0;
                nameMed = "";
                scoreMed = 0;
                nameHard = "";
                scoreHard = 0;
            }
        }
    }
}
