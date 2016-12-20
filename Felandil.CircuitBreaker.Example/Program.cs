// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Example
{
  using System;
  using System.Diagnostics;

  using Felandil.CircuitBreaker.Configuration;

  /// <summary>
  /// The program.
  /// </summary>
  internal class Program
  {
    #region Methods

    /// <summary>
    /// The main.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    private static void Main(string[] args)
    {
      // var storage = new CircuitBreakerDefaultStorage();
      var storage = new CircuitBreakerDefaultStorage(new CircuitBreakerConfiguration());
      var command = new GeocodingCircuitBreakerCommand(storage);

      var stopwatch = new Stopwatch();
      stopwatch.Start();

      while (stopwatch.ElapsedMilliseconds < 100000)
      {
        var result = command.Execute(new GeocodeApiRequest { Postcode = "30159", Town = "Hannover" });
        Console.WriteLine(result);
      }

      Console.ReadKey();
    }

    #endregion
  }
}