#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <math.h>

int main(int argc, char* argv[])
{
	int a1, b1;
	float x1, x2, a, b, c, d;;
	if ((strcmp(argv[1], "/q") == 0) || (strcmp(argv[1], "-q") == 0))
	{
		if (argc != 5)
		{
			printf("Invalid arguments count!");
			return 2;
		}

		if (sscanf(argv[2], "%f", &a) != 1 || a == 0)
		{
			printf("Invalid value of first parameter!");
			return 3;
		}

		if (sscanf(argv[3], "%f", &b) != 1)
		{
			printf("Invalid value of second parameter!");
			return 4;
		}

		if (sscanf(argv[4], "%f", &c) != 1)
		{
			printf("Invalid value of third parameter!");
			return 5;
		}
		d = (b * b - 4 * a * c);
		if (d > 0)
		{
			x1 = (-b + (sqrtf(d))) / (2.0 * a);
			x2 = (-b - (sqrtf(d))) / (2.0 * a);
			printf("x1 = %f, x2 = %f", x1, x2);
		}
		if (d == 0)
		{
			x1 = (- b) / (2.0 * a);
			printf("x1 = %f", x1);
		}
		if (d < 0)
		{
			printf("There are no roots!");
			return 6;
		}
		return 0;
	}
	else if ((strcmp(argv[1], "/m") == 0) || (strcmp(argv[1], "-m") == 0))
	{
		if (argc != 4)
		{
			printf("Invalid arguments count!");
			return 2;
		}

		if (sscanf(argv[2], "%d", &a1) != 1 || a1 == 0)
		{
			printf("Invalid value of first parameter!");
			return 3;
		}

		if (sscanf(argv[3], "%d", &b1) != 1 || b1 == 0)
		{
			printf("Invalid value of second parameter!");
			return 4;
		}
		
		if (a1 % b1 == 0)
		{
			printf("Yes, multiple");
		}
		else
		{
			printf("No, not multiple");
		}
	}
	else if ((strcmp(argv[1], "/t") == 0) || (strcmp(argv[1], "-t") == 0))
	{
		if (argc != 5)
		{
			printf("Invalid arguments count!");
			return 2;
		}

		if (sscanf(argv[2], "%f", &a) != 1 || a == 0)
		{
			printf("Invalid value of first parameter!");
			return 3;
		}

		if (sscanf(argv[3], "%f", &b) != 1 || b == 0)
		{
			printf("Invalid value of second parameter!");
			return 4;
		}

		if (sscanf(argv[4], "%f", &c) != 1 || c == 0)
		{
			printf("Invalid value of third parameter!");
			return 5;
		}

		if (a > b && a > c)
		{
			if (a * a == b * b + c * c)
			{
				printf("This is a right triangle");
			}
			else
			{
				printf("It's not a right triangle");
			}
		}

		if (a < b && b > c)
		{
			if (b * b == a * a + c * c)
			{
				printf("This is a right triangle");
			}
			else
			{
				printf("It's not a right triangle");
			}
		}

		if (c > a && b < c)
		{
			if (c * c == a * a + b * b)
			{
				printf("This is a right triangle");
			}
			else
			{
				printf("It's not a right triangle");
			}
		}

		if (c == a && b == c)
		{
			printf("It's not a right triangle");
		}

	}
	else
	{
		printf("Not a real flag!");
		return 1;
	}
}
