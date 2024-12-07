using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;
using UnityEngine.Video;

public class ContentDisplay : MonoBehaviour
{
    public RawImage videoPlayerImage;
    public VideoPlayer videoPlayer;
    public RenderTexture videoRenderTexture;

    public TextMeshProUGUI text1;

    public Image image1;
    public Image image2;
    public Image image3;

    public IEnumerator DisplayContentWithDelays(ContentData content)
    {
        if (content.videoClip != null)
        {
            videoPlayerImage.gameObject.SetActive(true);
            videoPlayer.targetTexture = videoRenderTexture;
            videoPlayerImage.texture = videoRenderTexture;
            videoPlayer.clip = content.videoClip;
            videoPlayer.Play();
        }

        yield return new WaitForSeconds(0.1f); 

        ShowImageAtTime(image1, content.image1, content.image1Delay);
        ShowImageAtTime(image2, content.image2, content.image2Delay);
        ShowImageAtTime(image3, content.image3, content.image3Delay);
        ShowTextAtTime(text1, content.textLine1, content.text1Delay);
    }

    private void ShowImageAtTime(Image imageComponent, Sprite sprite, float timeToShow)
    {
        StartCoroutine(ShowImageAfterTime(imageComponent, sprite, timeToShow));
    }

    private IEnumerator ShowImageAfterTime(Image imageComponent, Sprite sprite, float timeToShow)
    {
        yield return new WaitUntil(() => videoPlayer.time >= timeToShow);

        imageComponent.sprite = sprite;
        imageComponent.transform.localScale = Vector3.zero;
        imageComponent.gameObject.SetActive(true);
        imageComponent.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);
    }

    private void ShowTextAtTime(TextMeshProUGUI textComponent, string text, float timeToShow)
    {
        StartCoroutine(ShowTextAfterTime(textComponent, text, timeToShow));
    }

    private IEnumerator ShowTextAfterTime(TextMeshProUGUI textComponent, string text, float timeToShow)
    {
        yield return new WaitUntil(() => videoPlayer.time >= timeToShow);
        textComponent.text = text;
        textComponent.alpha = 0;
        textComponent.gameObject.SetActive(true);
        textComponent.DOFade(1, 0.5f);
    }

    public void ClearContent()
    {
        videoPlayer.Stop();
        videoPlayer.clip = null;
        videoPlayerImage.texture = null;
        videoPlayerImage.gameObject.SetActive(false);

        text1.text = string.Empty;

        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }
}
