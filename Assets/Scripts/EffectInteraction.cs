using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInteraction : MonoBehaviour
{


    private Effect _effect;
    private Organ _organ;

    public OrganInteraction _organInteraction;
    public int _effectIndex;
    public int _organIndex;
    GameObject player;
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
        
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if(_organ != null && _organ.currentHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
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
        _organInteraction.AddPointsToParasite(_organInteraction.parasiteGain01, _effect.instantGain);
        _organInteraction.AddPointsToParasite(_organInteraction.parasiteGain02, _effect.instantGain);

        _organ.currentHP -= _effect.instantGain * 2;
        float tempScale = _organInteraction.CalculateScale(_organ.maxHP, _organ.currentHP);
        _organInteraction.hpAmount.localScale = new Vector3(tempScale, tempScale, 0);
    }

    void ApplyMoreFood()
    {
        
    }

    void ApplyMoreTime()
    {
        FindObjectOfType<Timer>().timer += _effect.moreTime;
        StartCoroutine(_organInteraction.LooseLife(_effect.moreTime));
    }

    void ApplyRegeneration()
    {

    }

}
