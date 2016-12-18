// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerStorage.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  using System;

  using Felandil.CircuitBreaker.Configuration;

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
        return CircuitBreakerConfiguration.FailureThresholdByCommand(this.CommandName);
      }
    }

    /// <summary>
    /// Gets the last exception.
    /// </summary>
    public Exception LastException { get; private set; }

    /// <summary>
    /// Gets the last state changed date utc.
    /// </summary>
    public DateTime LastStateChangedDateUtc { get; private set; }

    /// <summary>
    /// Gets the open to half open wait time.
    /// </summary>
    public TimeSpan OpenToHalfOpenWaitTime
    {
      get
      {
        return CircuitBreakerConfiguration.OpenTimeByCommand(this.CommandName);
      }
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    public CircuitBreakerState State { get; private set; }

    /// <summary>
    /// Gets or sets the success counter.
    /// </summary>
    public abstract int SuccessCounter { get; protected set; }

    /// <summary>
    /// Gets the success threshold.
    /// </summary>
    public int SuccessThreshold
    {
      get
      {
        return CircuitBreakerConfiguration.SuccessThresholdByCommand(this.CommandName);
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the command name.
    /// </summary>
    protected string CommandName { get; private set; }

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
      this.FailCounter = 0;
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
      this.LastStateChangedDateUtc = DateTime.UtcNow;
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

      if (this.FailCounter == this.FailThreshold)
      {
        this.Trip(exception);
      }
    }

    /// <summary>
    /// The handle opened success.
    /// </summary>
    internal void HandleOpenedSuccess()
    {
      this.SuccessCounter++;

      if (this.SuccessCounter >= this.SuccessThreshold)
      {
        this.Reset();
      }
    }

    /// <summary>
    /// The init.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    internal void Init(string commandName)
    {
      this.CommandName = commandName;
    }

    #endregion
  }
}