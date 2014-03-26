using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusTestHighScore
{
    class HighScore
    {

        public HighScore()
        {
            Console.WriteLine("You just made a new High Score Object");
        }
        public List<int> TopTenScores(int totalScore)
        {
            List <int> highScoreList = new List<int>();
            //pulls an existing high score list
            //gets totalScore from ScoreCalculations
            //compares totalScore with entire list
            //places it in the list if it belongs in the top ten and makes a new list 
            return highScoreList; //final list with new score compared with stored scores
        }
        public int ScoreCalculations(int numberOfTurns, int goldLeft, int numberOfArrowsLeft )
        {
            int totalScore = 100;
            //Gets scoring information
            //calculates total score
            //calls TopTenScores()
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
