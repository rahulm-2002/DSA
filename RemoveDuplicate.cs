/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        // If list is empty or has only one node
        if (head == null)
            return head;

        ListNode current = head;

        while (current != null && current.next != null) {
            // If current value equals next value, skip the next node
            if (current.val == current.next.val) {
                current.next = current.next.next;
            } else {
                // Move to next node only if values are different
                current = current.next;
            }
        }

        return head;
    }
}
