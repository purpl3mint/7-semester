/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
grammar FortranCommentsLexer;

prog: (comment)+;

comment: (STAR correct)|((LETTER|DIGIT|SPLITTER) error)|ENDOFLINE;

correct: (LETTER|DIGIT|SPLITTER|STAR)* ENDOFLINE;

error:  (LETTER|DIGIT|SPLITTER|STAR)* ENDOFLINE;

STAR:       '*';
LETTER:     ('a'..'z'|'A'..'Z');
DIGIT:      ('0'..'9');
SPLITTER:   ('.'|','|'!'|'?'|'('|')'|'{'|'}'|'['|']'|'+'|'-'|'='|'\\'|'/'|'<'|
             '>'|' ');
ENDOFLINE:  (('\r'? '\n')|'\0');