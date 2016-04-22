using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Base;
using Assets.Scripts.Extensions;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        public WorldGen WorldGen;

        [Range(1, 20)]
        public int PlayerCount;

        /// <summary>
        /// Depth offset at which camera's for players should spawn in.
        /// </summary>
        [Tooltip("Depth offset at which camera's for players should spawn in")]
        public float CameraZOffset;

        private List<Player> players;
        private List<PlayAreaCamera> playerCameras;
        private List<MainCanvas> playerCanvases;

        [Header("Prefabs")]
        public GameObject PlayerPrefab;
        public GameObject PlayerCameraPrefab;
        public GameObject PlayerCanvasPrefab;

        [Header("Parents")]
        public Transform PlayersParent;
        public Transform PlayerCamerasParent;
        public Transform PlayerCanvasParent;

        /// <summary>
        ///     All players that are connected.
        /// </summary>
        public IEnumerable<Player> Players
        {
            get { return players; }
        }

        private void Awake()
        {
            if (!WorldGen)
            {
                Debug.LogError(string.Format("{0}: WorldGen is not set.", name));
                return;
            }
            players = new List<Player>(PlayerCount);
            playerCameras = new List<PlayAreaCamera>(PlayerCount);
            playerCanvases = new List<MainCanvas>();

            for (var i = 0; i < PlayerCount; i++)
            {
                // Create player.
                var pos = new Vector3(Random.Range(-WorldGen.SizeInMeters / 2f + 1, WorldGen.SizeInMeters / 2f - 1),
                    Random.Range(-WorldGen.SizeInMeters / 2f + 1, WorldGen.SizeInMeters / 2f - 1));
                var ply = (GameObject)Instantiate(PlayerPrefab, pos, Quaternion.identity);
                ply.name = "Player " + (i + 1);
                var plyScript = ply.GetComponent<Player>();
                plyScript.Index = i;
                players.Add(plyScript);
                ply.transform.SetParent(PlayersParent);

                // Create camera for player.
                var cam = (GameObject)Instantiate(PlayerCameraPrefab, pos + new Vector3(0, 0, CameraZOffset), Quaternion.identity);
                cam.name = ply.name + "'s camera";
                var camScript = cam.GetComponent<Camera>();
                camScript.SetViewportGrid(i, PlayerCount);
                var camAreaScript = cam.GetComponent<PlayAreaCamera>();
                camAreaScript.Target = ply.transform;
                playerCameras.Add(camAreaScript);
                cam.transform.SetParent(PlayerCamerasParent);

                // Create container on canvas for player.
                var can = (GameObject)Instantiate(PlayerCanvasPrefab);
                var canRect = can.GetComponent<RectTransform>();
                var canContainer = can.GetComponent<PlayerCanvasContainer>();
                can.transform.SetParent(PlayerCanvasParent, false);
                var canView = RectUtilities.GetGridRect(i, PlayerCount, Screen.width, Screen.height);
                canRect.sizeDelta = canView.size;
                canRect.localPosition = canView.position;
                plyScript.Hud = canContainer;
            }
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void Reset()
        {
            CameraZOffset = -10;
        }
    }
}