public class Solution {
    public int MinJumps(int[] nums) {
        int n = nums.Length;
        if (n == 1) return 0;

        int maxVal = 1_000_000;

        // 1. Sieve of Eratosthenes
        bool[] isPrime = new bool[maxVal + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= maxVal; i++) {
            if (isPrime[i]) {
                for (int j = i * i; j <= maxVal; j += i)
                    isPrime[j] = false;
            }
        }

        // 2. Map value -> indices
        Dictionary<int, List<int>> valueToIndices = new();
        for (int i = 0; i < n; i++) {
            if (!valueToIndices.ContainsKey(nums[i]))
                valueToIndices[nums[i]] = new List<int>();
            valueToIndices[nums[i]].Add(i);
        }

        // 3. BFS
        Queue<int> queue = new();
        bool[] visited = new bool[n];
        bool[] usedPrime = new bool[maxVal + 1];

        queue.Enqueue(0);
        visited[0] = true;

        int steps = 0;

        while (queue.Count > 0) {
            int size = queue.Count;
            while (size-- > 0) {
                int i = queue.Dequeue();
                if (i == n - 1)
                    return steps;

                // Adjacent moves
                if (i + 1 < n && !visited[i + 1]) {
                    visited[i + 1] = true;
                    queue.Enqueue(i + 1);
                }
                if (i - 1 >= 0 && !visited[i - 1]) {
                    visited[i - 1] = true;
                    queue.Enqueue(i - 1);
                }

                // Prime teleportation
                int p = nums[i];
                if (p <= maxVal && isPrime[p] && !usedPrime[p]) {
                    usedPrime[p] = true;
                    for (int multiple = p; multiple <= maxVal; multiple += p) {
                        if (valueToIndices.ContainsKey(multiple)) {
                            foreach (int idx in valueToIndices[multiple]) {
                                if (!visited[idx]) {
                                    visited[idx] = true;
                                    queue.Enqueue(idx);
                                }
                            }
                        }
                    }
                }
            }
            steps++;
        }

        return -1; // unreachable (should not happen)
    }
}
