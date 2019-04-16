using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    float explodeTime;
    SpriteRenderer m_renderer;
    CircleCollider2D m_collider;
    public int frequency_colorChange;

    public GameObject Fx_boom;

	// Use this for initialization
	void Start () {
        m_renderer = this.gameObject.GetComponent<SpriteRenderer>();
        m_collider = GetComponent<CircleCollider2D>();  
        explodeTime = AimingManager.instance.explodeTime;

        StartCoroutine(Count_Down());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Count_Down()
    {
        for (int i = 0; i < frequency_colorChange; i++)
        {
            yield return new WaitForSeconds(explodeTime / frequency_colorChange / 2);
            m_renderer.color = Color.red;
            yield return new WaitForSeconds(explodeTime / frequency_colorChange / 2);
            m_renderer.color = Color.white;
        }
        Explode();
        yield return null;
    }

    void Explode()
    {
        GameObject newFx = Instantiate(Fx_boom, transform.position, transform.rotation);
        this.gameObject.tag = "Bomb";
        m_renderer.enabled = false;
        m_collider.enabled = true;
        SoundManager.instance.Play_Sound(Sounds.爆炸聲);
        Destroy(this.gameObject, 0.7f);
    }
}
