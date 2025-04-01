using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidsShooting.Code;

public class Asteroid
{
    public static Texture2D Texture2D;
    Color color = Color.White;
    Vector2 Position;
    Vector2 Direction;
    float Scale;
    float Rotation = 0;
    float RotationSpeed = 1;

    Vector2 Center => new(Texture2D.Width / 2, Texture2D.Height / 2);

    Point Size => new((int)(Texture2D.Width * Scale), (int)(Texture2D.Height * Scale));

    public Asteroid(Vector2 position, Vector2 direction, float scale,
        float rotation, float rotationSpeed)
    {
        Position = position;
        Direction = direction;
        Rotation = rotation;
        RotationSpeed = rotationSpeed;
        Scale = scale;
    }
        
    public bool IsIntersect(Rectangle rectangle) => rectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Size.X, Size.Y));

    public Asteroid() => RandomSet();

    public Asteroid(Vector2 direction)
    {
        Direction = direction;
        RandomSet();
    }

    public void Update()
    {
        Position += Direction;
        Rotation += RotationSpeed;
        if (Position.X < -Texture2D.Width * Scale)
            RandomSet();
    }

    public void RandomSet()
    {
        Position = new Vector2(ActionsInGame.GetRandomCount(ActionsInGame.Width, ActionsInGame.Width + 300),
            ActionsInGame.GetRandomCount(0, ActionsInGame.Height));
        Direction = new Vector2(-(float)ActionsInGame.Rand.NextDouble() * 2 + 0.1f, 0f);
        Scale = (float)ActionsInGame.Rand.NextDouble();
        RotationSpeed = (float)(ActionsInGame.Rand.NextDouble() - 0.5) / 4;

    }

    public void Draw() => ActionsInGame.SpriteBatch.Draw(Texture2D, Position, null, color,
        Rotation, Center, Scale, SpriteEffects.None, 0);
}