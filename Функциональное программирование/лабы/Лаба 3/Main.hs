module Lab3 where

average :: [Double] -> Double
average [] = 0
average s = foldr (+) 0 s / foldr (\x y -> 1+y) 0 s

dotLists :: [Double] -> [Double] -> Double
dotLists [] [] = 0
dotLists a b = foldr (+) 0 (zipWith (*) a b)

countNegat :: [Double] -> Int
getNegat :: [Double] -> [Double]
getNegat = filter (\x -> x<0)
countNegat a = length (getNegat a)

quicksort :: [Double] -> [Double]
quicksort [] = []
quicksort (x:xs) = quicksort(filter (< x) xs) ++ [x] ++ quicksort(filter (>= x) xs)

quicksort' :: (a -> a -> Bool) -> [a] -> [a]
quicksort' p []     = []
quicksort' p (x:xs) = quicksort' p (filter (p x) xs)
                      ++ [x] ++
                      quicksort' p (filter (not . (p x)) xs)

delete :: Char -> String -> String
delete c [] = []
delete c str = filter (/=c) str