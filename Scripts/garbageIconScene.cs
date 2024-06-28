using Godot;
using System;

public partial class garbageIconScene : Sprite2D
{
	[Signal]
	public delegate void GarbageIconClickedEventHandler();
    private bool isFading = false;
    private float fadeSpeed = 0.5f; // 淡出速度，可以根据需要调整
    private float targetAlpha = 1.0f; // 目标透明度
    public override void _Ready()
	{
        // 确保节点有一个 ShaderMaterial
        if (this.Material is ShaderMaterial shaderMaterial)
        {
            // 初始化 AlphaParameter 为 0
            shaderMaterial.SetShaderParameter("AlphaParameter", 0.0f);
        }
    }

	public override void _Process(double delta)
	{
        if (isFading)
        {
            // 获取当前的 AlphaParameter 值
            float currentAlpha = (this.Material as ShaderMaterial).GetShaderParameter("AlphaParameter").AsSingle();

            // 计算新的 AlphaParameter 值
            float newAlpha = Mathf.Min(currentAlpha + (float)delta * fadeSpeed, targetAlpha);

            // 设置新的 AlphaParameter 值
            (this.Material as ShaderMaterial).SetShaderParameter("AlphaParameter", newAlpha);

            // 如果达到目标透明度，停止淡出
            if (newAlpha >= targetAlpha)
            {
                isFading = false;
                this.Dispose();
            }
        }

        // 被点击时并且点击的是该节点时，触发 GarbageIconClicked 信号
        /* if (Input.IsActionJustPressed("左键") && this.IsVisibleInTree() && this.GetRect().HasPoint(GetGlobalMousePosition()))*/
        if (Input.IsActionJustPressed("左键"))
        {
            EmitSignal(nameof(GarbageIconClicked));
            isFading = true;
        }
    }
}
