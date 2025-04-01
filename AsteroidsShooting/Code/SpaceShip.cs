using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidsShooting.Code;

public class SpaceShip
{
    public static Texture2D Texture2D;
    const int SpaceShipSpeed = 5;
    Color Color = Color.White;
    Vector2 Position;

    public SpaceShip(Vector2 position) => Position = position;

    public Vector2 GetFirePosition => new(Position.X + 75, Position.Y + 15);

    public void MoveUp()
    {
        if (Position.Y > 0)
            Position.Y -= SpaceShipSpeed;
    }

    public void MoveDown()
    {
        if (Position.Y < ActionsInGame.Height - Texture2D.Height)
            Position.Y += SpaceShipSpeed;
    }

    public void MoveLeft()
    {
        if (Position.X > 0)
            Position.X -= SpaceShipSpeed;
    }

    public void MoveRight()
    {
        if (Position.X < ActionsInGame.Width - Texture2D.Width)
            Position.X += SpaceShipSpeed;
    }

    public void Draw() => ActionsInGame.SpriteBatch.Draw(Texture2D, Position, Color);
}