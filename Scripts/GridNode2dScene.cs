using Godot;
/// <summary>
/// 主要功能是绘制一个网格
/// </summary>
[Tool]
public partial class GridNode2dScene : Node2D
{
    //每个属性的设置器中都调用了 QueueRedraw()，以便在属性值改变时触发重绘。
    [Export]
    public bool ShowGrid
    {
        get => showGrid;
        set
        {
            showGrid = value;
            QueueRedraw();
        }
    }

    [Export]
    public Vector2I GridSize
    {
        get => gridSize;
        set
        {
            gridSize = value;
            QueueRedraw();
        }
    }

    [Export]
    public Vector2I CellSize
    {
        get => cellSize;
        set
        {
            cellSize = value;
            QueueRedraw();
        }
    }
    [Export]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            QueueRedraw();
        }
    }

    [Export]
    public float BorderWidth
    {
        get => borderWidth;
        set
        {
            borderWidth = value;
            QueueRedraw();
        }
    }

    private bool showGrid = false;
    private Vector2I gridSize = new Vector2I(10, 10);
    private Vector2I cellSize = new Vector2I(32, 32);
    private Color borderColor = Colors.Yellow;
    private float borderWidth = 1.0f;

    public Rect2 GetCellRect(Vector2I cellPos)
    {
        return new Rect2(cellPos * cellSize, cellSize);
    }

    public override void _Draw()
    {
        if (ShowGrid)
        {
            for (int x = 0; x < GridSize.X; x++)
            {
                for (int y = 0; y < GridSize.Y; y++)
                {
                    Rect2 rect = GetCellRect(new Vector2I(x, y));
                    DrawRect(rect, BorderColor, false, BorderWidth);
                }
            }
        }
    }
}
