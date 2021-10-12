using System;
using System.Threading;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int ARRAY_SIZE = 10;
            int MAX_VAL = 100;
            int[] arraySingleThread = new int[ARRAY_SIZE];

            Random r = new Random();

            for(int i = 0; i < ARRAY_SIZE; i++){
                arraySingleThread[i] = r.Next(MAX_VAL + 1);
            
            }
            // TODO : Use the "Random" class in a for loop to initialize an array

            // copy array by value.. You can also use array.copy()
           // int[] arrayMultiThread = arraySingleThread.Slice(0,arraySingleThread.Length);
            Stopwatch stopwatch = new Stopwatch();


            /*TODO : Use the  "Stopwatch" class to measure the duration of time that
               it takes to sort an array using one-thread merge sort and
               multi-thead merge sort
            */
            Console.WriteLine("Single Thread Original:");
            //PrintArray(arraySingleThread);

            stopwatch.Start();
            MergeSort(arraySingleThread);
            stopwatch.Stop();
            

           
            bool ans = IsSorted(arraySingleThread);
            Console.WriteLine("Single Sorted? " + ans);

            //PrintArray(arraySingleThread);
            long t = stopwatch.ElapsedTicks;
            Console.WriteLine("Run time: " + t);

           

                
            stopwatch.Reset();
            
            //TODO :start the stopwatch
            //TODO :Stop the stopwatch

            //stopwatch.Start();
            //MultiMergeSort(arrayMultiThread);
            //stopwatch.Stop();

            //TODO: Multi Threading Merge Sort




             /*********************** Methods **********************
              *****************************************************/
             /*
             implement Merge method. This method takes two sorted array and
             and constructs a sorted array in the size of combined arrays
             */

            static int[] Merge(int[] LA, int[] RA, int[] A)
            {
               
                int i = 0;
                int j = 0;
                int ARRAY_SIZE = A.Length;

                for(int k = 0; k < ARRAY_SIZE; k++){
                    if ((RA.Length % 2 == 0 && LA.Length % 2 == 0) || (RA.Length % 2 != 0 && LA.Length % 2 != 0))
                    {
                        

                            //L=even, R=even or odd & odd
                            //Cases with both 1

                            if ((i != (ARRAY_SIZE / 2)) && (j != (ARRAY_SIZE / 2)))
                            {
                                if (LA[j] < RA[i])
                                {
                                    A[k] = LA[j];
                                    j++;
                                }
                                else
                                {
                                    A[k] = RA[i];
                                    i++;
                                }

                            }
                            else if (i != (ARRAY_SIZE / 2))
                            {
                                A[k] = RA[i];
                                i++;
                            }
                            else
                            {
                                A[k] = LA[j];// LA[j];
                                j++;
                            }
                        
                    }

                    //}
                    else
                    //L=odd, R==even or opp
                    {

                        if ((i != (ARRAY_SIZE / 2 + 1)) && (j != (ARRAY_SIZE / 2)))
                        {
                            if (LA[j] < RA[i])
                            {
                                A[k] = LA[j];
                                j++;
                            }
                            else
                            {
                                A[k] = RA[i];
                                i++;
                            }

                        }
                        else if (i != (ARRAY_SIZE / 2 + 1))
                        {
                            A[k] = RA[i];
                            i++;
                        }
                        else
                        {
                            A[k] = LA[j];// LA[j];
                            j++;
                        }

                    }
                    }
                    
                  
                return A;
                // TODO :implement

            }


             /*
             implement MergeSort method: takes an integer array by reference
             and makes some recursive calls to intself and then sorts the array
             */
            static int[] MergeSort(int[] A)
            {
                int length = A.Length;
                int[] left;
                int[] right;

                if(length % 2 == 0)
                {
                    left = new int[length/2];
                    right = new int[length/2];
                    if(length < 2)
                        return A;
                    for(int i = 0; i < length/2; i++)
                    {
                        left[i] = A[i];
                    }
                    for(int i = length/2; i < length; i++) 
                    {
                    
                        right[i-length/2] = A[i];
                    }

                     
                }
                else if(length < 2)
                {
                    return A;
                }
                else  
                {
                    left = new int[length/2];
                    right = new int[length/2+1];
                    if(length < 2)
                        return A;
                    for(int i = 0; i < length/2; i++)
                    {
                        left[i] = A[i];
                    }
                    for(int i = length/2; i < length; i++) 
                    {
                    
                        right[i-length/2] = A[i];
                    }

                }
                 
                MergeSort(left);
                MergeSort(right);
                Merge(left, right, A);

                return A;  

            }
/*
            static int[] MultiMergeSort(int[] A, int threadNum)
            {

                Thread t = new Thread;

                int length = A.Length;
                //int[] left = new int[length/2];
                //int[] right = new int[length/2];
                if(length < 2)
                    return;
                int index = length/threadNum;

                for(int i = 0; i < length; i+index-1)
                
                //for(int i = 0; i < length/2; i++)
                //{
                //    left[i] = A[i];
                //}
                //for(int i = length/2; i < length; i++) 
                //{
                    
                //    right[i-length/2] = A[i];
                //}

                MergeSort(left);
                MergeSort(right);
                Merge(left, right, A);

                return;
            }
*/

            // a helper function to print your array
            static void PrintArray(int[] myArray)
            {
                Console.Write("[");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write("{0} ", myArray[i]);

                }
                Console.Write("]");
                Console.WriteLine();

            }

            // a helper function to confirm your array is sorted
            // returns boolean True if the array is sorted
            static bool IsSorted(int[] a)
            {
                int j = a.Length - 1;
                if (j < 1) return true;
                int ai = a[0], i = 1;
                while (i <= j && ai <= (ai = a[i])) i++;
                return i > j;
            }


        }


    }
}
