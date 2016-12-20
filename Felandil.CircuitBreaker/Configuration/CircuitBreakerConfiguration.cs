// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CircuitBreakerConfiguration.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Configuration
{
  using System;
  using System.Configuration;

  /// <summary>
  /// The circuit breaker configuration.
  /// </summary>
  public class CircuitBreakerConfiguration
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerConfiguration"/> class.
    /// </summary>
    public CircuitBreakerConfiguration()
      : this(new CircuitBreakerMemoryConfigurationCache())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CircuitBreakerConfiguration"/> class.
    /// </summary>
    /// <param name="configurationCache">
    /// The configuration cache.
    /// </param>
    public CircuitBreakerConfiguration(IConfigurationCache configurationCache)
    {
      this.Cache = configurationCache;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets or sets the cache.
    /// </summary>
    public IConfigurationCache Cache { get; set; }

    /// <summary>
    /// Gets the default failure threshold.
    /// </summary>
    public int DefaultFailureThreshold
    {
      get
      {
        return this.GetCommand("Default").FailureThreshold;
      }
    }

    /// <summary>
    /// Gets the default open time.
    /// </summary>
    public TimeSpan DefaultOpenTime
    {
      get
      {
        return this.GetCommand("Default").OpenTime;
      }
    }

    /// <summary>
    /// Gets the default success threshold.
    /// </summary>
    public int DefaultSuccessThreshold
    {
      get
      {
        return this.GetCommand("Default").SuccessThreshold;
      }
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int FailureThresholdByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return this.DefaultFailureThreshold;
      }

      var config = this.GetCommand(commandName);
      return config == null ? this.DefaultFailureThreshold : config.FailureThreshold;
    }

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public TimeSpan OpenTimeByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return this.DefaultOpenTime;
      }

      var config = this.GetCommand(commandName);
      return config == null ? this.DefaultOpenTime : config.OpenTime;
    }

    /// <summary>
    /// The failure threshold by command.
    /// </summary>
    /// <param name="commandName">
    /// The command name.
    /// </param>
    /// <returns>
    /// The <see cref="int"/>.
    /// </returns>
    public int SuccessThresholdByCommand(string commandName)
    {
      if (string.IsNullOrEmpty(commandName))
      {
        return this.DefaultSuccessThreshold;
      }

      var config = this.GetCommand(commandName);
      return config == null ? this.DefaultSuccessThreshold : config.SuccessThreshold;
    }

    #endregion

    #region Methods

    /// <summary>
    /// The get section.
    /// </summary>
    /// <param name="commandName">
    /// The command Name.
    /// </param>
    /// <returns>
    /// The <see cref="CircuitBreakerConfigurationSection"/>.
    /// </returns>
    private CircuitBreakerConfigurationElement GetCommand(string commandName)
    {
      var element = this.Cache.GetConfigurationElement(commandName);

      if (element != null)
      {
        return element;
      }

      element = ((CircuitBreakerConfigurationSection)ConfigurationManager.GetSection("FelandilCircuitBreaker")).Commands.GetCommandByName(commandName);

      this.Cache.SaveConfigurationElement(element);

      return element;
    }

    #endregion
  }
}