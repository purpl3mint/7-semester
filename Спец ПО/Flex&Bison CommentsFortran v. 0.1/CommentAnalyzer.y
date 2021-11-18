%{

#include <stdio.h>
#include <stdlib.h>

extern int yylex();
extern int yyparse();
extern FILE* yyin;

void yyerror(const char* s);
%}

%union {
	int ival;
	float fval;
}

%token T_STAR
%token T_DIGIT
%token T_LETTER
%token T_SPLITTER
%token T_NEWLINE
%token T_QUIT

%start prog

%%

prog:
	| prog comment
;

comment: T_NEWLINE
	|	T_QUIT T_NEWLINE					{printf("Good bye\0"); exit(0);}
	| T_STAR correct T_NEWLINE	{printf("Correct comment\n");}
	|	T_LETTER err T_NEWLINE		{printf("Wrong comment\n");}
	|	T_DIGIT err T_NEWLINE			{printf("Wrong comment\n");}
	|	T_SPLITTER err T_NEWLINE	{printf("Wrong comment\n");}
;

correct:
	|	T_LETTER correct
	|	T_DIGIT correct
	|	T_SPLITTER correct
	|	T_STAR correct
;

err:
	|	T_LETTER err
	|	T_DIGIT err
	| T_SPLITTER err
	| T_STAR err
;


%%

int main() {
	yyin = stdin;

	do {
		yyparse();
	} while(!feof(yyin));

	return 0;
}

void yyerror(const char* s) {
	fprintf(stderr, "Parse error: %s\n", s);
	exit(1);
}