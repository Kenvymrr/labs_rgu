#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>
#include <string.h>

int main( int argc, char* argv[])
{
    unsigned int value, accumulator;
    int i, j, primality_flag;
    char str[1000]; 
    unsigned long long int counter;

    for (i = 0; i <= argc - 1; i++)
    {
        printf("%s\n", argv[i]);
    }

    if (argc != 3)
    {
        printf("Invalid arguments count!");
        return 1;
    }

    if (sscanf(argv[1], "%u", &value) != 1 || value == 0)
    {
        printf("Invalid value of second parameter!");
        return 2;
    }

    if ((strcmp(argv[2], "/h") == 0) || (strcmp(argv[2], "-h") == 0))
    {
        if (value <= 100)
        {
            accumulator = value;
            while (accumulator <= 100)
            {
                printf("%d ", accumulator);
                accumulator += value;
            }
        }
        else
        {
            printf("There are no multiples");
            return 3;
        }
        
    }
    else if ((strcmp(argv[2], "/p") == 0) || (strcmp(argv[2], "-p") == 0))
    {
        if (value == 1)
        {
            printf("Nor prime neither composite\n");
        }
        else if (value == 2)
        {
            printf("Prime\n");
        }
        else if ((value & 1) == 0)
        {
            printf("Composite\n");
        }
        else
        {
            primality_flag = 1;
            for (i = 3; i <= (int)sqrt(value); i += 2)
            {
                if (value % i == 0)
                {
                    primality_flag = 0;
                    break;
                }
            }
            printf(primality_flag == 0 ? "Composite" : "Prime");
        }
    }
    else if ((strcmp(argv[2], "/s") == 0) || (strcmp(argv[2], "-s") == 0))
    {
        sprintf(str, "%d", value);
        for (int i = 0; i <= strlen(str); i++)
        {
            printf("%c ", str[i]);
        }
      
    }
    else if ((strcmp(argv[2], "/e") == 0) || (strcmp(argv[2], "-e") == 0)) 
    {
        if (value <= 10)
        {
            for (i = 1; i <= 10; i++)
            {
                printf("%d: ", i);
                counter = 1;
                for (j = 1; j <= value; j ++)
                {
                    counter *= i;
                    printf("%llu ", counter);
                }
                printf("\n");
            }
        }
        else
        {
            printf("Value greater than 10");
            return 4;
        }
    }
    else if ((strcmp(argv[2], "/a") == 0) || (strcmp(argv[2], "-a") == 0))
    {
        counter = (value + 1) * (value / 2);
        printf("%llu", counter);
    }
    else if ((strcmp(argv[2], "/f") == 0) || (strcmp(argv[2], "-f") == 0))
    {
        counter = 1;
        if (value == 1)
        {
            printf("1");
        }
        else
        {
            for (i = 1; i <= value; i++)
            {
                counter *= i;
            }
            printf("%llu", counter);
        }
    }
    return 0;
}