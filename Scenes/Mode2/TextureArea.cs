using Godot;
using System;

public partial class TextureArea : Area2D
{

    // 信号用于处理点击事件
    [Signal]
    public delegate void TextureClickedEventHandler();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.InputEvent += this.OnInputEvent;

    }

    private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.ButtonIndex == MouseButton.Left && mouseEvent.Pressed)
        {
            EmitSignal(nameof(TextureClicked));
        }
    }
}
