%{
#undef UNICODE

#define WIN32_LEAN_AND_MEAN

#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "777"
#define ERROR_MAX_LENGTH 160

int lineCounter = 1;
int errorType = 0;

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
	|comment prog
;

comment: T_NEWLINE	{lineCounter++;}
	|	T_QUIT T_NEWLINE	{exit(0);}
	|   T_STAR correct T_NEWLINE	{lineCounter++;}
	|	T_LETTER notcomment error T_NEWLINE	{lineCounter++;}
	|	T_DIGIT notcomment error T_NEWLINE	{lineCounter++;}
	|	T_SPLITTER notcomment error T_NEWLINE	{lineCounter++;}
;

correct:
	|	T_LETTER correct
	|	T_DIGIT correct
	|	T_SPLITTER correct
	|	T_STAR correct
;

notcomment: {errorType = 1;}

%%

int errorsCount = 0;
char** errors;


int __cdecl main(void) {
	
    WSADATA wsaData;
    int iResult;

    SOCKET ListenSocket = INVALID_SOCKET;
    SOCKET ClientSocket = INVALID_SOCKET;

    struct addrinfo *result = NULL;
    struct addrinfo hints;

    int iSendResult;
    char recvbuf[DEFAULT_BUFLEN];
    int recvbuflen = DEFAULT_BUFLEN;
    
    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2,2), &wsaData);
    if (iResult != 0) {
        printf("WSAStartup failed with error: %d\n", iResult);
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_INET;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;
    hints.ai_flags = AI_PASSIVE;

    // Resolve the server address and port
    iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
    if ( iResult != 0 ) {
        printf("getaddrinfo failed with error: %d\n", iResult);
        WSACleanup();
        return 1;
    }

    // Create a SOCKET for connecting to server
    ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
    if (ListenSocket == INVALID_SOCKET) {
        printf("socket failed with error: %ld\n", WSAGetLastError());
        freeaddrinfo(result);
        WSACleanup();
        return 1;
    }

		// Setup the TCP listening socket
    iResult = bind( ListenSocket, result->ai_addr, (int)result->ai_addrlen);
    if (iResult == SOCKET_ERROR) {
        printf("bind failed with error: %d\n", WSAGetLastError());
        freeaddrinfo(result);
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

		freeaddrinfo(result);

    iResult = listen(ListenSocket, SOMAXCONN);
    if (iResult == SOCKET_ERROR) {
        printf("listen failed with error: %d\n", WSAGetLastError());
        closesocket(ListenSocket);
        WSACleanup();
        return 1;
    }

    printf("Server opened at 127.0.0.1:%s\n", DEFAULT_PORT);

	do {
        // Accept a client socket
        ClientSocket = accept(ListenSocket, NULL, NULL);
        if (ClientSocket == INVALID_SOCKET) {
            printf("accept failed with error: %d\n", WSAGetLastError());
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        // No longer need server socket
        //closesocket(ListenSocket);

        // Receive until the peer shuts down the connection
        do {
            iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
            if (iResult > 0) {
                printf("Bytes received: %d\n", iResult);

                printf("Message: %s\n", recvbuf);


                FILE* input = fopen("input.txt", "w");
                fprintf(input, "%s", recvbuf);
                fclose(input);

                yyin = fopen("input.txt", "r");
                do {
                    yyparse();
                }while(!feof(yyin));

                char error[ERROR_MAX_LENGTH * errorsCount * sizeof(char)];

                strcpy(error, (char*)"");
                if (errorsCount - 1 > 0) {
                    for(int i = 0; i < errorsCount; i++) {
                        if (i == 0)
                            strcpy(error, errors[i]);
                        else
                            strcat(error, errors[i]);
                    }

                    strcat(error, "\r\n");
                    strcat(error, "Total errors: ");
                    char* totalErrors = (char*) calloc (sizeof(char), 10);
                    itoa(errorsCount - 1, totalErrors, 10);
                    strcat(error, totalErrors);
                } else {
                    strcpy(error, (char*)"No errors\r\n");
                }

                // Echo the buffer back to the sender
                iSendResult = send( ClientSocket, error, ERROR_MAX_LENGTH * errorsCount * sizeof(char), 0 );
                if (iSendResult == SOCKET_ERROR) {
                    printf("send failed with error: %d\n", WSAGetLastError());
                    closesocket(ClientSocket);
                    WSACleanup();
                    return 1;
                }
                printf("Bytes sent: %d\n", iSendResult);

            }
            else if (iResult == 0)
                printf("Waiting for new data...\n");
            else  {
                printf("recv failed with error: %d\n", WSAGetLastError());
                closesocket(ClientSocket);
                WSACleanup();
                return 1;
            }

            errors = NULL;
            errorsCount = 0;
            lineCounter = 1;
            errorType = 0;
            for (int i = 0; i < recvbuflen; i++){
                recvbuf[i] = (char)0;
            }
        } while (iResult > 0);

        // shutdown the connection since we're done
        iResult = shutdown(ClientSocket, SD_SEND);
        if (iResult == SOCKET_ERROR) {
            printf("shutdown failed with error: %d\n", WSAGetLastError());
            closesocket(ClientSocket);
            WSACleanup();
            return 1;
        }
    }while(true);
    // cleanup
    closesocket(ClientSocket);
    WSACleanup();

	exit(0);
}

void yyerror(const char* s) {

	if (errors == NULL) {
		errors = (char**) calloc (sizeof(char*), ++errorsCount);
	} else {
		errors = (char**) realloc (errors, sizeof(char*)*(++errorsCount));
	}


	errors[errorsCount - 1] = (char*) calloc (sizeof(char), 200);

	if (errorType == 1) {
		strcpy(errors[errorsCount - 1], "");
		char* line = (char*) calloc (sizeof(char), 10);
		itoa(lineCounter, line, 10);
		strcat(errors[errorsCount - 1], "Line:");
		strcat(errors[errorsCount - 1], (const char*)line);
		strcat(errors[errorsCount - 1], ": [ERROR] line is not a comment\r\n");
	}

	errorType = 0;

	//exit(1);
}