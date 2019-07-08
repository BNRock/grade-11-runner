//Author: Ben Rockman
//File name: Game1.cs
//Project name: Runner
//Creation Date: April 14, 2018
//Modification Date: April 25, 2018
//Description: Endless runner game with a racoon








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

namespace Runner
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Determines whether the game is on a menu or not
        int gameState;

        // Background variable
        Texture2D background;
        Rectangle backgroundBox;
        Rectangle backgroundTwoBox;

        //Screen dimensions
        int screenHeight;
        int screenWidth;

        //Screen speed
        int speed;

        //Run animation variables
        Texture2D runSpriteSheet;
        Rectangle runAnimation;
        Rectangle runSourceBox;

        int runFrameNum = 0;
        int runNumFrames = 12;
        int runRows = 3;
        int runColumns = 4;
        int runFrameWidth = 0;
        int runFrameHeight = 0;
        int runRepetitions = -1;
        int runRow;
        int runColumn;
        int runRepeatCount = 0;
        int runRepeatLimit = 4;

        //Jump animation variables
        Texture2D jumpSpriteSheet;
        Rectangle jumpAnimation;
        Rectangle jumpSourceBox;

        int jumpFrameNum = 0;
        int jumpNumFrames = 11;
        int jumpRows = 3;
        int jumpColumns = 4;
        int jumpFrameWidth = 0;
        int jumpFrameHeight = 0;
        int jumpRepetitions = -1;
        int jumpRow;
        int jumpColumn;
        int jumpRepeatCount = 0;
        int jumpRepeatLimit = 6;

        //Slide animation variables
        Texture2D slideSpriteSheet;
        Rectangle slideAnimation;
        Rectangle slideSourceBox;

        int slideFrameNum = 0;
        int slideNumFrames = 9;
        int slideRows = 3;
        int slideColumns = 3;
        int slideFrameWidth = 0;
        int slideFrameHeight = 0;
        int slideRepetitions = -1;
        int slideRow;
        int slideColumn;
        int slideRepeatCount = 0;
        int slideRepeatLimit = 6;

        //Zombie animation variables
        Texture2D zombieSpriteSheet;
        Rectangle zombieAnimation;
        Rectangle zombieSourceBox;

        int zombieFrameNum = 0;
        int zombieNumFrames = 10;
        int zombieRows = 2;
        int zombieColumns = 5;
        int zombieFrameWidth = 0;
        int zombieFrameHeight = 0;
        int zombieRepetitions = -1;
        int zombieRow;
        int zombieColumn;
        int zombieRepeatCount = 0;
        int zombieRepeatLimit = 6;

        //Bird animation variables
        Texture2D birdSpriteSheet;
        Rectangle birdAnimation;
        Rectangle birdSourceBox;

        int birdFrameNum = 0;
        int birdNumFrames = 4;
        int birdRows = 2;
        int birdColumns = 2;
        int birdFrameWidth = 0;
        int birdFrameHeight = 0;
        int birdRepetitions = -1;
        int birdRow;
        int birdColumn;
        int birdRepeatCount = 0;
        int birdRepeatLimit = 6;

        //Bird two animation variables
        Rectangle birdTwoAnimation;
        Rectangle birdTwoSourceBox;

        int birdTwoFrameNum = 0;
        int birdTwoNumFrames = 4;
        int birdTwoRows = 2;
        int birdTwoColumns = 2;
        int birdTwoFrameWidth = 0;
        int birdTwoFrameHeight = 0;
        int birdTwoRepetitions = -1;
        int birdTwoRow;
        int birdTwoColumn;
        int birdTwoRepeatCount = 0;
        int birdTwoRepeatLimit = 6;

        //Red coin animation variables
        Texture2D redCoinSpriteSheet;
        Rectangle redCoinAnimation;
        Rectangle redCoinSourceBox;

        int redCoinFrameNum = 0;
        int redCoinNumFrames = 9;
        int redCoinRows = 3;
        int redCoinColumns = 3;
        int redCoinFrameWidth = 0;
        int redCoinFrameHeight = 0;
        int redCoinRepetitions = -1;
        int redCoinRow;
        int redCoinColumn;
        int redCoinRepeatCount = 0;
        int redCoinRepeatLimit = 6;

        //green coin animation variables
        Texture2D greenCoinSpriteSheet;
        Rectangle greenCoinAnimation;
        Rectangle greenCoinSourceBox;

        int greenCoinFrameNum = 0;
        int greenCoinNumFrames = 9;
        int greenCoinRows = 3;
        int greenCoinColumns = 3;
        int greenCoinFrameWidth = 0;
        int greenCoinFrameHeight = 0;
        int greenCoinRepetitions = -1;
        int greenCoinRow;
        int greenCoinColumn;
        int greenCoinRepeatCount = 0;
        int greenCoinRepeatLimit = 6;

        //Purple coin animation variables
        Texture2D purpleCoinSpriteSheet;
        Rectangle purpleCoinAnimation;
        Rectangle purpleCoinSourceBox;

        int purpleCoinFrameNum = 0;
        int purpleCoinNumFrames = 9;
        int purpleCoinRows = 3;
        int purpleCoinColumns = 3;
        int purpleCoinFrameWidth = 0;
        int purpleCoinFrameHeight = 0;
        int purpleCoinRepetitions = -1;
        int purpleCoinRow;
        int purpleCoinColumn;
        int purpleCoinRepeatCount = 0;
        int purpleCoinRepeatLimit = 6;

        //Spikes variables
        Texture2D spikes;
        Rectangle spikesBox;

        //Width and height of spikes
        int spikesWidth;
        int spikesHeight;

        int gravity = 3; // Gravity of the world
        int originalGravity = 3; // Holder variable for gravity
        bool hasJumped = false; //Determine if player has jumped
        int jumpSpeed = 32; //Jump power

        //Makes certain animations visible or invisible
        int jumpVisible = 0;
        int runVisible = 1;
        int slideVisible = 0;

        //Check to see if player is sliding
        bool hasSlided = false;

        //Different fonts
        SpriteFont mainFont;
        SpriteFont secondsFont;
        SpriteFont titleFont;

        //Different text locations
        Vector2 scoreText;
        Vector2 timeText;
        Vector2 secondsText;
        Vector2 highScoreText;
        Vector2 scoreNumberText;
        Vector2 highScoreNumberText;
        Vector2 titleText;
        Vector2 scoreNotif;

        //Player score
        int score;

        //Player high score
        int highScore;

        //Time and desired time variables
        int gameTimeElapsed;
        int speedUpTime;
        int speedUpInterval;
        int respawnTime;
        int respawnInterval;
        int redCoinRespawn;
        int redCoinInterval;
        int scoreTime;
        int scoreInterval;

        //Determines whether or not player has collided with enemy
        bool zombieCollision;
        bool zombieKill;
        bool birdCollision;
        bool spikesCollision;

        //Makes coins visible or invisible
        int redCoinVisible = 1;
        int purpleCoinVisible = 1;
        int greenCoinVisible = 1;

        //Determines whether player collides with coins or not
        bool redCoinCollision;
        bool greenCoinCollision;
        bool purpleCoinCollision;

        //Random Y position for coins
        Random coinY;

        //Bonus coins array
        int [] bonusCoins;

        //Values for coins
        int redCoinValue;
        int greenCoinValue;
        int purpleCoinValue;

        //Total coin points
        int coinTotal;
        
        //Button variables
        Texture2D playGame;
        Texture2D quit;
        Rectangle playGameBox;
        Rectangle quitBox;

        
        //Mouse state
        MouseState curMouse;

        //Mouse location
        Point mousePosition;

        //Score sentences
        string gotHighScore;
        string noHighScore;

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

            base.Initialize();
            IsMouseVisible = true;
            this.graphics.PreferredBackBufferHeight = screenHeight;
            this.graphics.PreferredBackBufferWidth = screenWidth;
            graphics.ApplyChanges();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Screen dimensions
            screenHeight = 768;
            screenWidth = 1350;

            //Initial game state
            gameState = 2;

            //Loading background
            background = Content.Load < Texture2D > ("Images/Background/darkBackground");
            backgroundBox = new Rectangle(0, 0, screenWidth, screenHeight);
            backgroundTwoBox = new Rectangle(screenWidth, 0, screenWidth, screenHeight);

            //Intial speed
            speed = 7;

            //Loading run animation
            runSpriteSheet = Content.Load<Texture2D>("Images/Sprites/runSpritesheet");
            runFrameWidth = runSpriteSheet.Width / runColumns;
            runFrameHeight = runSpriteSheet.Height / runRows;
            runAnimation = new Rectangle(200, 450, runFrameWidth, runFrameHeight);
            runSourceBox = new Rectangle(200, 450, runFrameWidth, runFrameHeight);

            //Loading jump animation
            jumpSpriteSheet = Content.Load<Texture2D>("Images/Sprites/jumpSpritesheet");
            jumpFrameWidth = jumpSpriteSheet.Width / jumpColumns;
            jumpFrameHeight = jumpSpriteSheet.Height / jumpRows;
            jumpAnimation = new Rectangle(200, 450, jumpFrameWidth, jumpFrameHeight);
            jumpSourceBox = new Rectangle(200, 450, jumpFrameWidth, jumpFrameHeight);

            //Loading slide animation
            slideSpriteSheet = Content.Load<Texture2D>("Images/Sprites/spritesheet");
            slideFrameWidth = slideSpriteSheet.Width / slideColumns;
            slideFrameHeight = slideSpriteSheet.Height / slideRows;
            slideAnimation = new Rectangle(200, 450, slideFrameWidth, slideFrameHeight);
            slideSourceBox = new Rectangle(200, 450, slideFrameWidth, slideFrameHeight);

            //Loading zombie animation
            zombieSpriteSheet = Content.Load<Texture2D>("Images/Sprites/zombieSpritesheet");
            zombieFrameWidth = zombieSpriteSheet.Width / zombieColumns;
            zombieFrameHeight = zombieSpriteSheet.Height / zombieRows;
            zombieAnimation = new Rectangle(1200, 475, zombieFrameWidth, zombieFrameHeight);
            zombieSourceBox = new Rectangle(1200, 475, zombieFrameWidth, zombieFrameHeight);

            //Loading bird animation
            birdSpriteSheet = Content.Load<Texture2D>("Images/Sprites/birdSpritesheet");        
            birdFrameWidth = birdSpriteSheet.Width / birdColumns;
            birdFrameHeight = birdSpriteSheet.Height / birdRows;
            birdAnimation = new Rectangle(3900, 290, birdFrameWidth, birdFrameHeight);
            birdSourceBox = new Rectangle(3900, 290, birdFrameWidth, birdFrameHeight);

            //Loading bird two animation
            birdTwoFrameWidth = birdSpriteSheet.Width / birdTwoColumns;
            birdTwoFrameHeight = birdSpriteSheet.Height / birdTwoRows;
            birdTwoAnimation = new Rectangle(3900, 75, birdTwoFrameWidth, birdTwoFrameHeight);
            birdTwoSourceBox = new Rectangle(3900, 75, birdTwoFrameWidth, birdTwoFrameHeight);

            //Loading red coin animation
            redCoinSpriteSheet = Content.Load<Texture2D>("Images/Sprites/redCoinSpritesheet");
            redCoinFrameWidth = redCoinSpriteSheet.Width / redCoinColumns;
            redCoinFrameHeight = redCoinSpriteSheet.Height / redCoinRows;
            redCoinAnimation = new Rectangle(-120, 450, redCoinFrameWidth, redCoinFrameHeight);
            redCoinSourceBox = new Rectangle(-120, 450, redCoinFrameWidth, redCoinFrameHeight);

            //Loading green coin animation
            greenCoinSpriteSheet = Content.Load<Texture2D>("Images/Sprites/greenCoinSpritesheet");
            greenCoinFrameWidth = greenCoinSpriteSheet.Width / greenCoinColumns;
            greenCoinFrameHeight = greenCoinSpriteSheet.Height / greenCoinRows;
            greenCoinAnimation = new Rectangle(1000, 450, greenCoinFrameWidth, greenCoinFrameHeight);
            greenCoinSourceBox = new Rectangle(1000, 450, greenCoinFrameWidth, greenCoinFrameHeight);

            //Loading purple coin animation
            purpleCoinSpriteSheet = Content.Load<Texture2D>("Images/Sprites/purpleCoinSpritesheet");
            purpleCoinFrameWidth = purpleCoinSpriteSheet.Width / purpleCoinColumns;
            purpleCoinFrameHeight = purpleCoinSpriteSheet.Height / purpleCoinRows;
            purpleCoinAnimation = new Rectangle(800, 450, purpleCoinFrameWidth, purpleCoinFrameHeight);
            purpleCoinSourceBox = new Rectangle(800, 450, purpleCoinFrameWidth, purpleCoinFrameHeight);

            //Loading spikes animation
            spikes = Content.Load<Texture2D>("Images/Sprites/spikes");
            spikesBox = new Rectangle(2300, 500, spikesWidth, spikesHeight);
            spikesWidth = 190;
            spikesHeight = 150;

            //Loading fonts
            mainFont = Content.Load<SpriteFont>("Fonts/mainFont");
            secondsFont = Content.Load<SpriteFont>("Fonts/secondsFont");
            titleFont = Content.Load<SpriteFont>("Fonts/titleFont");

            //Loading text positions
            timeText = new Vector2(10, 10);
            secondsText = new Vector2(120, 10);
            scoreText = new Vector2(300, 10);
            titleText = new Vector2(150, 100);
            scoreNotif = new Vector2(300, 300);

            //Loading time variables
            speedUpInterval = 20000;
            respawnInterval = 10000;
            scoreNumberText = new Vector2(450, 10);
            redCoinInterval = 6000;
            highScoreText = new Vector2(800, 10);
            highScoreNumberText = new Vector2(1050, 10);
            scoreInterval = 1000;

            //Loading random coin Y position
            coinY = new Random();

            //Loading coin values
            redCoinValue = 10;
            greenCoinValue = 15;
            purpleCoinValue = 25;
            
            //Initial coin points total
            coinTotal = 0;

            //Loading coins array
            bonusCoins = new int[] {0, 0, 0};

            //Loading buttons
            playGame = Content.Load<Texture2D>("Images/Buttons/playButton");
            quit = Content.Load<Texture2D>("Images/Buttons/quitButton");                     
            playGameBox = new Rectangle(50, 400, playGame.Width, playGame.Height);
            quitBox = new Rectangle(800, 400, quit.Width, quit.Height);
            
            

            // TODO: use this.Content to load your game content here
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

            //Setting score sentences
            gotHighScore = "You got the high score! Your score is " + score;
            noHighScore = "You didn't get the high score. \n Your score was " + score + " and the high score was " + highScore;

            //Creating a point to determine mouse location
            curMouse = Mouse.GetState();
            mousePosition = new Point(curMouse.X, curMouse.Y);

         
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //If the game state is on a menu or not
            if(gameState == 0 || gameState == 2)
            {
                if(playGameBox.Contains(mousePosition) && curMouse.LeftButton == ButtonState.Pressed)
                {
                    PlayGame();
                }
                else if(quitBox.Contains(mousePosition) && curMouse.LeftButton == ButtonState.Pressed)
                {
                    this.Exit();
                }
            } 

            //If the game is being played
            if(gameState == 1)
             { 
                //Updating high score
                if (score >= highScore)
                {
                    highScore = score;
                }

                //Updating times to current game time
                gameTimeElapsed += gameTime.ElapsedGameTime.Milliseconds;
                speedUpTime += gameTime.ElapsedGameTime.Milliseconds;
                respawnTime += gameTime.ElapsedGameTime.Milliseconds;
                redCoinRespawn += gameTime.ElapsedGameTime.Milliseconds;
                scoreTime += gameTime.ElapsedGameTime.Milliseconds;

                //Scrolls everything that needs to be scrolled
                Scrolling();

                //Speeding up every 20 seconds
                if (speedUpTime >= speedUpInterval && speed <= 21)
                {
                    SpeedUp();
                }

                //Respawning sprites
                if (respawnTime >= respawnInterval)
                {
                    Respawn();
                }

                //Scrolling background
                if (backgroundBox.X < -screenWidth)
                {
                    backgroundBox.X += 2 * screenWidth;
                }
                if (backgroundTwoBox.X < -screenWidth)
                {
                    backgroundTwoBox.X += 2 * screenWidth;
                }

                //Respawning red coin
                if (redCoinRespawn >= redCoinInterval)
                {
                    RedCoinRespawn();
                }

                //Calling animation functions
                if (runRepetitions != 0)
                {
                    RunAnimation();
                }

                if (jumpRepetitions != 0)
                {
                    JumpAnimation();
                }

                if (zombieRepetitions != 0)
                {
                    ZombieAnimation();
                }

                if (slideRepetitions != 0)
                {
                    SlideAnimation();
                }

                if (birdRepetitions != 0)
                {
                    BirdAnimation();
                }

                if (birdTwoRepetitions != 0)
                {
                    BirdTwoAnimation();
                }

                if(redCoinRepetitions != 0)
                {
                    RedCoinAnimation();
                }
                if (greenCoinRepetitions != 0)
                {
                    GreenCoinAnimation();
                }
                if (purpleCoinRepetitions != 0)
                {
                    PurpleCoinAnimation();
                }

                //Check if player pressed spacebar
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasSlided == false)
                {
                    hasJumped = true;
                }

                if (hasJumped == true)
                {
                    Jump();
                }

                //Check if player pressed down arrow
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && hasJumped == false)
                {
                    IsSliding();
                }
                else
                {
                    StoppedSliding();
                }

                //Check for run-zombie collision
                if (runAnimation.Right < zombieAnimation.Left + 50 || runAnimation.Left > zombieAnimation.Right - 110)
                {
                    zombieCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        zombieCollision = true;
                    }
                }

                //Check for run-bird collision
                if (RecCollision(runSourceBox, birdSourceBox) == false)
                {
                    birdCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        birdCollision = true;
                    }
                }

                //Check for jump-bird collision
                if (jumpAnimation.Right < birdAnimation.Left + 75 || jumpAnimation.Left > birdAnimation.Right - 200
                    || jumpAnimation.Right < birdTwoAnimation.Left + 75 || jumpAnimation.Left > birdTwoAnimation.Right - 200)
                {
                    birdCollision = false;
                }
                else
                {
                    if (jumpVisible == 1)
                    {
                        birdCollision = true;
                    }
                }

                //if collision, call collision
                if (birdCollision == true)
                {
                    Collision();
                }

                //Check for run-spike collision
                if (RecCollision(runSourceBox, spikesBox) == false)
                {
                    spikesCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        spikesCollision = true;
                    }
                }

                //Check for jump-spike collision
                if (jumpAnimation.Bottom < spikesBox.Top + 90 ||
                    jumpAnimation.Right < spikesBox.Left + 75 ||
                    jumpAnimation.Left > spikesBox.Right - 210)
                {
                    spikesCollision = false;
                }
                else
                {
                    spikesCollision = true;
                }

                //Check for slde-spike collision
                if (slideAnimation.Right < spikesBox.Left + 75 || slideAnimation.Left > spikesBox.Right - 75)
                {
                    spikesCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        spikesCollision = true;
                    }
                }

                if (spikesCollision == true)
                {
                    Collision();
                }

                if (slideAnimation.Right < zombieAnimation.Left + 100 || slideAnimation.Left > zombieAnimation.Right - 75)
                {
                    zombieCollision = false;
                }
                else
                {
                    if (slideVisible == 1)
                    {
                        zombieCollision = true;
                    }
                }

                

                if (jumpAnimation.Bottom < zombieAnimation.Top + 50 ||
                    jumpAnimation.Right < zombieAnimation.Left + 75 ||
                    jumpAnimation.Left > zombieAnimation.Right - 175)
                {
                    zombieKill = false;
                }
                else if(jumpAnimation.Bottom > zombieAnimation.Top + 100)
                {
                    zombieCollision = true;
                }
                else
                {
                    if (jumpVisible == 1 )
                    {
                        zombieKill = true;
                    }
                }
                if (zombieKill == true)
                {
                    ZombieKill();
                }

                if (zombieCollision == true)
                {
                    Collision();
                }

                if ((jumpAnimation.Bottom < redCoinAnimation.Top + 120 ||
                    jumpAnimation.Top > redCoinAnimation.Bottom - 120||
                    jumpAnimation.Right < redCoinAnimation.Left + 100||
                    jumpAnimation.Left > redCoinAnimation.Right - 100))
                {
                    redCoinCollision = false;
                }
                else
                {
                    if ((jumpVisible == 1))
                    {
                        RedCoinCollision();
                    }
                }

                if (runAnimation.Right < redCoinAnimation.Left + 50 ||
                    runAnimation.Left > redCoinAnimation.Right - 100 ||
                    runAnimation.Top > redCoinAnimation.Bottom - 50)
                {
                    redCoinCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        redCoinCollision = true;
                    }
                }
                if (slideAnimation.Right < redCoinAnimation.Left + 100||
                    slideAnimation.Left > redCoinAnimation.Right - 100 ||
                    slideAnimation.Top > redCoinAnimation.Bottom - 75)
                {
                    redCoinCollision = false;
                }
                else
                {
                    if (slideVisible == 1)
                    {
                        redCoinCollision = true;
                    }
                }

                if (redCoinCollision == true)
                {
                    RedCoinCollision();
                }

                if ((jumpAnimation.Bottom < greenCoinAnimation.Top + 120 ||
                    jumpAnimation.Top > greenCoinAnimation.Bottom - 120 ||
                    jumpAnimation.Right < greenCoinAnimation.Left + 100 ||
                    jumpAnimation.Left > greenCoinAnimation.Right - 100))
                {
                    greenCoinCollision = false;
                }
                else
                {
                    if (jumpVisible == 1)
                    {
                        GreenCoinCollision();
                    }
                }

                if (runAnimation.Right < greenCoinAnimation.Left + 50 
                    || runAnimation.Left > greenCoinAnimation.Right - 100 ||
                    runAnimation.Top > greenCoinAnimation.Bottom - 50)
                {
                    greenCoinCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        greenCoinCollision = true;
                    }
                }
                if (slideAnimation.Right < greenCoinAnimation.Left + 50 
                    || slideAnimation.Left > greenCoinAnimation.Right - 100 ||
                    slideAnimation.Top > greenCoinAnimation.Bottom - 75)
                {
                    greenCoinCollision = false;
                }
                else
                {
                    if (slideVisible == 1)
                    {
                        greenCoinCollision = true;
                    }
                }

                if (greenCoinCollision == true)
                {
                    GreenCoinCollision();
                }

                if ((jumpAnimation.Bottom < purpleCoinAnimation.Top + 120 ||
                    jumpAnimation.Top > purpleCoinAnimation.Bottom - 120 ||
                    jumpAnimation.Right < purpleCoinAnimation.Left + 100 ||
                    jumpAnimation.Left > purpleCoinAnimation.Right - 100))
                {
                    purpleCoinCollision = false;
                }
                else
                {
                    if (jumpVisible == 1)
                    {
                        PurpleCoinCollision();
                    }
                }

            if (runAnimation.Right < purpleCoinAnimation.Left + 50 
                || runAnimation.Left > purpleCoinAnimation.Right - 100 ||
                    runAnimation.Top > purpleCoinAnimation.Bottom - 50)
                {
                    purpleCoinCollision = false;
                }
                else
                {
                    if (runVisible == 1)
                    {
                        purpleCoinCollision = true;
                    }
                }
                if (slideAnimation.Right < purpleCoinAnimation.Left + 50 
                    || slideAnimation.Left > purpleCoinAnimation.Right - 100 ||
                    slideAnimation.Top > purpleCoinAnimation.Bottom - 75)
                {
                    purpleCoinCollision = false;
                }
                else
                {
                    if (slideVisible == 1)
                    {
                        purpleCoinCollision = true;
                    }
                }

                if (purpleCoinCollision == true)
                {
                    PurpleCoinCollision();
                }

                //Update score
                if (scoreTime > scoreInterval)
                {
                    ScoreTimeUpdate();
                }

                //Update score
                if (birdAnimation.Right < 0 && birdAnimation.Right > -7)
                {
                    OffScreenPoints();
                }

                if (spikesBox.Right < 0 && spikesBox.Right > -7)
                {
                    OffScreenPoints();
                }

                if (zombieAnimation.Right < 0 && zombieAnimation.Right > -7)
                {
                    OffScreenPoints();
                }

            
            }
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

            
            spriteBatch.Draw(background, backgroundBox, Color.White);
            spriteBatch.Draw(background, backgroundTwoBox, Color.White);
            //Draw if menu
            if(gameState == 0)
            {
                spriteBatch.Draw(playGame, playGameBox, Color.White);
                spriteBatch.Draw(quit, quitBox, Color.White);
                spriteBatch.DrawString(titleFont, "Racoon Rampage", titleText, Color.Red);
                if (score < highScore)
                {
                    spriteBatch.DrawString(secondsFont, noHighScore, scoreNotif, Color.Red);
                }
                else if (score >= highScore)
                {
                    spriteBatch.DrawString(secondsFont, gotHighScore, scoreNotif, Color.Red);
                }
            }
            //Draw if menu
            if(gameState == 2)
            {
                spriteBatch.Draw(playGame, playGameBox, Color.White);
                spriteBatch.Draw(quit, quitBox, Color.White);
                spriteBatch.DrawString(titleFont, "Racoon Rampage", titleText, Color.Red);               
            }

            //Draw if playing game
            if (gameState == 1)
            {
                spriteBatch.Draw(runSpriteSheet, runAnimation, runSourceBox, Color.White * runVisible);
                spriteBatch.Draw(jumpSpriteSheet, jumpAnimation, jumpSourceBox, Color.White * jumpVisible);
                spriteBatch.Draw(slideSpriteSheet, slideAnimation, slideSourceBox, Color.White * slideVisible);

                spriteBatch.Draw(zombieSpriteSheet, zombieAnimation, zombieSourceBox, Color.White);
                spriteBatch.Draw(birdSpriteSheet, birdAnimation, birdSourceBox, Color.White);
                spriteBatch.Draw(birdSpriteSheet, birdTwoAnimation, birdTwoSourceBox, Color.White);

                spriteBatch.Draw(redCoinSpriteSheet, redCoinAnimation, redCoinSourceBox, Color.White * redCoinVisible);
                spriteBatch.Draw(greenCoinSpriteSheet, greenCoinAnimation, greenCoinSourceBox, Color.White * greenCoinVisible);
                spriteBatch.Draw(purpleCoinSpriteSheet, purpleCoinAnimation, purpleCoinSourceBox, Color.White * purpleCoinVisible);

                spriteBatch.Draw(spikes, spikesBox, Color.White);
                spriteBatch.DrawString(mainFont, "Time: ", timeText, Color.Red);
                spriteBatch.DrawString(secondsFont, Convert.ToString(gameTimeElapsed / 1000), secondsText, Color.Red);

                spriteBatch.DrawString(mainFont, "Score: ", scoreText, Color.Red);
                spriteBatch.DrawString(secondsFont, Convert.ToString(score), scoreNumberText, Color.Red);

                spriteBatch.DrawString(mainFont, "High Score: ", highScoreText, Color.Red);
                spriteBatch.DrawString(secondsFont, Convert.ToString(highScore), highScoreNumberText, Color.Red);
                
            }
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        //Speeds up screen
        private void SpeedUp()
        {
            speedUpTime = 0;
            speed += 1;
            purpleCoinAnimation.X = 1200;
            purpleCoinSourceBox.X = 1200;
            purpleCoinAnimation.Y = coinY.Next(200, 500);
            purpleCoinSourceBox.Y = coinY.Next(200, 500);
            purpleCoinVisible = 1;
        }

        private void Respawn()
        {
            respawnTime = 0;

            zombieSourceBox.X = 1400;
            zombieAnimation.X = 1400;

            birdSourceBox.X = 3700;
            birdAnimation.X = 3700;

            birdTwoSourceBox.X = 3700;
            birdTwoAnimation.X = 3700;

            spikesBox.X = 2200;

            greenCoinAnimation.X = 1700;
            greenCoinSourceBox.X = 1700;
            greenCoinAnimation.Y = coinY.Next(200, 500);
            greenCoinAnimation.Y = coinY.Next(200, 500);
            greenCoinVisible = 1;



        }

        private void Collision()
        {
            score += coinTotal;
            if (score >= highScore)
            {
                highScore = score;
            }
            gameState = 0;
        }

        private void ZombieKill()
        {
            score += 3;
            zombieAnimation.X = -150;
        }

        private void RunAnimation()
        {
            runRow = runFrameNum / runColumns;
            runColumn = runFrameNum % runColumns;

            runSourceBox.X = runColumn * runFrameWidth;
            runSourceBox.Y = runRow * runFrameHeight;

            runRepeatCount++;
            if (runRepeatCount == runRepeatLimit)
            {
                runFrameNum = (runFrameNum + 1) % runNumFrames;
                runRepeatCount = 0;
            }
        }

        private void JumpAnimation()
        {
            jumpRow = jumpFrameNum / jumpColumns;
            jumpColumn = jumpFrameNum % jumpColumns;

            jumpSourceBox.X = jumpColumn * jumpFrameWidth;
            jumpSourceBox.Y = jumpRow * jumpFrameHeight;

            jumpRepeatCount++;
            if (jumpRepeatCount == jumpRepeatLimit)
            {
                jumpFrameNum = (jumpFrameNum + 1) % jumpNumFrames;
                jumpRepeatCount = 0;
            }
        }

        private void SlideAnimation()
        {
            slideRow = slideFrameNum / slideColumns;
            slideColumn = slideFrameNum % slideColumns;

            slideSourceBox.X = slideColumn * slideFrameWidth;
            slideSourceBox.Y = slideRow * slideFrameHeight;

            slideRepeatCount++;
            if (slideRepeatCount == slideRepeatLimit)
            {
                slideFrameNum = (slideFrameNum + 1) % slideNumFrames;
                slideRepeatCount = 0;
            }
        }

        private void ZombieAnimation()
        {
            zombieRow = zombieFrameNum / zombieColumns;
            zombieColumn = zombieFrameNum % zombieColumns;

            zombieSourceBox.X = zombieColumn * zombieFrameWidth;
            zombieSourceBox.Y = zombieRow * zombieFrameHeight;

            zombieRepeatCount++;
            if (zombieRepeatCount == zombieRepeatLimit)
            {
                zombieFrameNum = (zombieFrameNum + 1) % zombieNumFrames;
                zombieRepeatCount = 0;
            }
        }

        private void BirdAnimation()
        {
            birdRow = birdFrameNum / birdColumns;
            birdColumn = birdFrameNum % birdColumns;

            birdSourceBox.X = birdColumn * birdFrameWidth;
            birdSourceBox.Y = birdRow * birdFrameHeight;

            birdRepeatCount++;
            if (birdRepeatCount == birdRepeatLimit)
            {
                birdFrameNum = (birdFrameNum + 1) % birdNumFrames;
                birdRepeatCount = 0;
            }
        }

        private void BirdTwoAnimation()
        {
            birdTwoRow = birdTwoFrameNum / birdTwoColumns;
            birdTwoColumn = birdTwoFrameNum % birdTwoColumns;

            birdTwoSourceBox.X = birdTwoColumn * birdTwoFrameWidth;
            birdTwoSourceBox.Y = birdTwoRow * birdTwoFrameHeight;

            birdTwoRepeatCount++;
            if (birdTwoRepeatCount == birdTwoRepeatLimit)
            {
                birdTwoFrameNum = (birdTwoFrameNum + 1) % birdTwoNumFrames;
                birdTwoRepeatCount = 0;
            }
        }

        private void Jump()
        {
            gravity += 1;
            runVisible = 0;
            jumpVisible = 1;

            jumpAnimation.Y -= jumpSpeed;
            jumpAnimation.Y += gravity;
            jumpSourceBox.Y -= jumpSpeed;
            jumpSourceBox.Y += gravity;
            if (jumpAnimation.Y > 450)
            {
                jumpVisible = 0;
                jumpAnimation.Y = 450;
                jumpSourceBox.Y = 450;
                hasJumped = false;
                gravity = originalGravity;
                runVisible = 1;
            }
        }

        private void IsSliding()
        {
            hasSlided = true;
            runVisible = 0;
            slideVisible = 1;
        }

        private void StoppedSliding()
        {
            slideVisible = 0;
            if (hasJumped == false)
            {
                hasSlided = false;
                runVisible = 1;
            }
        }

        private void RedCoinAnimation()
        {
            redCoinRow = redCoinFrameNum / redCoinColumns;
            redCoinColumn = redCoinFrameNum % redCoinColumns;

            redCoinSourceBox.X = redCoinColumn * redCoinFrameWidth;
            redCoinSourceBox.Y = redCoinRow * redCoinFrameHeight;

            redCoinRepeatCount++;
            if (redCoinRepeatCount == redCoinRepeatLimit)
            {
                redCoinFrameNum = (redCoinFrameNum + 1) % redCoinNumFrames;
                redCoinRepeatCount = 0;
            }
        }

        private void GreenCoinAnimation()
        {
            greenCoinRow = greenCoinFrameNum / greenCoinColumns;
            greenCoinColumn = greenCoinFrameNum % greenCoinColumns;

            greenCoinSourceBox.X = greenCoinColumn * greenCoinFrameWidth;
            greenCoinSourceBox.Y = greenCoinRow * greenCoinFrameHeight;

            greenCoinRepeatCount++;
            if (greenCoinRepeatCount == greenCoinRepeatLimit)
            {
                greenCoinFrameNum = (greenCoinFrameNum + 1) % greenCoinNumFrames;
                greenCoinRepeatCount = 0;
            }
        }

        private void PurpleCoinAnimation()
        {
            purpleCoinRow = purpleCoinFrameNum / purpleCoinColumns;
            purpleCoinColumn = purpleCoinFrameNum % purpleCoinColumns;

            purpleCoinSourceBox.X = purpleCoinColumn * purpleCoinFrameWidth;
            purpleCoinSourceBox.Y = purpleCoinRow * purpleCoinFrameHeight;

            purpleCoinRepeatCount++;
            if (purpleCoinRepeatCount == purpleCoinRepeatLimit)
            {
                purpleCoinFrameNum = (purpleCoinFrameNum + 1) % purpleCoinNumFrames;
                purpleCoinRepeatCount = 0;
            }
        }

        private void RedCoinCollision()
        {
            if (redCoinVisible == 1)
            {

                bonusCoins[0] += 1;
                coinTotal += bonusCoins[0] * redCoinValue;
                
            }
            redCoinVisible = 0;
        }

        private void GreenCoinCollision()
        {
            if (greenCoinVisible == 1)
            {

                bonusCoins[1] += 1;
                coinTotal += bonusCoins[1] * greenCoinValue;
            }
            greenCoinVisible = 0;
        }

        private void PurpleCoinCollision()
        {
            if (purpleCoinVisible == 1)
            {

                bonusCoins[2] += 1;
                coinTotal += bonusCoins[2] * purpleCoinValue;

           }
            purpleCoinVisible = 0; 
        }

        private void RedCoinRespawn()
        {
            redCoinRespawn = 0;
            redCoinAnimation.X = 1500;
            redCoinSourceBox.X = 1500;
            redCoinAnimation.Y = coinY.Next(200, 500);
            redCoinSourceBox.Y = coinY.Next(200, 500);
            redCoinVisible = 1;
        }

        private void ScoreTimeUpdate()
        {
            scoreTime = 0;
            score += 1;
        }

        private void OffScreenPoints()
        {
            score += 3;
        }
        
        private void PlayGame()
        {
            score = 0;
            gameState = 1;
            gameTimeElapsed = 0;
            speedUpTime = 0;
            respawnTime = 0;
            redCoinRespawn = 0;
            scoreTime = 0;

            backgroundBox = new Rectangle(0, 0, screenWidth, screenHeight);
            backgroundTwoBox = new Rectangle(screenWidth, 0, screenWidth, screenHeight);

            speed = 7;


            runAnimation = new Rectangle(200, 450, runFrameWidth, runFrameHeight);
            runSourceBox = new Rectangle(200, 450, runFrameWidth, runFrameHeight);

            

            jumpAnimation = new Rectangle(200, 450, jumpFrameWidth, jumpFrameHeight);
            jumpSourceBox = new Rectangle(200, 450, jumpFrameWidth, jumpFrameHeight);

           

            slideAnimation = new Rectangle(200, 450, slideFrameWidth, slideFrameHeight);
            slideSourceBox = new Rectangle(200, 450, slideFrameWidth, slideFrameHeight);


           

            zombieAnimation = new Rectangle(1200, 475, zombieFrameWidth, zombieFrameHeight);
            zombieSourceBox = new Rectangle(1200, 475, zombieFrameWidth, zombieFrameHeight);

            

            birdAnimation = new Rectangle(3900, 290, birdFrameWidth, birdFrameHeight);
            birdSourceBox = new Rectangle(3900, 290, birdFrameWidth, birdFrameHeight);

            

            birdTwoAnimation = new Rectangle(3900, 75, birdTwoFrameWidth, birdTwoFrameHeight);
            birdTwoSourceBox = new Rectangle(3900, 75, birdTwoFrameWidth, birdTwoFrameHeight);

            
            redCoinAnimation = new Rectangle(-120, 450, redCoinFrameWidth, redCoinFrameHeight);
            redCoinSourceBox = new Rectangle(-120, 450, redCoinFrameWidth, redCoinFrameHeight);

            
            greenCoinAnimation = new Rectangle(1000, 450, greenCoinFrameWidth, greenCoinFrameHeight);
            greenCoinSourceBox = new Rectangle(1000, 450, greenCoinFrameWidth, greenCoinFrameHeight);

            
            purpleCoinAnimation = new Rectangle(800, 450, purpleCoinFrameWidth, purpleCoinFrameHeight);
            purpleCoinSourceBox = new Rectangle(800, 450, purpleCoinFrameWidth, purpleCoinFrameHeight);

            spikesBox = new Rectangle(2300, 500, spikesWidth, spikesHeight);

            coinTotal = 0;
            redCoinVisible = 1;
            greenCoinVisible = 1;
            purpleCoinVisible = 1;
            bonusCoins[0] = 0;
            bonusCoins[1] = 0;
            bonusCoins[2] = 0;
            
        }

        /// <summary>
        /// Check if objects are colliding
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns> bool of if objects are colliding</returns>
        private bool RecCollision(Rectangle r1, Rectangle r2)
        {
            bool collision;

            if(r1.Bottom < r2.Top || r1.Right < r2.Left || r1.Left > r2.Right || r1.Top > r2.Bottom)
            {
                collision = false;
            }
            else
            {
                collision = true;
            }

            return collision;
        }


        private void Scrolling()
        {
            backgroundBox.X -= speed;
            backgroundTwoBox.X -= speed;
            zombieAnimation.X -= speed;
            zombieSourceBox.X -= speed;
            birdAnimation.X -= speed;
            birdSourceBox.X -= speed;
            birdTwoAnimation.X -= speed;
            birdTwoSourceBox.X -= speed;
            spikesBox.X -= speed;
            redCoinAnimation.X -= speed;
            redCoinSourceBox.X -= speed;
            greenCoinAnimation.X -= speed;
            greenCoinSourceBox.X -= speed;
            purpleCoinAnimation.X -= speed;
            purpleCoinSourceBox.X -= speed;
        }
    }


}
