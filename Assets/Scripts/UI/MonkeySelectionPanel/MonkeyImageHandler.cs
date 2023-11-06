using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private Vector3 initialPosition;
        private Vector3 initialAnchoredPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            rectTransform = GetComponent<RectTransform>();
            initialPosition = rectTransform.position;
            initialAnchoredPosition = rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            //rectTransform.anchoredPosition += eventData.delta;
            rectTransform.position = eventData.position;
            owner.MonkeyDraggedAt(rectTransform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            owner.MonkeyDroppedAt(eventData.position);
            ResetMonkeyImagePosition();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, 0.6f);
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            ResetMonkeyImageColor();
        }
        private void ResetMonkeyImagePosition()
        {
            rectTransform.position = initialPosition;
            rectTransform.anchoredPosition = initialAnchoredPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }
        private void ResetMonkeyImageColor()
        {
            monkeyImage.color = new Color(1, 1, 1, 1f);
        }
    }
}