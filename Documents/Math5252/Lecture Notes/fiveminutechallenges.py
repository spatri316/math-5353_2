# def fold(setvector, s, target, fn):
#     s = fn(s, setvector[target])

#     if target < len(setvector) - 1:
#         return fold(setvector, s, target+1, fn)
#     else:
#         return s

# fn = lambda x, y: x+y
# g = [1,2,3,4,5]
# m = fold(g,0,0, fn)
# print(m)

# prime 

# def isPrime(x):
    
#     modulus_a = lambda x : x % (x-1)

#     if x > 0 & modulus_a == 0:
#         return 0
#     else: 
#         return isPrime(x-1)

    
# print(isPrime(5))
    
# print(isPrime())

# from sympy import *
# import numpy as np

# x = symbols('x')
# expr = exp(-x**2/2)

# limit_expr = limit(expr, -oo, oo)

# print(limit_expr)

# select * from transactions where Time > 