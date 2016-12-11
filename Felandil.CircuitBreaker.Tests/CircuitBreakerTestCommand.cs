// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerTestCommand.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Tests
{
  /// <summary>
  /// The circuit breaker test command.
  /// </summary>
  internal class CircuitBreakerTestCommand : CircuitBreakerCommand<int, int>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerTestCommand"/> class.
    /// </summary>
    /// <param name="stateStorage">
    /// The state storage.
    /// </param>
    public CircuitBreakerTestCommand(CircuitBreakerStorage stateStorage)
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
      return 1;
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