%option noyywrap

%{
#include <stdio.h>

#define YY_DECL int yylex()

#include "CommentAnalyzer.tab.h"

%}

%%

["\t"]	; // ignore all whitespace
"\n"		{return T_NEWLINE;}
"exit"		{return T_QUIT;}
"quit"		{return T_QUIT;}

"*"                     {return T_STAR;}
[0-9]                   {return T_DIGIT;}
[a-zA-Z]                {return T_LETTER;}
[.,!?(){}+-=<> ]        {return T_SPLITTER;}

%%