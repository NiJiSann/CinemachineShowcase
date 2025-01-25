using NaviCm;
using UnityEngine;

public class LightFx : AreaFx
{
    [SerializeField] private GameObject lightFx;
    
    public override void Play()
    {
        lightFx.SetActive(true);
    }

    public override void Stop()
    {
        lightFx.SetActive(false);
    }
}
