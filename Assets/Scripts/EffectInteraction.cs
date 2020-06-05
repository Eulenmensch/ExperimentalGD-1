using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInteraction : MonoBehaviour
{
    public Effect _effect;

    private void Update()
    {
        if (_effect.isActivated)
        {
            _effect.currentTimer -= Time.deltaTime;
            if (_effect.currentTimer <= 0)
            {
                _effect.isActivated = false;
                Debug.Log("DEACTIVATED");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_effect.isActivated)
        {
            ApplyEffect();
        }
    }

    public void ApplyEffect()
    {
        _effect.isActivated = true;
        _effect.currentTimer = _effect.effectDuration;

        switch (_effect.effectType)
        {
            case Effect.EffectType.InstantFood:
                ApplyInstantFood();
                break;
            case Effect.EffectType.MoreFood:
                ApplyMoreFood();
                break;
            case Effect.EffectType.MoreTime:
                ApplyMoreTime();
                break;
            case Effect.EffectType.Regeneration:
                ApplyRegeneration();
                break;
        }
    }

    void ApplyInstantFood()
    {
        Debug.Log("INSTANT FOOD");
    }

    void ApplyMoreFood()
    {
        Debug.Log("MORE FOOD");

    }

    void ApplyMoreTime()
    {
        Debug.Log("MORE TIME");

    }

    void ApplyRegeneration()
    {
        Debug.Log("REGEN");

    }

}
