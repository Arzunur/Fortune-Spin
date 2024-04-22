using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LineData", menuName = "Line Data")]
public class LineData : ScriptableObject
{
    [Serializable]
    public struct LineCombination
    {
        public int[] indices;
        public int points;
    }
    public List<LineCombination> combinations = new List<LineCombination>()
    {
        new LineCombination { indices = new int[] {5, 6, 7, 8, 9}, points = 1000},//1
        new LineCombination { indices = new int[] {0, 1, 2, 3, 4},points = 1000},//2
        new LineCombination { indices = new int[] {10, 11, 12, 13, 14},points = 500},//3
        new LineCombination { indices = new int[] {0, 6, 12, 8, 4},points = 800},//4
        new LineCombination { indices = new int[] {10, 6, 2, 8, 14},points = 1000},//5
        new LineCombination { indices = new int[] {5, 1, 2, 3, 9},points =1600 },//6
        new LineCombination { indices = new int[] {5, 11, 12, 13, 9},points = 1300},//7
        new LineCombination { indices = new int[] {0, 1, 7, 13, 14},points =1500 },//8
        new LineCombination { indices = new int[] {10, 11, 7, 3, 4},points = 1700},//9
        new LineCombination { indices = new int[] {5, 11, 7, 3, 9},points =1500 },//10
        new LineCombination { indices = new int[] {5, 1, 7, 13, 9},points =1200 },//11
        new LineCombination { indices = new int[] {0, 6, 7, 8, 4},points =1400 },//12
        new LineCombination { indices = new int[] {10, 6, 7, 8, 14},points =1300},//13
        new LineCombination { indices = new int[] {0, 6, 2, 8, 4},points =800 },// 14
        new LineCombination { indices = new int[] {5, 6, 2, 8, 9},points =1400},//15
        new LineCombination { indices = new int[] {5, 6, 12, 8, 9}, points =1500},//16
        new LineCombination { indices = new int[] {0, 1, 12, 3, 4}, points =1700},//17
        new LineCombination { indices = new int[] {10, 11, 2, 13, 14},points =600},//18
        new LineCombination { indices = new int[] {0, 11, 12, 13, 4},points =400}, //19
        new LineCombination { indices = new int[] {0, 11, 2, 13, 4}, points =1200},//20
        new LineCombination { indices = new int[] {10, 1, 12, 3, 14},points =200},//21
        new LineCombination { indices = new int[] {0, 11, 7, 13, 4},points =1500},//22
        new LineCombination { indices = new int[] {10, 1, 7, 3, 14},points =900},//23
        new LineCombination { indices = new int[] {0, 1, 12, 13, 14},points =1400},//24
        new LineCombination { indices = new int[] {10, 11, 2, 3, 4},points = 600},//25
        new LineCombination { indices = new int[] {0, 1, 7, 8, 14},points =1200},//26
        new LineCombination { indices = new int[] {10, 11, 7, 8, 4},points =500},//27
        new LineCombination { indices = new int[] {4, 10, 11, 12, 13}, points =5000},//28
        new LineCombination { indices = new int[] {10, 6, 2, 3, 4},points =700 },//29
        new LineCombination { indices = new int[] {0, 6, 7, 8, 9},points =1000},//30
     };
}
