/*
** Your job is to write a program for a speed camera. 
** For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. 
** Write a program that asks the user to enter the speed limit. 
** Once set, the program asks for the speed of a car. 
** If the user enters a value less than the speed limit, program should display Ok on the console. 
** If the value is above the speed limit, the program should calculate the number of demerit points. 
** For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. 
** If the number of demerit points is above 12, the program should display License Suspended.
**/
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter a speed limit: ");
        string? enteredSpeedLimit = Console.ReadLine();
        Console.WriteLine("Enter the speed of a car: ");
        string? enteredSpeedOfCar = Console.ReadLine();
        int speedLimit = int.Parse(enteredSpeedLimit!);
        int speedOfCar = int.Parse(enteredSpeedOfCar!);
        if (speedOfCar < speedLimit) {
            Console.WriteLine("OK");
        } else 
        {
            int demeritPoint = (speedOfCar - speedLimit) / 5;
            if (demeritPoint > 11) {
                Console.WriteLine("License Suspended");
            } else{
                Console.WriteLine($"Demerit points: {demeritPoint}");
            }
        }

    }
}