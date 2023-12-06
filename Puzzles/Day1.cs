namespace AdventOfCode2023.Puzzles;

internal class Day1 : PuzzleBase
{
    public Day1() : base(nameof(Day1)) { }

    public override string SolvePart1()
    {
        AssertInputLoaded();
        var sum = Input.Select(x => GetDigits(x)).Sum();
        return sum.ToString();
        
        static int GetDigits(ReadOnlySpan<char> calibration)
        {
            var indexLeft = calibration.IndexOfAnyInRange('0', '9');
            var indexRight = calibration.LastIndexOfAnyInRange('0', '9');
            return int.Parse([calibration[indexLeft], calibration[indexRight]]);
        }
    }

    public override string SolvePart2()
    {
        AssertInputLoaded();
        var sum = Input.Select(x => GetDigits(x)).Sum();
        return sum.ToString();
        
        static int GetDigits(ReadOnlySpan<char> calibration)
        {
            ReadOnlySpan<string> spelledDigits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
            
            var spelledLeft = GetSpelledIndexLeft(calibration, spelledDigits);
            var indexLeft = calibration.IndexOfAnyInRange('0', '9');
            var digitLeft = indexLeft >= 0 && (indexLeft < spelledLeft.Index || spelledLeft.Index < 0)
                ? int.Parse([calibration[indexLeft]])
                : spelledLeft.Digit;
            
            var spelledRight = GetSpelledIndexRight(calibration, spelledDigits);
            var indexRight = calibration.LastIndexOfAnyInRange('0', '9');
            var digitRight = indexRight > spelledRight.Index
                ? int.Parse([calibration[indexRight]])
                : spelledRight.Digit;

            return (digitLeft * 10) + digitRight;
            
            static (int Index, int Digit) GetSpelledIndexLeft(ReadOnlySpan<char> calibration, ReadOnlySpan<string> spelledDigits)
            {
                var leastCalibrationIndex = -1;
                var leastIndex = -1;
                for(var i=0; i<spelledDigits.Length; i++)
                {
                    var calibrationIndex = calibration.IndexOf(spelledDigits[i]);
                    if (calibrationIndex >= 0 && (calibrationIndex < leastCalibrationIndex || leastCalibrationIndex < 0))
                    {
                        leastCalibrationIndex = calibrationIndex;
                        leastIndex = i;
                    }
                }
                
                return (leastCalibrationIndex, leastIndex + 1);
            }

            static (int Index, int Digit) GetSpelledIndexRight(ReadOnlySpan<char> calibration, ReadOnlySpan<string> spelledDigits)
            {
                var leastCalibrationIndex = -1;
                var leastIndex = -1;
                for(var i=0; i<spelledDigits.Length; i++)
                {
                    var calibrationIndex = calibration.LastIndexOf(spelledDigits[i]);
                    if (calibrationIndex >= 0 && (calibrationIndex > leastCalibrationIndex || leastCalibrationIndex < 0))
                    {
                        leastCalibrationIndex = calibrationIndex;
                        leastIndex = i;
                    }
                }
                
                return (leastCalibrationIndex, leastIndex + 1);
            }
        }
    }
}