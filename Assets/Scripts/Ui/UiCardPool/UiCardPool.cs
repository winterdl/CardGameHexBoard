﻿using HexCardGame.SharedData;
using Tools.UiTransform;
using UnityEngine;
using Logger = Tools.Logger;

namespace HexCardGame.UI
{
    public interface IUiCardPool : IUiMotionHandler
    {
    }

    public class UiCardPool : MonoBehaviour, IUiCardPool
    {
        public ICardData Data { get; private set; }
        public UiMotion Motion { get; private set; }
        public MonoBehaviour MonoBehaviour => this;
        void Awake() => Motion = new UiMotion(this);
        void Update() => Motion.Update();

        public void SetData(ICardData data)
        {
            Data = data;
            UpdateUi();
        }

        void UpdateUi() => Logger.Log<UiCardPool>("Ui updated with dataId: " + Data.Id);
    }
}