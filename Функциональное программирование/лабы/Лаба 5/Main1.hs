data File = DataFile String Integer | Folder String [File] deriving Show
 
find :: String -> File -> String
find s1 (DataFile s _) | s == s1 = s
find s1 (Folder s xs) =  s ++ "/" ++ (concat (map (\ y -> find s1 y) xs))
find _ _ = []
 
-- Проверка
{--  
Main> find "F2" (Folder "Root" [Folder "Second" [DataFile "F3" 4], DataFile "F1" 5, DataFile "F2" 1])
 
"Root/Second/F2"
--}