using System.Collections;

namespace Solving.Model;

public class Cell : Component
{
    public int Value { get; set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    private Cell _right;

    private int[] _boardSize;
    private int _amountBoxes = 3;
    private decimal _horizontalBox = -1;
    private decimal _verticalBox = -1;

    public decimal[] boardBox
    {
        get
        {
            if (_horizontalBox == -1 || _verticalBox == -1)
            {
                CalculateWhichBox();
            }

            return new decimal[] {_horizontalBox, _verticalBox};
        }
    }

    private int[] _boxPosses;

    public int[] boardBoxInteger
    {
        get
        {
            if (_boxPosses == null)
            {
                _boxPosses = new int[2];
                _boxPosses[0] = X % 3;
                _boxPosses[1] = Y % 3;
            }
            return _boxPosses;
        }
    }


    public Cell(int[] boardSize)
    {
        Value = -1;
        _boardSize = boardSize;
    }

    public override void add(Component c)
    {
        throw new NotImplementedException();
    }
    
    public override bool IsComposite()
    {
        return false;
    }

    public List<Cell> CreateCellToYourRight(Queue<int> remainingValues, List<Cell> cells,
        int verticalLine, int ColNr)
    {
        X = ColNr;
        Y = verticalLine;
        Value = remainingValues.Dequeue();

        if (remainingValues.Count > 0)
        {
            _right = new Cell(_boardSize);
            cells.Add(this);
            cells = _right.CreateCellToYourRight(remainingValues, cells, 
                verticalLine, ColNr + 1);
        }
        else
        {
            cells.Add(this);
        }

        return cells;
    }

    public override bool isEmpty()
    {
        return Value == 0;
    }

    private void CalculateWhichBox()
    {
        var xSize = Convert.ToDecimal(_boardSize[0]);
        var ySize = Convert.ToDecimal(_boardSize[1]);

        var sizeOfHorizontalBox = Math.Round(xSize / _amountBoxes); // 3
        var sizeOfVerticalBox = Math.Round(ySize / _amountBoxes); // 3

        decimal tempSizeX = sizeOfHorizontalBox;
        decimal tempSizeY = sizeOfVerticalBox;

        while (_horizontalBox == -1)
        {
            if (tempSizeX < X)
                tempSizeX += sizeOfHorizontalBox;
            else if (tempSizeX >= X)
                _horizontalBox = Math.Round(tempSizeX / sizeOfHorizontalBox);
        }

        while (_verticalBox == -1)
        {
            if (tempSizeY < Y)
                tempSizeY += sizeOfVerticalBox;
            else if (tempSizeY >= Y)
                _verticalBox = Math.Round(tempSizeY / sizeOfVerticalBox);
        }
    }
}