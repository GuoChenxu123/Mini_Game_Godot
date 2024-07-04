using Godot;
using Mini_Game_Godot.Entity;
using Mini_Game_Godot.util;
using System;
using System.Collections.Generic;

public partial class load_garbage : Node
{

    private const string garbageJsonPath = "res://Resources/Rubbish.json";
    private static System.Collections.Generic.List<Rubbish> rubbishes;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //把garbageJsonPath路径转化为绝对路径
        string garbageJsonPath = ProjectSettings.GlobalizePath(load_garbage.garbageJsonPath);
        //读取json文件
        rubbishes = JsonToList.getList<Rubbish>(garbageJsonPath);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public static List<Rubbish> getRubbishes()
    {
        return rubbishes;
    }
}
