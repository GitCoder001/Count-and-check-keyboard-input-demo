Module Module1
    Sub Main()
        ' demonstration code for moving incrementing value around the screen without blocking for user input
        ' L.Minett 2020

        Dim Value As Integer = 1
        Dim quit As Boolean = False
        Dim x, y As Integer ' position
        x = 0
        y = 0

        Dim input As ConsoleKeyInfo
        Console.CursorVisible = False
        ' doesn't check if number will exceed width when expanding width (into new number columns) e.g. 99 to 100
        Do
            If Console.KeyAvailable() Then
                Select Case Console.ReadKey(True).Key
                    Case ConsoleKey.Q Or ConsoleKey.Escape
                        quit = True
                    Case ConsoleKey.UpArrow
                        PaintSpace(x, y)
                        x = If(x = 0, 0, x - 1)
                    Case ConsoleKey.LeftArrow
                        PaintSpace(x, y)
                        y = If(y = 0, 0, y - 1)
                    Case ConsoleKey.RightArrow
                        PaintSpace(x, y)
                        y = If(y = Console.WindowWidth, y, y + 1)
                    Case ConsoleKey.DownArrow
                        PaintSpace(x, y)
                        x = If(x = Console.WindowHeight, x, x + 1)
                End Select
            End If
            Value = If(Value > 999999, 0, Value + 1) ' wrap around when get to 1m
            Console.SetCursorPosition(y, x)
            Console.WriteLine(Value)
        Loop Until quit

    End Sub
    Sub PaintSpace(x As Integer, y As Integer)
        ' will place spaces where text was before, effectively deleting what was there
        ' console.clear is too laggy and unnecessary
        Console.SetCursorPosition(y, x) ' console co-ordinates are left, top
        Console.WriteLine("      ")

    End Sub
End Module