using Godot;
using Mini_Game_Godot.Entity;
using Mini_Game_Godot.util;
using System.Collections.Generic;

public partial class Mode2Scene : Node
{
    private string garbageJsonPath = "res://Resources/Rubbish.json";

    private GridNode2dScene _gridNode2d;
    private List<Rubbish> _rubbishList;
    private LevelInfoModel2 currentLevel;
    private List<LevelInfoModel2> levels;
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
        _gridNode2d = GetNode<GridNode2dScene>("GridNode2d");
        //把garbageJsonPath路径转化为绝对路径
        string garbageJsonPath = ProjectSettings.GlobalizePath(this.garbageJsonPath);
        //读取json文件
        _rubbishList = JsonToList.getList<Rubbish>(garbageJsonPath);
        //初始化关卡信息
        InitializeLevels();


        if (_gridNode2d != null)
        {
            //调用 GetCellRect 方法
            Vector2I cellPos = new Vector2I(1, 1);
            Rect2 cellRect = _gridNode2d.GetCellRect(cellPos);
            PackedScene garbageIconScene = GD.Load<PackedScene>("res://Scenes/Mode2/garbageIcon.tscn");
            Sprite2D newSprite = garbageIconScene.Instantiate() as Sprite2D;

            // 设置 Sprite 节点的纹理
            newSprite.Texture = GD.Load<Texture2D>("res://" + _rubbishList[0].image);
            newSprite.Centered = false;// 设置 Sprite 节点的锚点

            // 设置 Sprite 节点的位置和大小
            newSprite.Position = cellRect.Position + new Vector2(35f, 23f);
            newSprite.Scale = new Vector2(1f, 1f);
            _gridNode2d.AddChild(newSprite);// 将 Sprite 节点添加到场景中
        }
        else
        {
            GD.Print("GridNode2dScene not found!");
        }
    }

    private void InitializeLevels()
    {
        //初始化关卡信息
        levels = new List<LevelInfoModel2>
            {
                new LevelInfoModel2 { Name = "第 一 关", TrueRequired = 2, FalseAllowed = 0, TimeLimit = 10, Score = 4 , background = "res://Resources/background/background1.png" },
                new LevelInfoModel2 { Name = "第 二 关", TrueRequired = 4, FalseAllowed = 0, TimeLimit = 10 , Score = 4 ,background = "res://Resources/background/background1.png"},
                new LevelInfoModel2 { Name = "第 三 关", TrueRequired = 6, FalseAllowed = 0, TimeLimit = 10 , Score = 4 ,background = "res://Resources/background/background1.png"},
                new LevelInfoModel2 { Name = "第 四 关", TrueRequired = 13, FalseAllowed = 0, TimeLimit = 10, Score = 4 ,background = "res://Resources/background/background1.png"}
            };
        //初始关卡
        currentLevel = levels[0];
    }

    public override void _Process(double delta)
    {

    }
}
