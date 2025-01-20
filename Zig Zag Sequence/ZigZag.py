def findZigZagSequence(a, n):
    a.sort()  # Sort the array
    mid = (n - 1) // 2  # Correct middle index
    a[mid], a[n - 1] = a[n - 1], a[mid]  # Swap middle with the last element

    # Reverse only the elements from mid+1 to n-2
    st = mid + 1
    ed = n - 2
    while st < ed:  # Use strict < to avoid unnecessary swaps
        a[st], a[ed] = a[ed], a[st]
        st += 1
        ed -= 1

    # Print the zig-zag sequence
    for i in range(n):
        if i == n - 1:
            print(a[i])
        else:
            print(a[i], end=' ')
    return

# Main logic to handle input/output
t = int(input())
for _ in range(t):
    n = int(input())
    a = list(map(int, input().split()))
    findZigZagSequence(a, n)


# the code above works but the problem only wants you to edit 3 lines total

# Here is the original
'''
def findZigZagSequence(a, n):
    a.sort()
    mid = int((n + 1)/2)
    a[mid], a[n-1] = a[n-1], a[mid]

    st = mid + 1
    ed = n - 1
    while(st <= ed):
        a[st], a[ed] = a[ed], a[st]
        st = st + 1
        ed = ed + 1

    for i in range (n):
        if i == n-1:
            print(a[i])
        else:
            print(a[i], end = ' ')
    return

test_cases = int(input())
for cs in range (test_cases):
    n = int(input())
    a = list(map(int, input().split()))
    findZigZagSequence(a, n)
'''

# Here is the Corrected version
'''
def findZigZagSequence(a, n):
    a.sort()
    mid = (n - 1) // 2 # Corrected middle index calculation
    a[mid], a[n-1] = a[n-1], a[mid]

    st = mid + 1
    ed = n - 2 # Corrected the end index calculation
    while(st <= ed):
        a[st], a[ed] = a[ed], a[st]
        st = st + 1
        ed = ed - 1 # Corrected the decrement operation

    for i in range (n):
        if i == n-1:
            print(a[i])
        else:
            print(a[i], end = ' ')
    return

test_cases = int(input())
for cs in range (test_cases):
    n = int(input())
    a = list(map(int, input().split()))
    findZigZagSequence(a, n)
'''