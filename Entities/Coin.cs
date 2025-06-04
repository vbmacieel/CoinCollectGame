using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoinCollectGame.Entities;

public class Coin
{
    private Texture2D _texture;
    private Vector2 _position;

    public Rectangle Rectangle
    {
        get { return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); }
    }

    public Coin(Vector2 initialPosition)
    {
        _position = initialPosition;
    }

    public void LoadContent(Texture2D texture)
    {
        _texture = texture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int width = 20;
        int height = 20;
        Rectangle newSize = new Rectangle((int)_position.X, (int)_position.Y, width, height);
        spriteBatch.Draw(_texture, newSize, Color.White);
    }
}