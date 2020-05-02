using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int state;
    public float speed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StateCoroutine());
        StartCoroutine(MakeRandomNumber());
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                Upstate();
                break;
            case 2:
                Downstate();
                break;
        }
    }

    IEnumerator StateCoroutine()
    {
        while (true)
        {
            state = 1;
            yield return new WaitForSeconds(1);
            state = 2;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator MakeRandomNumber()
    {
        while (true)
        {
            int randomNum = Random.Range(0, 6);

            Debug.Log(randomNum);
            yield return new WaitForSeconds(1);
        }
    }

    void Upstate()
    {
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Downstate()
    {
       
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)

    {

        Destroy(other.gameObject);

    }
}
