//  [小鈎ハレ]  //
using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour
{
    public Slider slider;
    public Light scenelight;


    void Update()
    {
        scenelight.intensity = slider.value;
    }
}
