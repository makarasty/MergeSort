namespace MergeSortNamespace;

class Program
{
	static void Main()
	{
		int length = MyInputV2Int("Кількість елементів: ");
		int minValue = MyInputV2Int("Мінімальне значення: ");
		int maxValue = MyInputV2Int("Максимальне значення: ");

		int[] unsortedArray = GenerateRandomArray(length, minValue, maxValue);

		Console.WriteLine("\nНесортований масив:");
		PrintArray(unsortedArray);

		MergeSort(unsortedArray, 0, unsortedArray.Length - 1);

		Console.WriteLine("\nСортований масив:");
		PrintArray(unsortedArray);

	}
	static void MergeSort(int[] array, int left, int right)
	{
		if (left < right)
		{
			int mid = (left + right) / 2;
			MergeSort(array, left, mid);
			MergeSort(array, mid + 1, right);
			Merge(array, left, mid, right);
		}
	}

	static void Merge(int[] sourceArray, int leftIndex, int midIndex, int rightIndex)
	{
		int leftCount = midIndex - leftIndex + 1;
		int rightCount = rightIndex - midIndex;

		int[] leftPart = new int[leftCount];
		int[] rightPart = new int[rightCount];

		for (int i = 0; i < leftCount; i++)
		{
			leftPart[i] = sourceArray[leftIndex + i];
		}

		for (int i = 0; i < rightCount; i++)
		{
			rightPart[i] = sourceArray[midIndex + 1 + i];
		}

		int mergedIndex = leftIndex;
		int leftPartIndex = 0;
		int rightPartIndex = 0;

		while (leftPartIndex < leftCount && rightPartIndex < rightCount)
		{
			if (leftPart[leftPartIndex] <= rightPart[rightPartIndex])
			{
				sourceArray[mergedIndex++] = leftPart[leftPartIndex++];
			}
			else
			{
				sourceArray[mergedIndex++] = rightPart[rightPartIndex++];
			}
		}

		while (leftPartIndex < leftCount)
		{
			sourceArray[mergedIndex++] = leftPart[leftPartIndex++];
		}

		while (rightPartIndex < rightCount)
		{
			sourceArray[mergedIndex++] = rightPart[rightPartIndex++];
		}
	}
	private static int MyInputV2Int(string text)
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
	static int[] GenerateRandomArray(int length, int minValue, int maxValue)
	{
		var random = new Random();
		return Enumerable.Range(0, length).Select(_ => random.Next(minValue, maxValue + 1)).ToArray();
	}
	static void PrintArray(int[] array)
	{
		Console.WriteLine(string.Join(' ', array));
	}
}