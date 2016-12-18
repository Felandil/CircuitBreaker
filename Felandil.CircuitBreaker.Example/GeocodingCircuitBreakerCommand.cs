// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeocodingCircuitBreakerCommand.cs" company="Felandil IT">
//    Copyright (c) 2008 -2016 Felandil IT. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Felandil.CircuitBreaker.Example
{
  using System;
  using System.IO;
  using System.Net;

  /// <summary>
  /// The example circuit breaker command.
  /// </summary>
  public class GeocodingCircuitBreakerCommand : CircuitBreakerCommand<GeocodeApiRequest, string>
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="GeocodingCircuitBreakerCommand"/> class.
    /// </summary>
    /// <param name="stateStorage">
    /// The state storage.
    /// </param>
    public GeocodingCircuitBreakerCommand(CircuitBreakerStorage stateStorage)
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
    /// The <see cref="string"/>.
    /// </returns>
    protected override string Action(GeocodeApiRequest args)
    {
      var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}+{1}", args.Postcode, args.Town);
      var request = WebRequest.Create(requestUri);

      using (var response = request.GetResponse())
      {
        using (var responseStream = response.GetResponseStream())
        {
          if (responseStream == null)
          {
            return this.Fallback();
          }

          using (var streamReader = new StreamReader(responseStream))
          {
            var responseAsString = streamReader.ReadToEnd();

            if (responseAsString.Contains("OVER_QUERY"))
            {
              throw new Exception("Over Limit!");
            }

            return responseAsString;
          }
        }
      }
    }

    /// <summary>
    /// The fallback.
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    protected override string Fallback()
    {
      return "This functionality has been turned off.";
    }

    /// <summary>
    /// The handle exception.
    /// </summary>
    /// <param name="exception">
    /// The exception.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    protected override string HandleException(Exception exception)
    {
      Console.WriteLine("Hey! The action threw an exception with message:");
      Console.WriteLine(exception.Message);
      return base.HandleException(exception);
    }

    #endregion
  }
}