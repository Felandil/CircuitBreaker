# Felandil Circuit Breaker

See: 
* http://martinfowler.com/bliki/CircuitBreaker.html
* https://msdn.microsoft.com/de-de/library/dn589784.aspx

Basic useful feature list:

 * Basic circuit breaker functionality
 * Configurable Thresholds via App.config/Web.config
 * Extendable for custom error handling


For an example please see the example project.

Basic usage:

```javascript
var storage = new CircuitBreakerDefaultStorage();
var command = new GeocodingCircuitBreakerCommand(storage);
      
var result = command.Execute(new GeocodeApiRequest { Postcode = "30159", Town = "Hannover" });
```
<br>

<b>This project is licensed under the terms of the MIT license.</b>
