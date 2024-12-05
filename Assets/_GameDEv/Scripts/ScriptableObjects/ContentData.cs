using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "NewContent", menuName = "Content System/Content")]
public class ContentData : ScriptableObject
{
    public VideoClip videoClip;
    public string textLine1;
    public string textLine2; 
    public string textLine3; 
    public string textLine4;
}
