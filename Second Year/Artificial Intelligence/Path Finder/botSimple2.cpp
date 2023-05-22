#include "bots.h"

void cBotSimple2::ChooseNextGridPosition()
{
	//Your code will go here
	bool done = false;
	int startX = PositionX();
	int startY = PositionY();
	int targetX = gTarget.PositionX();
	int targetY = gTarget.PositionY();
	int posRight = 0;
	int posLeft = 0;
	int posUp = 0;
	int posDown = 0;
	if (gLevel.isValid(startX + 1, startY)) {
		posRight = startX + 1;
	}
	if (gLevel.isValid(startX - 1, startY)) {
		posLeft = startX - 1;
	}
	if (gLevel.isValid(startX, startY + 1)) {
		posDown = startY + 1;
	}
	if (gLevel.isValid(startX, startY - 1)) {
		posUp = startY - 1;
	}
	int distRight = abs(targetX - posRight);
	int distLeft = abs(targetX - posLeft);
	int distUp = abs(targetY - posUp);
	int distDown = abs(targetY - posDown);
	if (startY == targetY) {
		if ((distLeft < distRight) && (posLeft != 0)) {
			done = SetNext(posLeft, startY, gLevel);
		}
		else if (posRight != 0) {
			done = SetNext(posRight, startY, gLevel);
		}
		else {
			done = SetNext(startX, startY + 1, gLevel);
		}
	}
	if (startX == targetX) {
		if ((distDown < distUp) && (posDown != 0)) {
			done = SetNext(startX, posDown, gLevel);
		}
		else if (posUp != 0) {
			done = SetNext(startX, posUp, gLevel);
		}
		else {
			done = SetNext(startX + 1, startY, gLevel);
		}
	}
	else {
		if ((distLeft < distRight) && (distDown < distUp)) {
			done = SetNext(posLeft, posDown, gLevel);
		}
		if ((distLeft < distRight) && (distUp < distDown)) {
			done = SetNext(posLeft, posUp, gLevel);
		}
		if ((distRight < distLeft) && (distDown < distUp)) {
			done = SetNext(posRight, posDown, gLevel);
		}
		if ((distRight < distLeft) && (distUp < distDown)) {
			done = SetNext(posRight, posUp, gLevel);
		}
	}
};