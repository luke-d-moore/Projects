a = 1
n = int(input("Enter value of n which Fizzbuzz will run to: "))
while a<=n:
    if a%3==0 and a%5==0:
        print (' FizzBuzz')
    elif a%3==0:
        print ('Fizz')
    elif a%5==0:
        print ('Buzz')
    else:
        print (a)
    a+=1

input("Please Press enter to exit")
