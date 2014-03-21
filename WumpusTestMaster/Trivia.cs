using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WumpusTestHighScore
{
    class Trivia
    {
        public Trivia()
        {
            Console.WriteLine("You just made a new Trivia Object");
        }
        public void callTrivia()
        {
            //creates an initialization of trivia class 
            //will call SortTrivia() function on initialization
        }

        public void SortTrivia()
        {
            //will randomize the order of trivia questions
            //once randomized, trivia questions can be stepped through in order without repeating questions
            //allows for a different order of questions for each instance of a game
        }
        public string QuestionCall(int number2, out string questions)
        {
            questions = " ";
            return questions;
            //when used will use loop to output number2 of questions depending on input
        }

        public bool CheckAnswer(int guess, out bool Checked)
        {
            //will take in whatever number 1-4 is selected by player
            //will compare the answer recieved to correct answer
            //if right, Checked = true, if wrong, Checked = false
            Checked = false;
            return Checked;
        }
    }
}
