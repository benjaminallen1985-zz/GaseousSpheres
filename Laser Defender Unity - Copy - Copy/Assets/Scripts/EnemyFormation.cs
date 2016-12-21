using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {
	public GameObject projectile;
	public float health = 150;	
	public float projectileSpeed = 10;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability) {
			Fire();
		}
	}
	
	void Fire() {
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
		GameObject missle = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		missle.rigidbody2D.velocity = new Vector2(0f, -projectileSpeed);		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missle = collider.gameObject.GetComponent<Projectile>();
		if(missle){
			health -= missle.GetDamage();
			missle.Hit();
			if(health <= 0) {
				Die();
			}
		}
	}
	
	void Die() {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
	}
}
