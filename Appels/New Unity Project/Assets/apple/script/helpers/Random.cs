using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.helpers
{
    public static class RandomHelper
    {
        private static System.Random rng = new System.Random();

        public static void ShuffleList<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static Vector2 RandomVector2(Vector2 bottomLeft, Vector2 topRight)
        {
            float blx = bottomLeft.x;
            float bly = bottomLeft.y;
            float trx = topRight.x;
            float trY = topRight.y;
            return RandomVector2(blx, bly, trx, trY);
        }
        public static Vector2 RandomVector2(float bottomLeftX, float bottomLeftY, float topRightX, float topRightY)
        {
            float x = (float)rng.NextDouble() * (topRightX - bottomLeftX) + bottomLeftX;
            float y = (float)rng.NextDouble() * (topRightY - bottomLeftY) + bottomLeftY;
            return new Vector2(x, y);

        }

    }
}
