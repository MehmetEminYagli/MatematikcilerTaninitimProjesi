using UnityEngine;
using UnityEngine.Video;
[CreateAssetMenu(fileName = "NewContent", menuName = "Content System/Content")]

public class ContentData : ScriptableObject
{

    public VideoClip videoClip;

    public string textLine1;
    public float text1Delay;
    public Sprite image1;
    public float image1Delay;

    public Sprite image2;
    public float image2Delay;

    public Sprite image3;
    public float image3Delay;

}

