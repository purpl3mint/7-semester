grammar BASIC;		
prog        : (expr NEWLINE)*;

expr        : id'='ae';';

id          : SYMBOLW(SYMBOLW | DIGIT)*;

ae          : term | term'+'ae;

term        : operator | operator'*'term;

operator    : ('-')?(id | floatw | '(' ae ')');

floatw      : number('.'number)*;

number      : DIGIT(DIGIT)*;

SYMBOLW      : ('a'..'z'|'A'..'Z');
DIGIT       : ('0'..'9');
NEWLINE     : [\r\n]+;
