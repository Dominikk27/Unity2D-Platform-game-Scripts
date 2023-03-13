using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;

    List<HeartScript> hearts = new List<HeartScript>();

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDamaged -= DrawHearts;
    }


    void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHP();
        float hpReminder = playerHealth.maxHealth % 2;
        int Real_HP = (int)(playerHealth.maxHealth /2 + hpReminder);
        for (int i = 0; i< Real_HP; i++){
            CreateEmptyHP();
        }

        for (int i = 0; i< hearts.Count; i++)
        {
            int HP_StatusReminder = (int)Mathf.Clamp(playerHealth.health - (i*2), 0, 2);
            hearts[i].SetHeartIMG((HeartStatus)HP_StatusReminder);
        }
    }

    public void CreateEmptyHP()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HeartScript heartComp = newHeart.GetComponent<HeartScript>();
        heartComp.SetHeartIMG(HeartStatus.Empty);
        hearts.Add(heartComp);
    }


    public void ClearHP()
    {
        foreach (Transform T in transform)
        {
            Destroy(T.gameObject);
        }
        hearts = new List<HeartScript>();
    }


}
