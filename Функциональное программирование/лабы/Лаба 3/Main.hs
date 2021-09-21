module Lab3 where


average s = foldr (+) 0 s / foldr (\x y -> 1+y) 0 s


dotLists a b = foldr (+) 0 (zipWith (*) a b)


countEven a = length (filter (even) a)


quicksort (x:xs) = quicksort(filter (< x) xs) ++ [x] ++ quicksort(filter (>= x) xs)

{--
inversion x = if x == True then False else True
comparator x y = y >= x
quicksort' [] comparator = []
quicksort' (x:xs) comparator = quicksort'(filter (comparator x) xs) ++ [x] ++ quicksort'(filter (comparator x) xs)
--}


delete :: Char -> String -> String
delete c [] = []
delete c str = filter (/=c) str