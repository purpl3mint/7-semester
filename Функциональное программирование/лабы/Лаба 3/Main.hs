module Lab3 where

{--Get the geometric mean--}
mean :: [Double] -> Double
mean [] = 0
mean s = (foldr (*) 1 s) ** (1.0 / (foldr(\x y -> 1.0+x) 0.0 s))

{--Get scalar product --}
scalar :: [Double] -> [Double] -> Double
scalar [] [] = 0
scalar a b = foldr (+) 0 (zipWith (*) a b)

{--Count negative numbers --}
countNegat :: [Double] -> Int
getNegat :: [Double] -> [Double]
getNegat = filter (\x -> x<0)
countNegat a = length (getNegat a)

{--Quicksort without comparator --}
quicksort :: [Double] -> [Double]
quicksort [] = []
quicksort (x:xs) = quicksort(filter (< x) xs) ++ [x] ++ quicksort(filter (>= x) xs)

{--Quicksort with comparator --}
quicksort' :: (a -> a -> Bool) -> [a] -> [a]
quicksort' cmp []     = []
quicksort' cmp (x:xs) = quicksort' cmp (filter (cmp x) xs)
                      ++ [x] ++
                      quicksort' cmp (filter (not . (cmp x)) xs)

{--Delete character from string --}
delete :: Char -> String -> String
delete c [] = []
delete c str = filter (/=c) str

belongsSet :: Double -> Double -> Bool
lowBorder = 1
highBorder = 5
belongsSet x b = if (b <= highBorder && b >= lowBorder) then True else False