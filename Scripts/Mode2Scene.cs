using Godot;
using Mini_Game_Godot.Entity;
using System.Collections.Generic;

public partial class Mode2Scene : Node
{


    private GridNode2dScene _gridNode2d;
    private List<Rubbish> _rubbishList;
    private LevelInfoModel2 currentLevel;
    private List<LevelInfoModel2> levels;
    private int _state;//状态
    List<Vector2I> vector2s;
    public int tongType = 1;

    /*private int _score;
	private int _level;
	private int _maxLevel;
	private int _currentLevel;
	private int _currentScore;
	private int _currentRubbishCount;
	private int _maxRubbishCount;
	private int _currentRubbishSpeed;
	private int _maxRubbishSpeed;
	private int _currentRubbishInterval;
	private int _maxRubbishInterval;
	private int _currentRubbishDuration;
	private int _maxRubbishDuration;
	private int _currentRubbishScore;
	private int _maxRubbishScore;
	private int _currentRubbishIntervalScore;
	private int _maxRubbishIntervalScore;
	private int _currentRubbishDurationScore;
	private int _maxRubbishDurationScore;
	private int _currentRubbishSpeedScore;
	private int _maxRubbishSpeedScore;*/
    public override void _Ready()
    {
        //表格绘制顺序
        vector2s = new List<Vector2I> {
            new Vector2I(2,1),
            new Vector2I(2,2),
            new Vector2I(3,1),
            new Vector2I(3,2),
            new Vector2I(0,0),
            new Vector2I(5,0),
            new Vector2I(0,3),
            new Vector2I(5,3),
            new Vector2I(1,1),
            new Vector2I(4,1),
            new Vector2I(1,2),
            new Vector2I(4,2),
            new Vector2I(2,0),
            new Vector2I(3,0),
            new Vector2I(2,3),
            new Vector2I(3,3),
            new Vector2I(1,0),
            new Vector2I(4,0),
            new Vector2I(1,3),
            new Vector2I(4,3),
            new Vector2I(0,1),
            new Vector2I(5,1),
            new Vector2I(0,2),
            new Vector2I(5,2),

        };
        //加载垃圾信息
        _rubbishList = load_garbage.getRubbishes();
        //初始化关卡信息
        InitializeLevels();
        //初始化GridNode2d
        _gridNode2d = GetNode<GridNode2dScene>("GridNode2d");
        ShowGarbageOnGrid();
    }
    //初始化关卡信息
    private void InitializeLevels()
    {
        levels = new List<LevelInfoModel2>
            {
                new LevelInfoModel2 { Name = "第 一 关", TrueRequired = 2, FalseAllowed = 0, TimeLimit = 10, Score = 4 , background = "res://Resources/background/background1.png" ,number_of_garbage = 4},
                new LevelInfoModel2 { Name = "第 二 关", TrueRequired = 4, FalseAllowed = 0, TimeLimit = 10 , Score = 4 ,background = "res://Resources/background/background1.png" , number_of_garbage = 8},
                new LevelInfoModel2 { Name = "第 三 关", TrueRequired = 6, FalseAllowed = 0, TimeLimit = 10 , Score = 4 ,background = "res://Resources/background/background1.png" , number_of_garbage = 12},
                new LevelInfoModel2 { Name = "第 四 关", TrueRequired = 13, FalseAllowed = 0, TimeLimit = 10, Score = 4 ,background = "res://Resources/background/background1.png" , number_of_garbage = 24}
            };
        //初始关卡
        currentLevel = levels[0];
    }
    public override void _Process(double delta)
    {

    }
    public void OnButtonClick_returnGame()
    {
        QueueFree();
    }

    public void ShowGarbageOnGrid()
    {
        for (int i = 0; i < currentLevel.number_of_garbage; i++)
        {
            if (_gridNode2d != null)
            {
                //调用 GetCellRect 方法
                Vector2I cellPos = vector2s[i];
                Rect2 cellRect = _gridNode2d.GetCellRect(cellPos);
                PackedScene garbageIconScene = GD.Load<PackedScene>("res://Scenes/Mode2/garbageIcon.tscn");
                Node2D newSprite = garbageIconScene.Instantiate() as Node2D;
                _gridNode2d.AddChild(newSprite);// 将 Sprite 节点添加到场景中

                newSprite.Set("Garbageid", _rubbishList[i].id.ToString());
                newSprite.Set("GarbageiconPath", _rubbishList[i].image);
                newSprite.Set("Garbagename", _rubbishList[i].name);
                Sprite2D textureSprite = newSprite.GetChildren()[0].GetChildren()[0] as Sprite2D;
                textureSprite.Centered = false;
                // 设置 Sprite 节点的位置和大小
                textureSprite.Position = cellRect.Position + new Vector2(35f, 23f);
                textureSprite.Scale = new Vector2(1f, 1f);
                textureSprite.Texture = GD.Load<Texture2D>("res://" + newSprite.Get("GarbageiconPath"));// 设置 Sprite 节点的纹理

                // 确保 TextureArea 节点存在并且是 TextureArea 类型
                if (newSprite.HasNode("TextureArea"))
                {
                    TextureArea textureArea = newSprite.GetNode<TextureArea>("TextureArea");
                    // 连接 TextureArea 节点的 TextureClicked 信号到 OnTextureClicker 方法
                    Callable callable = new Callable(this, nameof(OnTextureClicker));
                    //callable = callable.Bind(i); // 绑定参数
                    textureArea.Connect(nameof(TextureArea.TextureClicked), callable);
                }

                    //Area2D textureArea = (Area2D)newSprite.GetNode("textureArea");
                // 连接 TextureArea 节点的 TextureClicked 信号到 OnTextureClicker 方法
                //Callable callable = new Callable(this, "OnTextureClicker");
                //callable = (Callable)callable.Call(i);

                //textureArea.Connect(nameof(TextureArea.TextureClicked), new Callable(this  , "OnTextureClicker" ));
               /* GD.Print("Node found, type: " + textureAreaInstance.GetType().FullName);
                if (textureAreaInstance != null && textureAreaInstance is TextureArea)
                {
                    TextureArea textureArea = (TextureArea)textureAreaInstance;
                    textureArea.TextureClicked += () =>
                    {
                        // 点击纹理区域
                        OnTextureClicker(i);
                    };
                }*/

            }
            else
            {
                GD.Print("GridNode2dScene not found!");
            }
        }
    }

    private void OnTextureClicker()
    {
        GD.Print("Texture ", " clicked" );
    }
}
