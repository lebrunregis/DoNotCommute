using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour
{
    private LinkedList<GameObject> cars = new();

    public LinkedList<GameObject> Cars { get => cars; set => cars = value; }

    public bool HasCar()
    {
        return cars.Count > 0;
    }

    public GameObject GetRandomCar()
    {
        GameObject car = null;
        if (HasCar())
        {
          int randomInt=  Random.Range(0, cars.Count);
            LinkedListNode<GameObject> node = cars.First;
            for (int i = 0; i < randomInt; i++)
            {
                node = node.Next;
            }

            car= node.Value;
            cars.Remove(car);
        }
        return car;
    }
}

