using System;

namespace pi
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfSamples = 1000;
            long hits;
            double pi = EstimatePI(numberOfSamples, ref long hits);



            static double EstimatePI(long numberOfSamples, ref long hits)
            {
                double[,] sample;
                double w =0;
                double l =0;

                sample = GenerateSamples(numberOfSamples);
                for(int i =0; i < numberOfSamples; i++)
                {
                     w,l = sample[i, i];
                }
            }


            static double[,] GenerateSamples(long numberOfSamples)
            {
                double[,] sample = new double[numberOfSamples, numberOfSamples];
                double MIN = -1.0;
                double MAX = 1.0;

                Random r = new Random();


                for (int i = 0; i < numberOfSamples; i++)
                {
                    sample[i,i] = r.NextDouble()*(MAX-MIN)+MIN;

                }
                return sample;

        }
    }
}