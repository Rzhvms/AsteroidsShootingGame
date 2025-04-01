using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AsteroidsShooting.Code;

public class ActionsInGame
{
    public static int Width, Height;
    public static Random Rand = new();
    public static SpriteBatch SpriteBatch;
    public static Stars[] Stars;
    public static SpaceShip SpaceShip;
    public static List<FireShot> FireShoots = new();
    public static List<Asteroid> AsteroidsList = new();

    public static int GetRandomCount(int minValue, int maxValue) => Rand.Next(minValue, maxValue);

    public static void SpaceShipFire() => FireShoots.Add(new FireShot(SpaceShip.GetFirePosition));

    public static void Initialize(SpriteBatch spriteBatch, int width, int height)
    {
        SpriteBatch = spriteBatch;
        Width = width;
        Height = height;
        Stars = new Stars[100];
        SpaceShip = new SpaceShip(new Vector2(0, Height / 2 - 75));

        for (var i = 0; i < Stars.Length; i++)
            Stars[i] = new Stars(new Vector2(-Rand.Next(1, 10), 0));

        for (var i = 0; i < 40; i++)
            AsteroidsList.Add(new Asteroid());
    }

    public static void Draw()
    {
        foreach (var star in Stars)
            star.Draw();

        foreach (var fire in FireShoots)
            fire.Draw();

        foreach (var asteroid in AsteroidsList)
            asteroid.Draw();

        SpaceShip.Draw();
    }

    public static void Update()
    {
        foreach (var star in Stars)
            star.Update();

        foreach (var asteroid in AsteroidsList)
            asteroid.Update();

        for (var i = 0; i < FireShoots.Count; i++)
        {
            FireShoots[i].Update();
            var crashAsteroid = FireShoots[i].Crash(AsteroidsList);

            if (crashAsteroid != null)
            {
                AsteroidsList.Remove(crashAsteroid);
                FireShoots.RemoveAt(i);
                i--;
                continue;
            }

            if (FireShoots[i].Hidden)
            {
                FireShoots.RemoveAt(i);
                i--;
            }
        }
    }
}