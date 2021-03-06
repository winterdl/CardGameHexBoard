﻿using System.Collections.Generic;
using Game.Ui;
using HexCardGame.Runtime;
using HexCardGame.Runtime.Game;
using HexCardGame.SharedData;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HexCardGame.UI
{
    public class UiBoardElements : UiEventListener, ICreateBoardElement, IRestartGame
    {
        private readonly HashSet<GameObject> _boardElements = new HashSet<GameObject>();
        [SerializeField] private GameObject boardElementPrefab;
        private Tilemap TileMap { get; set; }

        void ICreateBoardElement.OnCreateBoardElement(SeatType id, CreatureElement creatureElement, Vector3Int cell,
            CardHand card)
        {
            var data = creatureElement.Data;
            CreateElement(creatureElement, data, cell);
        }

        void IRestartGame.OnRestart()
        {
            foreach (var element in _boardElements)
                ObjectPooler.Instance.Release(element);
            _boardElements.Clear();
            TileMap.ClearAllTiles();
        }

        protected override void Awake()
        {
            base.Awake();
            TileMap = GetComponentInChildren<Tilemap>();
        }

        private void CreateElement(CreatureElement creatureElement, ICardData data, Vector3Int cell)
        {
            var element = ObjectPooler.Instance.Get(boardElementPrefab);
            _boardElements.Add(element);
            var elementTransform = element.transform;
            var boardElement = element.GetComponent<UiBoardElement>();
            elementTransform.SetParent(transform);
            elementTransform.position = TileMap.CellToWorld(cell);
            boardElement.SetElement(creatureElement);
        }
    }
}