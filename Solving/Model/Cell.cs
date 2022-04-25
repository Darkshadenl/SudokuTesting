using System.Collections;

namespace Solving.Model;

public class Cell : ICell
{
    public int Value { get; set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Box { get; private set; }

    private Cell _right;

    private int[] _boardSize;
    private int _amountBoxes = 3;
    private double _horizontalBox = -1;
    private double _verticalBox = -1;

    public double[] boardBox
    {
        get
        {
            if (_horizontalBox == -1 || _verticalBox == -1)
            {
                CalculateWhichBox();
            }

            return new double[] {_horizontalBox, _verticalBox};
        }
    }


    public Cell(int[] boardSize)
    {
        Value = -1;
        _boardSize = boardSize;
    }


    public List<Cell> CreateCellToYourRight(Stack<int> remainingValues, List<Cell> cells, int verticalLine)
    {
        X = remainingValues.Count;
        Y = verticalLine;

        if (X > 0)
        {
            Value = remainingValues.Pop();

            if (remainingValues.Count > 0) {
                _right = new Cell(_boardSize);
                cells.Add(this);
                _right.CreateCellToYourRight(remainingValues, cells, verticalLine);
            }
        }

        return cells;
    }

    public bool isEmpty()
        {
            return Value == 0;
        }

        private void CalculateWhichBox()
        {
            var xSize = Convert.ToDouble(_boardSize[0]);
            var ySize = Convert.ToDouble(_boardSize[1]);

            var sizeOfHorizontalBox = Math.Round(xSize / _amountBoxes); // 3
            var sizeOfVerticalBox = Math.Round(ySize / _amountBoxes); // 3

            double tempSizeX = sizeOfHorizontalBox;
            double tempSizeY = sizeOfVerticalBox;

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