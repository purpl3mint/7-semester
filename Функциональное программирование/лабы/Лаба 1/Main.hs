module Lab1 where


a = (('a', 1), "foo", [2.9, 3.1])
b = [(4.1, True, ("foo", 10)), (5.1, False, ("bar", 59))]
c = ([4, 3, 8], [4.6, 63.1, 97,6], [(True, 'a'), (False, 'b')])
d = [[[(1, True), (2, True)], [(3, False)]], [[(10, False)], [(23, False), (4, True)], [(0, False)]]]
e = ((('f', 'g'), 'e'), ["aaa", "bbb"])
f = (([3.4, 0.1], [True, False, False]), [1, 2, 60])
g = [(1, (2, [True, False])), (3, (4, [False, False, False]))]
h = (True, ([True, False, True], [3, 1, 6]))
i = [([True, True], [1.4, 6.3, 9.4]), ([False, True], [6.2])]
j = [([4, 2, 59], ['g', 'j', 'r']), ([5, 7, 1], ['t'])]


basement p l = p - 2 * l