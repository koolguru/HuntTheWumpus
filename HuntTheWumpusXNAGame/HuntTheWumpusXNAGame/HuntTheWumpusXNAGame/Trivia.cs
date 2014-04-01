using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
        XmlDocument database;

        public Trivia()
        {
            //populating the array from the xml document
            database = new XmlDocument();
            database.Load("Trivia.xml");
            XmlNodeList trivia = database.GetElementsByTagName("Trivia");
            XmlNodeList question = database.GetElementsByTagName("Question");
            XmlNodeList choice1 = database.GetElementsByTagName("Choice1");
            XmlNodeList choice2 = database.GetElementsByTagName("Choice2");
            XmlNodeList choice3 = database.GetElementsByTagName("Choice3");
            XmlNodeList choice4 = database.GetElementsByTagName("Choice4");
            XmlNodeList answer = database.GetElementsByTagName("Answer");

            for (int i = 0; i < trivia.Count; i++)
            {
                QuestionSet[i] = new Question();
                QuestionSet[i].questionText = question[i].InnerText;
                QuestionSet[i].answer = Convert.ToInt32(answer[i].InnerText);
                QuestionSet[i].choice1 = choice1[i].InnerText;
                QuestionSet[i].choice2 = choice2[i].InnerText;
                QuestionSet[i].choice3 = choice3[i].InnerText;
                QuestionSet[i].choice4 = choice4[i].InnerText;
            }
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
