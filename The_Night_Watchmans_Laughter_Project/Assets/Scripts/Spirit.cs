using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public int curSpirt = 0;
    public int maxSpirt = 100;

    [SerializeField]
    private SpiritMeter spiritMeter;

    [SerializeField]
    private float _delayTimer;

    // Start is called before the first frame update
    void Start()
    {
        curSpirt = maxSpirt;
    }

    // Update is called once per frame
    void Update()
    {
        if (_delayTimer > 0)
        {
            _delayTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Scream!") && curSpirt > 0)
        {
            StartCoroutine(ScreamingRoutine());
            
        }
    }

    public void usingSpirit(int sp)
    {
        curSpirt -= sp;
        spiritMeter.SetSpirit(curSpirt);
    }

    IEnumerator ScreamingRoutine()
    {
        usingSpirit(10);
        yield return new WaitForSeconds(0.1f);
        usingSpirit(10);
        Debug.Log("Is repecting");
    }

    public void PickupPower()
    {
        curSpirt = maxSpirt;
        spiritMeter.SetSpirit(curSpirt);
    }
}
