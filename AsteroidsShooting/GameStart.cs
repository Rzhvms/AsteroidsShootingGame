﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AsteroidsShooting.Code;

namespace AsteroidsShooting;

enum StateScene
{
    SplashScreen,
    Game
}

public class GameStart : Game
{
    GraphicsDeviceManager _graphics;
    SpriteBatch _spriteBatch;
    StateScene Scene = StateScene.SplashScreen;
    KeyboardState KeyboardGetState, OldKeyboardState = Keyboard.GetState();

    public GameStart()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SplashScreen.Background = Content.Load<Texture2D>("SpaceBackground");
        SplashScreen.Font = Content.Load<SpriteFont>("SplashScreenFont");
        Stars.Texture2D = Content.Load<Texture2D>("Star");
        SpaceShip.Texture2D = Content.Load<Texture2D>("SpaceShip");
        FireShot.Texture2D = Content.Load<Texture2D>("Fire");
        Asteroid.Texture2D = Content.Load<Texture2D>("Asteroid");
        ActionsInGame.Initialize(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardGetState = Keyboard.GetState();

        switch (Scene)
        {
            case StateScene.SplashScreen:
                SplashScreen.UpdateColor();
                if (KeyCheck(Keys.Space))
                    Scene = StateScene.Game;
                break;

            case StateScene.Game:
                ActionsInGame.Update();
                if (KeyCheck(Keys.Q))
                    Scene = StateScene.SplashScreen;
                if (KeyCheck(Keys.Up) || KeyCheck(Keys.W))
                    ActionsInGame.SpaceShip.MoveUp();
                if (KeyCheck(Keys.Down) || KeyCheck(Keys.S))
                    ActionsInGame.SpaceShip.MoveDown();
                if (KeyCheck(Keys.Left) || KeyCheck(Keys.A))
                    ActionsInGame.SpaceShip.MoveLeft();
                if (KeyCheck(Keys.Right) || KeyCheck(Keys.D))
                    ActionsInGame.SpaceShip.MoveRight();
                if (KeyCheck(Keys.E) && OldKeyboardState.IsKeyUp(Keys.E))
                    ActionsInGame.SpaceShipFire();
                break;
        }

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || KeyCheck(Keys.Escape))
            Exit();

        OldKeyboardState = KeyboardGetState;

        base.Update(gameTime);
    }

    public bool KeyCheck(Keys key) => KeyboardGetState.IsKeyDown(key);

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();

        switch (Scene)
        {
            case StateScene.SplashScreen:
                SplashScreen.Draw(_spriteBatch);
                break;

            case StateScene.Game:
                ActionsInGame.Draw();
                break;
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}