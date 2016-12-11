// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerOpenException.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  using System;

  /// <summary>
  /// The circuit breaker open exception.
  /// </summary>
  public class CircuitBreakerOpenException : ApplicationException
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerOpenException"/> class.
    /// </summary>
    /// <param name="innerException">
    /// The inner exception.
    /// </param>
    public CircuitBreakerOpenException(Exception innerException)
      : base(innerException.Message, innerException is CircuitBreakerOpenException ? innerException.InnerException : innerException)
    {
    }

    #endregion
  }
}