using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWaves : MonoBehaviour {

    //Flipped Script
    public Flip flipScript;
    bool flipped;

    //WaveSpawner
    public GameObject waveSpawnerDX;
    public GameObject waveSpawnerSX;

    //Wave
    public GameObject soundWaveNormal;
    public GameObject soundWaveHeavy;
    public GameObject soundWaveLight;
    public GameObject soundWaveSpecial;

    public GameObject soundWaveNormalVfx;
    public GameObject soundWaveHeavyVfx;
    public GameObject soundWaveLightVfx;
    public GameObject soundWaveSpecialVfx;

    public float cooldownTime = .8f;

    private bool canShoot = true;
    
    private VariableManager _varMgr;
    void Start() {
        _varMgr = FindObjectOfType<VariableManager>();
    }

    void Update() {
        GameObject soundWave;
        GameObject soundWaveVfx;
        switch (_varMgr.GetSelectedGuitar()) {
            case GuitarTypes.Leggera:
                soundWave = soundWaveLight;
                soundWaveVfx = soundWaveLightVfx;
                break;
            case GuitarTypes.Pesante:
                soundWave = soundWaveHeavy;
                soundWaveVfx = soundWaveHeavyVfx;
                break;
            case GuitarTypes.OP:
                soundWave = soundWaveSpecial;
                soundWaveVfx = soundWaveSpecialVfx;
                break;
            default:
                soundWave = soundWaveNormal;
                soundWaveVfx = soundWaveNormalVfx;
                break;
        }
        
        if (Input.GetButtonDown("Fire1") && canShoot) {
            canShoot = false;
            flipped = flipScript.isFlipped;
            if (!flipped) {
                GameObject ondaSonora = Instantiate(soundWave, waveSpawnerDX.transform.position, waveSpawnerDX.transform.rotation);
                GameObject ondaSonoraVfx = Instantiate(soundWaveVfx, waveSpawnerDX.transform.position, waveSpawnerDX.transform.rotation);
            } else if (flipped) {
                GameObject ondaSonora = Instantiate(soundWave, waveSpawnerSX.transform.position, waveSpawnerSX.transform.rotation);
                GameObject ondaSonoraVfx = Instantiate(soundWaveVfx, waveSpawnerSX.transform.position, waveSpawnerSX.transform.rotation);
            }
            Invoke("ReactivateGuitar", cooldownTime);
        }
    }

    private void ReactivateGuitar() {
        canShoot = true;
    }
}
