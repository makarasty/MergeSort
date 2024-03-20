namespace CommonNamespace;

public class Common
{
	public static int MyInputV2Int(string text)
	{
		while (true)
		{
			Console.Write(text);
			if (int.TryParse(Console.ReadLine(), out int result))
			{
				return result;
			}
			else
			{
				Console.WriteLine("Невірний формат числа. Спробуйте ще раз.");
			}
		}
	}
	public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
	{
		var random = new Random();
		return Enumerable.Range(0, length).Select(_ => random.Next(minValue, maxValue + 1)).ToArray();
	}
	public static void PrintArray(int[] array)
	{
		Console.WriteLine(string.Join(' ', array));
	}
}
