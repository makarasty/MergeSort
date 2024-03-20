namespace MergeSortV1Namespace;

using CommonNamespace;

class Program
{
	static void Main()
	{
		int length = Common.MyInputV2Int("Кількість елементів: ");
		int minValue = Common.MyInputV2Int("Мінімальне значення: ");
		int maxValue = Common.MyInputV2Int("Максимальне значення: ");

		int[] unsortedArray = Common.GenerateRandomArray(length, minValue, maxValue);

		Console.WriteLine("\nНесортований масив:");
		Common.PrintArray(unsortedArray);

		MergeSort(unsortedArray, 0, unsortedArray.Length - 1);

		Console.WriteLine("\nСортований масив:");
		Common.PrintArray(unsortedArray);

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
}