using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpusXNAGame
{
    //Question will become a global class, so that game control can access it
    public class Question
    {
        //contains variables for the text of a question
        //all four choices
        //and the correct answer
        public string questionText;
        public int answer;
        public string choice1;
        public string choice2;
        public string choice3;
        public string choice4;
    }

    class Trivia
    {
        //uses an array to load in the data from an xml file or potentially from an online source
        public Question[] QuestionSet = new Question[3];
        public int currentQnumber = 0;

        public Trivia()
        {
            //hard-coding declarations of storing the questions in the array
            QuestionSet[0] = new Question();
            QuestionSet[0].questionText = "How many in a dozen?";
            QuestionSet[0].answer = 2;
            QuestionSet[0].choice1 = "13";
            QuestionSet[0].choice2 = "12";
            QuestionSet[0].choice3 = "9";
            QuestionSet[0].choice4 = "10";
            QuestionSet[1] = new Question();
            QuestionSet[1].questionText = "What color was George Washington's white horse?";
            QuestionSet[1].answer = 4;
            QuestionSet[1].choice1 = "Blue";
            QuestionSet[1].choice2 = "Brown";
            QuestionSet[1].choice3 = "Black";
            QuestionSet[1].choice4 = "White";
            QuestionSet[2] = new Question();
            QuestionSet[2].questionText = "Who's buried in Grant's tomb?";
            QuestionSet[2].answer = 1;
            QuestionSet[2].choice1 = "Grant";
            QuestionSet[2].choice2 = "Betty";
            QuestionSet[2].choice3 = "John";
            QuestionSet[2].choice4 = "Lucy";
        }

        public void SortTrivia()
        {
            //will randomize the order of trivia questions
            //once randomized, trivia questions can be stepped through in order without repeating questions
            //allows for a different order of questions for each instance of a game
        }

        public Question FetchQuestion()
        {
            //returns a question and increments the current number
            //so that questions can be stepped through in order without repeating anything
            return QuestionSet[currentQnumber++];

        }
    }
    //private Question question;
    //create a new instance of (what will be) global class Question
    //question = Trivia.FetchQuestion();
    //       //the class variable will then equal whatever output comes from my FetchQuestion()
    //       label2.Text = question.questionText;
    //       radioButton1.Text = question.choice1;
    //       radioButton2.Text = question.choice2;
    //       radioButton3.Text = question.choice3;
    //       radioButton4.Text = question.choice4;
    //passes through the text, choices, and correct answer all at once
    //can pass the text and choices to gui while keeping the answer for that instance
    //int playerInput = 0;

    //        if (radioButton1.Checked)
    //            playerInput = 1;
    //        if (radioButton2.Checked)
    //            playerInput = 2;
    //        if (radioButton3.Checked)
    //            playerInput = 3;
    //        if (radioButton4.Checked)
    //            playerInput = 4;

    //        //can, in game control, instantly check whether the player got it right or now
    //        //using the question.answer variable
    //        if (playerInput == question.answer)
    //            label3.Text = "Correct!";
    //        if (playerInput != question.answer)
    //            label3.Text = "Incorrect!";
}
