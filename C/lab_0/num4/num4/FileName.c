#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>



int main() {
    FILE *inputFile, *outputFile;
    char first[1000], second[1000], third[1000], error[1000];
    int count1 = 0, count2 = 0, countstr = 1, strings;

    inputFile = fopen("input.txt", "r");
    if (inputFile == NULL) {
        printf("Error opening the file input!");
        return 1;
    }

    while ((strings = fgetc(inputFile)) != EOF)
    {
        if (strings == '\n')
        {
            countstr++;
        }
    }
    rewind(inputFile);

    while ((fscanf(inputFile, "%s %s %s", first, second, third)) == 3)
    {
        count1++;
    }
    rewind(inputFile);

    while ((fscanf(inputFile, "%s", error)) == 1)
    {
        count2++;
    }
    rewind(inputFile);
    
    if ((countstr != count1) || (count2 != (count1 * 3)))
    {
        printf("The file does not contain three columns in all rows!\n");
        return 2;
    }


    outputFile = fopen("output.txt", "w");
    if (outputFile == NULL) {
        printf("Error opening the file output!");
        return 3;
    }

    while (fscanf(inputFile, "%s %s %s", first, second, third) == 3) {
        fprintf(outputFile, "%s %s %s\n", third, first, second);
    }

    fclose(inputFile);
    fclose(outputFile);

    return 0;
}