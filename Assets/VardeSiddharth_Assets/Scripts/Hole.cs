using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    [SerializeField]
    int points = 0;
    [SerializeField]
    int maxPoints = 50;
    [SerializeField]
    float playerSizeInYAxis = 0.01f;
    [SerializeField]
    int size = 2;
    [SerializeField]
    Image pointsImageRefrence;

    public int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSize();
        pointsImageRefrence.fillAmount = (float)this.points / (float)maxPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSize()
    {
        transform.localScale = new Vector3(size, playerSizeInYAxis, size);
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        this.points += points;
        pointsImageRefrence.fillAmount = ((float)this.points / (float)maxPoints);

        if(this.points >= maxPoints)
        {
            this.points = 0;
            size++;
            ChangeSize();
        }
    }

    
    public float GetPlayerSize()
    {
        return new Vector2(size, size).magnitude;
    }
    
}
