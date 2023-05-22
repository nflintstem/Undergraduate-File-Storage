M = readtable("STD_USDA_vegan.csv");
MNum = [M.Fat_g_ M.Fiber_g_ M.Sugars_g_ M.Energy_kcal_ M.Carbohydrate_g_ M.Protein_g_ M.Calcium_mg_ M.Iron_mg_ M.VitaminC_mg_];
MIDs = [M.NDB_NO]
MStrs = [M.Description]
[Z, MMean, MStDev] = zscore(MNum);
C = cov(Z);
[EVec, EVal] = eig(C);
EBasis = (inv(EVec)*Z')';

NewData = [2.3 10 2.1 270 64.1 12.7 50 8.3 1.1];
NDZ = zscore(NewData);
NDBasis = (inv(EVec)*NDZ')';
NDZx = NDBasis(:,9);
NDZy = NDBasis(:,8);

fruitsx = [];
fruitsy = [];
vegetablesx = [];
vegetablesy = [];
legumesx = [];
legumesy= [];
grainsx = [];
grainsy = [];
unclassifiedx = [];
unclassifiedy = [];
for r = 1:1070
    ID = MIDs(r,1);
    Str = MStrs(r,1);
    if (ID < 10000)
        fruitsx = [fruitsx EBasis(r,9)];
        fruitsy = [fruitsy EBasis(r,8)];
    elseif (ID > 11000) &&(ID < 12000)
        if (contains(Str,"Beans") == 1)
            legumesx = [legumesx EBasis(r,9)];
            legumesy = [legumesy EBasis(r,8)];
        else 
            vegetablesx = [vegetablesx EBasis(r,9)];
            vegetablesy = [vegetablesy EBasis(r,8)];
        end
    elseif (ID > 20000) && (ID < 30000)
        grainsx = [grainsx EBasis(r,9)];
        grainsy = [grainsy EBasis(r,9)];
    else
        unclassifiedx = [unclassifiedx EBasis(r,9)];
        unclassifiedy = [unclassifiedy EBasis(r,8)];
    end
end
figure
plot(unclassifiedx, unclassifiedy, "b o")
hold on
scatter(fruitsx,fruitsy,"r s");
scatter(vegetablesx, vegetablesy,"y ^");
scatter(legumesx,legumesy, "c d");
scatter(grainsx, grainsy, "g x");
legend(["Unclassified", "Fruits", "Legumes","Vegetables","Grains"], "Location", "northwest")
title(["Gel Scores: A Graph to show the", "Energy and Proteins compared to","the Sugars and Carbohydrates in the Gels"]);
xlabel("Principal Component 1: Energy and Proteins");
ylabel("Principal Component 2: Sugars and Carbohydrates");
hold off;

UnknownGel = [0 0 0 0 0 0 0 -1.8 3];
StandardUGel = (UnknownGel/inv(EVec))';
UGData = (StandardUGel*MStDev)+MMean;
disp(UGData);
