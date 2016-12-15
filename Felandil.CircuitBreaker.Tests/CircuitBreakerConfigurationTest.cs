// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfigurationTest.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using Felandil.CircuitBreaker.Configuration;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  /// <summary>
  /// The circuit breaker configuration test.
  /// </summary>
  [TestClass]
  public class CircuitBreakerConfigurationTest
  {
    #region Public Methods and Operators

    /// <summary>
    /// The test command does exist in configuration should return values.
    /// </summary>
    [TestMethod]
    public void TestCommandDoesExistInConfigurationShouldReturnValues()
    {
      var failureThreshold = CircuitBreakerConfiguration.FailureThresholdByCommand("ExistantCommand");
      Assert.AreEqual(210, failureThreshold);

      var successThreshold = CircuitBreakerConfiguration.SuccessThresholdByCommand("ExistantCommand");
      Assert.AreEqual(200, successThreshold);

      var openTime = CircuitBreakerConfiguration.OpenTimeByCommand("ExistantCommand");
      Assert.AreEqual(59, openTime.Seconds);
      Assert.AreEqual(14, openTime.Minutes);
      Assert.AreEqual(2, openTime.Hours);
    }

    /// <summary>
    /// The test command does not exist in configuration should return default values.
    /// </summary>
    [TestMethod]
    public void TestCommandDoesNotExistInConfigurationShouldReturnDefaultValues()
    {
      var failureThreshold = CircuitBreakerConfiguration.FailureThresholdByCommand("NonExistantCommand");
      Assert.AreEqual(110, failureThreshold);

      var successThreshold = CircuitBreakerConfiguration.SuccessThresholdByCommand("NonExistantCommand");
      Assert.AreEqual(100, successThreshold);

      var openTime = CircuitBreakerConfiguration.OpenTimeByCommand("NonExistantCommand");
      Assert.AreEqual(55, openTime.Seconds);
      Assert.AreEqual(12, openTime.Minutes);
      Assert.AreEqual(1, openTime.Hours);
    }

    /// <summary>
    /// The test default values get returned.
    /// </summary>
    [TestMethod]
    public void TestDefaultValuesGetReturned()
    {
      var defaultSuccessThreshold = CircuitBreakerConfiguration.DefaultSuccessThreshold;
      Assert.AreEqual(100, defaultSuccessThreshold);

      var defaultFailureThreshold = CircuitBreakerConfiguration.DefaultFailureThreshold;
      Assert.AreEqual(110, defaultFailureThreshold);

      var defaultOpenTime = CircuitBreakerConfiguration.DefaultOpenTime;
      Assert.AreEqual(55, defaultOpenTime.Seconds);
      Assert.AreEqual(12, defaultOpenTime.Minutes);
      Assert.AreEqual(1, defaultOpenTime.Hours);
    }

    #endregion
  }
}