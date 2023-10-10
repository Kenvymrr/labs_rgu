#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

main()
{
	int *massive;
	int i, n, idmin, idmax, min, max;
	printf("Enter the length of the array: ");
	scanf("%d", &n);
	if (n < 1)
	{
		printf("Incorrect array length is entered!");
		return 1;
	}
	massive = (int*)malloc(n * sizeof(int));
	printf("Old massive: ");
	for (i = 0; i <= (n - 1); i++)
	{
		massive[i] = rand() % 2147483647;
		printf("%d ", massive[i]);
	}

	max = 0;
	min = 2147483647;
	for (i = 0; i <= (n - 1); i++)
	{
		if (massive[i] < min)
		{
			min = massive[i];
			idmin = i;
		}
		if (massive[i] > max)
		{
			max = massive[i];
			idmax = i;
		}
	}
	massive[idmin] = max;
	massive[idmax] = min;

	printf("\nNew massive: ");
	for (i = 0; i <= (n - 1); i++)
	{
		printf("%d ", massive[i]);
	}
	return 0;
}