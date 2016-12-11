// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerFailingCommand.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  using System;

  /// <summary>
  /// The circuit breaker failing command.
  /// </summary>
  internal class CircuitBreakerFailingCommand : CircuitBreakerCommand<int, int>
  {
    internal int ActionCalledCounter = 0;

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerFailingCommand"/> class.
    /// </summary>
    /// <param name="stateStorage">
    /// The state storage.
    /// </param>
    public CircuitBreakerFailingCommand(CircuitBreakerStorage stateStorage)
      : base(stateStorage)
    {
    }

    #endregion

    #region Public Methods and Operators

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
      this.ActionCalledCounter++;
      throw new Exception();
    }

    /// <summary>
    /// The fallback.
    /// </summary>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    protected override int Fallback()
    {
      return 10;
    }

    #endregion
  }
}