using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class ContentDisplay : MonoBehaviour
{
    public RawImage videoPlayerImage; 
    public TextMeshProUGUI text1; 
    public TextMeshProUGUI text2; 
    public TextMeshProUGUI text3; 
    public TextMeshProUGUI text4; 
    public VideoPlayer videoPlayer; 

    public void DisplayContent(ContentData content)
    {
        videoPlayer.clip = content.videoClip;
        videoPlayer.Play();

        text1.text = content.textLine1;
        text2.text = content.textLine2;
        text3.text = content.textLine3;
        text4.text = content.textLine4;
    }

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
