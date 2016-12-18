// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryCircuitBreakerStateStorage.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  /// <summary>
  /// The in memory circuit breaker state storage.
  /// </summary>
  internal class InMemoryCircuitBreakerStateStorage : CircuitBreakerStorage
  {
    #region Properties

    /// <summary>
    /// Gets or sets the fail counter.
    /// </summary>
    public override int FailCounter { get; protected set; }

    /// <summary>
    /// Gets or sets the success counter.
    /// </summary>
    public override int SuccessCounter { get; protected set; }

    #endregion
  }
}