// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var s = new Solution();
int[] T = new int[] { 2,0, 1, 0, 1, 10, 0, 2, 13, 0, 3, 18 }; 
Console.WriteLine(s.solution(T));

Console.WriteLine(s.solution1(new int[] { 1, 1, 1, 1, 3 }, new int[] { 2, 2, 2, 3, 4, 5 }));
Console.WriteLine(s.solution1(new int[] { 1, 1, 2, 3 }, new int[] { 2, 2, 3, 4, 5 }));
class Solution
{
	public int solution1(int[] A, int[] B)
	{
		int n = A.Length;
		int m = B.Length;
		Array.Sort(A);
		Array.Sort(B);
		int i = 0;
		for (int k = 0; k < n; k++)
		{
			if (i < m - 1 && B[i] < A[k] )
				i += 1;
			if (i < m -2 && B[i] == B[i + 1])
				i += 1;
			if (A[k] == B[i])
				return A[k];
		}
		return -1;
	}
	public string solution(int[] T)
	{
		// Implement your solution here
		int N = T.Length;
		int I = N / 4;
		List<int> list = new List<int>();
		for (int i = 0; i < N; i = i + I)
		{
			List<int> t = new List<int>();
			for (int j = i; j < i+I; j++)
			{
				t.Add(T[j]);
			}
			list.Add(t.Max() - t.Min());
		}
		int index = list.IndexOf(list.Max());
		switch (index)
		{
			case 0:
				return "WINTER";
				break;
			case 1:
				return "SPRING";
				break;
			case 2:
				return "SUMMER";
				break;
			case 3:
				return "AUTUMN";
				break;
			default:
				return "";
		}
	}
}