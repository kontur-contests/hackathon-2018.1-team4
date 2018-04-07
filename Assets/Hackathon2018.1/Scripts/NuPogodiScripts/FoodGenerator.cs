using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Hackathon2018._1.NuPogodiScripts
{
    public class FoodGenerator : MonoBehaviour
    {
        private readonly List<GameObject> goodFoodTypes = new List<GameObject>();
        private readonly List<GameObject> badFoodTypes = new List<GameObject>();
        
        private void Start()
        {
            goodFoodTypes.AddRange(GameObject.FindGameObjectsWithTag("GoodFoodPiece").ToArray());
            badFoodTypes.AddRange(GameObject.FindGameObjectsWithTag("BadFoodPiece").ToArray());
            StartCoroutine(Food());
        }

        private IEnumerator Food()
        {
            while (true)
            {
                var currentFood = GetRandomEat();
                var food = currentFood.IsPoison ? GetNotEdibleFood() : GetEdibleFood();
                Instantiate(food, currentFood.Position, Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
        }
	
        private GameObject GetNotEdibleFood()
        {
            return goodFoodTypes[Random.Range(0, goodFoodTypes.Count)];
        }

        private GameObject GetEdibleFood()
        {
            return badFoodTypes[Random.Range(0, badFoodTypes.Count)];
        }

        private static Food GetRandomEat()
        {
            var random = new System.Random();
		
            var positions = new[]
            {
                new Vector3(12, 2.3f), new Vector3(12, 4), new Vector3(12, 8),  
                new Vector3(-13, 2), new Vector3(-13, 4), new Vector3(-13, 8)   
            };

            var randomPosition = random.Next(0, 6);
            var height = GetHeight(randomPosition);
            var hor = GetHorisontal(randomPosition);
            var isPoison = new[] {true, false}[random.Next(0,2)];
            
            return new Food(isPoison, positions[randomPosition], height, hor);
        }

        private static StateEnum GetHeight(int position)
        {
            switch (position)
            {
                    case 0:
                        return StateEnum.Down;
                    case 1:
                        return StateEnum.Mid;
                    case 2:
                        return StateEnum.Up;
                    case 3:
                        return StateEnum.Down;
                    case 4:
                        return StateEnum.Mid;
                    case 5:
                        return StateEnum.Up;
            }

            return StateEnum.Down;
        }

        private static Horisontal GetHorisontal(int position)
        {
            switch (position)
            {
                case 0:
                case 1:
                case 2:
                    return Horisontal.Right;
                case 3:
                case 4:
                case 5:
                    return Horisontal.Left;
            }

            return Horisontal.Left;
        }

    }
}