public class Solution {
    public int ClimbStairs(int n) {
        // Base cases
        if (n <= 2)
            return n;

        int prev1 = 1; // ways to climb 1 step
        int prev2 = 2; // ways to climb 2 steps

        for (int i = 3; i <= n; i++) {
            int current = prev1 + prev2;
            prev1 = prev2;
            prev2 = current;
        }

        return prev2;
    }
}
