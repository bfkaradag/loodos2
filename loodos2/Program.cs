using System;
using System.Collections;

namespace loodos2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stacks stacks = new Stacks(3);
            stacks.Push(0, "Stack:0 Val:1");
            stacks.Push(0, "Stack:0 Val:2");
            stacks.Push(0, "Stack:0 Val:3");
            stacks.Push(1, "Stack:1 Val:1");
            stacks.Push(1, "Stack:1 Val:2");
            stacks.Push(1, "Stack:1 Val:3");
            stacks.Push(2, "Stack:2 Val:1");
            stacks.Push(2, "Stack:2 Val:2");
            stacks.Push(2, "Stack:2 Val:3");

            for(int i = 0; i < 3; i++)
            {
                while(stacks.isEmpty(i) != true)
                {
                    Console.Write(stacks.Pop(i));
                }
            }
        }
    }
    public class Stacks
    {
        int size;
        object[] stacksArr;
        int[] stackTops = { -1, -1, -1 };

        public Stacks(int size)
        {
            this.size = size;
            stacksArr = new object[size * 3];
        }

        public void Push(int stackNum, object value)
        {
            if(stackTops[stackNum] + 1 >= size)
            {
                throw new Exception("stack overflow");
            }
            stackTops[stackNum] += 1;
            stacksArr[getTopOfCurrentStack(stackNum)] = value;
        }

        public object Pop(int stackNum)
        {
            if(stackTops[stackNum] == -1)
            {
                throw new Exception("empty stack");
            }
            object val = stacksArr[getTopOfCurrentStack(stackNum)];
            stackTops[stackNum] -= 1;
            return val;
        }

        public object Peek(int stackNum)
        {
            int i = getTopOfCurrentStack(stackNum);
            return stacksArr[i];
        }
        public bool isEmpty(int stackNum)
        {
            return stackTops[stackNum] == -1;
        }
        private int getTopOfCurrentStack(int stackNum)
        {
            return stackNum * size + stackTops[stackNum];
        }
    }
}
