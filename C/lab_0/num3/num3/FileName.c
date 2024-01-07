#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>

FILE* file, * fileout_;
char* ch;
char sym;
char prefix[5] = "out_";

char c; int i, count = 0;
int main(int argc, char* argv[]) 
{
    if ((file = fopen(argv[2], "r")) == NULL) 
    {
        printf("Invalid reading file");
        return 1;
    }

    char* ninflag;
    ninflag = strchr(argv[1], 'n');
    if (ninflag == NULL) 
    {
        if (argc != 3) 
        {
            printf("Invalid count element(not 3 arguments)");
            return 2;
        }
        fileout_ = fopen(strcat(prefix, argv[2]), "w");

    }

    else 
    {
        if (argc != 4) 
        {
            printf("Invalid count element(not 4 elements)");
            return 3;
        }
        fileout_ = fopen(argv[3], "w");
    }

    if (fileout_ == NULL) 
    {
        printf("Invalid writing file");
        return 4;
    }

    if ((strcmp(argv[1], "-nd") == 0) || (strcmp(argv[1], "/nd") == 0) || (strcmp(argv[1], "-d") == 0) || (strcmp(argv[1], "/d") == 0)) 
    {
        while ((ch = fgetc(file)) != EOF)
        {
            if (!isdigit(ch))
            {
                fputc(ch, fileout_);
            }
        }
    }

    if ((strcmp(argv[1], "-ni") == 0) || (strcmp(argv[1], "/ni") == 0) || (strcmp(argv[1], "-i") == 0) || (strcmp(argv[1], "/i") == 0)) 
    {
        int count = 0, numString = 0;

        while ((sym = fgetc(file)))
        {
            if (isalpha(sym))
            {
                count++;
            }
            if (sym == '\n' || sym == EOF)
            {
                fprintf(fileout_, "The number of letters in the %d line: %d\n", ++numString, count);
                count = 0;
                if (sym == EOF)
                {
                    break;
                }
            }
        }
    }

    if ((strcmp(argv[1], "-ns") == 0) || (strcmp(argv[1], "/ns") == 0) || (strcmp(argv[1], "-s") == 0) || (strcmp(argv[1], "/s") == 0)) 
    {
        int count = 0, numString = 0;

        while ((sym = fgetc(file)))
        {
            if (sym != EOF && !isalpha(sym) && !isspace(sym) && !isdigit(sym))
            {
                count++;
            }
            if (sym == '\n' || sym == EOF)
            {
                fprintf(fileout_, "The number of letters in the %d line: %d\n", ++numString, count);
                count = 0;
                if (sym == EOF)
                {
                    break;
                }
            }
        }
    }

    if ((strcmp(argv[1], "-na") == 0) || (strcmp(argv[1], "/na") == 0) || (strcmp(argv[1], "-a") == 0) || (strcmp(argv[1], "/a") == 0)) 
    {
        while ((sym = fgetc(file)) != EOF)
        {
            if (!isdigit(sym))
            {
                fprintf(fileout_, "%d ", sym);
            }
        }
    }

    if ((strcmp(argv[1], "-nf") == 0) || (strcmp(argv[1], "/nf") == 0) || (strcmp(argv[1], "-f") == 0) || (strcmp(argv[1], "/f") == 0)) 
    {
        int count = 0;

        while ((sym = fgetc(file)) != EOF)
        {
            if (isspace(sym))
            {
                fputc(sym, fileout_);
                count++;
            }
            else if (count % 2 == 1)
            {
                fprintf(file, "%c", tolower(sym));
            }
            else if (count % 5 == 4)
            {
                fprintf(fileout_, "%d", sym);
            }
            else
            {
                fputc(sym, fileout_);
            }
        }
    }
    fclose(file);
    fclose(fileout_);
    return 0;
}