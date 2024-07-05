using System.Collections;
using UnityEngine;

public class Effector : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ParticleSystem _particleEffect;

    private void Awake()
    {
        if (_audio == null)
        {
            Debug.LogWarning($"Audio Source not initialized in {gameObject.name}");
        }

        if (_particleEffect == null)
        {
            Debug.LogWarning($"Particle System not initialized in {gameObject.name}");
        }
    }

    public void Play()
    {
        if (_audio != null)
        {
            _audio.Play();
        }

        if (_particleEffect != null)
        {
            _particleEffect.Play();
        }

        StartCoroutine(OnSoundEnd());
    }

    private IEnumerator OnSoundEnd()
    {
        if (_audio != null)
        {
            yield return new WaitWhile(() => _audio.isPlaying);
        }

        if (_particleEffect != null)
        {
            yield return new WaitWhile(() => _particleEffect.isPlaying);
        }

        Destroy(gameObject);
    }
}
