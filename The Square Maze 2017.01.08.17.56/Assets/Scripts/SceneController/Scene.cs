using UnityEngine;


public class Scene : MonoBehaviour
{
    public class Properties
    {
        public PositionMaze positionMaze = new PositionMaze();
		public int id {
			get;
			set;
		}

		public Properties()
		{
			this.id = Random.Range(0,1000);
		}

    }

	public class PositionMaze
	{
		public int x { get; set; }
		public int y { get; set; }
	}

	public class ScenePath<X>
    {
		public ScenePath<X> left;
		public ScenePath<X> top;
		public ScenePath<X> right;
		public ScenePath<X> bottom;

		public Properties properties;

		public ScenePath(){
			properties = new Properties();
		}

    }

	public void changeScene(ref ScenePath<Properties> currentScene)
    {
        //ScenePath<Properties> startScene = new ScenePath<Properties>();

        //startScene.properties.positionMaze.x = 0;
        //startScene.properties.positionMaze.y = 0;

		generateScene(ref currentScene, Sides.LEFT);
		generateScene(ref currentScene, Sides.TOP);
		generateScene(ref currentScene, Sides.RIGHT);
		generateScene(ref currentScene, Sides.BOTTOM);

        //return startScene;
        
    }

	public void onChangeScene()
	{
		
	}

    void generateScene(ref ScenePath<Properties> currentScene, int createToSide)
    {
        switch (createToSide)
        {
            case Sides.LEFT:
                {
                    ScenePath<Properties> newSceneLeft = new ScenePath<Properties>();
                    newSceneLeft.right = currentScene;
                    newSceneLeft.properties.positionMaze.x = currentScene.properties.positionMaze.x - 1;
                    newSceneLeft.properties.positionMaze.y = currentScene.properties.positionMaze.y;


                    if (currentScene.top != null)
                        if (currentScene.top.left != null)
                            if (currentScene.top.left.bottom != null)
                                return;// currentScene.top.left.bottom;
                            else
                            {
                                newSceneLeft.top = currentScene.top.left;
                                currentScene.top.left.bottom = newSceneLeft;
                            }

                    if (currentScene.bottom != null)
                        if (currentScene.bottom.left != null)
                            if (currentScene.bottom.left.top != null)
                                return;// currentScene.bottom.left.top;
                            else
                            {
                                newSceneLeft.bottom = currentScene.bottom.left;
                                currentScene.bottom.left.top = newSceneLeft;
                            }

                    currentScene.left = newSceneLeft;
                    break;
                }
            case Sides.TOP:
                {

                    ScenePath<Properties> newSceneTop = new ScenePath<Properties>();
                    newSceneTop.bottom = currentScene;
                    newSceneTop.properties.positionMaze.x = currentScene.properties.positionMaze.x;
                    newSceneTop.properties.positionMaze.y = currentScene.properties.positionMaze.y + 1;

                    if (currentScene.left != null)
                        if (currentScene.left.top != null)
                            if (currentScene.left.top.right != null)
                                return;// currentScene.left.top.right;
                            else
                            {
                                newSceneTop.left = currentScene.left.top;
                                currentScene.left.top.right = newSceneTop;
                            }

                    if (currentScene.right != null)
                        if (currentScene.right.top != null)
                            if (currentScene.right.top.left != null)
                                return;// currentScene.right.top.left;
                            else
                            {
                                newSceneTop.right = currentScene.right.top;
                                currentScene.right.top.left = newSceneTop;
                            }

                    currentScene.top = newSceneTop;
                    break;

                }
            case Sides.RIGHT:
                {
                    ScenePath<Properties> newSceneRight = new ScenePath<Properties>();
                    newSceneRight.left = currentScene;
                    newSceneRight.properties.positionMaze.x = currentScene.properties.positionMaze.x + 1;
                    newSceneRight.properties.positionMaze.y = currentScene.properties.positionMaze.y;


                    if (currentScene.top != null)
                        if (currentScene.top.right != null)
                            if (currentScene.top.right.bottom != null)
                                return;// currentScene.top.right.bottom;
                            else
                            {
                                newSceneRight.top = currentScene.top.right;
                                currentScene.top.right.bottom = newSceneRight;
                            }

                    if (currentScene.bottom != null)
                        if (currentScene.bottom.right != null)
                            if (currentScene.bottom.right.top != null)
                                return;// currentScene.bottom.right.top;
                            else
                            {
                                newSceneRight.bottom = currentScene.bottom.right;
                                currentScene.bottom.right.top = newSceneRight;
                            }

					currentScene.right = newSceneRight;
                    break;
                }

            case Sides.BOTTOM:
                {
                    ScenePath<Properties> newSceneBottom = new ScenePath<Properties>();
                    newSceneBottom.top = currentScene;
                    newSceneBottom.properties.positionMaze.x = currentScene.properties.positionMaze.x;
                    newSceneBottom.properties.positionMaze.y = currentScene.properties.positionMaze.y - 1;

                    if (currentScene.left != null)
                        if (currentScene.left.bottom != null)
                            if (currentScene.left.bottom.right != null)
                                return; // currentScene.left.bottom.right;
                            else
                            {
                                newSceneBottom.left = currentScene.left.bottom;
                                currentScene.left.bottom.right = newSceneBottom;
                            }

                    if (currentScene.right != null)
                        if (currentScene.right.bottom != null)
                            if (currentScene.right.bottom.left != null)
                                return; // currentScene.right.bottom.left;
                            else
                            {
                                newSceneBottom.right = currentScene.right.bottom;
                                currentScene.right.bottom.left = newSceneBottom;
                            }

                    currentScene.bottom = newSceneBottom;

                    break;
                }
            default:
                {
                    break
                        ;
                }

        }
    }


}
