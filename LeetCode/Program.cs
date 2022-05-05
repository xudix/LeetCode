using LeetCode;

int[] a = new int[] { 2, 5, 4, 4, 1, 3, 4, 4, 1, 4, 4, 1, 2, 1, 2, 2, 3, 2, 4, 2};
int[] b = new int[] {2,3,4,5 };
int[][] c = new int[1][];
c[0] = new int[] { 2,2,1 };
int[][] rectangles = new int[3][];
rectangles[0] = new int[] { 1, 2 };
rectangles[1] = new int[] { 2, 3 };
rectangles[2] = new int[] { 2, 5 };
int[][] points = new int[2][];
points[0] = new int[] { 2, 1 };
points[1] = new int[] { 1, 4 };


Console.WriteLine((new Solution()).FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" }));


