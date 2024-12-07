using UnityEngine;

using UnityEngine.Video;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "NewContent", menuName = "Content System/Content")]
public class ContentData : ScriptableObject
{
    public VideoClip videoClip;

    public string textLine1;
    public float text1Delay;

    public List<Sprite> images; 
    public List<float> imageDelays;
}
