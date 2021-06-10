def fibb(n):
     a = 0
     b = 1
     while a < n:
         print(a, end = "  ")
         c = a+b
         a = b
         b = c
     print()

fibb(1000)

input("Please press Enter to exit")
