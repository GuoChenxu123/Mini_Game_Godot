using Godot;
using System;

public partial class main : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnButtonClick_btn2()
	{
		PackedScene mode2 = GD.Load<PackedScene>("res://Scenes/Mode2/Mode2.tscn");
		//清空场景树
		//GetTree().Root.Call("clear_children");
		//实例化mode2场景
		Node mode2_node = mode2.Instantiate();
		//添加到场景树
		GetTree().Root.AddChild(mode2_node);
	}

	public void OnButtonClick_exit()
	{
		GetTree().Quit();
	}
}
