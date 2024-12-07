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

        yield return new WaitForSeconds(content.image1Delay);
        ShowImageWithAnimation(image1, content.image1);

        yield return new WaitForSeconds(content.image2Delay);
        ShowImageWithAnimation(image2, content.image2);

        yield return new WaitForSeconds(content.image3Delay);
        ShowImageWithAnimation(image3, content.image3);
        
        yield return new WaitForSeconds(content.text1Delay);
        ShowTextWithAnimation(text1, content.textLine1);


    }

    private void ShowTextWithAnimation(TextMeshProUGUI textComponent, string text)
    {
        textComponent.text = text;
        textComponent.alpha = 0;
        textComponent.gameObject.SetActive(true);
        textComponent.DOFade(1, 0.5f);
    }

    private void ShowImageWithAnimation(Image imageComponent, Sprite sprite)
    {
        imageComponent.sprite = sprite;
        imageComponent.transform.localScale = Vector3.zero;
        imageComponent.gameObject.SetActive(true);
        imageComponent.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);
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
