// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerCommand.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker
{
  using System;

  /// <summary>
  /// The circuit breaker command.
  /// </summary>
  /// <typeparam name="TOut">
  /// The return value
  /// </typeparam>
  /// <typeparam name="TInput">
  /// The input value
  /// </typeparam>
  public abstract class CircuitBreakerCommand<TOut, TInput>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerCommand{TOut,TInput}"/> class. 
    /// </summary>
    /// <param name="stateStorage">
    /// The state storage.
    /// </param>
    protected CircuitBreakerCommand(CircuitBreakerStorage stateStorage)
    {
      this.StateStorage = stateStorage;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets a value indicating whether is closed.
    /// </summary>
    public bool IsClosed
    {
      get
      {
        return this.StateStorage.State == CircuitBreakerState.Closed;
      }
    }

    /// <summary>
    /// Gets a value indicating whether is openend.
    /// </summary>
    public bool IsOpen
    {
      get
      {
        return this.StateStorage.State != CircuitBreakerState.Closed;
      }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    private CircuitBreakerStorage StateStorage { get; set; }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    /// <returns>
    /// The <see cref="TOut"/>.
    /// </returns>
    public TOut Execute(TInput args)
    {
      try
      {
        return this.IsOpen ? this.HandleOpened(args) : this.Action(args);
      }
      catch (Exception exception)
      {
        return this.HandleException(exception);
      }
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
    /// The <see cref="T"/>.
    /// </returns>
    protected abstract TOut Action(TInput args);

    /// <summary>
    /// The fallback.
    /// </summary>
    /// <returns>
    /// The <see cref="TOut"/>.
    /// </returns>
    protected abstract TOut Fallback();

    /// <summary>
    /// The handle exception.
    /// </summary>
    /// <param name="exception">
    /// The exception.
    /// </param>
    /// <returns>
    /// The <see cref="TOut"/>.
    /// </returns>
    protected virtual TOut HandleException(Exception exception)
    {
      this.StateStorage.HandleException(exception);
      return this.Fallback();
    }

    /// <summary>
    /// The handle opened.
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    /// <returns>
    /// The <see cref="TOut"/>.
    /// </returns>
    private TOut HandleOpened(TInput args)
    {
      if (!this.OpenWaitTimeExpired())
      {
        throw new CircuitBreakerOpenException(this.StateStorage.LastException);
      }

      try
      {
        this.StateStorage.HalfOpen();

        var result = this.Action(args);

        this.StateStorage.HandleOpenedSuccess();

        return result;
      }
      catch (Exception exception)
      {
        this.StateStorage.Trip(exception);
        throw;
      }
    }

    /// <summary>
    /// The open wait time expired.
    /// </summary>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    private bool OpenWaitTimeExpired()
    {
      return this.StateStorage.LastStateChangedDateUtc + this.StateStorage.OpenToHalfOpenWaitTime < DateTime.UtcNow;
    }

    #endregion
  }
}