using System;
using Economy;
using JetBrains.Annotations;
using UnityEngine;

namespace Building
{
    public class TilePlacer : MonoBehaviour
    {
        public static TilePlacer Instance { get; private set; }

        private const int PlacementLayerMask = ~(1 << 6);

        public Vector2 gridSize;
        public GameObject placementObject;
        public ITile Tile { get; set; }

        [CanBeNull] private GameObject _placedObject;

        private Camera _camera;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            if (Instance != this)
                Destroy(this);
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0) || !_placedObject) return;

            // Check if the tile to place has a cost
            if (Tile is IMaterialCost tileMaterialCost)
            {
                GameState.Instance.Economy.Purchase(tileMaterialCost.Cost)
                    .Match(onSuccess: () => Debug.Log("Successfully purchased tile"), 
                           onError: error => Debug.Log(error));
                return;
            }

            // Else just place the tile
            Console.WriteLine();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitData, Mathf.Infinity, PlacementLayerMask))
            {
                if (!_placedObject)
                    _placedObject = Instantiate(placementObject);

                var position = hitData.point;
                position.x = Mathf.Floor(position.x / gridSize.x) * gridSize.x;
                position.z = Mathf.Floor(position.z / gridSize.y) * gridSize.y;
                _placedObject!.transform.position = position;
            }
            else
            {
                if (_placedObject)
                    Destroy(_placedObject);
            }
        }
    }
}