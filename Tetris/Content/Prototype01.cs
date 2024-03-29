﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Linq;


//This script should be attached to a enemy entity with a separate controller script that dictates it's actions
//it's primary function is to calculate the utility value of each action, evaluate these, and finally tell the entity what action to perform 

//********************************************************
//This script utilizes arrays instead of linked lists for Utility management, this is due to lists having faster insertion/deletion, times but arrays -
//- having faster access times. The idea is that because there will be no actual insertions during runtime, but a large amount accessing and -
//- calculations on utility factors, an array solution should promote a faster decision making process for the entities during runtime.
//********************************************************
public class Prototype01
{
    bool displayingDBMenu;
    int maxValue= 100;
    int k = 3;
    
    public struct Utility{
        public string name;
        public float weight;
        //*****************************
        // void UtilityAction
        //Should point to an associated utility action decided in the constructor
        //will then perform this action when UtilityAction is called
        //******************************
        public delegate void MyAction();
        MyAction myAction;
        public void UtilityAction(){
            myAction();
        }
        //
        //****************************
        public Utility(string n, Action a) {
            myAction = new MyAction(a);
            name = n;
            weight = 0.0f;
        }
        public void SetWeight(float i) {
            weight = i; 
        }
    }

    public struct UtilityCategory{
        //the utilities belonging to the category
        public Dictionary<string, Utility> utilityDict;
        public string name;
        public float weight;
        public UtilityCategory(string n) : this(){ name = n;
            utilityDict = new Dictionary<string, Utility>();
        }
        public void SetWeight(float i) {
            weight = i;
        }
    }

    //All the utility categories
    public Dictionary<string, UtilityCategory> utilityCategoriesDict;

    void Awake(){
        utilityCategoriesDict = new Dictionary<string, UtilityCategory>();

    }

    void Update()
    {
        DisplayUtilities(displayingDBMenu);
        PerformAction();
    }

    //perform utility action (will be used during runtime) using a weight-based random on the best -
    // - remaining utilities after proper elimination of useless utilities has been performed
    void PerformAction() {
        var BestUtilityAction = BestRemainingUtilities(BestRemainingCategory()).Aggregate((x, y) => x.Value.weight > y.Value.weight ? x : y).Value;
        BestUtilityAction.UtilityAction();
        //*********************************
        //use the Utilities weight to make a roll on which action will be performed
        //example: 
        // A utility with a weight of 0.3 has a 30% chance to happen
        // a utility with a weight of 1 has a 100% chance of happening
        //Note: if i want all the best utilities sum up to 1 then i have to do some serious black magic here
        //other option: do a random roll on all the bests (don't bother summing up to 1 (it could be really hard to do and not sure if it really serves a purpose))
        //**********************************
    }
    #region Math
    //calculate the utility of the action or action category (will be used during runtime) uses a quadratic curve
    float CalculateWeight(float input, float max, float k){
        //a normalization equation, large value of k will have very little impact for low values of x
        return (float)Math.Pow(input / max, k);
    }
    #endregion

    //find the best utility, eliminate the ones that are much much worse, and return the ones that are left
    /*
    ***********************
    The idea here is that you don't want to perform the best possible utilities every time, as it will come
    across as robotic, instead roll a dice on the top utilities 
    ***********************
    */
    Dictionary<string, Utility> BestRemainingUtilities(UtilityCategory category){
        int numOfUtilitiesToKeep = 3;
        float cutOff = 0.2f;
        var bestUtilities = new Dictionary<string, Utility>();
        //utility values should be normalized to a 1 point decimal between 0 and 1
        //keep the best one and the two next best ones if they are in the 20% range (0.2 or higher)
        var orderedUtilies = category.utilityDict.OrderByDescending(x => x.Value.weight).ToList();
        for(int i = 0; i < numOfUtilitiesToKeep; i++) {
            if(i > 0 && orderedUtilies[i].Value.weight > cutOff) {
                bestUtilities.Add(orderedUtilies[i].Key,orderedUtilies[i].Value);
            }
            else {
                bestUtilities.Add(orderedUtilies[i].Key, orderedUtilies[i].Value);
            }
        }
        return bestUtilities;
    }

    //Find the utility category with the highest utility score
    UtilityCategory BestRemainingCategory() {
        var best = new UtilityCategory();
        foreach(UtilityCategory category in utilityCategoriesDict.Values) {
            if(category.weight >  best.weight) {
                best = category;
            }
        }
        return best;
    }

    //create a utility action and put it into the category's list of utilities, also creates a category if one does not exist (won't be used during runtime)
    //bit of a messy logic, can probably clean this using delegates or lambdas 

    void CreateUtility(string n, string c, Action a){
        Utility u = new Utility(n, a);
        //check if a category with the name c exists in the categoriesArray array
        //if it does exist, add the newly created utility to the category's uAray array 
        //if it doesn't, create the category with the name c, then put the newly created utility to the category's uAray array 

        //There is a category with this name
        if (utilityCategoriesDict.ContainsKey(c)){
            //The category does not contain this utility
            if (!utilityCategoriesDict[c].utilityDict.ContainsKey(n)){
                //Add it to the category's dictionary
                utilityCategoriesDict[c].utilityDict.Add(n, u);
            }
        }
        //else there's no category, make one and insert the newly made utility
        else {
            utilityCategoriesDict.Add(c, new UtilityCategory(c));
            utilityCategoriesDict[c].utilityDict.Add(n, u);
        }
    }

    //Give utility value to action or category (will be used during runtime)
    public void AssignUtilityValue(string n, string c, float x){
        if (utilityCategoriesDict[c].utilityDict.ContainsKey(n)) {
            var i = utilityCategoriesDict[c].utilityDict[n];
            i.weight = CalculateWeight(x, maxValue, k);
            utilityCategoriesDict[c].utilityDict[n] = i;
        }
        else {
            //TODO:
            //insert debug message, does not contain utility
        }

    }
    //Give utility category value (will be used during runtime)
    public void AssignCategoryValue(string n, int x){
        if (utilityCategoriesDict.ContainsKey(n)) {
            var i = utilityCategoriesDict[n];
            i.weight = CalculateWeight(x, maxValue, k);
            utilityCategoriesDict[n] = i;
            //Debug.Log(utilityCategoriesDict[n].weight);
        }
        else {
            //TODO:
            //debug message, category does not exist
        }
    }
    public void MakeTestUtility(string n, string c, Action a){
        CreateUtility(n, c, a);
    }

    //Debug function, should not be utilized during real play 
    //displays a window with all the entity's utilities  divided into categories, displaying their names and weights when a button is pressed
    void DisplayUtilities(bool display){
        //TODO:
        //Debug menu should display the utility categories dictionary
    }
}
