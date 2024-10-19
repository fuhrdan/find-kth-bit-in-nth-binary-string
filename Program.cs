//*****************************************************************************
//** 1545. Find Kth Bit in Nth Binary String    leetcode                     **
//*****************************************************************************


// Helper function to reverse a string
char* reverse(const char* s) {
    int len = strlen(s);
    char* rev = (char*)malloc((len + 1) * sizeof(char)); // Allocating space for reversed string
    for (int i = 0; i < len; i++) {
        rev[i] = s[len - i - 1]; // Reversing the string
    }
    rev[len] = '\0'; // Null-terminate the string
    return rev;
}

// Helper function to invert a string
char* invert(const char* s) {
    int len = strlen(s);
    char* inv = (char*)malloc((len + 1) * sizeof(char)); // Allocating space for inverted string
    for (int i = 0; i < len; i++) {
        inv[i] = (s[i] == '1') ? '0' : '1'; // Inverting '1' to '0' and vice versa
    }
    inv[len] = '\0'; // Null-terminate the string
    return inv;
}

// Function to find the k-th bit in the n-th binary string
char findKthBit(int n, int k) {
    char* s = (char*)malloc(2 * sizeof(char));
    strcpy(s, "0"); // Starting with S1 = "0"

    for (int i = 2; i <= n && strlen(s) < k; i++) {
        char* rev_inverted = reverse(invert(s)); // Reverse and invert the string
        char* new_s = (char*)malloc((strlen(s) + strlen(rev_inverted) + 2) * sizeof(char)); // Space for new string
        sprintf(new_s, "%s1%s", s, rev_inverted); // Append "1" and reverse-inverted part to form Sn
        free(s);
        free(rev_inverted);
        s = new_s; // Move to the next sequence
    }

    char result = s[k - 1]; // Get the k-th character
    free(s); // Free the allocated memory for s
    return result;
}