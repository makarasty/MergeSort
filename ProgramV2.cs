namespace MergeSortV2Namespace;

using CommonNamespace;

class Program
{
	static void Main()
	{
		int length = Common.MyInputV2Int("Кількість елементів: ");
		int minValue = Common.MyInputV2Int("Мінімальне значення: ");
		int maxValue = Common.MyInputV2Int("Максимальне значення: ");

		int[] data = Common.GenerateRandomArray(length, minValue, maxValue);

		Console.WriteLine("\nНесортований масив:");
		Common.PrintArray(data);

		int[] sortedData = MergeSort(data);

		Console.WriteLine("\nСортований масив:");
		Common.PrintArray(sortedData);
	}

	static int[] MergeSort(int[] array)
	{
		if (array.Length <= 1)
		{
			return array;
		}

		int midpoint = array.Length / 2;
		int[] left = new int[midpoint];
		int[] right;

		if (array.Length % 2 == 0)
		{
			right = new int[midpoint];
		}
		else
		{
			right = new int[midpoint + 1];
		}

		Array.Copy(array, 0, left, 0, midpoint);
		Array.Copy(array, midpoint, right, 0, array.Length - midpoint);

		left = MergeSort(left);
		right = MergeSort(right);

		return Merge(left, right);
	}

	static int[] Merge(int[] left, int[] right)
	{
		int[] result = new int[left.Length + right.Length];
		int leftIndex = 0;
		int rightIndex = 0;
		int resultIndex = 0;

		while (leftIndex < left.Length && rightIndex < right.Length)
		{
			if (left[leftIndex] <= right[rightIndex])
			{
				result[resultIndex++] = left[leftIndex++];
			}
			else
			{
				result[resultIndex++] = right[rightIndex++];
			}
		}

		Array.Copy(left, leftIndex, result, resultIndex, left.Length - leftIndex);
		Array.Copy(right, rightIndex, result, resultIndex, right.Length - rightIndex);

		return result;
	}
}