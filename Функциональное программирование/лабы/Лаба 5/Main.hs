module Lab5 where

type MyFile = (String, Integer)

data MySystem =   FFile MyFile
                | FDir  (String, [MySystem]) deriving Show

{--File system for examples --}
fs = (FDir ("Main", [FFile ("bin.exe", 19000), FFile ("run.exe", 434200), FDir ("Log", [FFile ("log1.txt", 1000), FFile ("log2.txt", 3500), FFile ("run.exe", 434200)])]))

{--Total length of files in file system--}
du :: MySystem -> Integer
du (FDir (x,[])) = 0
du (FFile x)     = snd(x)
du (FDir  (x,y)) = du(head(y))+du(FDir (x,tail(y))) 

{--List of all filenames in file system --} 
dirscan :: (String,MySystem) -> String
dirscan (c,(FDir (x,[]))) = []
dirscan (c,(FFile x))     = c++"/"++fst(x)
dirscan (c,(FDir(x,y)))   = if (c=="/") then
                              dirscan( c++x ,head(y) )++";  "++dirscan( c, FDir(x,tail(y)) ) 
                           else
                              dirscan( c++"/"++x ,head(y) )++";  "++dirscan( c, FDir(x,tail(y)) ) 

dirAll :: MySystem -> String
dirAll (FFile x)     = fst(x)
dirAll (FDir (x,[])) = []
dirAll (FDir (x,y))  = dirscan("/",FDir(x,y))


{--Find file by filename in file system --} 
fscan :: (String,String,MySystem) -> String
fscan (n,c,(FDir (x,[]))) = []
fscan (n,c,(FFile x))     = if fst(x) == n then 
                               c++"/"++fst(x)++" "++show(snd(x))++";  "
                            else
                               ""
fscan (n,c,(FDir(x,y)))   = if (c=="/") then
                              fscan( n, c++x ,head(y) )++fscan( n, c, FDir(x,tail(y)) ) 
                           else
                              fscan( n, c++"/"++x ,head(y) )++fscan( n, c, FDir(x,tail(y)) ) 

find :: (String,MySystem) -> String
find (n,x) = fscan(n,"/",x)