// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerStorageTest.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  /// <summary>
  /// The circuit breaker storage test.
  /// </summary>
  [TestClass]
  public class CircuitBreakerStorageTest
  {
    #region Public Methods and Operators

    /// <summary>
    /// The test command is registered should load configuration.
    /// </summary>
    [TestMethod]
    public void TestCommandShouldLoadConfiguration()
    {
      var storage = new InMemoryCircuitBreakerStateStorage();
      Assert.AreEqual(100, storage.SuccessThreshold);
      Assert.AreEqual(110, storage.FailThreshold);

      Assert.AreEqual(55, storage.OpenToHalfOpenWaitTime.Seconds);
    }

    /// <summary>
    /// The test default storage does store calls in cache.
    /// </summary>
    [TestMethod]
    public void TestDefaultStorageDoesStoreCallsInCache()
    {
      var storage = new CircuitBreakerDefaultStorage();
      var command = new CircuitBreakerFailingCommand(storage);

      command.Execute(1);
      command.Execute(1);

      Assert.AreEqual(2, storage.FailCounter);
      Assert.AreEqual(0, storage.SuccessCounter);
    }

    #endregion
  }
}