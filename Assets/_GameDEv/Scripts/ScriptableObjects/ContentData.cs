using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "NewContent", menuName = "Content System/Content")]
public class ContentData : ScriptableObject
{
    public VideoClip videoClip; // Yerel video dosyas�
    public string textLine1; // �lk metin
    public string textLine2; // �kinci metin
    public string textLine3; // ���nc� metin
    public string textLine4; // D�rd�nc� metin
}
