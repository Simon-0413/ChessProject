namespace ChessProject
{
    public partial class ChessBoard : Form
    {
        private bool isFirstButtonClicked = false;
        private Button firstButton = new Button();
        private Button secondButton = new Button();
        private bool isBlackTurn = false;


        private Dictionary<char, int> colDict = new Dictionary<char, int> {
                {'A', 1},
                {'B', 2},
                {'C', 3},
                {'D', 4},
                {'E', 5},
                {'F', 6},
                {'G', 7},
                {'H', 8}
            };

        public ChessBoard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int buttonSize = 100;  // Desired button size in pixels
            int spacing = 0;     // Desired spacing between buttons in pixels

            int currentTop = 0;
            int currentLeft = 0;

            foreach (var FieldButton in Controls.OfType<FieldButton>())
            {
                FieldButton.FlatStyle = FlatStyle.Flat;
                FieldButton.FlatAppearance.MouseOverBackColor = FieldButton.BackColor;
                FieldButton.FlatAppearance.MouseDownBackColor = FieldButton.BackColor;
                FieldButton.FlatAppearance.MouseOverBackColor = FieldButton.BackColor;
                FieldButton.Size = new Size(buttonSize, buttonSize);
                FieldButton.Location = new Point(currentLeft, currentTop);

                currentLeft += buttonSize + spacing;

                if (currentLeft + buttonSize > this.ClientSize.Width)
                {
                    currentLeft = 0;
                    currentTop += buttonSize + spacing;
                }
            }

            btnA8.Tag = "BlRook".ToString();
            btnB8.Tag = "BlKnight".ToString();
            btnC8.Tag = "BlBishop".ToString();
            btnD8.Tag = "BlQueen".ToString();
            btnE8.Tag = "BlKing".ToString();
            btnF8.Tag = "BlBishop".ToString();
            btnG8.Tag = "BlKnight".ToString();
            btnH8.Tag = "BlRook".ToString();

            btnA7.Tag = "BlPawn".ToString();
            btnB7.Tag = "BlPawn".ToString();
            btnC7.Tag = "BlPawn".ToString();
            btnD7.Tag = "BlPawn".ToString();
            btnE7.Tag = "BlPawn".ToString();
            btnF7.Tag = "BlPawn".ToString();
            btnG7.Tag = "BlPawn".ToString();
            btnH7.Tag = "BlPawn".ToString();

            btnA1.Tag = "Rook".ToString();
            btnB1.Tag = "Knight".ToString();
            btnC1.Tag = "Bishop".ToString();
            btnD1.Tag = "Queen".ToString();
            btnE1.Tag = "King".ToString();
            btnF1.Tag = "Bishop".ToString();
            btnG1.Tag = "Knight".ToString();
            btnH1.Tag = "Rook".ToString();

            btnA2.Tag = "Pawn".ToString();
            btnB2.Tag = "Pawn".ToString();
            btnC2.Tag = "Pawn".ToString();
            btnD2.Tag = "Pawn".ToString();
            btnE2.Tag = "Pawn".ToString();
            btnF2.Tag = "Pawn".ToString();
            btnG2.Tag = "Pawn".ToString();
            btnH2.Tag = "Pawn".ToString();

            btnA6.Tag = "Empty".ToString();
            btnB6.Tag = "Empty".ToString();
            btnC6.Tag = "Empty".ToString();
            btnD6.Tag = "Empty".ToString();
            btnE6.Tag = "Empty".ToString();
            btnF6.Tag = "Empty".ToString();
            btnG6.Tag = "Empty".ToString();
            btnH6.Tag = "Empty".ToString();

            btnA5.Tag = "Empty".ToString();
            btnB5.Tag = "Empty".ToString();
            btnC5.Tag = "Empty".ToString();
            btnD5.Tag = "Empty".ToString();
            btnE5.Tag = "Empty".ToString();
            btnF5.Tag = "Empty".ToString();
            btnG5.Tag = "Empty".ToString();
            btnH5.Tag = "Empty".ToString();

            btnA4.Tag = "Empty".ToString();
            btnB4.Tag = "Empty".ToString();
            btnC4.Tag = "Empty".ToString();
            btnD4.Tag = "Empty".ToString();
            btnE4.Tag = "Empty".ToString();
            btnF4.Tag = "Empty".ToString();
            btnG4.Tag = "Empty".ToString();
            btnH4.Tag = "Empty".ToString();

            btnA3.Tag = "Empty".ToString();
            btnB3.Tag = "Empty".ToString();
            btnC3.Tag = "Empty".ToString();
            btnD3.Tag = "Empty".ToString();
            btnE3.Tag = "Empty".ToString();
            btnF3.Tag = "Empty".ToString();
            btnG3.Tag = "Empty".ToString();
            btnH3.Tag = "Empty".ToString();

        }

        private void Castling(Button sourceButton, Button targetButton)
        {
            throw new NotImplementedException();
        }

        private void ButtonClick(Button clickedButton)
        {

            if (!isFirstButtonClicked)
            {
                isFirstButtonClicked = true;
                firstButton = clickedButton;
                clickedButton.BackColor = Color.Yellow;
            }
            else
            {
                isFirstButtonClicked = false;
                secondButton = clickedButton;

                int sourceRow = GetRowFromButtonName(firstButton.Name);
                int sourceCol = GetColFromButtonName(firstButton.Name);
                int targetRow = GetRowFromButtonName(secondButton.Name);
                int targetCol = GetColFromButtonName(secondButton.Name);

                int direction = targetRow - sourceRow;
                int colDifference = Math.Abs(targetCol - sourceCol);

                if (firstButton != secondButton)
                {
                    firstButton.BackColor = GetResetColor(firstButton, secondButton, direction, colDifference);
                }
                else
                {
                    firstButton.BackColor = GetResetColor(firstButton, secondButton, direction, colDifference);
                }

                switch (firstButton.Tag.ToString())
                {
                    case "Pawn":
                    case "BlPawn":
                        MovePawn(firstButton, secondButton);
                        break;

                    case "Rook":
                    case "BlRook":
                        MoveRook(firstButton, secondButton);
                        break;

                    case "Knight":
                    case "BlKnight":
                        MoveKnight(firstButton, secondButton);
                        break;

                    case "Bishop":
                    case "BlBishop":
                        MoveBishop(firstButton, secondButton);
                        break;

                    case "Queen":
                    case "BlQueen":
                        MoveQueen(firstButton, secondButton);
                        break;

                    case "King":
                    case "BlKing":
                        if ((firstButton.Name == "btnE8" && secondButton.Name == "btnH8") || (firstButton.Name == "btnE1" && secondButton.Name == "btnH1") || (firstButton.Name == "btnE8" && secondButton.Name == "btnA8") || (firstButton.Name == "btnE1" && secondButton.Name == "btnA1"))
                        {

                            if (CheckForObstacleHorizontal(ref firstButton, ref secondButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item1 == false)
                            {
                                Castling(firstButton, secondButton);
                                break;
                            }
                            else
                            {
                                firstButton.BackColor = GetResetColor(firstButton, secondButton, direction, colDifference);
                                break;
                            }

                        }
                        else
                        {
                            MoveKing(firstButton, secondButton);
                            break;
                        }

                }
            }
        }

        private Tuple<bool, bool> CheckForObstacleHorizontal(ref Button sourceButton, ref Button targetButton, ref int sourceRow, ref int targetRow, ref int sourceCol, ref int targetCol, ref int direction, ref int colDifference)
        {
            //tuple values = (isObstacleInTheWay, canCatch)
            //canCatch is true when the the only obstacle is an enemy piece on the targetSquare  

            int rowStep = (targetRow > sourceRow) ? 1 : 0;
            int colStep = (targetCol > sourceCol) ? 1 : 0;

            int currentRow = sourceRow + rowStep;
            int currentCol = sourceCol + colStep;

            if (rowStep == 1 && colStep == 0)
            {
                while (currentRow <= targetRow)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentRow += rowStep;

                }
            }
            else if (rowStep == 0 && colStep == 1)
            {
                while (currentRow >= targetRow && currentCol >= targetCol)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentCol += colStep;

                }
            }
            return Tuple.Create(false, false);
        }

        private Tuple<bool, bool> CheckForObstacleDiagonal(ref Button sourceButton, ref Button targetButton, ref int sourceRow, ref int targetRow, ref int sourceCol, ref int targetCol, ref int direction, ref int colDifference)
        {
            //tuple values = (isObstacleInTheWay, canCatch)
            //canCatch is true when the the only obstacle is an enemy piece on the targetSquare  

            int rowStep = (targetRow > sourceRow) ? 1 : -1;
            int colStep = (targetCol > sourceCol) ? 1 : -1;

            int currentRow = sourceRow + rowStep;
            int currentCol = sourceCol + colStep;

            if (rowStep == 1 && colStep == 1)
            {
                while (currentRow <= targetRow && currentCol <= targetCol)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentRow += rowStep;
                    currentCol += colStep;

                }
                return Tuple.Create(false, false);
            }
            else if (rowStep == -1 && colStep == -1)
            {
                while (currentRow >= targetRow && currentCol >= targetCol)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentRow += rowStep;
                    currentCol += colStep;

                }
                return Tuple.Create(false, false);
            }
            else if (rowStep == -1 && colStep == 1)
            {
                while (currentRow >= targetRow && currentCol <= targetCol)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentRow += rowStep;
                    currentCol += colStep;

                }
                return Tuple.Create(false, false);
            }
            else if (rowStep == 1 && colStep == -1)
            {
                while (currentRow <= targetRow && currentCol >= targetCol)
                {
                    Button? currentButton = GetButtonFromRowCol(currentRow, currentCol);

                    if (currentButton?.Tag.ToString() != "Empty")
                    {
                        if (targetButton.Name == currentButton?.Name)
                        {
                            string currentButtonTag = currentButton.Tag?.ToString() ?? string.Empty;

                            if ((isBlackTurn && !currentButtonTag.StartsWith("Bl")) ||
                                (!isBlackTurn && currentButtonTag.StartsWith("Bl")))
                            {
                                return Tuple.Create(true, true);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return Tuple.Create(true, false);
                            }
                        }

                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        return Tuple.Create(true, false);
                    }

                    currentRow += rowStep;
                    currentCol += colStep;

                }
                return Tuple.Create(false, false);
            }
            return Tuple.Create(false, false);
        }

        private bool CheckForCheck()
        {
            throw new NotImplementedException();
        }

        private bool CheckForCheckMate()
        {
            throw new NotImplementedException();
        }

        private void MovePiece(ref Button sourceButton, ref Button targetButton)
        {

            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = targetRow - sourceRow;
            int colDifference = Math.Abs(targetCol - sourceCol);

            targetButton.Image = sourceButton.Image;
            targetButton.Tag = sourceButton.Tag;
            sourceButton.Image = null;
            sourceButton.Tag = "Empty";
            isBlackTurn = !isBlackTurn;
            sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
        }

        private void MovePawn(Button sourceButton, Button targetButton)
        {
            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = targetRow - sourceRow;
            int colDifference = Math.Abs(targetCol - sourceCol);

            if ((direction == 1 && colDifference == 0) || (sourceRow == 2 && direction == 2 && colDifference == 0) || (sourceRow == 7 && direction == -2 && colDifference == 0) || (direction == 1 && colDifference == 1))
            {
                if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                {
                    if (targetButton.Tag.ToString() == "Empty")
                    {
                        if (direction == 2 && colDifference == 0)
                        {
                            int middleRow;
                            if (!isBlackTurn)
                            {
                                middleRow = sourceRow + 1;
                            }
                            else
                            {
                                middleRow = sourceRow + 4;
                            }
                            Button? middleButton = GetButtonFromRowCol(middleRow, sourceCol);

                            if (middleButton?.Tag.ToString() != "Empty")
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                return;
                            }
                        }

                        MovePiece(ref sourceButton, ref targetButton);
                    }
                    else
                    {
                        if (direction == 1 && colDifference == 1)
                        {
                            if (isBlackTurn)
                            {
                                if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                                {
                                    MovePiece(ref sourceButton, ref targetButton);
                                }
                            }
                            else
                            {
                                if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                                {
                                    MovePiece(ref sourceButton, ref targetButton);
                                }
                            }
                        }
                    }
                }
                else
                {
                    sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                }
            }
            else
            {
                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
            }
        }

        private void MoveKnight(Button sourceButton, Button targetButton)
        {
            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = Math.Abs(targetRow - sourceRow);
            int colDifference = Math.Abs(targetCol - sourceCol);

            if ((direction == 1 && colDifference == 2) || (direction == 2 && colDifference == 1))
            {
                if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                {
                    if (targetButton.Tag.ToString() == "Empty")
                    {
                        MovePiece(ref sourceButton, ref targetButton);
                    }
                    else
                    {
                        if (isBlackTurn)
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                        }
                        else
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                        }
                    }
                }
                else
                {
                    sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                }
            }
            else
            {
                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
            }

        }


        private void MoveBishop(Button sourceButton, Button targetButton)
        {
            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = Math.Abs(targetRow - sourceRow);
            int colDifference = Math.Abs(targetCol - sourceCol);

            if (((CheckForObstacleDiagonal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item1 == false) || (CheckForObstacleDiagonal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item2 == true)) && (direction - colDifference == 0))
            {
                if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                {
                    if (targetButton.Tag.ToString() == "Empty")
                    {
                        MovePiece(ref sourceButton, ref targetButton);
                    }
                    else
                    {
                        if (isBlackTurn)
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                            {
                                MovePiece(ref targetButton, ref sourceButton);
                            }
                        }
                        else
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                        }
                    }
                }
            }
            else
            {
                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
            }
        }

        private void MoveRook(Button sourceButton, Button targetButton)
        {

            {
                int sourceRow = GetRowFromButtonName(sourceButton.Name);
                int sourceCol = GetColFromButtonName(sourceButton.Name);
                int targetRow = GetRowFromButtonName(targetButton.Name);
                int targetCol = GetColFromButtonName(targetButton.Name);

                int direction = Math.Abs(targetRow - sourceRow);
                int colDifference = Math.Abs(targetCol - sourceCol);

                if (((CheckForObstacleHorizontal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item1 == false) || (CheckForObstacleHorizontal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item2 == true)) && (direction == 0 || colDifference == 0))
                {
                    if (direction == 0 || colDifference == 0)
                    {
                        if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                        {
                            if (targetButton.Tag.ToString() == "Empty")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                            else
                            {
                                if (isBlackTurn)
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                }
                                else
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        }
                    }
                    else
                    {
                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                    }
                }
                else
                {
                    sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                }
            }
        }

        private void MoveKing(Button sourceButton, Button targetButton)
        {
            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = Math.Abs(targetRow - sourceRow);
            int colDifference = Math.Abs(targetCol - sourceCol);

            if ((direction == 1 && colDifference == 0) || (direction == 0 && colDifference == 1) || (direction == 1 && colDifference == 1) || (direction == 0 && colDifference == 0))
            {

                if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                {
                    if (targetButton.Tag.ToString() == "Empty")
                    {
                        MovePiece(ref sourceButton, ref targetButton);
                    }
                    else
                    {


                        if (isBlackTurn)
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                            }
                        }
                        else
                        {
                            if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                            else
                            {
                                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                            }
                        }
                    }

                }
                else
                {
                    sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                }
            }
            else
            {
                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
            }
        }

        private void MoveQueen(Button sourceButton, Button targetButton)
        {
            int sourceRow = GetRowFromButtonName(sourceButton.Name);
            int sourceCol = GetColFromButtonName(sourceButton.Name);
            int targetRow = GetRowFromButtonName(targetButton.Name);
            int targetCol = GetColFromButtonName(targetButton.Name);

            int direction = Math.Abs(targetRow - sourceRow);
            int colDifference = Math.Abs(targetCol - sourceCol);

            if (direction == 0 || colDifference == 0 || (colDifference - direction == 0))
            {
                if (direction == 0 || colDifference == 0)
                {
                    if ((CheckForObstacleHorizontal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item1 == false) || (CheckForObstacleHorizontal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item2 == true))
                    {
                        if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                        {
                            if (targetButton.Tag.ToString() == "Empty")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                            else
                            {


                                if (isBlackTurn)
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                    else
                                    {
                                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                    }
                                }
                                else
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                    else
                                    {
                                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        }

                    }
                }
                else
                {
                    if (((CheckForObstacleDiagonal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item1 == false) || (CheckForObstacleDiagonal(ref sourceButton, ref targetButton, ref sourceRow, ref targetRow, ref sourceCol, ref targetCol, ref direction, ref colDifference).Item2 == true)) && (direction - colDifference == 0))
                    {
                        if ((isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) == "Bl") || (!isBlackTurn && sourceButton.Tag?.ToString()?.Substring(0, 2) != "Bl"))
                        {
                            if (targetButton.Tag.ToString() == "Empty")
                            {
                                MovePiece(ref sourceButton, ref targetButton);
                            }
                            else
                            {


                                if (isBlackTurn)
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) != "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                    else
                                    {
                                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                    }
                                }
                                else
                                {
                                    if (targetButton.Tag?.ToString()?.Substring(0, 2) == "Bl")
                                    {
                                        MovePiece(ref sourceButton, ref targetButton);
                                    }
                                    else
                                    {
                                        sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
                        }
                    }
                }
            }
            else
            {
                sourceButton.BackColor = GetResetColor(sourceButton, targetButton, direction, colDifference);
            }
        }

        private Color GetResetColor(Button sourceButton, Button targetButton, int direction, int colDifference)
        {
            //doppelclick auf button
            if (sourceButton == targetButton)
            {
                int nextToNumber;
                if (targetButton.Name.Substring(4) == "8")
                {
                    nextToNumber = int.Parse(sourceButton.Name[4..]) - 1;
                }
                else
                {
                    nextToNumber = int.Parse(sourceButton.Name[4..]) + 1;
                }

                string nextToButton = sourceButton.Name.Substring(0, 4) + nextToNumber.ToString();
                Button? nextButton = GetButtonByName(nextToButton);
                if (nextButton != null)
                {
                    if (nextButton.BackColor == Color.White)
                    {
                        return Color.ForestGreen;
                    }
                    else
                    {
                        return Color.White;
                    }
                }

            }

            int sumOfDifferences = colDifference + direction;
            if (sumOfDifferences % 2 == 0)
            {
                return targetButton.BackColor;
            }
            else
            {
                if (targetButton.BackColor == Color.White)
                {
                    return Color.ForestGreen;
                }
                else
                {
                    return Color.White;
                }
            }
        }

        private int GetRowFromButtonName(string buttonName)
        {
            int row = int.Parse(buttonName[buttonName.Length - 1].ToString());

            // Flip the row index if it's black's turn
            if (isBlackTurn)
            {
                row = 9 - row;
            }

            return row;
        }

        private int GetColFromButtonName(string buttonName)
        {
            int col = colDict[buttonName[buttonName.Length - 2]];

            return col;
        }

        private Button? GetButtonFromRowCol(int row, int col)
        {

            char colChar = 'x';
            foreach (var pair in colDict)
            {
                if (pair.Value == col)
                {
                    colChar = pair.Key;
                    break;
                }
            }

            if (isBlackTurn)
            {
                row = 9 - row;
            }

            string buttonName = "btn" + colChar + row.ToString();
            Button? button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
            try
            {
                if (button != null)
                {
                    return button;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        private Button? GetButtonByName(string buttonName)
        {
            Button? button = Controls.Find(buttonName, true).FirstOrDefault() as Button;
            try
            {
                if (button != null)
                {
                    return button;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }



        private void btnA8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);

        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH2_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnD1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnE1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnG1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ButtonClick(clickedButton);
        }
    }
}