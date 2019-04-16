using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarGenerator : MonoBehaviour
{
    //車子位置
    Vector2 posStartCarLeft1;
    Vector2 posStartCarLeft2;
    Vector2 posStartCarLeft3;
    Vector2 posStartCarLeft4;
    Vector2 posEndCarLeft1;
    Vector2 posEndCarLeft2;
    Vector2 posEndCarLeft3;
    Vector2 posEndCarLeft4;

    Vector2 posStartCarRight1;
    Vector2 posStartCarRight2;
    Vector2 posStartCarRight3;
    Vector2 posStartCarRight4;
    Vector2 posEndCarRight1;
    Vector2 posEndCarRight2;
    Vector2 posEndCarRight3;
    Vector2 posEndCarRight4;

    public float xStartCarLeft;
    public float xEndCarLeft;

    public float xStartCarRight;
    public float xEndCarRight;

    public float yCar1;
    public float yCar2;
    public float yCar3;
    public float yCar4;

    public float moveSpeed;

    
    public GameObject carLeft1, carLeft2, carLeft3, carLeft4, carRight1, carRight2, carRight3, carRight4;
    public GameObject Prefab_car;

    public Vector2 force;
    public float X_leftEnd, X_rightEnd;

    public Sprite[] Sprite_car;

    // Use this for initialization
    void Start()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        moveSpeed = 1;

        xStartCarLeft = -12.0f;
        xEndCarLeft = -1.16f;

        xStartCarRight = 12.0f;
        xEndCarRight = 1.76f;

        yCar1 = 2.46f;
        yCar2 = 0.65f;
        yCar3 = -1.23f;
        yCar4 = -2.71f;

        posStartCarLeft1 = new Vector2(xStartCarLeft, yCar1);
        posStartCarLeft2 = new Vector2(xStartCarLeft, yCar2);
        posStartCarLeft3 = new Vector2(xStartCarLeft, yCar3);
        posStartCarLeft4 = new Vector2(xStartCarLeft, yCar4);
        posEndCarLeft1 = new Vector2(xEndCarLeft, yCar1);
        posEndCarLeft2 = new Vector2(xEndCarLeft, yCar2);
        posEndCarLeft3 = new Vector2(xEndCarLeft, yCar3);
        posEndCarLeft4 = new Vector2(xEndCarLeft, yCar4);

        posStartCarRight1 = new Vector2(xStartCarRight, yCar1);
        posStartCarRight2 = new Vector2(xStartCarRight, yCar2);
        posStartCarRight3 = new Vector2(xStartCarRight, yCar3);
        posStartCarRight4 = new Vector2(xStartCarRight, yCar4);
        posEndCarRight1 = new Vector2(xEndCarRight, yCar1);
        posEndCarRight2 = new Vector2(xEndCarRight, yCar2);
        posEndCarRight3 = new Vector2(xEndCarRight, yCar3);
        posEndCarRight4 = new Vector2(xEndCarRight, yCar4);

        switch(StageManager.instance.cur_stageNum)
        {
            case 1:
                StartCoroutine(Stage_One());
                break;
            case 2:
                StartCoroutine(Stage_Two());
                break;
            case 3:
                break;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }

    void Flip_X(GameObject target)
    {
        target.GetComponent<SpriteRenderer>().flipX = true;
    }

    IEnumerator Stage_One()
    {

        carLeft1 = Instantiate(Prefab_car, posStartCarLeft1, Quaternion.identity);
        carLeft2 = Instantiate(Prefab_car, posStartCarLeft2, Quaternion.identity);
        carLeft3 = Instantiate(Prefab_car, posStartCarLeft3, Quaternion.identity);
        carLeft4 = Instantiate(Prefab_car, posStartCarLeft4, Quaternion.identity);
        carRight1 = Instantiate(Prefab_car, posStartCarRight1, Quaternion.identity);
        carRight2 = Instantiate(Prefab_car, posStartCarRight2, Quaternion.identity);
        carRight3 = Instantiate(Prefab_car, posStartCarRight3, Quaternion.identity);
        carRight4 = Instantiate(Prefab_car, posStartCarRight4, Quaternion.identity);


        carLeft1.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carLeft2.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carLeft3.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carLeft4.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];

        Flip_X(carLeft1);
        Flip_X(carLeft2);
        Flip_X(carLeft3);
        Flip_X(carLeft4);

        carRight1.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carRight2.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carRight3.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];
        carRight4.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, Sprite_car.Length)];

        carLeft4.GetComponent<Car>().isDangerous = true;

        carRight1.transform.DOMove(new Vector3(X_rightEnd, yCar1, 0f), 4f, false).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        carLeft2.transform.DOMove(new Vector3(X_leftEnd, yCar2, 0f), 4f, false).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        carRight3.transform.DOMove(new Vector3(X_rightEnd, yCar3, 0f), 4f, false).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(3.5f);
        carLeft4.transform.DOMove(new Vector3(posStartCarRight4.x, yCar4, 0f), 4f, false).SetEase(Ease.Linear);



    }

    IEnumerator Stage_Two()
    {
        while(true)
        {
            int trackNum = Random.Range(1, 5);
            int isFromLeft = Random.Range(0, 2);
            int isDangerous = Random.Range(0, 2);
            Vector3 bornPos = Vector3.zero;
            float targetX;

            switch(trackNum)
            {
                case 1:
                    if (isFromLeft==1)
                        bornPos = posStartCarLeft1;
                    else
                        bornPos = posStartCarRight1;                        
                    break;
                case 2:
                    if (isFromLeft==1)
                        bornPos = posStartCarLeft2;
                    else
                        bornPos = posStartCarRight2;   
                    break;
                case 3:
                    if (isFromLeft==1)
                        bornPos = posStartCarLeft3;
                    else
                        bornPos = posStartCarRight3;   
                    break;
                case 4:
                    if (isFromLeft==1)
                        bornPos = posStartCarLeft4;
                    else
                        bornPos = posStartCarRight4;                 
                    break;
            }



            GameObject newCar = Instantiate(Prefab_car, bornPos, Quaternion.identity);

            newCar.GetComponent<SpriteRenderer>().sprite = Sprite_car[Random.Range(0, 5)];

            if (isFromLeft == 1)
            {
                targetX = X_leftEnd;
                Flip_X(newCar);
            }
            else
            {
                targetX = X_rightEnd;
            }

            if (isDangerous == 0)
            {
                newCar.GetComponent<Car>().isDangerous = false;
    
                newCar.transform.DOMoveX(targetX, Random.Range(4.5f, 6f), false).SetEase(Ease.Linear);
            }
            else
            {
                if (targetX.Equals(X_leftEnd))
                    targetX = X_rightEnd;
                else
                    targetX = X_leftEnd;

                newCar.GetComponent<Car>().isDangerous = true;
                newCar.GetComponent<Car>().Go_Bad();

                int easeCurve = Random.Range(0, 6);
                switch(easeCurve)
                {
                    case 0:
                        newCar.transform.DOMoveX(targetX, Random.Range(4f, 5.5f), false).SetEase(Ease.Linear);
                        break;
                    case 1:
                        newCar.transform.DOMoveX(targetX, Random.Range(5f, 6f), false).SetEase(Ease.InQuart);
                        break;
                    case 2:
                        newCar.transform.DOMoveX(targetX, Random.Range(4.5f, 6f), false).SetEase(Ease.OutCirc);
                        break;
                    case 3:
                        newCar.transform.DOMoveX(targetX, Random.Range(4.5f, 6f), false).SetEase(Ease.InBounce);
                        break;
                    case 4:
                        newCar.transform.DOMoveX(targetX, Random.Range(4.7f, 6.5f), false).SetEase(Ease.InOutQuad);
                        break;
                    case 5:
                        newCar.transform.DOMoveX(targetX, Random.Range(4.7f, 6.5f), false).SetEase(Ease.OutQuint);
                        break;
                }
            }

            yield return new WaitForSeconds(2f);

        }

        yield return null;
    }
}
