// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerOpenClosedCommand.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using System;

  /// <summary>
  /// The circuit breaker open closed command.
  /// </summary>
  internal class CircuitBreakerOpenClosedCommand : CircuitBreakerCommand<int, int>
  {
    public int SuccessfullCallsCounter = 0;

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerOpenClosedCommand"/> class.
    /// </summary>
    /// <param name="stateStorage">
    /// The state storage.
    /// </param>
    public CircuitBreakerOpenClosedCommand(CircuitBreakerStorage stateStorage)
      : base(stateStorage)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// The action.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    protected override int Action(int args)
    {
      if (this.IsClosed)
      {
        throw new Exception();
      }

      this.SuccessfullCallsCounter++;
      return 10;
    }

    /// <summary>
    /// The fallback.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    protected override int Fallback()
    {
      return 1;
    }

    #endregion
  }
}