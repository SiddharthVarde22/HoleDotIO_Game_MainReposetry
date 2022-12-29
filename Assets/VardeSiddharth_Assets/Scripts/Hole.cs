using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    int points = 0;
    [SerializeField]
    int size = 2;
    // Start is called before the first frame update
    void Start()
    {
        ChangeSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSize()
    {
        transform.localScale = new Vector3(size, 0, size);
    }

    public void AddPoints(int points)
    {
        this.points += points;

        if(this.points >= 50)
        {
            this.points = 0;
            size++;
            ChangeSize();
        }
    }
}
