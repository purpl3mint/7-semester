module Lab4 where

{-- 
Data types:

Flat level squareAll maxLevel
Room level squareAll maxLevel squareRoom
House squareAll

--}

data RealEstate = Null |
                  Flat Integer Double Integer |
                  Room Integer Double Integer Double |
                  House Double deriving(Eq, Show)


db = [(Flat 2 44.3 9, 40000),
      (Flat 5 56.1 5, 35000),
      (Room 3 77.0 8 12.5, 10000),
      (House 180.3, 70000)]

getHouses :: [(RealEstate, Integer)] -> [(RealEstate, Integer)]
getHouses [] = []
getHouses (((House squareAll), price):xs) = ((House squareAll), price) : (getHouses xs)
getHouses ((_, _):xs) = getHouses xs

getByPrice :: [(RealEstate, Integer)] -> Integer -> [(RealEstate, Integer)]
getByPrice [] _ = []
getByPrice (x:xs) value | (snd x) < value = x : (getByPrice xs value)
                        |  otherwise = (getByPrice xs value)

getByLevel :: [(RealEstate, Integer)] -> Integer -> [(RealEstate, Integer)]
getByLevel [] _ = []
getByLevel (((Flat level squareAll maxLevel), price):xs) value | level == value = ((Flat level squareAll maxLevel), price) : (getByLevel xs value)
                                                               | otherwise = (getByLevel xs value)
getByLevel ((_, _):xs) value = (getByLevel xs value)

getExceptBounds :: [(RealEstate, Integer)] -> [(RealEstate, Integer)]
getExceptBounds [] = []
getExceptBounds (((Flat level squareAll maxLevel), price):xs) | ((level - 1) * (maxLevel - level)) /= 0 = ((Flat level squareAll maxLevel), price) : (getExceptBounds xs)
                                                              | otherwise = (getExceptBounds xs)
getExceptBounds ((_, _):xs) = (getExceptBounds xs)