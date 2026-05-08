public class Solution {
    public int StrStr(string haystack, string needle) {
        // If needle is empty (not needed here due to constraints, but safe)
        if (needle.Length == 0)
            return 0;

        // Loop through haystack where needle can still fit
        for (int i = 0; i <= haystack.Length - needle.Length; i++) {
            int j = 0;

            // Check character by character
            while (j < needle.Length && haystack[i + j] == needle[j]) {
                j++;
            }

            // If full needle matched
            if (j == needle.Length) {
                return i;
            }
        }

        return -1;
    }
}
