using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    ///     Manager for the HUD of a player.
    /// </summary>
    public class PlayerCanvasContainer : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField]
        private Text scoreValue;

        [SerializeField]
        private CanvasGroup doneGroup;

        private int playerScore;

        private bool done;

        /// <summary>
        ///     Score of the player.Automatically updates UI.
        /// </summary>
        public int PlayerScore
        {
            get { return playerScore; }
            set
            {
                playerScore = value;
                scoreValue.text = PlayerScore.ToString();
            }
        }

        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                StartCoroutine(Fade(done));
            }
        }

        private IEnumerator Fade(bool fadeIn)
        {
            var alpha = fadeIn ? 0 : 1f;
            while ((fadeIn && alpha < 1) || (!fadeIn && alpha > 0))
            {
                alpha += (fadeIn ? 2f : -2f) * Time.deltaTime;
                doneGroup.alpha = alpha;
                yield return null;
            }

            // Set direct because floating points aren't accurate.
            doneGroup.alpha = fadeIn ? 1f : 0;
        }
    }
}