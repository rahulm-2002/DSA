public class Solution {
    public string Multiply(string num1, string num2) {
        // If either number is "0", result is "0"
        if (num1 == "0" || num2 == "0")
            return "0";

        int m = num1.Length;
        int n = num2.Length;

        // Result can be at most m + n digits
        int[] result = new int[m + n];

        // Multiply from right to left (like manual multiplication)
        for (int i = m - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int sum = mul + result[i + j + 1];

                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }

        // Convert result array to string, skipping leading zeros
        StringBuilder sb = new StringBuilder();
        int index = 0;

        while (index < result.Length && result[index] == 0) {
            index++;
        }

        for (; index < result.Length; index++) {
            sb.Append(result[index]);
        }

        return sb.ToString();
    }
}
