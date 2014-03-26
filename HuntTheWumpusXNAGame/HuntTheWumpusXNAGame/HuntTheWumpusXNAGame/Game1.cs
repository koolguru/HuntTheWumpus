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
        public NodeTest(bool[] Connections)
        {
            this.Connections = Connections;
        }
    }
    public class PlayerTest
    {
        public NodeTest room;
        public PlayerTest(NodeTest room)
        {
            this.room = room;
        }
    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D caveTex;
        Texture2D doorVert;
        Texture2D door30;
        Texture2D door60;
        PlayerTest player;
        NodeTest room;
        bool[] doors;

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
            doors = new bool[] { true, true, true, false, false, false };
            room = new NodeTest(doors);
            player = new PlayerTest(room);
            //Load Content
            caveTex = Content.Load<Texture2D>("Cave");
            doorVert = Content.Load<Texture2D>("Door");
            door30 = Content.Load<Texture2D>("Door30");
            door60 = Content.Load<Texture2D>("Door60");
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(caveTex, new Rectangle(300, 50, 200, 200), Color.White);
            if (player.room.Connections[0])
            {
                spriteBatch.Draw(doorVert, new Rectangle(375, 0, 50, 50), Color.White);
            }
            if (player.room.Connections[1])
            {
                spriteBatch.Draw(door60, new Rectangle(460, 50, 70, 70), Color.White);
            }
            if (player.room.Connections[2])
            {
                spriteBatch.Draw(door30, new Rectangle(460, 180, 70, 70), Color.White);
            }
            if (player.room.Connections[3])
            {
                spriteBatch.Draw(doorVert, new Rectangle(375, 250, 50, 50), Color.White);
            }
            if (player.room.Connections[4])
            {
                spriteBatch.Draw(door60, new Rectangle(270, 180, 70, 70), Color.White);
            }
            if (player.room.Connections[5])
            {
                spriteBatch.Draw(door30, new Rectangle(270, 50, 70, 70), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
