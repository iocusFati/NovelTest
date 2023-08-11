using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UI
{
    public class QuestLog
    {
        private readonly Transform _marker;
        private readonly TextMeshProUGUI _text;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly float _pauseBetweenLetters;

        private int _questCounter = 1;
        
        private readonly List<string> _unwrittenAchievements = new();

        public QuestLog(TextMeshProUGUI text, 
            ICoroutineRunner coroutineRunner, 
            float pauseBetweenLetters)
        {
            _text = text;
            _coroutineRunner = coroutineRunner;
            _pauseBetweenLetters = pauseBetweenLetters;
        }

        public void UpdateAchievement(string achievement)
        {
            _unwrittenAchievements.Add(achievement);
        }

        public void ShowQuestText() => 
            _coroutineRunner.StartCoroutine(WriteText());

        private IEnumerator WriteText()
        {
            foreach (var achievement in _unwrittenAchievements)
            {
                _text.text += $"\n{_questCounter}. ";
                char[] letters = SplitText(achievement);

                foreach (var letter in letters)
                {
                    _text.text += letter;

                    yield return new WaitForSeconds(_pauseBetweenLetters);
                }

                _questCounter++;
            }
            
            _unwrittenAchievements.Clear();
        }
        
        private static char[] SplitText(string text) => 
            text.ToCharArray();
    }
}