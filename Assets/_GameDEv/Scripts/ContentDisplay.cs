using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ContentDisplay : MonoBehaviour
{
    public RawImage videoPlayerImage; // Video gösterimi için RawImage
    public TextMeshProUGUI text1; // Ýlk metin
    public TextMeshProUGUI text2; // Ýkinci metin
    public TextMeshProUGUI text3; // Üçüncü metin
    public TextMeshProUGUI text4; // Dördüncü metin
    public VideoPlayer videoPlayer; // Video oynatýcý bileþeni

    // Ýçeriði UI üzerinde göster
    public void DisplayContent(ContentData content)
    {
        // Video dosyasýný oynatýcýya baðla
        videoPlayer.clip = content.videoClip;
        videoPlayer.Play();

        // Metin alanlarýný doldur
        text1.text = content.textLine1;
        text2.text = content.textLine2;
        text3.text = content.textLine3;
        text4.text = content.textLine4;
    }

    // Ýçeriði temizle ve video oynatmayý durdur
    public void ClearContent()
    {
        videoPlayer.Stop();
        videoPlayer.clip = null;
        text1.text = string.Empty;
        text2.text = string.Empty;
        text3.text = string.Empty;
        text4.text = string.Empty;
    }
}
