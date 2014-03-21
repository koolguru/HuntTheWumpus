using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WumpusTestHighScore
{
    public partial class Form1 : Form
    {
        private HighScore highScore;
        int number = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void constructorButton_Click(object sender, EventArgs e)
        {
             highScore = new HighScore();
             number++;
             constructorLabel.Text = "High Score Initialized";
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            GameControl gameController = new GameControl();
            gameControllerLabel.Text = "Game Controller Initialized";
        }

        private void playerConstructorButton_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            playerConstructorLabel.Text = "Player Initialized";
        }

        private void guidedUIButton_Click(object sender, EventArgs e)
        {
            Gui gui = new Gui();
            guidedUILabel.Text = "GUI Initialized";
        }

        private void triviaButton_Click(object sender, EventArgs e)
        {
            Trivia trvia = new Trivia();
            triviaLabel.Text = "Trivia intialized"; 
        }

        private void caveConstructorButton_Click(object sender, EventArgs e)
        {
            Cave cave = new Cave();
            CaveConstructorLabel.Text = "Cave Initialized";
        }

        private void mapConstructorButton_Click(object sender, EventArgs e)
        {
            map map = new map();
            mapConstructorLabel.Text = "Da map has been initalized";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapConstructorLabel.Text = "";
            CaveConstructorLabel.Text = "";
            triviaLabel.Text = "";
            guidedUILabel.Text = "";
            gameControllerLabel.Text = "";
            constructorLabel.Text = "";
            playerConstructorLabel.Text = "";
        }
    }
}
