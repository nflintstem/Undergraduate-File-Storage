# include "bots.h"

void cBotSimple::ChooseNextGridPosition()
{
	//Your code will go here
	bool done = false;
	int startX = PositionX();
	int startY = PositionY();
	int targetX = gTarget.PositionX();
	int targetY = gTarget.PositionY();
	int yDist = abs(targetY - startY);
	int xDist = abs(targetX - startX);
	if ((startY == targetY) || (xDist < yDist)) {
		int posRight = startX + 1;
		int posLeft = startX - 1;
		int distRight = abs(targetX - posRight);
		int distLeft = abs(targetX - posLeft);
		if (distLeft < distRight) {
			done = SetNext(posLeft, startY, gLevel);
		}
		else {
			done = SetNext(posRight, startY, gLevel);
		}
	}
	if ((startX == targetX) || (yDist < xDist)) {
		int posUp = startY - 1;
		int posDown = startY + 1;
		int distUp = abs(targetY - posUp);
		int distDown = abs(targetY - posDown);
		if (distDown < distUp) {
			done = SetNext(startX, posDown, gLevel);
		}
		else {
			done = SetNext(startX, posUp, gLevel);
		}
	}
};