using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class RectUtilities
    {
        /// <summary>
        ///     Calculates the viewport dimensions for evenly distributing dimensions across the screen.
        /// </summary>
        /// <param name="tileIndex">Index of the tile to calculate and return dimensions for.</param>
        /// <param name="maxTiles">Amount of tiles that are going to be on the screen (for calculating dimensions).</param>
        /// <param name="totalWidth">Total width of the area to project to grid dimensions.</param>
        /// <param name="totalHeight">Total height of the area to project to grid dimensions.</param>
        /// <returns>Dimensions of a tile in the grid.</returns>
        public static Rect GetGridRect(int tileIndex, int maxTiles, int totalWidth, int totalHeight)
        {
            if (maxTiles <= 1)
            {
                return new Rect(0, 0, totalWidth, totalHeight);
            }

            if (maxTiles % 2 == 0)
            {
                //totalFitAmount--;
            }

            int tileWidth = Screen.width / maxTiles;
            int tileHeight = Screen.height / Mathf.Min(maxTiles / 2, 1);

            return new Rect(tileWidth * tileIndex, 0, tileWidth, tileHeight);
        }
    }
}