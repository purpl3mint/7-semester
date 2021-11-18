/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

grammar CommentsFortran;

options
{
    language = CSharp;
}
@parser::namespace { comment_analyzer }
@lexer::namespace  { comment_analyzer }

@header {
         using System;
         using System.Collections;
}


prog
        : (comment WS)* comment? EOF;

/*
comment
        : (STAR correct) { Console.WriteLine("Correct"); }
        |((LETTER|DIGIT|SPLITTER) error) { Console.WriteLine("Error! Line is not comment"); }
        |ENDOFLINE { Console.WriteLine("Empty Line")};

comment
        : (STAR correct)
        |((LETTER|DIGIT|SPLITTER) error)
        |ENDOFLINE;
*/

comment
        : STAR (LETTER|DIGIT|SPLITTER|STAR)*;

/*
correct
        : (LETTER|DIGIT|SPLITTER|STAR)*;


error
        : (LETTER|DIGIT|SPLITTER|STAR)*;
*/

STAR:       '*';
LETTER:     ('a'..'z'|'A'..'Z');
DIGIT:      ('0'..'9');
SPLITTER:   ('.'|','|'!'|'?'|'('|')'|'{'|'}'|'['|']'|'+'|'-'|'='|'\\'|'/'|'<'|
             '>'|' ');
//NEWLINE:    '\r'? '\n';
WS: ( '\r'? '\n');
