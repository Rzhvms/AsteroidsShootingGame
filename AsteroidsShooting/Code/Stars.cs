using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidsShooting.Code;

public class Stars
{
    public static Texture2D Texture2D;
    Vector2 Position;
    Vector2 Direction;
    Color Color;

    public Stars(Vector2 position, Vector2 direction)
    {
        Position = position;
        Direction = direction;
    }

    public Stars(Vector2 direction)
    {
        Direction = direction;
        RandomSet();
    }

    public void Update()
    {
        Position += Direction;

        if (Position.X < 0)
            RandomSet();
    }

    public void RandomSet()
    {
        Position = new Vector2(ActionsInGame.GetRandomCount(ActionsInGame.Width, ActionsInGame.Width + 300),
            ActionsInGame.GetRandomCount(0, ActionsInGame.Height));

        var colorSet = ActionsInGame.GetRandomCount(0, 256);
        Color = Color.FromNonPremultiplied(colorSet, colorSet, colorSet, colorSet);
    }

    public void Draw() => ActionsInGame.SpriteBatch.Draw(Texture2D, Position, Color);
}