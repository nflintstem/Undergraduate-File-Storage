#include "bots.h"

bool isAdjacent(int startNum, int endNum) {
	if (endNum - startNum == 1) {
		return true;
	}
	if (endNum - startNum == 0) {
		return true;
	}
	if (endNum - startNum == -1) {
		return true;
	}
	else {
		return false;
	}
}

void cDijkstra::Build(cBotBase& bot) {
	for (int i = 0; i < GRIDWIDTH; i++) {
		for (int j = 0; j < GRIDHEIGHT; j++) {
			closed[i][j] = false;
			cost[i][j] = INT_MAX;
			linkX[i][j] = -1;
			linkY[i][j] = -1;
			inPath[i][j] = false;
			Current[i][j] = false;
		}
	}
	int TargetX = gTarget.PositionX();
	int TargetY = gTarget.PositionY();
	int startX = bot.PositionX();
	int startY = bot.PositionY();
	cost[startX][startY] = 0;
	int CurrentX = startX;
	int CurrentY = startY;
	while (closed[gTarget.PositionX()][gTarget.PositionY()] == false) {
		int minimum = cost[CurrentX][CurrentY];
		int minPlaceX = CurrentX;
		int minPlaceY = CurrentY;

		for (int k = 0; k < GRIDWIDTH; k++)
		{
			for (int L = 0; L < GRIDHEIGHT; L++)
			{
				if (gLevel.isValid(k, L) && !closed[k][L] && cost[k][L] <= minimum)
				{
					minimum = cost[k][L];
					minPlaceX = k;
					minPlaceY = L;
				}
			}

		}
		CurrentX = minPlaceX;
		CurrentY = minPlaceY;
		closed[CurrentX][CurrentY] = true;
		for (int deltaX = -1; deltaX <= 1; deltaX++)
		{
			for (int deltaY = -1; deltaY <= 1; deltaY++)
			{
				int newX = CurrentX + deltaX;
				int newY = CurrentY + deltaY;
				if (gLevel.isValid(newX, newY) && !closed[newX][newY])
				{
					if (newX == CurrentX || newY == CurrentY) {
						float newcost = cost[CurrentX][CurrentY] + 1;
						if (newcost < cost[newX][newY]) {
							cost[newX][newY] = newcost;
							linkX[newX][newY] = CurrentX;
							linkY[newX][newY] = CurrentY;
						}
					}
					else {
						float newcost = cost[CurrentX][CurrentY] + 1.4;
						if (newcost < cost[newX][newY]) {
							cost[newX][newY] = newcost;
							linkX[newX][newY] = CurrentX;
							linkY[newX][newY] = CurrentY;
						}
					}
				}
			}
		}
	}
	bool done = false; //set to true when we are back at the bot position
	int nextClosedX = gTarget.PositionX(); //start of path
	int nextClosedY = gTarget.PositionY(); //start of path
	while (!done)
	{
		inPath[nextClosedX][nextClosedY] = true;
		int tmpX = nextClosedX;
		int tmpY = nextClosedY;
		nextClosedX = linkX[tmpX][tmpY];
		nextClosedY = linkY[tmpX][tmpY];
		if (nextClosedX == bot.PositionX() && nextClosedY == bot.PositionY()) done = true;
	}
	completed = true;
}
cDijkstra gDijkstra;

void cAStar::Build(cBotBase& bot)
{
	for (int i = 0; i < GRIDWIDTH; i++) {
		for (int j = 0; j < GRIDHEIGHT; j++) {
			closed[i][j] = false;
			cost[i][j] = INT_MAX;
			linkX[i][j] = -1;
			linkY[i][j] = -1;
			inPath[i][j] = false;
			Current[i][j] = false;
		}
	}
	int TargetX = gTarget.PositionX();
	int TargetY = gTarget.PositionY();
	int startX = bot.PositionX();
	int startY = bot.PositionY();
	cost[startX][startY] = 0;
	int CurrentX = startX;
	int CurrentY = startY;
	while (closed[gTarget.PositionX()][gTarget.PositionY()] == false) {
		int minimum = cost[CurrentX][CurrentY];
		int minPlaceX = CurrentX;
		int minPlaceY = CurrentY;

		for (int k = 0; k < GRIDWIDTH; k++)
		{
			for (int L = 0; L < GRIDHEIGHT; L++)
			{
				if (gLevel.isValid(k, L) && !closed[k][L] && cost[k][L] <= minimum)
				{
					minimum = cost[k][L];
					minPlaceX = k;
					minPlaceY = L;
				}
			}

		}
		CurrentX = minPlaceX;
		CurrentY = minPlaceY;
		closed[CurrentX][CurrentY] = true;
		for (int deltaX = -1; deltaX <= 1; deltaX++)
		{
			for (int deltaY = -1; deltaY <= 1; deltaY++)
			{
				int newX = CurrentX + deltaX;
				int newY = CurrentY + deltaY;
				if (gLevel.isValid(newX, newY) && !closed[newX][newY])
				{
					if (newX == CurrentX || newY == CurrentY) {
						float heuristic = fabs(gTarget.PositionX() - newX) + fabs(gTarget.PositionY() - newY);
						float gcost = cost[CurrentX][CurrentY] + 1;
						float newcost = heuristic + gcost;
						if (newcost < cost[newX][newY]) {
							cost[newX][newY] = newcost;
							linkX[newX][newY] = CurrentX;
							linkY[newX][newY] = CurrentY;
						}
					}
					else {
						float heuristic = fabs(gTarget.PositionX() - newX) + fabs(gTarget.PositionY() - newY);
						float gcost = cost[CurrentX][CurrentY] + 1.4;
						float newcost = heuristic + gcost;
						if (newcost < cost[newX][newY]) {
							cost[newX][newY] = newcost;
							linkX[newX][newY] = CurrentX;
							linkY[newX][newY] = CurrentY;
						}
					}
				}
			}
		}
	}
	bool done = false; //set to true when we are back at the bot position
	int nextClosedX = gTarget.PositionX(); //start of path
	int nextClosedY = gTarget.PositionY(); //start of path
	while (!done)
	{
		inPath[nextClosedX][nextClosedY] = true;
		int tmpX = nextClosedX;
		int tmpY = nextClosedY;
		nextClosedX = linkX[tmpX][tmpY];
		nextClosedY = linkY[tmpX][tmpY];
		if (nextClosedX == bot.PositionX() && nextClosedY == bot.PositionY()) done = true;
	}
	completed = true;
}