using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.Video;
using System.Collections;

public class ContentManager : MonoBehaviour
{
    public List<Button> buttons;
    public List<ContentData> contents;
    public ContentDisplay contentDisplay;
    public GameObject panel;
    public VideoPlayer videoPlayer;

    private RectTransform panelRectTransform;

    public Vector2 panelMinSize = new Vector2(0, 0);
    public Vector2 panelMaxSize = new Vector2(100, 100);

    private void Start()
    {
        panelRectTransform = panel.GetComponent<RectTransform>();

        for (int i = 0; i < buttons.Count && i < contents.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int contentIndex)
    {
        if (contentIndex >= 0 && contentIndex < contents.Count)
        {
            panel.SetActive(true);
            panelRectTransform.sizeDelta = panelMinSize;
            panelRectTransform.DOSizeDelta(panelMaxSize, 0.6f).SetEase(Ease.OutBack);

            ToggleButtons(false);

            StartCoroutine(contentDisplay.DisplayContentWithDelays(contents[contentIndex]));
        }
    }

    public void ClosePanel()
    {
        panelRectTransform.DOSizeDelta(panelMaxSize * 1.1f, 0.3f).SetEase(Ease.InBack)
            .OnComplete(() => panelRectTransform.DOSizeDelta(panelMinSize, 0.3f).SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                panel.SetActive(false);
                contentDisplay.ClearContent();
               
            }));
        ToggleButtons(true);
    }

    private void ToggleButtons(bool state)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(state);
        }

        Debug.Log($"ToggleButtons called with state: {state}");
    }
}
