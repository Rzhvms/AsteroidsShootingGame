using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidsShooting.Code;

public class FireShot
{
    public static Texture2D Texture2D;
    const int FireSpeed = 7;
    Color Color = Color.White;
    Vector2 Position;
    Vector2 Direction;

    public FireShot(Vector2 position)
    {
        Position = position;
        Direction = new Vector2(FireSpeed, 0);
    }

    public Asteroid Crash(List<Asteroid> asteroidsList)
    {
        foreach (var asteroid in asteroidsList)
            if (asteroid.IsIntersect(new Rectangle((int)Position.X, (int)Position.Y, Texture2D.Width, Texture2D.Height)))
                return asteroid;

        return null;
    }

    public void Update()
    {
        if (Position.X <= ActionsInGame.Width)
            Position += Direction;
    }

    public bool Hidden => Position.X > ActionsInGame.Width;

    public void Draw() => ActionsInGame.SpriteBatch.Draw(Texture2D, Position, Color);
}