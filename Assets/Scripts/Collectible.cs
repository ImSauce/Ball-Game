// using UnityEngine;

// public class Collectible : MonoBehaviour
// {
//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             // Tell manager we got one
//             CollectibleManager manager = Object.FindFirstObjectByType<CollectibleManager>();
//             if (manager != null)
//             {
//                 manager.AddCollectible();
//             }

//             // Destroy the collectible object
//             Destroy(gameObject);
//         }
//     }
// }