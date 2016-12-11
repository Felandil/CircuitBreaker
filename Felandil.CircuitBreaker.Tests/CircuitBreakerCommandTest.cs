// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerCommandTest.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  /// <summary>
  /// The circuit breaker command test.
  /// </summary>
  [TestClass]
  public class CircuitBreakerCommandTest
  {
    #region Public Methods and Operators

    /// <summary>
    /// The test action throws exception should set state to opened after defined fail count.
    /// </summary>
    [TestMethod]
    public void TestActionThrowsExceptionShouldSetStateToOpenedAfterDefinedFailCount()
    {
      var breakerStateStorage = new InMemoryCircuitBreakerStateStorage();
      var command = new CircuitBreakerFailingCommand(breakerStateStorage);

      for (var i = 1; i < breakerStateStorage.FailThreshold + 1; i++)
      {
        SafeExecute(command);

        if (i < breakerStateStorage.FailThreshold)
        {
          Assert.IsTrue(command.IsClosed);
        }
        else
        {
          Assert.IsFalse(command.IsClosed);
          Assert.IsTrue(command.IsOpen);
        }
      }
    }

    /// <summary>
    /// The test circuit breaker is open or half open.
    /// </summary>
    [TestMethod]
    public void TestCircuitBreakerIsOpenOrHalfOpen()
    {
      var breakerStateStorage = new InMemoryCircuitBreakerStateStorage();
      var command = new CircuitBreakerTestCommand(breakerStateStorage);

      Assert.IsTrue(command.IsClosed);

      breakerStateStorage.HalfOpen();

      Assert.IsTrue(command.IsOpen);
    }

    /// <summary>
    /// The test circuit is open should not call action.
    /// </summary>
    [TestMethod]
    public void TestCircuitIsOpenShouldNotCallActionAndReturnsFallbackValue()
    {
      var breakerStateStorage = new InMemoryCircuitBreakerStateStorage();
      var command = new CircuitBreakerFailingCommand(breakerStateStorage);
      while (command.IsClosed)
      {
        SafeExecute(command);
        Assert.IsNotNull(breakerStateStorage.LastException);
      }

      var result = command.Execute(1);

      Assert.AreEqual(breakerStateStorage.FailThreshold, command.ActionCalledCounter);
      Assert.AreEqual(10, result);
    }

    #endregion

    #region Methods

    /// <summary>
    /// The safe execute.
    /// </summary>
    /// <param name="command">
    /// The command.
    /// </param>
    private static void SafeExecute(CircuitBreakerFailingCommand command)
    {
      try
      {
        command.Execute(1);
      }
      catch
      {
      }
    }

    #endregion
  }
}