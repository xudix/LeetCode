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
            while (start < end)
            {
                int mid = (start + end) >> 1;
                if (target < s[mid])
                    end = mid;
                else
                    start = mid + 1; // [0, start) is not greater than target
            }
            return end>start && s[end - 1] == target ? end-1 : -1;
        }
    }
}
