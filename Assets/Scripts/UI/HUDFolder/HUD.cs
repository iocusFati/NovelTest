using System.Collections;
using System.Collections.Generic;
using Naninovel;
using Naninovel.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : CustomUI, ICoroutineRunner
    {
        [Header("HUD")]
        [SerializeField] private TextMeshProUGUI _questProgressText;
        [SerializeField] private Button _mapButton;
        [SerializeField] private float _pauseBetweenLetters;
        [SerializeField] private Transform _mapMarker;
        [SerializeField] private GameObject _container;
        [SerializeField] private List<LocationUI> _locationsUI;
        [SerializeField] private Button _dungeonButton;
        [SerializeField] private Image _dungeonIcon;

        private QuestLog _questLog;
        private MapUI _mapUI;

        protected override void Awake()
        {
            _questLog = new QuestLog(_questProgressText, this, _pauseBetweenLetters);
            _mapUI = new MapUI(_mapMarker, _locationsUI, _dungeonButton, _dungeonIcon);
            
            base.Awake();
        }

        public void UpdateAchievement(string achievement, string location = null)
        {
            _questLog.UpdateAchievement(achievement);
            
            if (location is not null) 
                _mapUI.SetQuestMarkerAbove(location);
            else
                _mapMarker.gameObject.SetActive(false);
        }

        public void ShowAchievements() => 
            _questLog.ShowQuestText();

        public void Appear() => 
            _container.SetActive(true);

        public void BlockMap(bool block) => 
            _mapButton.interactable = !block;

        void ICoroutineRunner.StartCoroutine(IEnumerator coroutine) => 
            StartCoroutine(coroutine);

        public void OpenDungeon(bool open)
        {
            _mapUI.OpenDungeon(open);
        }
    }
}