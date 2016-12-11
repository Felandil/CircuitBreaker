// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerState.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  /// <summary>
  /// The circuit breaker state.
  /// </summary>
  public enum CircuitBreakerState
  {
    /// <summary>
    /// The open.
    /// </summary>
    Open, 

    /// <summary>
    /// The closed.
    /// </summary>
    Closed, 

    /// <summary>
    /// The half opened.
    /// </summary>
    HalfOpened
  }
}