module Lab5 where

type MyFile = (String,Integer)
 
data MySystem =   FFile MyFile
                | FDir  (String,[MySystem]) deriving Show
 
{--
Файловая система для примера

fs = ("Main", [("bin.exe", 9323991), ("config.txt", 256), ("lock.txt", 503212), ("Local", [("ru.txt", 40312), ("en.txt", 94912)])])

--}

-- Суммарная длина файлов в каталоге (с подкаталогами)
 
du :: MySystem -> Integer
 
du (FDir (x,[])) = 0
du (FFile x)     = snd(x)
du (FDir  (x,y)) = du(head(y))+du(FDir (x,tail(y))) 
 
-- Сканирование директории
 
dirscan :: (String,MySystem) -> String
 
dirscan (c,(FDir (x,[]))) = []
dirscan (c,(FFile x))     = c++"/"++fst(x)
dirscan (c,(FDir(x,y)))   = if (c=="/") then
                              dirscan( c++x ,head(y) )++"\n"++dirscan( c, FDir(x,tail(y)) ) 
                           else
                              dirscan( c++"/"++x ,head(y) )++"\n"++dirscan( c, FDir(x,tail(y)) ) 
 
-- Список имен файлов произвольной директории 
 
dirAll :: MySystem -> String
 
dirAll (FFile x)     = fst(x)
dirAll (FDir (x,[])) = []
dirAll (FDir (x,y))  = dirscan("/",FDir(x,y))
 
 
fscan :: (String,String,MySystem) -> String
fscan (n,c,(FDir (x,[]))) = []
fscan (n,c,(FFile x))     = if fst(x) == n then 
                               c++"/"++fst(x)++" "++show(snd(x))++"\n"
                            else
                               ""
fscan (n,c,(FDir(x,y)))   = if (c=="/") then
                              fscan( n, c++x ,head(y) )++fscan( n, c, FDir(x,tail(y)) ) 
                           else
                              fscan( n, c++"/"++x ,head(y) )++fscan( n, c, FDir(x,tail(y)) ) 
 
-- Поиск по имени
 
find :: (String,MySystem) -> String
find (n,x) = fscan(n,"/",x)