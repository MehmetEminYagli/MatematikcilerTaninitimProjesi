using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "NewContent", menuName = "Content System/Content")]
public class ContentData : ScriptableObject
{
    public VideoClip videoClip; // Yerel video dosyasý
    public string textLine1; // Ýlk metin
    public string textLine2; // Ýkinci metin
    public string textLine3; // Üçüncü metin
    public string textLine4; // Dördüncü metin
}
