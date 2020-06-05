using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInteraction : MonoBehaviour
{


    private Effect _effect;
    private Organ _organ;

    public GameObject _organGO;
    public int _effectIndex;
    public int _organIndex;

    private void OnEnable()
    {
        FindObjectOfType<GameStateManager>().OnInitialized += Initialize;

    }

    private void OnDisable()
    {
        FindObjectOfType<GameStateManager>().OnInitialized -= Initialize;
    }

    private void Initialize()
    {
        _organ = FindObjectOfType<GameStateManager>().gameStateData.organs[_organIndex];
        _effect = _organ.effects[_effectIndex];
    }

    private void Update()
    {
        if (_effect != null)
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
        Debug.Log("INSTANT FOOD from" + _organGO.name);
    }

    void ApplyMoreFood()
    {
        Debug.Log("MORE FOOD" + _organGO.name);

    }

    void ApplyMoreTime()
    {
        Debug.Log("MORE TIME" + _organGO.name);

    }

    void ApplyRegeneration()
    {
        Debug.Log("REGEN" + _organGO.name);

    }

}
