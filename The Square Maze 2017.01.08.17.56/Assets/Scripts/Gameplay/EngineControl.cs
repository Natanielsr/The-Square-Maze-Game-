using UnityEngine;
using System.Collections;

public class EngineControl : MonoBehaviour {

    public Scene.ScenePath<Scene.Properties> currentScene;
	public Transform player;

	public int x;
	public int y;

    // Use this for initialization
    void Start ()
    {
		currentScene = new Scene.ScenePath<Scene.Properties> ();
		currentScene.properties.positionMaze.x = 0;
		currentScene.properties.positionMaze.y = 0;
		new Scene().changeScene(ref currentScene);
		setPosition();
	}

	private void setPosition()
	{
		x = currentScene.properties.positionMaze.x;
		y = currentScene.properties.positionMaze.y;
		Debug.Log ("X = "+x+", Y = "+y);
		Debug.Log ("id: "+currentScene.properties.id);
	}

	// Update is called once per frame
	void Update () 
	{

		if (player.position.x < -7)
		{
			
			changeScene(currentScene.left);

		}
		else if(player.position.x > 7)
		{
			changeScene(currentScene.right);
		}
		else if(player.position.y < -5)
		{
			changeScene(currentScene.bottom);
		}
		else if(player.position.y > 5)
		{
			changeScene(currentScene.top);
		}


		//Debug.Log ("X = "+player.position.x+", Y = "+player.position.y);
	}

	public void changeScene(Scene.ScenePath<Scene.Properties> newSide)
	{
		//Debug.Log ("Chamou a função");
		player.position = new Vector3 (0, 0, 0);

		new Scene().changeScene(ref newSide);
		currentScene = newSide;
		setPosition();
	}
}
