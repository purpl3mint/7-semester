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
@parser::namespace { CommentAnalyzerTest }
@lexer::namespace  { CommentAnalyzerTest }

@header {
         using System;
         using System.Collections;
}

prog
        : (comment)+;

comment
        : (STAR correct) { Console.WriteLine("Correct"); }
        |((LETTER|DIGIT|SPLITTER) error) { Console.WriteLine("Error"); }
        |ENDOFLINE;

correct
        : (LETTER|DIGIT|SPLITTER|STAR)* ENDOFLINE;

error
        : (LETTER|DIGIT|SPLITTER|STAR)* ENDOFLINE;

STAR:       '*';
LETTER:     ('a'..'z'|'A'..'Z');
DIGIT:      ('0'..'9');
SPLITTER:   ('.'|','|'!'|'?'|'('|')'|'{'|'}'|'['|']'|'+'|'-'|'='|'\\'|'/'|'<'|
             '>'|' ');
ENDOFLINE:  '\r'? '\n';
