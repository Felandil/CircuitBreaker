// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerStorage.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  using System;

  /// <summary>
  /// The CircuitBreakerStorage interface.
  /// </summary>
  public abstract class CircuitBreakerStorage
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerStorage"/> class.
    /// </summary>
    protected CircuitBreakerStorage()
    {
      this.State = CircuitBreakerState.Closed;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the fail counter.
    /// </summary>
    public abstract int FailCounter { get; protected set; }

    /// <summary>
    /// Gets the fail threshold.
    /// </summary>
    public int FailThreshold
    {
      get
      {
        return 10;
      }
    }

    /// <summary>
    /// Gets a value indicating whether is closed.
    /// </summary>
    public bool IsClosed
    {
      get
      {
        return this.State == CircuitBreakerState.Closed;
      }
    }

    /// <summary>
    /// Gets the last exception.
    /// </summary>
    public Exception LastException { get; private set; }

    /// <summary>
    /// Gets or sets the last state changed date utc.
    /// </summary>
    public DateTime LastStateChangedDateUtc { get; protected set; }

    /// <summary>
    /// Gets the state.
    /// </summary>
    public CircuitBreakerState State { get; private set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The half open.
    /// </summary>
    public void HalfOpen()
    {
      this.State = CircuitBreakerState.HalfOpened;
    }

    /// <summary>
    /// The reset.
    /// </summary>
    public void Reset()
    {
      this.State = CircuitBreakerState.Closed;
    }

    /// <summary>
    /// The trip.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    public void Trip(Exception ex)
    {
      this.State = CircuitBreakerState.Open;
    }

    #endregion

    #region Methods

    /// <summary>
    /// The handle exception.
    /// </summary>
    /// <param name="exception">
    /// The exception.
    /// </param>
    internal void HandleException(Exception exception)
    {
      this.FailCounter++;
      this.LastException = exception;

      if (this.FailCounter >= this.FailThreshold)
      {
        this.Trip(exception);
      }
    }

    #endregion
  }
}