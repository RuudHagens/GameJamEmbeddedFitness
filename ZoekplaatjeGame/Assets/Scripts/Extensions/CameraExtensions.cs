using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class CameraExtensions
    {
        /// <summary>
        ///     Calculates the viewport rect based on the current index and the desired totalFitAmount of viewports the screen
        ///     should fit.
        /// </summary>
        /// <param name="index">Index that determines the location of the current camera.</param>
        /// <param name="totalFitAmount">Amount of viewports that the screen should fit.</param>
        public static void SetViewportGrid(this Camera camera, int index, int totalFitAmount)
        {
            camera.pixelRect = RectUtilities.GetGridRect(index, totalFitAmount, Screen.width, Screen.height);
        }
    }
}