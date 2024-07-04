using Godot;
using System;

public partial class garbageIconScene : Node2D
{
    [Export]
    public string Garbageid;// 垃圾类型ID
    [Export]
    public string Garbagename;// 垃圾类型名称
    [Export]
    public int Garbagedescription;// 垃圾类型描述
    [Export]
    public string GarbageiconPath;// 垃圾类型图标路径
    Area2D area2D;
    public override void _Ready()
	{
        area2D = GetNode<Area2D>("textureArea");
    }
	public override void _Process(double delta)
	{
      
    }

   
 
}
