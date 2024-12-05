using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ContentDisplay : MonoBehaviour
{
    public RawImage videoPlayerImage; // Video g�sterimi i�in RawImage
    public TextMeshProUGUI text1; // �lk metin
    public TextMeshProUGUI text2; // �kinci metin
    public TextMeshProUGUI text3; // ���nc� metin
    public TextMeshProUGUI text4; // D�rd�nc� metin
    public VideoPlayer videoPlayer; // Video oynat�c� bile�eni

    // ��eri�i UI �zerinde g�ster
    public void DisplayContent(ContentData content)
    {
        // Video dosyas�n� oynat�c�ya ba�la
        videoPlayer.clip = content.videoClip;
        videoPlayer.Play();

        // Metin alanlar�n� doldur
        text1.text = content.textLine1;
        text2.text = content.textLine2;
        text3.text = content.textLine3;
        text4.text = content.textLine4;
    }

    // ��eri�i temizle ve video oynatmay� durdur
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
