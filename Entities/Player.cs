using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CoinCollectGame.Entities;

public class Player
{
    private Texture2D _texture;
    private Vector2 _position;
    private readonly float _speed;
    private readonly float _scale;

    public Rectangle Rectangle
    {
        get
        {
            int widthScale = (int)(_texture.Width * _scale);
            int heightScale = (int)(_texture.Height * _scale);
            return new Rectangle((int)_position.X, (int)_position.Y, widthScale, heightScale);
        }
    }

    public Player(Vector2 intialPosition)
    {
        _position = intialPosition;
        _speed = 200f;
        _scale = 0.1f;
    }

    public void LoadContent(Texture2D texture)
    {
        _texture = texture;
    }

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Left))
            _position.X -= _speed * deltaTime;
        if (keyboard.IsKeyDown(Keys.Right))
            _position.X += _speed * deltaTime;
        if (keyboard.IsKeyDown(Keys.Up))
            _position.Y -= _speed * deltaTime;
        if (keyboard.IsKeyDown(Keys.Down))
            _position.Y += _speed * deltaTime;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
    }
}