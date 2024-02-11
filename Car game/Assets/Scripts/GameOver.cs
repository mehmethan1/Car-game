using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject explosionPrefab; // Patlama efektini içeren prefab
    public GameObject explosionText; // Patlama efektini içeren prefab
    public GameObject RoadSpawner, ObstacleSpawner;
    public GameObject GameOverPanel;
    public GameObject Camera;


    private void OnTriggerEnter(Collider other)
    {
        Vector3 Bombtransform = new Vector3(this.transform.position.x, 1.5f, -2.11f);
        if (other.tag == "Obstacle")
        {
            //EFECT
            GameObject bomb = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameObject bombText = Instantiate(explosionText, Bombtransform, Quaternion.identity);
            StartCoroutine(Shake(1.0f, 0.1f)); // Shake metodu çağrılıyor
            //Destroy
            Destroy(ObstacleSpawner);
            RoadSpawner.SetActive(false);


            //scenedeki Police ve roadları bul yok et
            Police[] police = FindObjectsOfType<Police>();
            if (police.Length > 0)
            {
                foreach (Police foundPolice in police)
                {
                    foundPolice.Explode();
                }
            }

            Road[] road = FindObjectsOfType<Road>();
            if (road.Length > 0)
            {
                foreach (Road foundroad in road)
                {
                    foundroad.Explode();
                }
            }

            Player[] player = FindObjectsOfType<Player>();

            foreach (Player foundplayer in player)
            {
               foundplayer.EndGame();
            }
            
            //Game Over Paneli aktif et
            GameOverPanel.SetActive(true);
        }

    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orginalpos = Camera.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.transform.localPosition = new Vector3(orginalpos.x + x, orginalpos.y + y, orginalpos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }
        Camera.transform.localPosition = orginalpos;
    }


}