using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HuntTheWumpusXNAGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class NodeTest
    {
        public bool[] Connections;
        public Vector2 pos;
        public NodeTest(bool[] Connections, Vector2 pos)
        {
            this.Connections = Connections;
            this.pos = pos;
        }
    }
    public class PlayerTest
    {
        public NodeTest room;
        public Rectangle bounding;
        public PlayerTest(NodeTest room, Rectangle bounding)
        {
            this.room = room;
            this.bounding = bounding;
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D caveTex;
        PlayerTest player;
        bool[] doors;
        Texture2D edge;
        List<NodeTest> nodes;
        Texture2D playerTex;
        Texture2D twelve;
        Texture2D two;
        Texture2D four;
        Texture2D six;
        Texture2D eight;
        Texture2D ten;
        Trivia trivia;
        TriviaQuestion tQuestion;
        TriviaAnswer tAnswerA;
        TriviaAnswer tAnswerB;
        TriviaAnswer tAnswerC;
        TriviaAnswer tAnswerD;
        Question question;
        enum GameState { Menu, MainGame, GameOver };
        SpriteFont spriteFont;
        KeyboardState oldState;
        int score;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Define all variables not defined in Initizalize
            doors = new bool[] { true, false, true, true, false, false };
            nodes = new List<NodeTest>();
            nodes.Add(new NodeTest(doors, new Vector2(200, 0)));
            nodes.Add(new NodeTest(doors, new Vector2(50, 100)));
            player = new PlayerTest(nodes[0], new Rectangle(350, 100, 50, 50));
            playerTex = Content.Load<Texture2D>("Player");
            twelve = Content.Load<Texture2D>("0");
            two = Content.Load<Texture2D>("1");
            four = Content.Load<Texture2D>("2");
            six = Content.Load<Texture2D>("3");
            eight = Content.Load<Texture2D>("4");
            ten = Content.Load<Texture2D>("5");
            //Load Content
            caveTex = Content.Load<Texture2D>("Cave");
            edge = Content.Load<Texture2D>("ViewportEdge");
            trivia = new Trivia();
            tQuestion = new TriviaQuestion("", 0);
            tAnswerA = new TriviaAnswer("", 1);
            tAnswerB = new TriviaAnswer("", 2);
            tAnswerC = new TriviaAnswer("", 3);
            tAnswerD = new TriviaAnswer("", 4);
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            oldState = Keyboard.GetState();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                foreach (NodeTest n in nodes)
                {
                        n.pos.Y++;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                foreach (NodeTest n in nodes)
                {
                    n.pos.X--;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                foreach (NodeTest n in nodes)
                {
                    n.pos.Y--;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                foreach (NodeTest n in nodes)
                {
                    n.pos.X++;
                }
            }
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.R) && !oldState.IsKeyDown(Keys.R))
            {
                UpdateTrivia();
            }
            oldState = Keyboard.GetState();
            if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                if (new Rectangle(20, 35 + 16, Convert.ToInt32(spriteFont.MeasureString(tAnswerA.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    if (question.answer == 1)
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                    ClearTrivia();
                }
                else if (new Rectangle(20, 350 + 32, Convert.ToInt32(spriteFont.MeasureString(tAnswerB.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    if (question.answer == 2)
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                    ClearTrivia();
                }
                else if (new Rectangle(20, 350 + 48, Convert.ToInt32(spriteFont.MeasureString(tAnswerC.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    if (question.answer == 3)
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                    ClearTrivia();
                }
                else if (new Rectangle(20, 350 + 64, Convert.ToInt32(spriteFont.MeasureString(tAnswerD.question).X), 16).Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    if (question.answer == 4)
                    {
                        score++;
                    }
                    else
                    {
                        score--;
                    }
                    ClearTrivia();
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                ClearTrivia();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void UpdateTrivia()
        {
            question = trivia.FetchQuestion();
            tQuestion.question = question.questionText;
            tQuestion.correctAnswer = question.answer;
            tAnswerA.question = question.choice1;
            tAnswerB.question = question.choice2;
            tAnswerC.question = question.choice3;
            tAnswerD.question = question.choice4;
        }
        public void ClearTrivia()
        {
            tQuestion.question = "";
            tQuestion.correctAnswer = 0;
            tAnswerA.question = "";
            tAnswerB.question = "";
            tAnswerC.question = "";
            tAnswerD.question = "";
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (NodeTest n in nodes)
            {
                spriteBatch.Draw(caveTex, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                if (n.Connections[0])
                {
                    spriteBatch.Draw(twelve, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
                if (n.Connections[1])
                {
                    spriteBatch.Draw(two, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
                if (n.Connections[2])
                {
                    spriteBatch.Draw(four, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
                if (n.Connections[3])
                {
                    spriteBatch.Draw(six, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
                if (n.Connections[4])
                {
                    spriteBatch.Draw(eight, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
                if (n.Connections[5])
                {
                    spriteBatch.Draw(ten, new Rectangle(Convert.ToInt32(n.pos.X), Convert.ToInt32(n.pos.Y), 200, 200), Color.White);
                }
            }
            spriteBatch.Draw(edge, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(playerTex, new Rectangle(350, 100, 50, 50), Color.White);
            spriteBatch.DrawString(spriteFont, tQuestion.question, new Vector2(20, 350), Color.Gold);
            spriteBatch.DrawString(spriteFont, tAnswerA.question, tAnswerA.bounding, Color.Gold);
            spriteBatch.DrawString(spriteFont, tAnswerB.question, tAnswerB.bounding, Color.Gold);
            spriteBatch.DrawString(spriteFont, tAnswerC.question, tAnswerC.bounding, Color.Gold);
            spriteBatch.DrawString(spriteFont, tAnswerD.question, tAnswerD.bounding, Color.Gold);
            spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(0, 0), Color.Gold);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
