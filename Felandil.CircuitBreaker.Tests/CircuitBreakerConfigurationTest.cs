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
    /// The test configuration is read from cache after being saved to it.
    /// </summary>
    [TestMethod]
    public void TestConfigurationIsReadFromCacheAfterBeingSavedToIt()
    {
      var cache = new InMemoryConfigurationCache();
      var config = new CircuitBreakerConfiguration(cache);

      var dummy = config.DefaultSuccessThreshold;

      var cacheCallOne = config.DefaultSuccessThreshold;
      Assert.AreEqual(1, cache.ConfigLoadedFromCache);

      var cacheCallTwo = config.DefaultFailureThreshold;
      Assert.AreEqual(2, cache.ConfigLoadedFromCache);

      var cacheCallThree = config.DefaultOpenTime;
      Assert.AreEqual(3, cache.ConfigLoadedFromCache);
    }

    /// <summary>
    /// The test default configuration values get loaded.
    /// </summary>
    [TestMethod]
    public void TestDefaultConfigurationValuesGetLoaded()
    {
      var config = new CircuitBreakerConfiguration();

      Assert.AreEqual(100, config.DefaultSuccessThreshold);
      Assert.AreEqual(110, config.DefaultFailureThreshold);
      Assert.AreEqual("01:12:55", config.DefaultOpenTime.ToString());
    }

    /// <summary>
    /// The test specific configuration values get loaded.
    /// </summary>
    [TestMethod]
    public void TestSpecificConfigurationValuesGetLoaded()
    {
      var config = new CircuitBreakerConfiguration();

      Assert.AreEqual(200, config.SuccessThresholdByCommand("ExistantCommand"));
      Assert.AreEqual(210, config.FailureThresholdByCommand("ExistantCommand"));
      Assert.AreEqual("02:14:59", config.OpenTimeByCommand("ExistantCommand").ToString());
    }

    #endregion
  }
}