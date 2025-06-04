using System;
using System.Collections.Generic;
using CoinCollectGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinCollectGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player _player;
    private List<Coin> _coins;
    private SpriteFont _font;
    private int _points;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _player = new Player(new Vector2(100, _graphics.PreferredBackBufferHeight / 2));
        _coins = new List<Coin>();
        _points = 0;

        var random = new Random();
        for (int i = 0; i < 100; i++)
        {
            int x = random.Next(50, _graphics.PreferredBackBufferWidth - 50);
            int y = random.Next(50, _graphics.PreferredBackBufferHeight - 50);
            _coins.Add(new Coin(new Vector2(x, y)));
        }

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D playerTexture = Content.Load<Texture2D>("player");
        Texture2D coinTexture = Content.Load<Texture2D>("coin");
        _font = Content.Load<SpriteFont>("font");

        _player.LoadContent(playerTexture);
        foreach(var coin in _coins)
        {
            coin.LoadContent(coinTexture);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _player.Update(gameTime);

        for (int i = _coins.Count - 1; i >= 0; i--)
        {
            if (_player.Rectangle.Intersects(_coins[i].Rectangle))
            {
                _coins.RemoveAt(i);
                _points++;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _player.Draw(_spriteBatch);
        foreach(var coin in _coins)
        {
            coin.Draw(_spriteBatch);
        }

        _spriteBatch.DrawString(_font, $"Points: {_points}", new Vector2(10, 10), Color.White);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
