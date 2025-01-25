using NaviCm;
using UnityEngine;

public class ParticleFx : AreaFx
{
    [SerializeField] private ParticleSystem particles;
    
    public override void Play()
    {
        particles.Play();    
    }

    public override void Stop()
    {
        particles.Stop();    
    }
}
