module Lab2 where

{--Natural numbers--}
list1 :: Integer -> [Integer]
list1 0 = [ ]
list1 x = list1 (x-1)++(x:[])

{--Odd numbers --}
list2 :: Integer -> [Integer]
list2 0 = [ ]
list2 x = list2 (x-1)++(2*x-1:[])

{--Even numbers --}
list3 :: Integer -> [Integer]
list3 0 = [ ]
list3 x = list3 (x-1)++(2*x:[])

{-- --}
list4 :: Integer -> [Integer]
list4 0 = [ ]
list4 x = list4 (x-1)++((x*x*x):[])

list5 :: Integer -> [Integer]
factorial 0 = 1
factorial x = x*factorial(x-1)
list5 0 = [ ]
list5 x = list5 (x-1)++[factorial(x)]  

list6 :: Integer -> [Integer]
stepen 1 = 1
stepen x = 10*stepen(x-1)
list6 0 = [ ]
list6 x = list6 (x-1)++[stepen(x+1)]

list7 :: Integer -> [Integer]
triangle 1 = 1
triangle(x) = x+triangle(x-1)
list7 0 = [ ]
list7 x = list7 (x-1)++[triangle(x)]

list8 :: Integer -> [Integer]
pyramid 1 = 1
pyramid(x) = x+pyramid(x-1)
p 1 = 1
p x = pyramid(x) + p(x-1)
list8 0 = [ ]
list8 x = list8 (x-1)++[p(x)]

delete :: Char -> String -> String
delete c [] = []
delete c (x:xs) = if x == c then delete c xs else x:delete c xs