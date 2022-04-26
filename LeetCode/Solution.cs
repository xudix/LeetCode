using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        /// <summary>
        /// Two Sum
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]) && dict[target - nums[i]] != i)
                    return new int[] { dict[target - nums[i]], i };
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Add Two Numbers
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int temp = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
            int temp2 = temp / 10;
            ListNode ansHead = new ListNode(temp % 10);
            ListNode current = ansHead;
            while ((l1 = (l1 == null ? null : l1.next)) != null | (l2 = (l2 == null ? null : l2.next)) != null)
            {
                temp = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + temp2;
                temp2 = temp / 10;
                current.next = new ListNode(temp % 10);
                current = current.next;
            }
            if (temp2 != 0)
                current.next = new ListNode(temp2);
            return ansHead;

        }



        /// <summary>
        /// Longest Substring Without Repeating Characters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int[] hashSet = new int[256];
            for (int i = 0; i < 256; hashSet[i++] = -1) ;
            int longest = 0, currentLen;
            int left = 0, right = 0;
            for (; right < s.Length; right++)
            {
                if (hashSet[(int)s[right]] >= left)
                {
                    left = hashSet[(int)s[right]] + 1;
                }
                hashSet[(int)s[right]] = right;
                currentLen = right - left + 1;
                if (currentLen > longest)
                    longest = currentLen;
            }
            return longest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int lo1 = 0, hi1 = nums1.Length, lo2 = 0, hi2 = nums2.Length;
            double median1 = Median(nums1, lo1, hi1), median2 = Median(nums2, lo2, hi2);

            while (true)
            {
                if (median1 < median2)
                {
                    lo1 = (hi1 + lo1) >> 1;
                    hi2 = (hi2 + lo2) >> 1;
                }
                else
                {
                    hi1 = (hi1 + lo1) >> 1;
                    lo2 = (hi2 + lo2) >> 1;
                }
                median1 = Median(nums1, lo1, hi1);
                median2 = Median(nums2, lo2, hi2);
            }

        }

        /// <summary>
        /// Find the Median of an array in range of [lo,hi)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        double Median(int[] nums, int lo, int hi) =>
            (hi - lo) % 2 == 0 ? (nums[lo + ((hi - lo) >> 1) - 1] + nums[lo + ((hi - lo) >> 1)]) / 2.0 : nums[lo + (hi - lo) >> 1];

        /// <summary>
        ///  number of elements no greater than target
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// 
        /// <returns></returns>
        protected int N_LE(int[] nums, int left, int right, double target)
        {

            int mid;
            while (left < right)
            {
                mid = (left + right) >> 1;
                if (target < nums[mid])
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        /// <summary>
        /// Longest Palindromic Substring
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            string ans = s[0].ToString();
            int maxLen = 1;
            int l, r;
            for (int current = 1; current < s.Length; current++)
            {
                r = current;
                l = current - 1;
                do
                {
                    if (s[l] == s[r])
                    {
                        if (r - l + 1 > maxLen)
                        {
                            maxLen = r - l + 1;
                            ans = s[l..(r + 1)];
                        }
                    }
                    else
                        break;
                } while (--l >= 0 && ++r < s.Length);
                if (current > 1)
                {
                    r = current;
                    l = current - 2;
                    do
                    {
                        if (s[l] == s[r])
                        {
                            if (r - l + 1 > maxLen)
                            {
                                maxLen = r - l + 1;
                                ans = s[l..(r + 1)];
                            }
                        }
                        else
                            break;
                    } while (--l >= 0 && ++r < s.Length);
                }

            }
            return ans;
        }

        public string IntToRoman(int num)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < num / 1000; i++)
                ans.Append('M');
            switch ((num / 100) % 10)
            {
                case 9:
                    ans.Append("CM");
                    break;
                case 8 or 7 or 6 or 5:
                    ans.Append('D');
                    for (int i = 0; i < (num / 100) % 10 - 5; i++)
                        ans.Append('C');
                    break;
                case 4:
                    ans.Append("CD");
                    break;
                case 3 or 2 or 1:
                    for (int i = 0; i < (num / 100) % 10; i++)
                        ans.Append('C');
                    break;
                default:
                    break;
            }
            switch ((num / 10) % 10)
            {
                case 9:
                    ans.Append("XC");
                    break;
                case 8 or 7 or 6 or 5:
                    ans.Append('L');
                    for (int i = 0; i < (num / 10) % 10 - 5; i++)
                        ans.Append('X');
                    break;
                case 4:
                    ans.Append("XL");
                    break;
                case 3 or 2 or 1:
                    for (int i = 0; i < (num / 10) % 10; i++)
                        ans.Append('X');
                    break;
                default:
                    break;
            }
            switch ((num) % 10)
            {
                case 9:
                    ans.Append("IX");
                    break;
                case 8 or 7 or 6 or 5:
                    ans.Append('V');
                    for (int i = 0; i < (num) % 10 - 5; i++)
                        ans.Append('I');
                    break;
                case 4:
                    ans.Append("IV");
                    break;
                case 3 or 2 or 1:
                    for (int i = 0; i < (num) % 10; i++)
                        ans.Append('I');
                    break;
                default:
                    break;
            }
            return ans.ToString();
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ans = new List<IList<int>>();
            int[] s = nums;
            Array.Sort(s);
            int i = 0, j = 0, k = s.Length;
            for (i = 0; i < s.Length - 2; i++)
            {
                j = i + 1;
                if (s[i] + s[j] > 0)
                    return ans;
                if (i > 0 && s[i] == s[i - 1])
                    continue;
                k = s.Length;
                for (; j < k - 1; j++)
                {
                    if (j > i + 1 && s[j] == s[j - 1])
                        continue;
                    int r = BinSearch4ThreeSum(s, j + 1, ref k, -s[i] - s[j]);
                    if (r >= 0)
                        ans.Add(new int[] { s[i], s[j], s[r] });
                }
            }
            return ans;
        }

        int BinSearch4ThreeSum(int[] s, int start, ref int end, int target)
        {
            int lo = start;
            while (start < end)
            {
                int mid = (start + end) >> 1;
                if (target < s[mid])
                    end = mid;
                else
                    start = mid + 1; // [0, start) is not greater than target
            }
            return end > lo && s[end - 1] == target ? end - 1 : -1;
        }

        public IList<IList<int>> ThreeSum_hash(int[] nums)
        {
            var ans = new List<IList<int>>();
            Array.Sort(nums);
            var hashSet = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (!hashSet.ContainsKey(nums[i]))
                    hashSet.Add(nums[i], i);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0)
                    break;
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] > 0)
                        break;
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    if (hashSet.ContainsKey(-nums[i] - nums[j]))
                    {
                        if (hashSet[-nums[i] - nums[j]] > j)
                            ans.Add(new int[] { nums[i], nums[j], nums[hashSet[-nums[i] - nums[j]]] });
                        else if (-nums[i] - nums[j] == nums[j] && nums[j] == nums[j + 1])
                            ans.Add(new int[] { nums[i], nums[j], nums[j + 1] });
                    }

                }
            }
            return ans;
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int ans = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {

                    int diff = nums[i] + nums[j] + nums[k] - target;
                    if (Math.Abs(target - ans) > Math.Abs(diff))
                        ans = target + diff;
                    if (diff == 0)
                        return ans;
                    else if (diff > 0)
                        k--;
                    else
                        j++;
                }
            }
            return ans;
        }

        public IList<string> LetterCombinations(string digits)
        {
            var ans = new List<String>();
            int len = digits.Length;
            if (len == 0)
                return ans;
            string[] letters = new string[len];
            for (int i = 0; i < len; i++)
            {
                switch (digits[i])
                {
                    case '2':
                        letters[i] = "abc";
                        break;
                    case '3':
                        letters[i] = "def";
                        break;
                    case '4':
                        letters[i] = "ghi";
                        break;
                    case '5':
                        letters[i] = "jkl";
                        break;
                    case '6':
                        letters[i] = "mno";
                        break;
                    case '7':
                        letters[i] = "pqrs";
                        break;
                    case '8':
                        letters[i] = "tuv";
                        break;
                    case '9':
                        letters[i] = "wxyz";
                        break;
                    default:
                        return ans;
                }
            }
            int maxCode = 0b100 << ((len - 1) << 1);
            StringBuilder sb = new();
            for (int code = 0b0; code < maxCode; code++)
            {
                sb.Clear();
                int loc = 0b11, i;
                for (i = 0; i < len; i++)
                {
                    int index = (loc & code) >> (i << 1);
                    if (index < letters[i].Length)
                        sb.Append(letters[i][index]);
                    else
                        break;
                    loc <<= 2;
                }
                if (i == len)
                    ans.Add(sb.ToString());
            }
            return ans;
        }

        public IList<IList<int>> FourSum(int[] nums, int target) =>
            NSum(nums, target, 4);

        public IList<IList<int>> NSum(int[] nums, int target, int n)
        {
            Dictionary<int, int> hashset = new();
            if (n < 2)
            {
                throw new ArgumentOutOfRangeException("n is too small");
            }
            else if (n > 2)
            {
                Array.Sort(nums);
            }
            for (int i = nums.Length - 1; i > -1; i--)
            {
                if (!hashset.ContainsKey(nums[i]))
                    hashset.Add(nums[i], i);
            }
            return NSum(nums, target, n, hashset, -1);

        }

        List<IList<int>> NSum(int[] nums, int target, int n, Dictionary<int, int> hashSet, int ThirdLargest)
        {
            List<IList<int>> ans = new();
            if (n == 2)
            {

                for (int i = ThirdLargest + 1; i < nums.Length - 1; i++)
                {
                    if (i > ThirdLargest + 1 && nums[i] == nums[i - 1])
                        continue;
                    if (hashSet.ContainsKey(target - nums[i]) && hashSet[target - nums[i]] > i)
                    {
                        var newAns = new List<int>() { target - nums[i], nums[i] };
                        ans.Add(newAns);
                    }
                }
                return ans;
            }
            else if (n > 2)
            {
                List<IList<int>> newans = new();
                for (int i = ThirdLargest + 1; i < nums.Length; i++)
                {
                    if (i > ThirdLargest + 1 && nums[i] == nums[i - 1])
                        continue;
                    newans = NSum(nums, target - nums[i], n - 1, hashSet, i);
                    foreach (IList<int> a in newans)
                        a.Add(nums[i]);
                    ans.AddRange(newans);
                }
                return ans;
            }
            else
                throw new ArgumentException();

        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var originalHead = head;
            ListNode[] queue = new ListNode[n + 1];
            int next = 0, count = 0;
            do
            {
                queue[next++] = head;
                count++;
                if (next == n + 1)
                    next = 0;
            } while ((head = head.next) != null);
            // queue[next] will be kept. queue[next+1] will be deleted
            if (count < n)
                throw new ArgumentException();
            if (count == n)
                originalHead = originalHead.next;
            else
            {
                queue[next].next = queue[next].next.next;
            }
            return originalHead;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var dummy = new ListNode();
            var ans = dummy;
            var current1 = list1;
            var current2 = list2;
            while (true)
            {
                if (current1 != null && current2 != null)
                {
                    if (current1.val <= current2.val)
                    {
                        ans.next = current1;
                        current1 = current1.next;
                    }
                    else
                    {
                        ans.next = current2;
                        current2 = current2.next;
                    }
                    ans = ans.next;
                }
                else if (current1 == null && current2 == null)
                {
                    return dummy.next;
                }
                else if (current1 == null)
                {
                    ans.next = current2;
                    return dummy.next;
                }
                else
                {
                    ans.next = current1;
                    return dummy.next;
                }
            }

        }

        public IList<int> Intersection(int[][] nums)
        {
            Array.Sort(nums[0]);
            if (nums.Length == 1)
            {
                return nums[0];
            }
            List<int> ans = new();
            HashSet<int>[] hashSets = new HashSet<int>[nums.Length - 1];
            for (int i = 1; i < nums.Length; i++)
            {
                hashSets[i] = new HashSet<int>();
                for (int j = 0; j < nums[i].Length; j++)
                    hashSets[i].Add(nums[i][j]);
            }
            foreach (int a in nums[0])
            {
                bool present = true;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (!hashSets[i].Contains(a))
                        present = false;
                }
                if (present)
                    ans.Add(a);

            }
            return ans;
        }

        public int CountLatticePoints(int[][] circles)
        {
            int minx = 100, miny = 100, maxx = 0, maxy = 0;
            for (int i = 0; i < circles.Length; i++)
            {
                if (circles[i][0] + circles[i][2] > maxx)
                {
                    maxx = circles[i][0] + circles[i][2];
                }
                if (circles[i][0] - circles[i][2] < minx)
                {
                    minx = circles[i][0] - circles[i][2];
                }
                if (circles[i][1] + circles[i][2] > maxy)
                {
                    maxy = circles[i][1] + circles[i][2];
                }
                if (circles[i][1] - circles[i][2] < miny)
                {
                    miny = circles[i][1] - circles[i][2];
                }
            }
            int output = 0;
            for (int x = minx; x <= maxx; x++)
            {
                for (int y = miny; y <= maxy; y++)
                {
                    for (int i = 0; i < circles.Length; i++)
                    {
                        if (IsInCircle(circles[i], x, y))
                        {
                            output++;
                            break;
                        }
                    }
                }
            }
            return output;
        }

        bool IsInCircle(int[] circle, int x, int y) =>
            (x - circle[0]) * (x - circle[0]) + (y - circle[1]) * (y - circle[1]) - circle[2] * circle[2] <= 0;

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            char[] stack = new char[n << 1];
            int cursor = 1;
            int nLeft = 1, nRight = 0;
            stack[0] = '(';
            while (cursor > -1)
            {
                // try to add a new char
                if (stack[cursor] == '\0')
                {
                    if (nLeft < n)
                    {
                        stack[cursor] = '(';
                        cursor++;
                        nLeft++;
                    }
                    else if (nRight < n)
                    {
                        stack[cursor] = ')';
                        cursor++;
                        nRight++;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else if (stack[cursor] == '(' && nLeft - 1 > nRight)
                {
                    stack[cursor] = ')';
                    nLeft--;
                    nRight++;
                    cursor++;
                }
                else
                {
                    if (stack[cursor] == '(')
                        nLeft--;
                    else
                        nRight--;
                    stack[cursor] = '\0';
                    cursor--;
                }
                if (cursor == stack.Length)
                {
                    result.Add(new string(stack));
                    stack[--cursor] = '\0';
                    nRight--;
                    cursor--;
                }

            }
            return result;
        }

        public int Divide(int dividend, int divisor)
        {
            bool negative = false;
            uint udividend, udivisor;
            if (dividend == int.MinValue)
            {
                udividend = (uint)int.MaxValue + 1;
                negative = !negative;
            }
            else if (dividend < 0)
            {
                negative = !negative;
                udividend = (uint)-dividend;
            }
            else
                udividend = (uint)dividend;
            if (divisor == int.MinValue)
            {
                return dividend == int.MinValue ? 1 : 0;
            }
            else if (divisor < 0)
            {
                negative = !negative;
                udivisor = (uint)-divisor;
            }
            else
                udivisor = (uint)divisor;
            uint originalDivisor = udivisor;
            uint result = 0;
            while (udivisor <= (udividend >> 1))
                udivisor <<= 1;
            while (udivisor >= originalDivisor)
            {
                result <<= 1;
                if (udividend >= udivisor)
                {
                    udividend -= udivisor;
                    result++;
                }
                udivisor >>= 1;
            }
            return negative ? (int)-result : result <= int.MaxValue ? (int)result : int.MaxValue;
        }
    }
}
