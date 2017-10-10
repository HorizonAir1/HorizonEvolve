var App = angular.module('App', ['ngRoute']);

App.controller('MainController', MainController);
App.controller('TableController', TableController);
App.controller('FlightController', FlightController);
App.controller('PaymentController', PaymentController);
App.controller('ConfirmationController', ConfirmationController);



var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/', {
            templateUrl: 'Views/main.html',
            controller: MainController
        }).
        when('/departures', {
            templateUrl: 'Views/Table.html',
            controller: TableController
        }).
        when('/arrivals', {
            templateUrl: 'Views/Table2.html',
            controller: FlightController
        }).
        when('/payment', {
            templateUrl: 'Views/Payment.html',
            controller: PaymentController
        }).
        when('/confirmation', {
            templateUrl: 'Views/Confirmation.html',
            controller: ConfirmationController
        }).
        otherwise({
            redirectTo: function () {
                return '/';
            }
        });
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);

App.service('FlightService', function() {
  var booking = [];

  var addBooking = function(newObj) {
      booking.push(newObj);
      console.log(booking);

  };

  var getBooking = function(){
      return booking ;
  };

  return {
    addBooking: addBooking,
    getBooking: getBooking,
  };

});
