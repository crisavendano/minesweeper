namespace Minesweeper.Tests
{
    public class UserInputTest
    {
        // [Theory]
        // [InlineData(5, 5)]
        // public void GetRowAndColumn_ReturnsTuple(int row, int column)
        // {
        //     string simulatedInput = $"{row}\n{column}\n";
        //     using (var inputSimulator = new StringReader(simulatedInput))
        //     {
        //         TextReader originalInput = Console.In;
        //         try
        //         {
        //             Console.SetIn(inputSimulator);
        //             (int, int) actual = UserInput.GetRowAndColumn();
        //             Assert.Equal((row, column), actual);
        //         }
        //         finally
        //         {
        //             Console.SetIn(originalInput);
        //         }
        //     }
        // }
        //
        // [Theory]
        // [InlineData("Row: ", 5)]
        // [InlineData("Column: ", 5)]
        // public void GetNumber_ReturnsNumber(string message, int number)
        // {
        //     string simulatedInput = $"{number}\n";
        //     using (var inputSimulator = new StringReader(simulatedInput))
        //     {
        //         TextReader originalInput = Console.In;
        //         try
        //         {
        //             Console.SetIn(inputSimulator);
        //             int actual = UserInput.GetNumber(message);
        //             Assert.Equal(number, actual);
        //         }
        //         finally2
        //         {
        //             Console.SetIn(originalInput);
        //         }
        //     }
        // }
        // [Theory]
        // [InlineData(PlayType.Reveal)]
        // [InlineData(PlayType.Flag)]
        // [InlineData(PlayType.EndGame)]
        // public void GetUserInput_ShouldReturnPlay(PlayType play)
        // {
        //     int playInt = (int)play;
        //     string simulatedInput = $"{playInt.ToString()}\n";
        //     using (var inputSimulator = new StringReader(simulatedInput))
        //     {
        //         TextReader originalInput = Console.In;
        //         try
        //         {
        //             Console.SetIn(inputSimulator);
        //             PlayType actual = UserInput.GetPlay();
        //             Assert.Equal(play, actual);
        //         }
        //         finally
        //         {
        //             Console.SetIn(originalInput);
        //         }
        //     }
        // }
    }
}
