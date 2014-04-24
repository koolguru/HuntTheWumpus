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
        public Hexagon hex;
        public Node node;
        public NodeTest(Node node, Vector2 pos)
        {
            this.node = node;
            this.pos = pos;
            this.hex = new Hexagon(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y), 200, 200, this);
            Connections = new bool[] { false, false, false, false, false, false };
        }
        public void Update()
        {
            this.hex = new Hexagon(Convert.ToInt32(pos.X), Convert.ToInt32(pos.Y), 200, 200, this);
            if (this.pos.X > .9 * Game1.graphics.GraphicsDevice.Viewport.Width)
            {
                pos.X = Convert.ToInt32(.1 * Game1.graphics.GraphicsDevice.Viewport.Width) + 1;
            }
            else if (pos.X < .1 * Game1.graphics.GraphicsDevice.Viewport.Width)
            {
                pos.X = Convert.ToInt32(.9 * Game1.graphics.GraphicsDevice.Viewport.Width) - 1;
            }
        }
    }
    public class PlayerTest
    {
        public NodeTest room;
        public Rectangle bounding;
        public Vector2 topLeft;
        public Vector2 topRight;
        public Vector2 botLeft;
        public Vector2 botRight;
        public Vector2 top;
        public Vector2 bot;
        public PlayerTest(NodeTest room, Rectangle bounding)
        {
            this.room = room;
            this.bounding = bounding;
        }
        public void Update(List<NodeTest> nodes)
        {
            foreach (NodeTest node in Game1.nodes)
            {
                NodeTest temp = room;
                if (node != temp)
                {
                    node.hex.checkArea(new Point(375, 125), this);
                }
            }
            room.Update();
            topLeft = new Vector2(bounding.X, 100);
            topRight = new Vector2(bounding.X + 50, 100);
            botLeft = new Vector2(bounding.X, 150);
            botRight = new Vector2(bounding.X + 50, 150);
            top = new Vector2(bounding.X + 25, 100);
            bot = new Vector2(bounding.X + 25, 150);
            if (Keyboard.GetState().IsKeyDown(Keys.W) && room.hex.testUp(this))
            {
                if (room.hex.testUp(this))
                {
                    foreach (NodeTest n in nodes)
                    {
                        n.pos.Y++;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (room.hex.testRight(this))
                {
                    foreach (NodeTest n in nodes)
                    {
                        n.pos.X--;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (room.hex.testDown(this))
                {
                    foreach (NodeTest n in nodes)
                    {
                        n.pos.Y--;
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (room.hex.testLeft(this))
                {
                    foreach (NodeTest n in nodes)
                    {
                        n.pos.X++;
                    }
                }
            }
        }
    }
    public class Button
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Rectangle bounding;
        public Button(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.bounding = new Rectangle(x, y, width, height); 
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D caveTex;
        PlayerTest player;
        bool[] doors;
        Texture2D edge;
        public static List<NodeTest> nodes;
        Texture2D playerTex;
        Texture2D twelve;
        Texture2D two;
        Texture2D four;
        Texture2D six;
        Texture2D eight;
        Texture2D ten;
        Texture2D lineTest;
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
        Texture2D dummyTexture;
        int currentTurn = 0;
        SpriteFont UIFont;
        Texture2D menuTex;
        GameState gamestate;
        Engine engine;
        List<Node> engineNodes;
        Button startGame;
        bool debug;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Resize the screen.
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            //Make game FullScreen
            //graphics.ToggleFullScreen();
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
            gamestate = GameState.Menu;
            menuTex = Content.Load<Texture2D>("MenuScreen1");
            engine = new Engine();
            engineNodes = engine.genMap();
            nodes = new List<NodeTest>();
            for (int i = 0; i < 30; i++)
            {
                int x = (i % 6) * 150;
                int y = (i / 6) * 200;
                if (i % 2 == 1)
                {
                    y += 100;
                }
                nodes.Add(new NodeTest(engineNodes[i], new Vector2(x, y)));
            }
            foreach (NodeTest nt in nodes)
            {
                nt.node.room = nt;
            }
            for (int i = 0; i < 30; i++)
            {
                foreach (Node node2 in nodes[i].node.connections)
                {
                    if (nodes[i].node.room.hex.x == node2.room.hex.x && nodes[i].node.room.hex.y < node2.room.hex.y)
                    {
                        nodes[i].Connections[0] = true;
                    }
                    else if (nodes[i].node.room.hex.x > node2.room.hex.x && nodes[i].node.room.hex.y < node2.room.hex.y)
                    {
                        nodes[i].Connections[1] = true;
                    }
                    else if (nodes[i].node.room.hex.x > node2.room.hex.x && nodes[i].node.room.hex.y > node2.room.hex.y)
                    {
                        nodes[i].Connections[2] = true;
                    }
                    else if (nodes[i].node.room.hex.x == node2.room.hex.x && nodes[i].node.room.hex.y > node2.room.hex.y)
                    {
                        nodes[i].Connections[3] = true;
                    }
                    else if (nodes[i].node.room.hex.x < node2.room.hex.x && nodes[i].node.room.hex.y > node2.room.hex.y)
                    {
                        nodes[i].Connections[4] = true;
                    }
                    else if (nodes[i].node.room.hex.x < node2.room.hex.x && nodes[i].node.room.hex.y < node2.room.hex.y)
                    {
                        nodes[i].Connections[5] = true;
                    }
                }
                startGame = new Button(530, 480, 405, 150);
            }            
            playerTex = Content.Load<Texture2D>("Player");
            player = new PlayerTest(nodes[0], new Rectangle((graphics.GraphicsDevice.Viewport.Width / 2) - (playerTex.Width / 2), 100, 50, 50));
            twelve = Content.Load<Texture2D>("0");
            two = Content.Load<Texture2D>("1");
            four = Content.Load<Texture2D>("2");
            six = Content.Load<Texture2D>("3");
            eight = Content.Load<Texture2D>("4");
            ten = Content.Load<Texture2D>("5");
            lineTest = Content.Load<Texture2D>("LineTest");
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
            UIFont = Content.Load<SpriteFont>("UIFont");
            oldState = Keyboard.GetState();
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1); //Creates a dummy texture to make solid black rectangles
            dummyTexture.SetData(new Color[] { Color.Black });
            gamestate = GameState.Menu; //Starts game on menu
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
            player.room.hex.Update();
            // TODO: Add your update logic here
            ///////////////////
            // Menu Controls //
            ///////////////////
            if (gamestate == GameState.Menu)
            {
                if (startGame.bounding.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    menuTex = Content.Load<Texture2D>("MenuScreen2");
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        gamestate = GameState.MainGame;
                }
                else
                    menuTex = Content.Load<Texture2D>("MenuScreen1");
            }
            ///////////////////
            // Game Controls //
            ///////////////////
            if (gamestate == GameState.MainGame)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.R) && !oldState.IsKeyDown(Keys.R))
                {
                    UpdateTrivia();
                }
                if (Keyboard.GetState().IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
                {
                    debug = !debug;
                }
                player.room.hex.Update();
                player.Update(nodes);
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
            if (gamestate == GameState.Menu) //When game is on Menu
                spriteBatch.Draw(menuTex, new Vector2(0, 0), Color.White); //Draws Menu Background
            if (gamestate == GameState.MainGame)
            {
                //UI Draw Functions
                spriteBatch.Draw(dummyTexture, new Rectangle(0, 972, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 972), Color.Black); //Draws the Bottom Black UI Backing
                spriteBatch.DrawString(UIFont, "Turn: " + currentTurn, new Vector2(1750, 1000), Color.White); //Draws the Turn Number   
                spriteBatch.DrawString(UIFont, Convert.ToString(gameTime.TotalGameTime).Substring(3, 5), new Vector2(31, 1000), Color.White); //Draws the game timer

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
                spriteBatch.Draw(edge, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(playerTex, player.bounding, Color.White);
                spriteBatch.DrawString(spriteFont, tQuestion.question, new Vector2(20, 350), Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerA.question, tAnswerA.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerB.question, tAnswerB.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerC.question, tAnswerC.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, tAnswerD.question, tAnswerD.bounding, Color.Gold);
                spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(0, 0), Color.Gold);
                if (debug)
                {
                    foreach (Vector2 v in player.room.hex.twelve.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.two.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.four.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.six.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.eight.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                    foreach (Vector2 v in player.room.hex.ten.ints)
                    {
                        spriteBatch.Draw(lineTest, new Rectangle(Convert.ToInt32(v.X), Convert.ToInt32(v.Y), 1, 1), Color.White);
                    }
                }
            }
            if (debug)
            {
                foreach (NodeTest n in nodes)
                {
                    spriteBatch.DrawString(spriteFont, Convert.ToString(n.node.nodeNumber), n.pos, Color.Gold);
                }
                spriteBatch.DrawString(spriteFont, player.room.node.connections[0].nodeNumber + ", " + player.room.node.connections[1].nodeNumber + ", " + player.room.node.connections[2].nodeNumber, new Vector2(player.room.pos.X + 30, player.room.pos.Y), Color.Gold);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

