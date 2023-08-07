using System;
using System.Collections;
using Naninovel.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ArtifactUI : CustomUI
    {
        [Header("Artifact")]
        public Image Artifact;
        
        [SerializeField] private float _raiseDuration;
        [SerializeField] private float _raiseBy;
        [SerializeField] private Button _button;

        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();

            _rectTransform = Artifact.GetComponent<RectTransform>();

            _button.onClick.AddListener(Raise);
        }

        public void StartFade(Action onComplete, float duration)
        {
            StartCoroutine(Fade(onComplete, duration));
        }

        private void Raise() => 
            StartCoroutine(RaiseSelf());

        private IEnumerator RaiseSelf()
        {
            float elapsedTime = 0f;
            Vector2 initialPosition = _rectTransform.localPosition;
            Vector2 targetPosition = new Vector3(initialPosition.x, initialPosition.y + _raiseBy);
            Debug.Log(targetPosition);
            
            while (elapsedTime < _raiseDuration)
            {
                float t = elapsedTime / _raiseDuration;
                
                _rectTransform.localPosition = Vector3.Lerp(initialPosition, targetPosition, t);
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _rectTransform.localPosition = targetPosition;
        }
        
        private IEnumerator Fade(Action onComplete, float duration)
        {
            float elapsedTime = 0f;
            Color initialColor = Artifact.color;
            
            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Color newColor = Color.Lerp(initialColor, Color.clear, t);
                Artifact.color = newColor;

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            Artifact.color = Color.clear;
            onComplete.Invoke();
        }
    }
}