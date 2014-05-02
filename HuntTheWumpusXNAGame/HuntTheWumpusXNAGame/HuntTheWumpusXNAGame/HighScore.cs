using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HuntTheWumpusXNAGame
{
    class HighScore
    {
        public int NumberOfTurns { get; set; } //game control
        public int NumberOfArrows { get; set; } //player
        public int GoldLeft { get; set; } //player

        public HighScore(int turns, int arrows, int gold)
        {
            NumberOfTurns = turns;
            NumberOfArrows = arrows;
            GoldLeft = gold;
            XmlDocument database;
            database = new XmlDocument();
            database.Load("HighScores.xml");
        }
        public List<double> TopTenScores(double totalScore)
        {
            List<double> highScoreList = new List<double>();
            //pulls an existing high score list
            //gets totalScore from ScoreCalculations
            //compares totalScore with entire list
            //places it in the list if it belongs in the top ten and makes a new list 
            ScoreCalculations(100, 200, 300);
            return highScoreList; //final list with new score compared with stored scores
        }
        public int ScoreCalculations(int numberOfTurns, int goldLeft, int numberOfArrowsLeft)
        {
            int totalScore = 100;
            totalScore = 100 - numberOfTurns + goldLeft + (10 * numberOfArrowsLeft);
            return totalScore; //total score
        }
        public void ScoreHandler()
        {
            //keep track of number of turns
            int numberOfTurns = 1;
            //keep track of gold left
            int goldLeft = 1;
            //keep track of arrows
            int arrowsLeft = 1;
            //keep updating during game
            //Call the ScoreCalculator() and provide it with the above variables as paramters 
        }
    }
}
